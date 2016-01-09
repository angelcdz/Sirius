using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for DisableService.xaml
    /// </summary>
    public partial class DisableService : ViewBaseControl
    {
        public DisableService()
        {
            this.DataContext = new DisableServiceViewModel();
            InitializeComponent();
        }
    }
}
