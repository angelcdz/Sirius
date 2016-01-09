using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for EnabledServiceDetails.xaml
    /// </summary>
    public partial class EnabledServiceDetails : ViewBaseControl
    {
        public EnabledServiceDetails()
        {
            this.DataContext = new EnabledServiceDetailsViewModel();
            InitializeComponent();
        }
    }
}
