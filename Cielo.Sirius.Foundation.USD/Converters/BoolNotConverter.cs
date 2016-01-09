using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class BoolNotConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            if (!(value_ is bool))
            {
                throw new ArgumentException("The conversion argument should be 'bool'.", "value_");
            }

            return !(bool)value_;
        }

        public object ConvertBack(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }
    }
}
