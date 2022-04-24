using Rhino.Mvvm;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;

namespace Rhino.DuplicateCleaner.ViewModels
{
    public class DeleteFile : NotifyObject
    {
        public string MD5 { get; set; }

        public string FileName { get; set; }

        private bool _canDelete = true;
        public bool CanDelete
        {
            get => _canDelete;
            set
            {
                _canDelete = value;
                RaisePropertyChanged(nameof(Fill));
            }
        }

        private bool _deleted = false;
        public bool Deleted
        {
            get => _deleted;
            set
            {
                _canDelete = value;
                _deleted = value;
                RaisePropertyChanged(nameof(Fill));
            }
        }

        public Brush Fill
        {
            get
            {
                if (Deleted) { return Brushes.Gray; }
                if (!CanDelete) { return Brushes.OldLace; }
                return Brushes.Green;
            }
        }

        public ICommand DeleteCommand { get; set; }

        public DeleteFile(string md5, string fileName)
        {
            MD5 = md5;
            FileName = fileName;

            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete(object obj)
        {
            if (!CanDelete || Deleted) { return; }

            Deleted = true;
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            CompareResult.Remove(this);
        }
    }
}