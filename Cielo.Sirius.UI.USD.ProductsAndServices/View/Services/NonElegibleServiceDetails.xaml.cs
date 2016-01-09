using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for NonElegibleServiceDetails.xaml
    /// </summary>
    public partial class NonElegibleServiceDetails : ViewBaseControl
    {
        public NonElegibleServiceDetails()
        {
            this.DataContext = new NonElegibleServiceDetailsViewModel();
            InitializeComponent();
        }
    }
}
