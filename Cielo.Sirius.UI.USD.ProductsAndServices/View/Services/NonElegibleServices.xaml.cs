using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonElegibleServices.xaml
    /// </summary>
    public partial class NonElegibleServices : ViewBaseControl
    {
        public NonElegibleServices()
        {
            this.DataContext = new NonElegibleServicesViewModel();
            InitializeComponent();
        }
    }
}
