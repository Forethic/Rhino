using Inventory.ViewModels;
using Inventory.Views;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory
{
    sealed partial class App : Application
    {
        private Type EntryViewModel => typeof(DashboardViewModel);
        private object EntryViewState => new DashboardViewState();

        public App()
        {
            InitializeComponent();

            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(1280, 840);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // 不要在窗口已包含内容时重复应用程序初始化，
            // 只需确保窗口处于活动状态
            if (rootFrame == null)
            {
                // 创建要充当导航上下文的框架，并导航到第一页
                rootFrame = new Frame();

                // 将框架放在当前窗口中
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                // 程序初始化配置
                await StartUp.ConfigureAsync();

                if (rootFrame.Content == null)
                {
                    var viewState = new ShellViewState
                    {
                        ViewModel = EntryViewModel,
                        Parameter = EntryViewState,
                    };
                    rootFrame.Navigate(typeof(MainShellView), viewState);
                }
                // 确保当前窗口处于活动状态
                Window.Current.Activate();
            }

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(500, 500));
        }
    }
}