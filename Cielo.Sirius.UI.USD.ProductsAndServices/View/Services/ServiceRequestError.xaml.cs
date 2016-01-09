using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ServiceRequestError.xaml
    /// </summary>
    public partial class ServiceRequestError : ViewBaseControl
    {
        public ServiceRequestError()
        {
            this.DataContext = new ServiceRequestErrorViewModel();
            InitializeComponent();
        }
    }
}
