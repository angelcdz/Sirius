using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ProducRequestsSelector.xaml
    /// </summary>
    public partial class NonElegibleProductRequestsSelector : ViewBaseControl
    {
        public NonElegibleProductRequestsSelector()
        {
            this.DataContext = new NonElegibleProductRequestsSelectorViewModel();
            InitializeComponent();
        }
    }
}
