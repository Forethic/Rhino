using System.Windows;

namespace ProWPF.Ch22
{
    /// <summary>
    /// AdvancedListViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdvancedListViewWindow : Window
    {
        public AdvancedListViewWindow()
        {
            InitializeComponent();

            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }
    }
}