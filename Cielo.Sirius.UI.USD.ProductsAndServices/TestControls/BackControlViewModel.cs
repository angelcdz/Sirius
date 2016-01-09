using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.TestControls
{
    class BackControlViewModel : ViewModelBase
    {
        #region Commands

        private ICommand _Back;

        public ICommand Back
        {
            get
            {
                if (_Back == null)
                {
                    _Back = new RelayCommand(
                        param => Navegate("ProductsAndServices", "ProductsAndServicesMainRegion", "", null),
                        param => true
                    );
                }
                return _Back;
            }
        }
        #endregion
    }
}
