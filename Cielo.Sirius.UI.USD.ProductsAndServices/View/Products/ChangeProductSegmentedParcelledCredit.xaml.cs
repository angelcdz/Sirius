using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using System.Windows.Controls;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for ChangeProductSegmentedParcelledCredit.xaml
    /// </summary>
    public partial class ChangeProductSegmentedParcelledCredit : ViewBaseControl
    {
        public ChangeProductSegmentedParcelledCredit()
        {
            this.DataContext = new ChangeProductSegmentedParcelledCreditViewModel();
            InitializeComponent();
        }
    }
}
