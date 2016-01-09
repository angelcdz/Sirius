using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Products;
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

namespace Cielo.Sirius.UI.USD.ProductsAndServices.View.Products
{
    /// <summary>
    /// Interaction logic for DisableProduct.xaml
    /// </summary>
    public partial class DisableProduct : ViewBaseControl
    {
        public DisableProduct()
        {
            this.DataContext = new DisableProductViewModel();
            InitializeComponent();
        }
    }
}
