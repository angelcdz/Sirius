using Cielo.Sirius.Foundation.USD;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.TestControls
{
    /// <summary>
    /// Interaction logic for BackControl.xaml
    /// </summary>
    public partial class BackControl : ViewBaseControl
    {
        public BackControl()
        {
            DataContext = new BackControlViewModel();
            InitializeComponent();
        }
    }
}
