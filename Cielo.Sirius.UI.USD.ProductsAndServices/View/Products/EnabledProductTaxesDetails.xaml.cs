using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class EnabledProductTaxesDetails : ViewBaseControl
    {
        public EnabledProductTaxesDetails()
        {
            this.DataContext = new EnabledProductTaxesDetailsViewModel();
            InitializeComponent();
        }
    }
}
