using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Cielo.Sirius.Foundation.USD.Controls
{
    [TemplatePart(Name = "PART_WaterMark", Type = typeof(FrameworkElement))]
    public class LabeledTextBox : TextBox
    {

        [Category("Text")]
        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMark", typeof(string), typeof(LabeledTextBox), new PropertyMetadata("--"));

        /// <summary>
        /// Water mark
        /// </summary>
        public string WaterMark
        {
            get
            {
                return (string)GetValue(WaterMarkTextProperty);
            }
            set
            {
                SetValue(WaterMarkTextProperty, value);
            }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register("LabelText", typeof(string),
                                     typeof(LabeledTextBox), new PropertyMetadata(string.Empty, delegate { },
                                                          (d, value) => { return value.ToString(); }));

        /// <summary>
        /// Label
        /// </summary>
        public string LabelText
        {
            get
            {
                return (string)GetValue(LabelTextProperty);
            }
            set
            {
                SetValue(LabelTextProperty, value);
            }
        }
    }
}
