using System;
using System.Globalization;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            double result = 1.0;
            foreach (var item in values_)
            {
                var numericalItem = 0.0;
                if (double.TryParse(item.ToString(), out numericalItem))
                {
                    result *= numericalItem.Equals(double.NaN) ? 0.0 : numericalItem;
                }
            }

            return result;
        }

        public object[] ConvertBack(object value_, Type[] targetType_, object parameter, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }
    }
}
