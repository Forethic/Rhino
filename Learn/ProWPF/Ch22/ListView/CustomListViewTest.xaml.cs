using System.Windows;
using System.Windows.Controls;

namespace ProWPF.Ch22
{
    /// <summary>
    /// CustomListViewTest.xaml 的交互逻辑
    /// </summary>
    public partial class CustomListViewTest : Window
    {
        public CustomListViewTest()
        {
            InitializeComponent();

            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView.SelectedItem is ComboBoxItem selectedItem)
            {
                lstProducts.View = FindResource(selectedItem.Content) as ViewBase;
            }
        }
    }
}