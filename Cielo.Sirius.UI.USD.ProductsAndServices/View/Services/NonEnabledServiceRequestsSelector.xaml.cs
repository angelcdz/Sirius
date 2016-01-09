using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View.Services
{
    /// <summary>
    /// Interaction logic for DisabledServiceRequestsSelector.xaml
    /// </summary>
    public partial class NonEnabledServiceRequestsSelector : ViewBaseControl
    {
        public NonEnabledServiceRequestsSelector()
        {
            this.DataContext = new NonEnabledServiceRequestsSelectorViewModel();
            InitializeComponent();
        }
    }
}
