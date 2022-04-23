using ProWPF.StoreDatabase;
using System.Windows;

namespace ProWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static StoreDb _storeDb = null;
        public static StoreDb StoreDb => _storeDb ?? (_storeDb = new StoreDb());

        private static StoreDbDataSet _storeDbDataSet = null;
        public static StoreDbDataSet StoreDbDataSet => _storeDbDataSet ?? (_storeDbDataSet = new StoreDbDataSet());
    }
}