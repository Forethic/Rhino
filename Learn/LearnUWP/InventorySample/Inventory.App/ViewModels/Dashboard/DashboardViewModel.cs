using Inventory.Services;

namespace Inventory.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; }

        public DashboardViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void ItemSelected(string item)
        {
            switch (item)
            {
                case "Customers":
                    NavigationService.Navigate<CustomersViewModel>(new CustomersViewState());
                    break;
                case "Orders":
                    NavigationService.Navigate<OrdersViewModel>(new OrdersViewState());
                    break;
                case "Products":
                    NavigationService.Navigate<ProductsViewModel>(new ProductsViewState());
                    break;
                default:
                    break;
            }
        }
    }
}