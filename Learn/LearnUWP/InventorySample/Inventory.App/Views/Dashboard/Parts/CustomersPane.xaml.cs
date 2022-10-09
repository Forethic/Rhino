using Inventory.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory.Views
{
    public sealed partial class CustomersPane : UserControl
    {
        public IList<CustomerModel> ItemsSource
        {
            get => (IList<CustomerModel>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty
            = DependencyProperty.Register(nameof(ItemsSource), typeof(IList<CustomerModel>), typeof(CustomersPane), new PropertyMetadata(null));

        public CustomersPane()
        {
            InitializeComponent();

            /// 设计时数据样本
            ItemsSource = new List<CustomerModel>()
            {
                new CustomerModel
                {
                    FirstName = "Lia",
                    LastName = "Jonathan",
                    ThumbBitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri("ms-appx:///Assets/StoreLogo.png")),
                    EmailAddress = "forethic@outlook.com"
                }
            };
        }
    }
}