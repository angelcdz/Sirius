using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services
{
    public class NonEnabledServiceRequestsSelectorViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Erro ao consultar informações de Serviços. Informar ao cliente para tentar novamente mais tarde";

        #endregion

        #region Attributes

        private string _codigoServico;
        private IEnumerable<RequestType> _requestsTypeList;
        private object _selectedRequest;
        private ICommand _selectedItemCommand;

        private Logger _logger = Logger.LoggerFor<NonEnabledServiceRequestsSelectorViewModel>();

        #endregion

        #region Properties

        private ConsultarServicoClienteElegivelServicoDTO _service;
        public ConsultarServicoClienteElegivelServicoDTO Service
        {
            get { return _service; }
            set
            {
                if (_service == value)
                    return;

                _service = value;
                OnPropertyChanged();
            }
        }

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

            _service = navegationParams_["service"] as ConsultarServicoClienteElegivelServicoDTO;

            LoadProdutRequestTypes();
            base.PreInitialize(navegationParams_);
        }

        #endregion

        #region Methods

        private void LoadProdutRequestTypes()
        {
            var serviceRequestTypesRequest = new GetNonEnabledServiceRequestTypesRequest();
            serviceRequestTypesRequest.ServiceGroup = Constants.GRUPO_SERVICO_ELEGIVEL_NAOHABILITADO;

            string serviceName = _service.NomeServico;
            if (string.IsNullOrEmpty(serviceName))
            {
                ErrorMessage = "Nome do serviço inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
            }

            serviceRequestTypesRequest.ServiceName = serviceName;
            var serviceRequestTypesModel = new NonEnabledServiceRequestsTypesModel();
            serviceRequestTypesModel.Request = serviceRequestTypesRequest;
            var executionState = serviceRequestTypesModel.Execute();

            var response = serviceRequestTypesModel.Response;
            if (response != null && (response.Status == ExecutionStatus.Success || response.Status == ExecutionStatus.Warning))
            {
                ViewState = ViewStates.Default;

                var requestsTypeList = new List<RequestType>();
                if (serviceRequestTypesModel.Response != null
                    && serviceRequestTypesModel.Response.ServiceRequestTypes != null)
                {
                    foreach (var type in serviceRequestTypesModel.Response.ServiceRequestTypes)
                    {
                        requestsTypeList.Add(new RequestType()
                        {
                            Id = type.Id,
                            Description = type.Name,
                            IntegrationRequestCode = type.IntegrationRequestCode
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
            var requestType = SelectedRequest as RequestType;
            if (requestType != null)
            {
                var navParams = new Dictionary<string, object>();
                navParams.Add("serviceId", _codigoServico);
                navParams.Add("requestTypeId", requestType.IntegrationRequestCode);
                navParams.Add("demandId", requestType.Id);

                //Consulta Lista de Motivos passando o rquestType.Id
                GetRequestReasonModel getRequestReasonModel = new GetRequestReasonModel();
                GetRequestReasonRequest reasonRequest = new GetRequestReasonRequest();

                reasonRequest.DemandId = requestType.Id;

                //configura model para executar serviço utilizando o reasonrequest
                getRequestReasonModel.Request = reasonRequest;
                var executionState = getRequestReasonModel.Execute();

                if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
                {
                    var reasonList = new List<GetRequestReasonDTO>();
                    if (getRequestReasonModel.Response != null
                        && getRequestReasonModel.Response.Reasons != null)
                    {
                        reasonList = getRequestReasonModel.Response.Reasons;
                    }

                    //Incluir lista nos parametros de navegacao - ver nome do parametro
                    navParams.Add("ListaMotivos", reasonList);

                    switch (requestType.IntegrationRequestCode)
                    {
                        case 2001:
                            Navegate("EnableService", "RequestsRegion", "", navParams);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ErrorMessage = getRequestReasonModel.ErrorMessage;
                    ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                    ViewState = ViewStates.ActionError;
                    _logger.LogError(ErrorMessage);
                }
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
