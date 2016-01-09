using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for DisabledTypedSale.xaml
    /// </summary>
    public partial class DisabledTypedSale : ViewBaseControl
    {
        public DisabledTypedSale()
        {
            this.DataContext = new DisabledTypedSaleViewModel();
            InitializeComponent();
        }

      
    }
}
