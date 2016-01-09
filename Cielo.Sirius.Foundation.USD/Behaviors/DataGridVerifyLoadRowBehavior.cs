using Cielo.Sirius.Foundation.USD.UiHelper;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Cielo.Sirius.Foundation.USD.Behaviors
{
    public class DataGridVerifyLoadRowBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.LoadingRow += AssociatedObject_LoadingRow;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.LoadingRow -= AssociatedObject_LoadingRow;
        }

        private void AssociatedObject_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg != null && dg.Items.Count > 0)
            {
                if (Equals(dg.Items.Count, dg.SelectedItems.Count))
                {
                    var chk = WPFTreeHelper.FindChildren<CheckBox>(dg, "chekSelect");
                    chk.IsChecked = true;
                }
            }
        }
    }
}
