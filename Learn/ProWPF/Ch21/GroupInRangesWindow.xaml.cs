using ProWPF.StoreDatabase;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace ProWPF.Ch21
{
    /// <summary>
    /// GroupInRangesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GroupInRangesWindow : Window
    {
        public GroupInRangesWindow()
        {
            InitializeComponent();
        }

        private ICollection<Product> _products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            _products = App.StoreDb.GetProducts();
            CollectionViewSource viewSource = (CollectionViewSource)FindResource("GroupByRangeView");
            viewSource.Source = _products;
        }
    }
}