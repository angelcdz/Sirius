using System;
using System.Globalization;
using System.Windows.Data;

namespace Cielo.Sirius.Foundation.USD.Converters
{
    public class BoolToSimNaoConverter : IValueConverter
    {
        /// <summary>
        /// Conversor de valores booleanos para variáveis String "Sim" e "Não". Valor true convertido para "Sim" e valor "false" convertido para
        /// </summary>
        /// <param name="value_"> Valor boleano</param>
        /// <param name="targetType_"></param>
        /// <param name="parameter_"></param>
        /// <param name="culture_"></param>
        /// <returns></returns>
        public object Convert(object value_, Type targetType_, object parameter_, CultureInfo culture_)
        {

            if (!(value_ is bool))
            {
                throw new InvalidOperationException("Converter espera argumento do tipo bool");
            }

            return (bool)value_ ? "Sim" : "Não";

        }

        public object ConvertBack(object value_, Type targetType_, object parameter, CultureInfo culture_)
        {
            throw new NotImplementedException();
        }

    }
}
