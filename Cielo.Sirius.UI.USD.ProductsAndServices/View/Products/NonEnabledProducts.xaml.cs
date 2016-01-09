using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonEnabledProducts.xaml
    /// </summary>
    public partial class NonEnabledProducts : ViewBaseControl
    {
        public NonEnabledProducts()
        {
            this.DataContext = new NonEnabledProductsViewModel();
            InitializeComponent();
        }
    }
}
