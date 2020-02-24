namespace OpenCC_GUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal static class FileListUtility
    {
        private static readonly int MaxTask;
        private static bool isRunning = false;
        private static IProgress<Reportinfo> progress;

        static FileListUtility()
        {
            progress = new Progress<Reportinfo>(info =>
            {
                if (info.Finishied)
                {
                    info.FileListItems.Remove(info.Item);
                }
                else
                {
                    info.Item.ErrorMessage = info.Message;
                }
            });

            MaxTask = Environment.ProcessorCount - 2;
            if (MaxTask < 1)
            {
                MaxTask = 1;
            }
        }

        public static void AppendFileList(BindingList<FileListItem> list, string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                list.Add(new FileListItem() { FileName = fileName });
            }
        }

        public static async void ConvertAndStoreFilesInList(BindingList<FileListItem> fileListItems, string configFileName, string outputFolder = null)
        {
            if (isRunning)
            {
                return;
            }
            isRunning = true;

            while (fileListItems.Count != 0)
            {
                SemaphoreSlim semaphore = new SemaphoreSlim(MaxTask, MaxTask);
                var fileListItemsClone = new FileListItem[fileListItems.Count];
                fileListItems.CopyTo(fileListItemsClone, 0);
                var tasks = new List<Task>(fileListItemsClone.Length);

                foreach (var item in fileListItemsClone)
                {
                    tasks.Add(Task.Run(() => ConvertTask(fileListItems, item, configFileName, outputFolder, semaphore)));
                }
                await Task.WhenAll(tasks);
            }

            isRunning = false;
        }

        private static void ConvertTask(BindingList<FileListItem> fileListItems, FileListItem item, string configFileName, string outputFolder, SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            if (!fileListItems.Contains(item))
            {
                semaphore.Release();
                return;
            }

            try
            {
                string content = System.IO.File.ReadAllText(item.FileName);
                string result = Converter.Convert(content, configFileName);
                string outputPath;
                if (outputFolder == null)
                {
                    outputPath = item.FileName;
                }
                else
                {
                    outputPath = outputFolder + "\\" + System.IO.Path.GetFileName(item.FileName);
                }

                System.IO.File.WriteAllText(outputPath, result, Encoding.UTF8);

                progress.Report(new Reportinfo { FileListItems = fileListItems, Finishied = true, Item = item });
            }
            catch (Exception exception)
            {
                progress.Report(new Reportinfo { FileListItems = fileListItems, Finishied = false, Item = item, Message = exception.Message });
            }
            finally
            {
                semaphore.Release();
            }
        }

        private class Reportinfo
        {
            public BindingList<FileListItem> FileListItems;
            public bool Finishied;
            public FileListItem Item;
            public string Message;
        }
    }

    internal static class TextUtility
    {
        public static void LoadTextToTextBox(TextBox textBox, string fileName)
        {
            try
            {
                textBox.Text = System.IO.File.ReadAllText(fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
