using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Inventory.Converters
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int n)
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
                if (int.TryParse(value.ToString(), out int n))
                {
                    return n;
                }
            }
            return 0;
        }
    }
}
