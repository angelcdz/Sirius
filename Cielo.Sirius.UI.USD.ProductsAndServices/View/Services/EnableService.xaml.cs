using System;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for EnableService.xaml
    /// </summary>
    public partial class EnableService : ViewBaseControl
    {
        public EnableService()
        {
            this.DataContext =new EnableServiceViewModel();
            InitializeComponent();
        }
    }
}
