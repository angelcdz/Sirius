using System.Windows;
using System.Windows.Controls;

namespace Cielo.Sirius.Foundation.USD.Controls
{
    public class LabeledText : Label
    {
        public static readonly DependencyProperty LabelTextProperty = 
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledText), 
            new PropertyMetadata(string.Empty, delegate { }, (d, value) => { return value.ToString(); }));

        /// <summary>
        /// Controls label
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
