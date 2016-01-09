using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.CommercialDeal
{
    class CommercialDealRequestsSelectorViewModel : ViewModelBase
    {
        private Logger _logger = Logger.LoggerFor<CommercialDealRequestsSelectorViewModel>();

        #region Properties 

        private IEnumerable<RequestType> _requestsTypeList;
        public IEnumerable<RequestType> RequestsTypeList
        {
            get { return _requestsTypeList; }
            set
            {
                if (_requestsTypeList == value)
                    return;
                _requestsTypeList = value;
                OnPropertyChanged();
            }
        }

        private object _selectedRequest;
        public object SelectedRequest
        {
            get { return _selectedRequest; }
            set
            {
                if (_selectedRequest == value)
                    return;
                _selectedRequest = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand _selectedItemCommand;
        public ICommand SelectedItemCommand
        {
            get
            {
                if (_selectedItemCommand == null)
                {
                    _selectedItemCommand = new RelayCommand(
                        param => SelectedItemCommandMethod(param as RequestType),
                        param => true
                    );
                }
                return _selectedItemCommand;
            }
        }

        #endregion

        private void SelectedItemCommandMethod(RequestType requestType_)
        {

        }

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            LoadRequestTypes();
            base.PreInitialize(navegationParams_);
        }

        private void LoadRequestTypes()
        {
            
        }

        #region Aditional Classes

        public class RequestType
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public int IntegrationRequestCode { get; set; }
        }
        

        #endregion

    }
}
