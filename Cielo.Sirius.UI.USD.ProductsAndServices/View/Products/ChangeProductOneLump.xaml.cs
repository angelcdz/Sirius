using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for RateChange.xaml
    /// </summary>
    public partial class ChangeProductOneLump : ViewBaseControl
    {
        public ChangeProductOneLump()
        {
            this.DataContext = new ChangeProductOneLumpViewModel();
            InitializeComponent();
        }
    }
}
