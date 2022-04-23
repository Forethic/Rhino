using ProWPF.StoreDatabase;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace ProWPF.Ch21
{
    /// <summary>
    /// NavigateCollectionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NavigateCollectionWindow : Window
    {
        private ListCollectionView _view;
        private ICollection<Product> _products;

        public NavigateCollectionWindow()
        {
            InitializeComponent();

            _products = App.StoreDb.GetProducts();
            DataContext = _products;

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(DataContext);
            _view.CurrentChanged += View_CurrentChanged;

            lstProducts.ItemsSource = _products;
        }

        private void View_CurrentChanged(object sender, System.EventArgs e)
        {
            lblPosition.Text = "Record " + (_view.CurrentPosition + 1) + " of " + _view.Count;
            cmdPrev.IsEnabled = _view.CurrentPosition > 0;
            cmdNext.IsEnabled = _view.CurrentPosition < _view.Count - 1;
        }

        private void lstProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void cmdPrev_Click(object sender, RoutedEventArgs e)
        {
            _view.MoveCurrentToPrevious();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            _view.MoveCurrentToNext();
        }
    }
}