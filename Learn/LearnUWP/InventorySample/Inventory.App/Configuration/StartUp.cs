using Inventory.Services;
using Inventory.ViewModels;
using Inventory.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Inventory
{
    public static class StartUp
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();

        public static async Task ConfigureAsync()
        {
            ServiceLocator.Configure(_serviceCollection);

            ConfigureNavigation();
        }

        private static void ConfigureNavigation()
        {
            NavigationService.Register<ShellViewModel, ShellView>();
            NavigationService.Register<MainShellViewModel, MainShellView>();
            NavigationService.Register<DashboardViewModel, DashboardView>();
        }
    }
}