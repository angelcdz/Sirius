using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class SelectedItemBoolNotToVisibilityConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            return (value_ == null) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value_, Type targetType_, object parameter, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }
    }
}
