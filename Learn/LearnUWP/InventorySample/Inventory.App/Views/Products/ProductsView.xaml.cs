using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Inventory.Views
{
    public sealed partial class ProductsView : Page
    {
        public ProductsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            this.SetTitle($"Products");
        }
    }
}