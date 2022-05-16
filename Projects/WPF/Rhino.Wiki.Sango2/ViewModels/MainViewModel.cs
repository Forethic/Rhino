using Rhino.Mvvm;
using Rhino.Wiki.Sango2.DataModels;
using System.Collections.ObjectModel;

namespace Rhino.Wiki.Sango2.ViewModels
{
    public class MainViewModel : NotifyObject
    {
        private ObservableCollection<Military> _militaries;
        public ObservableCollection<Military> Militaries
        {
            get => _militaries;
            set => Update(ref _militaries, value);
        }

        public MainViewModel()
        {
            ReadData();
        }

        private void ReadData()
        {
            StorageDatabase.StoreDb.Instance.Read();
        }
    }
}