using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonElegibleProductDetails.xaml
    /// </summary>
    public partial class NonElegibleProductTaxesDetails : ViewBaseControl
    {
        public NonElegibleProductTaxesDetails()
        {
            this.DataContext = new NonElegibleProductTaxesDetailsViewModel();
            InitializeComponent();
        }
    }
}
