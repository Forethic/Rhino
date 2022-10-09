using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace Inventory
{
    public static class PageExtensions
    {
        public static void SetTitle(this Control page, string title)
        {
            ApplicationView.GetForCurrentView().Title = title;
        }
    }
}