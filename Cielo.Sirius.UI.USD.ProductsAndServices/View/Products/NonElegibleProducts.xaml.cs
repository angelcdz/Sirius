using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonElegibleProducts.xaml
    /// </summary>
    public partial class NonElegibleProducts : ViewBaseControl
    {
        public NonElegibleProducts()
        {
            this.DataContext = new NonElegibleProductsViewModel();
            InitializeComponent();
        }
    }
}
