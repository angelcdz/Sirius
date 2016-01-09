using Cielo.Sirius.Foundation.USD.UiHelper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Cielo.Sirius.Foundation.USD.Behaviors
{
    public class DataGridMultipleSelectionBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_PreviewMouseLeftButtonDown;
        }

        void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // get the DataGridRow 
            var dgr = WPFTreeHelper.FindParent<DataGridRow>(e.OriginalSource as DependencyObject, base.AssociatedObject);
            var chkheader = WPFTreeHelper.FindChildren<CheckBox>(sender as DependencyObject, "chekSelect");

            // only handle this when Ctrl or Shift not pressed 
            ModifierKeys mods = Keyboard.PrimaryDevice.Modifiers;
            if (dgr != null && ((int)(mods & ModifierKeys.Control) == 0 && (int)(mods & ModifierKeys.Shift) == 0))
            {
                // check if it is a inside control click
                var chk = WPFTreeHelper.FindParent<ToggleButton>(e.OriginalSource as DependencyObject, dgr);
                var textBox = WPFTreeHelper.FindParent<TextBox>(e.OriginalSource as DependencyObject, dgr);
                var dgrh = WPFTreeHelper.FindParent<DataGridRowHeader>(e.OriginalSource as DependencyObject, dgr);

                chkheader.IsChecked = false;

                if (chk != null)
                {
                    chk.IsChecked = !chk.IsChecked;
                    dgr.IsSelected = dgrh != null ? dgr.IsSelected : true;
                }
                else if (textBox != null)
                {
                    dgr.IsSelected = true;
                    textBox.Focus();
                }
                else
                {
                    dgr.IsSelected = !dgr.IsSelected;
                }

                if (Equals((sender as DataGrid).Items.Count, (sender as DataGrid).SelectedItems.Count))
                {
                    chkheader.IsChecked = true;
                }
            }
            
            if (dgr == null && chkheader != null && chkheader.IsChecked == true)
            {
                (sender as DataGrid).UnselectAll();
                chkheader.IsChecked = false;
            }
            else if (dgr == null && chkheader != null && chkheader.IsChecked == false)
            {
                (sender as DataGrid).SelectAll();
                chkheader.IsChecked = true;
            }

            e.Handled = true;
        }
    }
}
