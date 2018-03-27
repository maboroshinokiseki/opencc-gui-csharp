using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCC_GUI
{
    static class FileListUtility
    {
        private static readonly int maxTask;
        private static int runningThread;
        private static IProgress<Reportinfo> progress;

        static FileListUtility()
        {
            progress = new Progress<Reportinfo>(info =>
            {
                if (info.finishied)
                {
                    info.fileListItems.Remove(info.item);
                }
                else
                {
                    info.item.ErrorMessage = info.message;
                }
            });

            maxTask = Environment.ProcessorCount - 2;
            if (maxTask < 1)
            {
                maxTask = 1;
            }
        }
        
        public static void AppendFileList(BindingList<FileListItem> list, string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                list.Add(new FileListItem() { FileName = fileName});
            }
        }
        
        public static BindingList<FileListItem> CreateNewBindingList()
        {
            BindingList<FileListItem> fileListItems = new BindingList<FileListItem>();
            return fileListItems;
        }

        public static BindingSource CreateNewBindingSource(BindingList<FileListItem> fileListItems)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = fileListItems;
            return bindingSource;
        }

        private static void ConvertTask(BindingList<FileListItem> fileListItems, FileListItem item, string configFileName, string outputFolder, SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            try
            {
                string content = System.IO.File.ReadAllText(item.FileName);
                string result = Converter.Convert(content, configFileName);
                if (result != null)
                {
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

                    progress.Report(new Reportinfo { fileListItems = fileListItems, finishied = true, item = item });
                }
                else
                {
                    throw new Exception("OpenCC Unknown Error!");
                }
            }
            catch (Exception exception)
            {
                progress.Report(new Reportinfo { fileListItems = fileListItems, finishied = false, item = item, message = exception.Message });
            }
            finally
            {
                semaphore.Release();
                Interlocked.Decrement(ref runningThread);
            }
        }

        public static void ConvertAndStoreFilesInList(BindingList<FileListItem> fileListItems, string configFileName, string outputFolder = null)
        {
            if (runningThread != 0)
            {
                return;
            }
            runningThread = fileListItems.Count;

            SemaphoreSlim semaphore = new SemaphoreSlim(maxTask, maxTask);
            var fileListItemsClone = new FileListItem[fileListItems.Count];
            fileListItems.CopyTo(fileListItemsClone, 0);

            foreach (var item in fileListItemsClone)
            {
                Task.Run(() => ConvertTask(fileListItems, item, configFileName, outputFolder, semaphore));
            }
        }

        private class Reportinfo
        {
            public BindingList<FileListItem> fileListItems;
            public bool finishied;
            public FileListItem item;
            public string message;
        }
    }

    class FileListItem : INotifyPropertyChanged
    {
        private string fileName;

        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    static class TextUtility
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
