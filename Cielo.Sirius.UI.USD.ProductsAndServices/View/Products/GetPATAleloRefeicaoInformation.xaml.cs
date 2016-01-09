using Cielo.Sirius.Foundation.USD;
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
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View
{
    /// <summary>
    /// Interaction logic for GetPATAleloRefeicaoInformation.xaml
    /// </summary>
    public partial class GetPATAleloRefeicaoInformation : ViewBaseControl
    {
        public GetPATAleloRefeicaoInformation()
        {

            this.DataContext = new GetPATAleloRefeicaoInformationViewModel();
            InitializeComponent();
        }
    }
}
