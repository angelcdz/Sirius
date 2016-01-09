using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Cielo.Sirius.Foundation.USD.Behaviors
{
    public class NumericTextBoxBehavior : Behavior<TextBox>
    {
        private string _lastText;

        protected override void OnAttached()
        {
            base.AssociatedObject.TextChanged += AssociatedObject_TextChanged;
            base.OnAttached();

            _lastText = AssociatedObject.Text;

            if (AssociatedObject.InputScope == null)
            {
                var inputScope = new InputScope();
                inputScope.Names.Add(new InputScopeName(InputScopeNameValue.Number));
                AssociatedObject.InputScope = inputScope;
            }
        }

        protected override void OnDetaching()
        {
            base.AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
            base.OnDetaching();
        }

        void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AssociatedObject != null)
            {
                double value;
                if (string.IsNullOrEmpty(AssociatedObject.Text) || Double.TryParse(AssociatedObject.Text, out value))
                {
                    _lastText = AssociatedObject.Text;
                    return;
                }

                AssociatedObject.Text = _lastText;
                AssociatedObject.SelectionStart = AssociatedObject.Text.Length;
            }
        }
    }
}
