using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonEnabledProductDetails.xaml
    /// </summary>
    public partial class NonEnabledProductTaxesDetails : ViewBaseControl
    {
        public NonEnabledProductTaxesDetails()
        {
            this.DataContext = new NonEnabledProductTaxesDetailsViewModel();
            InitializeComponent();
        }
    }
}
