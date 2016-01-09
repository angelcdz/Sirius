using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ServiceRequestsHistory.xaml
    /// </summary>
    public partial class ServiceRequestsHistory : ViewBaseControl
    {
        public ServiceRequestsHistory()
        {
            this.DataContext = new ServiceRequestsHistoryViewModel();
            InitializeComponent();
        }
    }
}
