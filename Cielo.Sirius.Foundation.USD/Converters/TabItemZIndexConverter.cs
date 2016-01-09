using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class TabItemZIndexConverter : IValueConverter
    {
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            if (!(value_ is TabItem))
            {
                return 0;
            }
            var parent = (value_ as TabItem).Parent;
            return parent is TabControl ? -1 * (parent as TabControl).Items.IndexOf(value_) : 0;
        }

        public object ConvertBack(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {
            return null;
        }
    }
}
