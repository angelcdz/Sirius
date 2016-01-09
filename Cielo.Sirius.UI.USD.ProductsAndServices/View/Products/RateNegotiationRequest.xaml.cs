using System;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;
using Cielo.Sirius.Foundation.USD;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for RateNegotiationRequest.xaml
    /// </summary>
    public partial class RateNegotiationRequest : ViewBaseControl
    {
        public RateNegotiationRequest()
        {
            this.DataContext = new RateNegotiationRequestViewModel();
            InitializeComponent();
        }
    }
}
