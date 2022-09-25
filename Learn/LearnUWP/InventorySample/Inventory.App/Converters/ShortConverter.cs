using System;
using Windows.UI.Xaml.Data;

namespace Inventory.Converters
{
    public class ShortConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is short n16)
            {
                if (targetType == typeof(string))
                {
                    return n16 == 0 ? "" : n16.ToString();
                }
                return n16;
            }

            return targetType == typeof(string) ? "" : (object)0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (short.TryParse(value.ToString(), out short n16))
                {
                    return n16;
                }
            }
            return 0;
        }
    }
}