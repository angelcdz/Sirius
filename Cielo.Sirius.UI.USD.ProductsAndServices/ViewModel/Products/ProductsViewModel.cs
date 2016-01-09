using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.Foundation.USD.Messenger;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class ProductsViewModel : ViewModelBase
    {
        #region Properties

        private string _lastTransaction;
        public string LastTransaction
        {
            get { return _lastTransaction; }
            set
            {
                if (_lastTransaction == value)
                    return;
                _lastTransaction = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand _selectEnabledProducts;
        public ICommand SelectEnabledProducts
        {
            get
            {
                if (_selectEnabledProducts == null)
                {
                    _selectEnabledProducts = new RelayCommand(
                        param => Navegate("EnabledProducts", "FirstResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectEnabledProducts;
            }
        }

        private ICommand _selectNonEnabledProducts;
        public ICommand SelectNonEnabledProducts
        {
            get
            {
                if (_selectNonEnabledProducts == null)
                {
                    _selectNonEnabledProducts = new RelayCommand(
                        param => Navegate("NonEnabledProducts", "FirstResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectNonEnabledProducts;
            }
        }

        private ICommand _selectNotElegibleProducts;
        public ICommand SelectNotElegibleProducts
        {
            get
            {
                if (_selectNotElegibleProducts == null)
                {
                    _selectNotElegibleProducts = new RelayCommand(
                        param => Navegate("NonElegibleProducts", "FirstResultsListRegion", "", null),
                        param => true
                    );
                }
                return _selectNotElegibleProducts;
            }
        }

        #endregion

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            Messenger.Register<NotificationMessage>(this, NotificationMessageReceived());
            base.PreInitialize(navegationParams_);
        }

        private Action<NotificationMessage> NotificationMessageReceived()
        {
            return nm =>
            {
                if (nm.Notification == "UpdateLastTransaction")
                {
                    LastTransaction = nm.Description;
                }
            };
        }
    }
}
