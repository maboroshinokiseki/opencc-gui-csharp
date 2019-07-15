namespace OpenCC_GUI
{
    using System;
    using System.ComponentModel;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal static class FileListUtility
    {
        private static readonly int MaxTask;
        private static int runningThread;
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

        public static void ConvertAndStoreFilesInList(BindingList<FileListItem> fileListItems, string configFileName, string outputFolder = null)
        {
            if (runningThread != 0)
            {
                return;
            }

            runningThread = fileListItems.Count;

            SemaphoreSlim semaphore = new SemaphoreSlim(MaxTask, MaxTask);
            var fileListItemsClone = new FileListItem[fileListItems.Count];
            fileListItems.CopyTo(fileListItemsClone, 0);

            foreach (var item in fileListItemsClone)
            {
                Task.Run(() => ConvertTask(fileListItems, item, configFileName, outputFolder, semaphore));
            }
        }

        private static void ConvertTask(BindingList<FileListItem> fileListItems, FileListItem item, string configFileName, string outputFolder, SemaphoreSlim semaphore)
        {
            semaphore.Wait();
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
                Interlocked.Decrement(ref runningThread);
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

    internal class FileListItem : INotifyPropertyChanged
    {
        private string fileName;
        private string errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FileName
        {
            get => this.fileName;
            set
            {
                this.fileName = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }

        public string ErrorMessage
        {
            get => this.errorMessage;
            set
            {
                this.errorMessage = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
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
