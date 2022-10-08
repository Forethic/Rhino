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
                case nameof(SettingsViewModel):
                    NavigationService.Navigate(viewModel, new SettingsViewState());
                    break;
            }
        }

        private IEnumerable<NavigationItem> GetItems()
        {
            yield return DashboardItem;
        }
    }
}