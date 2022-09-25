using System;
using Windows.UI.Xaml.Data;

namespace Inventory.Converters
{
    public sealed class BoolNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool boolean && boolean);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool boolean && boolean);
        }
    }
}