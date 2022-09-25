using System;
using Windows.UI.Xaml.Data;

namespace Inventory.Converters
{
    public class LongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is long n)
            {
                if (targetType == typeof(string))
                {
                    return n == 0 ? "" : n.ToString();
                }
                return n;
            }
            return targetType == typeof(string) ? "" : (object)0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (long.TryParse(value.ToString(), out long n)) { return n; }
            }
            return 0;
        }
    }
}