using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Products;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View.Products
{
    /// <summary>
    /// Interaction logic for ProductRequestSuccess.xaml
    /// </summary>
    public partial class ProductRequestSuccess : ViewBaseControl
    {
        public ProductRequestSuccess()
        {
            DataContext = new ProductRequestSuccessViewModel();
            InitializeComponent();
        }
    }
}
