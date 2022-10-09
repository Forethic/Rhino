using Inventory.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Inventory.Views
{
    public sealed partial class OrdersPane
    {
        public IList<OrderModel> ItemsSource
        {
            get => (IList<OrderModel>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty
            = DependencyProperty.Register(nameof(ItemsSource), typeof(IList<OrderModel>), typeof(OrdersPane), new PropertyMetadata(default));

        public OrdersPane()
        {
            InitializeComponent();

            ItemsSource = new List<OrderModel>()
            {
                new OrderModel()
                {
                    OrderID = 10001,
                    CustomerID = 99986,
                    OrderDate = System.DateTimeOffset.Now,
                }
            };
        }
    }
}