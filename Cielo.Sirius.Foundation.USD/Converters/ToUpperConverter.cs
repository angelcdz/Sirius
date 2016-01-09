using System;
using System.Globalization;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            if (value_ == null)
            {
                return null;
            }

            return value_.ToString().ToUpper();
        }

        public object ConvertBack(object value_, Type targetType_, object parameter, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }
    }
}
