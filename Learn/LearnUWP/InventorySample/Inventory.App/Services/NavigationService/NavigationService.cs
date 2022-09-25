using Inventory.ViewModels;
using Inventory.Views;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory.Services
{
    public class NavigationService : INavigationService
    {
        private static readonly ConcurrentDictionary<Type, Type> _viewModelMap = new ConcurrentDictionary<Type, Type>();

        public static int MainViewId { get; }

        public bool IsMainView => CoreApplication.GetCurrentView().IsMain;

        public Frame Frame { get; private set; }

        public bool CanGoBack => Frame.CanGoBack;

        static NavigationService()
        {
            MainViewId = ApplicationView.GetForCurrentView().Id;
        }

        public static void Register<TViewModel, TView>()
            where TView : Page
        {
            if (!_viewModelMap.TryAdd(typeof(TViewModel), typeof(TView)))
            {
                throw new InvalidOperationException($"ViewModel already registered '{typeof(TViewModel).FullName}'");
            }
        }

        public static Type GetView<TViewModel>() => GetView(typeof(TViewModel));
        public static Type GetView(Type viewModelType)
        {
            if (_viewModelMap.TryGetValue(viewModelType, out Type view))
            {
                return view;
            }
            throw new InvalidOperationException($"View not registered for ViewModel '{viewModelType.FullName}'");
        }
        public static Type GetViewModel(Type viewType)
        {
            var type = _viewModelMap.Where(r => r.Value == viewType).Select(r => r.Key).FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException($"View not registered for ViewModel '{viewType.FullName}'");
            }
            return type;
        }

        public async Task CloseViewAsync()
        {
            int currentId = ApplicationView.GetForCurrentView().Id;
            await ApplicationViewSwitcher.SwitchAsync(MainViewId, currentId, ApplicationViewSwitchingOptions.ConsolidateViews);
        }

        public async Task<int> CreateNewViewAsync<TViewModel>(object parameter = null)
        {
            return await CreateNewViewAsync(typeof(TViewModel), parameter);
        }

        public async Task<int> CreateNewViewAsync(Type viewModelType, object parameter = null)
        {
            int viewId = 0;
            var newView = CoreApplication.CreateNewView();
            await newView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    viewId = ApplicationView.GetForCurrentView().Id;

                    var frame = new Frame();
                    var viewState = new ShellViewState
                    {
                        ViewModel = viewModelType,
                        Parameter = parameter
                    };
                    frame.Navigate(typeof(ShellView), viewState);

                    Window.Current.Content = frame;
                    Window.Current.Activate();
                });

            if (await ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewId))
            {
                return viewId;
            }

            return 0;
        }

        public void GoBack() => Frame.GoBack();

        public void Initialize(Frame frame)
        {
            if (Frame != null)
            {
                throw new InvalidOperationException("Navigation frame already initialized.");
            }
            Frame = frame;
        }

        public bool Navigate<TViewModel>(object parameter = null) => Navigate(typeof(TViewModel), parameter);

        public bool Navigate(Type viewModelType, object parameter = null)
        {
            if (Frame == null)
            {
                throw new InvalidOperationException("Navigation frame not initialized");
            }
            return Frame.Navigate(GetView(viewModelType), parameter);
        }
    }
}