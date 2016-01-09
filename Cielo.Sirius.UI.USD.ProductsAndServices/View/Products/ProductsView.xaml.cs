using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : ViewBaseControl
    {
        public ProductsView()
        {
            InitializeComponent();
            this.DataContext = new ProductsViewModel();
        }
    }
}
