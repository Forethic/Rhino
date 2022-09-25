using Inventory.Services;
using Inventory.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using Windows.UI.ViewManagement;

namespace Inventory
{
    public class ServiceLocator : IDisposable
    {
        private static readonly ConcurrentDictionary<int, ServiceLocator> _serviceLocators = new ConcurrentDictionary<int, ServiceLocator>();

        private static ServiceProvider _rootServiceProvider = null;

        public static ServiceLocator Current
        {
            get
            {
                int currentViewId = ApplicationView.GetForCurrentView().Id;
                return _serviceLocators.GetOrAdd(currentViewId, key => new ServiceLocator());
            }
        }

        public static void Configure(IServiceCollection serviceCollection)
        {
            // 添加 Depenency Injection

            serviceCollection.AddScoped<INavigationService, NavigationService>();

            serviceCollection.AddTransient<ShellViewModel>();
            serviceCollection.AddTransient<MainShellViewModel>();
            serviceCollection.AddTransient<DashboardViewModel>();
            serviceCollection.AddTransient<SettingsViewModel>();

            _rootServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private IServiceScope _serviceScope = null;

        private ServiceLocator()
        {
            _serviceScope = _rootServiceProvider.CreateScope();
        }

        public T GetService<T>() => GetService<T>(true);
        public T GetService<T>(bool isRequired)
            => isRequired ? _serviceScope.ServiceProvider.GetRequiredService<T>() : _serviceScope.ServiceProvider.GetService<T>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceScope?.Dispose();
            }
        }
    }
}
