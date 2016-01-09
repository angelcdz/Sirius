using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonElegibleProductDetails.xaml
    /// </summary>
    public partial class NonElegibleProductDetails : ViewBaseControl
    {
        public NonElegibleProductDetails()
        {
            this.DataContext = new NonElegibleProductDetailsViewModel();
            InitializeComponent();
        }
    }
}
