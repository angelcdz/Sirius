using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonEnabledProductDetails.xaml
    /// </summary>
    public partial class NonEnabledProductDetails : ViewBaseControl
    {
        public NonEnabledProductDetails()
        {
            this.DataContext = new NonEnabledProductDetailsViewModel();
            InitializeComponent();
        }
    }
}
