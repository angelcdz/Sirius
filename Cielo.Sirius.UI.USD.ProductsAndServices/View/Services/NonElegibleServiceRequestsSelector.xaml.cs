using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ServiceRequestsSelector.xaml
    /// </summary>
    public partial class NonElegibleServiceRequestsSelector : ViewBaseControl
    {
        public NonElegibleServiceRequestsSelector()
        {
            this.DataContext = new NonElegibleServiceRequestsSelectorViewModel();
            InitializeComponent();
        }

      
      
    }
}
