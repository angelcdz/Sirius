using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for EnabledProducts.xaml
    /// </summary>
    public partial class EnabledProducts : ViewBaseControl
    {
        public EnabledProducts()
        {
            this.DataContext = new EnabledProductsViewModel();
            InitializeComponent();
        }
    }
}
