using Rhino.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Rhino.DuplicateCleaner.ViewModels
{
    public class MainViewModel : NotifyObject
    {
        private string _selectPath;
        public string SelectPath
        {
            get => _selectPath;
            set => Update(ref _selectPath, value, after: OnSelectedPathChanged);
        }

        private bool _canCompare = false;
        public bool CanCompare
        {
            get => _canCompare;
            set => Update(ref _canCompare, value);
        }

        private bool _inComparing = false;
        public bool InComparing
        {
            get => _inComparing;
            set => Update(ref _inComparing, value);
        }

        private double _compareOfProgress = 0;
        public double CompareOfProgress
        {
            get => _compareOfProgress;
            set => Update(ref _compareOfProgress, value);
        }

        private ObservableCollection<CompareResult> _results;
        public ObservableCollection<CompareResult> Results
        {
            get => _results;
            set => Update(ref _results, value);
        }

        public ICommand SelectDirCommand { get; set; }
        public ICommand StartCompareCommand { get; set; }

        public MainViewModel()
        {
            SelectDirCommand = new RelayCommand(SelectDir);
            StartCompareCommand = new RelayCommand(StartCompare);
        }

        private void StartCompare(object obj)
        {
            CanCompare = false;
            InComparing = true;
            CompareResult.Clear();
            Task.Run(() =>
            {
                Compare(SelectPath);
            }).ContinueWith((t) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Results = CompareResult.ToObservableCollection();
                });
                InComparing = false;
                CanCompare = true;
            });
        }

        private void SelectDir(object obj)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectPath = dialog.SelectedPath;
                }
            }
        }

        private int total = 0;
        private void Compare(string dir)
        {
            if (dir == SelectPath)
            {
                total = Directory.GetFiles(dir).Length;
                total += Directory.GetDirectories(dir).Length;
            }

            double i = 0;
            foreach (var file in Directory.GetFiles(dir))
            {
                Thread.Sleep(100);
                CompareResult.Add(file);
                if (dir == SelectPath)
                {
                    CompareOfProgress = (++i) / total * 100;
                }
            }

            foreach (var subDir in Directory.GetDirectories(dir))
            {
                Compare(subDir);
                if (dir == SelectPath)
                {
                    CompareOfProgress = (++i) / total * 100;
                }
            }
        }

        private void OnSelectedPathChanged(string field, string value)
        {
            CanCompare = Directory.Exists(value);
        }
    }
}