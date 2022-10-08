using Inventory.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Inventory.Views
{
    public sealed partial class ProductsPane
    {
        public IList<ProductModel> ItemsSource
        {
            get => (IList<ProductModel>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty
            = DependencyProperty.Register(nameof(ItemsSource), typeof(IList<ProductModel>), typeof(ProductsPane), new PropertyMetadata(null));

        public ProductsPane()
        {
            InitializeComponent();

            // 测试数据
            ItemsSource = new List<ProductModel>()
            {
                new ProductModel
                {
                    ProductID = "10086",
                    Name = "测试商品",
                    ListPrice = 180m,
                    ThumbnailBitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri("ms-appx:///Assets/StoreLogo.png")),
                }
            };
        }
    }
}