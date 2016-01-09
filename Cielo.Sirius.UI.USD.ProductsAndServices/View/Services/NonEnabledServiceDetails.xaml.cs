using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonEnabledServiceDetails.xaml
    /// </summary>
    public partial class NonEnabledServiceDetails : ViewBaseControl
    {
        public NonEnabledServiceDetails()
        {
            this.DataContext = new NonEnabledServiceDetailsViewModel();
            InitializeComponent();
        }
    }
}
