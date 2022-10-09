using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Inventory.Views
{
    public sealed partial class OrdersView : Page
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            this.SetTitle($"Orders");
        }
    }
}