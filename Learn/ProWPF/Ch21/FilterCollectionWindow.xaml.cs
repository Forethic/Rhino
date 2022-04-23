using ProWPF.StoreDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProWPF.Ch21
{
    /// <summary>
    /// FilterCollectionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FilterCollectionWindow : Window
    {
        private ICollection<Product> _products;
        private ProductByPriceFilterer _filterer;

        public FilterCollectionWindow()
        {
            InitializeComponent();
        }

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            _products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = _products;

            ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);

            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            ListCollectionView lcview = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;

            lcview.IsLiveFiltering = true;
            lcview.LiveFilteringProperties.Add("UnitCost");
        }

        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;

                if (view != null)
                {
                    _filterer = new ProductByPriceFilterer(minimumPrice);
                    view.Filter = new Predicate<object>(_filterer.FilterItem);
                    view.Refresh();
                }
            }
        }

        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }

        private void txtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                decimal minimumPrice;
                if (decimal.TryParse(txtMinPrice.Text, out minimumPrice) && (_filterer != null))
                {
                    _filterer.MinimumPrice = minimumPrice;
                }
            }
        }
    }

    public class ProductByPriceFilterer
    {
        public decimal MinimumPrice
        {
            get;
            set;
        }

        public ProductByPriceFilterer(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        public bool FilterItem(object item)
        {
            Product product = item as Product;
            if (product != null)
            {
                if (product.UnitCost > MinimumPrice)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class SortByModelNameLength : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            Product productX = (Product)x;
            Product productY = (Product)y;
            return productX.ModelName.Length.CompareTo(productY.ModelName.Length);
        }
    }
}