using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ProducRequestsSelector.xaml
    /// </summary>
    public partial class EnabledProductRequestsSelector : ViewBaseControl
    {
        public EnabledProductRequestsSelector()
        {
            this.DataContext = new EnabledProductRequestsSelectorViewModel();
            InitializeComponent();
        }
    }
}
