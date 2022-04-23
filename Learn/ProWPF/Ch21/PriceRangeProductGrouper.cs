using System;
using System.Globalization;
using System.Windows.Data;

namespace ProWPF.Ch21
{
    public class PriceRangeProductGrouper : IValueConverter
    {
        public int GroupInterval { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price < GroupInterval)
            {
                return $"Less than {GroupInterval:C}";
            }
            else
            {
                int interval = (int)price / GroupInterval;
                int lowerLimit = interval * GroupInterval;
                int upperLimit = (interval + 1) * GroupInterval;
                return $"{lowerLimit:C} to {upperLimit:C}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("This converter is for grouping only.");
        }
    }
}