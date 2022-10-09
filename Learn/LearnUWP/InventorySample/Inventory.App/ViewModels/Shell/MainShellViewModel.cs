using Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class MainShellViewModel : ShellViewModel
    {
        private readonly NavigationItem DashboardItem = new NavigationItem(0xE80F, "Dashboard", typeof(DashboardViewModel));
        private readonly NavigationItem CustomersItem = new NavigationItem(0xE716, "Customers", typeof(CustomersViewModel));
        private readonly NavigationItem OrdersItem = new NavigationItem(0xE14C, "Orders", typeof(OrdersViewModel));
        private readonly NavigationItem ProductsItem = new NavigationItem(0xECAA, "Products", typeof(ProductsViewModel));

        public IEnumerable<NavigationItem> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }
        private IEnumerable<NavigationItem> _items;

        public object SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        private object _selectedItem;

        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => Set(ref _isPaneOpen, value);
        }
        private bool _isPaneOpen = true;

        public MainShellViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public override Task LoadAsync(ShellViewState viewState)
        {
            Items = GetItems().ToArray();
            return base.LoadAsync(viewState);
        }

        public void NavigateTo(Type viewModel)
        {
            switch (viewModel.Name)
            {
                case nameof(DashboardViewModel):
                    NavigationService.Navigate(viewModel, new DashboardViewState());
                    break;
                case nameof(CustomersViewModel):
                    NavigationService.Navigate(viewModel, new CustomersViewState());
                    break;
                case nameof(OrdersViewModel):
                    NavigationService.Navigate(viewModel, new OrdersViewState());
                    break;
                case nameof(ProductsViewModel):
                    NavigationService.Navigate(viewModel, new ProductsViewState());
                    break;
                case nameof(SettingsViewModel):
                    NavigationService.Navigate(viewModel, new SettingsViewState());
                    break;
            }
        }

        private IEnumerable<NavigationItem> GetItems()
        {
            yield return DashboardItem;
            yield return CustomersItem;
            yield return OrdersItem;
            yield return ProductsItem;
        }
    }
}