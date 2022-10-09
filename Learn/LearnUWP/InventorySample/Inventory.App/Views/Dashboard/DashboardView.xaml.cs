using Inventory.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Inventory.Views
{
    public sealed partial class DashboardView : Page
    {
        public DashboardViewModel ViewModel { get; set; }

        public DashboardView()
        {
            ViewModel = ServiceLocator.Current.GetService<DashboardViewModel>();
            InitializeComponent();
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Control control)
            {
                ViewModel.ItemSelected(control.Tag as string);
            }
        }
    }
}