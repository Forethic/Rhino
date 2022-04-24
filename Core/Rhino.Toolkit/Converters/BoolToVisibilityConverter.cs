using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Rhino.Toolkit.Converters
{
    public class BoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return (Visibility)value != Visibility.Visible;
            }
            else
            {
                return (Visibility)value == Visibility.Visible;
            }
        }
    }
}