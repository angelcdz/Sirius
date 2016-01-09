using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for EnabledServices.xaml
    /// </summary>
    public partial class EnabledServices : ViewBaseControl
    {
        public EnabledServices()
        {
            this.DataContext = new EnabledServicesViewModel();
            InitializeComponent();
        }
    }
}
