using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class ServicesViewModel : ViewModelBase
    {
        #region Commands

        private ICommand _selectEnabledServices;
        public ICommand SelectEnabledServices
        {
            get
            {
                if (_selectEnabledServices == null)
                {
                    _selectEnabledServices = new RelayCommand(
                        param => Navegate("EnabledServices", "SecoundResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectEnabledServices;
            }
        }

        private ICommand _selectNonEnabledServices;
        public ICommand SelectNonEnabledServices
        {
            get
            {
                if (_selectNonEnabledServices == null)
                {
                    _selectNonEnabledServices = new RelayCommand(
                        param => Navegate("NonEnabledServices", "SecoundResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectNonEnabledServices;
            }
        }

        private ICommand _selectNotElegibleServices;
        public ICommand SelectNotElegibleServices
        {
            get
            {
                if (_selectNotElegibleServices == null)
                {
                    _selectNotElegibleServices = new RelayCommand(
                        param => Navegate("NonElegibleServices", "SecoundResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectNotElegibleServices;
            }
        }

        #endregion
    }
}
