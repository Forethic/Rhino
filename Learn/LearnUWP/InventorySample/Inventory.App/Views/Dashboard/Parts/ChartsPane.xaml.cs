using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory.Views
{
    public sealed partial class ChartsPane : UserControl
    {
        private WebView _webView;

        public ChartsPane()
        {
            InitializeComponent();

            Loaded += OnLoaded;

            _webView = new WebView(WebViewExecutionMode.SeparateThread);
            _webView.SetValue(Grid.RowProperty, 1);
            _webView.NavigationCompleted += OnNavigationCompleted;
        }

        private void OnNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            RootGridLayout.Children.Add(_webView);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            string text = await LoadStringFromPackageFileAsync("ChartHtmlControl.html");
            _webView.NavigateToString(text);
        }

        public static async Task<string> LoadStringFromPackageFileAsync(string name)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///html/{name}"));
            return await FileIO.ReadTextAsync(file);
        }
    }
}