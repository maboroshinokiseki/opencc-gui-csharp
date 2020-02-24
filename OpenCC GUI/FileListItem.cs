using System.ComponentModel;

namespace OpenCC_GUI
{
    class FileListItem : INotifyPropertyChanged
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
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
            }
        }

        public string ErrorMessage
        {
            get => this.errorMessage;
            set
            {
                this.errorMessage = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(errorMessage)));
            }
        }
    }
}
