using ProWPF.StoreDatabase;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace ProWPF.Ch21
{
    /// <summary>
    /// GroupListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GroupListWindow : Window
    {
        private ICollection<Product> _products;

        public GroupListWindow()
        {
            InitializeComponent();
        }

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            _products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = _products;

            ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CategoryName", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));
        }
    }
}