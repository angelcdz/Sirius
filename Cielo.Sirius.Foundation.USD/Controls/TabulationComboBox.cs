using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Cielo.Sirius.Foundation.USD.Controls
{
    public class TabulationComboBox : ComboBox
    {
        [Category("Text")]
        public static readonly DependencyProperty WaterMarkTabulationTextProperty =
            DependencyProperty.Register("WaterMarkTabulation", typeof(string), typeof(LabeledTextBox), new PropertyMetadata("Selecione uma opção"));

        /// <summary>
        /// Water mark
        /// </summary>
        public string WaterMarkTabulation
        {
            get
            {
                return (string)GetValue(WaterMarkTabulationTextProperty);
            }
            set
            {
                SetValue(WaterMarkTabulationTextProperty, value);
            }
        }
    }
}
