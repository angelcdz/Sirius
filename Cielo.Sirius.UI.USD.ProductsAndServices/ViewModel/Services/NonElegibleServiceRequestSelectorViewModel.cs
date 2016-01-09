using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using System.Diagnostics;
using System.Globalization;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services
{
    public class NonElegibleServiceRequestsSelectorViewModel : ViewModelBase
    {
        #region Attributes

        private string _codigoServico;
        private IEnumerable<RequestType> _requestsTypeList;
        private object _selectedRequest;
        private ICommand _selectedItemCommand;

        private Logger _logger = Logger.LoggerFor<NonElegibleServiceRequestsSelectorViewModel>();

        #endregion

        #region Properties

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

        #region Initialize

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null && navegationParams_.ContainsKey("serviceId") && navegationParams_["serviceId"] != null)
            {
                _codigoServico = navegationParams_["serviceId"].ToString();
            }
            LoadProdutRequestTypes();
            base.PreInitialize(navegationParams_);
        }

        #endregion

        #region Methods

        private void LoadProdutRequestTypes()
        {
            var serviceRequestTypesRequest = new GetNonEligibleServiceRequestTypesRequest();
            serviceRequestTypesRequest.ServiceGroup = Constants.GRUPO_SERVICO_NAOELEGIVEL;

            var serviceRequestTypesModel = new NonElegibleServiceRequestsTypesModel();
            serviceRequestTypesModel.Request = serviceRequestTypesRequest;

            serviceRequestTypesModel.Execute();
            var response = serviceRequestTypesModel.Response;

            if (response != null && (response.Status == ExecutionStatus.Success || response.Status == ExecutionStatus.Warning))
            {
                var requestsTypeList = new List<RequestType>();

                if (response.ServiceRequestTypes != null)
                {
                    foreach (var type in response.ServiceRequestTypes)
                    {
                        requestsTypeList.Add(new RequestType()
                        {
                            Id = type.Id,
                            IntegrationRequestCode = type.IntegrationRequestCode,
                            Description = type.Name

                        });
                    }
                }

                RequestsTypeList = requestsTypeList;
            }
            else if (response != null)
            {
                ViewState = ViewStates.LoadingError;
                ErrorId = response.CorrelationId.ToString();
                ErrorMessage = response.ErrorMessage;
            }
            else
            {
                ViewState = ViewStates.LoadingError;
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
            }
        }

        private void SelectedItemCommandMethod(RequestType requestType_)
        {
            var rquestType = SelectedRequest as RequestType;
            if (rquestType != null)
            {
                var navParams = new Dictionary<string, object>();
                navParams.Add("serviceId", _codigoServico);
                navParams.Add("requestTypeId", requestType_.IntegrationRequestCode);
                navParams.Add("demandId", requestType_.Id);
            }
        }

        #endregion

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
