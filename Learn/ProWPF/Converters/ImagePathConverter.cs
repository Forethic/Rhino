using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProWPF.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        private string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        public string ImageDirectory
        {
            get => _imageDirectory;
            set => _imageDirectory = value;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = Path.Combine(ImageDirectory, (string)value);
            return new BitmapImage(new Uri(imagePath));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
    }
}