using System.Windows;

namespace ProWPF.Ch22
{
    /// <summary>
    /// BasicListViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BasicListViewWindow : Window
    {
        public BasicListViewWindow()
        {
            InitializeComponent();

            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }
    }
}