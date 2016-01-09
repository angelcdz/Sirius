using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class StringNullOrEmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            var s = value_ as string;
            return string.IsNullOrEmpty(s) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value_, Type targetType_, object parameter, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }
    }
}
