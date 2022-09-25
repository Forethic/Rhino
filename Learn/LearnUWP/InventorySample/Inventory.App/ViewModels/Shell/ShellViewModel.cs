using Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }
        private bool _isBusy = false;

        public string StatusMessage
        {
            get => _statusMessage;
            set => Set(ref _statusMessage, value);
        }
        private string _statusMessage;

        public ShellViewState ViewState { get; protected set; }

        public INavigationService NavigationService { get; }

        public ShellViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual async Task LoadAsync(ShellViewState viewState)
        {
            ViewState = viewState ?? new ShellViewState();
            NavigationService.Navigate(ViewState.ViewModel, ViewState.Parameter);
        }

        public virtual void Unload() { }
    }
}