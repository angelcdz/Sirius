using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Products;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View.Products
{
    /// <summary>
    /// Interaction logic for ProductRequestError.xaml
    /// </summary>
    public partial class ProductRequestError : ViewBaseControl
    {
        public ProductRequestError()
        {
            DataContext = new ProductRequestErrorViewModel();
            InitializeComponent();
        }
    }
}
