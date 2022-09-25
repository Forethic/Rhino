using System;
using Windows.Globalization.DateTimeFormatting;
using Windows.System.UserProfile;
using Windows.UI.Xaml.Data;

namespace Inventory.Converters
{
    public sealed class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTimeOffset dateTime)
            {
                try
                {
                    var format = parameter as string ?? "shortdate";
                    var userLanguages = GlobalizationPreferences.Languages;
                    var dateFormat = new DateTimeFormatter(format, userLanguages);
                    return dateFormat.Format(dateTime);
                }
                catch
                {
                    return "N/A";
                }
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}