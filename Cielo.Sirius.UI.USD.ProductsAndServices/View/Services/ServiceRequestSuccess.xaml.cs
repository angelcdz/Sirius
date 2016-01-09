using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ServiceRequestSucess.xaml
    /// </summary>
    public partial class ServiceRequestSuccess : ViewBaseControl
    {
        public ServiceRequestSuccess()
        {
            this.DataContext = new ServiceRequestSuccessViewModel();
            InitializeComponent();
        }
    }
}
