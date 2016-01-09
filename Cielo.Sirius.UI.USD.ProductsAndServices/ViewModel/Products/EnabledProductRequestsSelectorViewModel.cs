using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.Foundation.USD.Messenger;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class EnabledProductRequestsSelectorViewModel : ViewModelBase
    {
        private string _codigoProduto;
        private string _tipoProduto;
        private List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO> _enabledProductRates;
        private bool _meiIndicator;
        private string _branchOfActivityCode;

        private Logger _logger = Logger.LoggerFor<DisabledTypedSaleViewModel>();

        #region Properties

        private List<ConsultarProdutoHabilitadoClienteProdutoDTO> _clientProducts;
        public List<ConsultarProdutoHabilitadoClienteProdutoDTO> ClientProducts
        {
            get { return _clientProducts; }
            set { _clientProducts = value; }
        }

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

        #region Initialize

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            _codigoProduto = navegationParams_["product"] as string;
            _tipoProduto = navegationParams_["productType"] as string;
            _clientProducts = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();
            _clientProducts = (List<ConsultarProdutoHabilitadoClienteProdutoDTO>)(navegationParams_["products"]);

            Messenger.Register<List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>>(this,
                (enabledProducDetailsDTO_) => _enabledProductRates = enabledProducDetailsDTO_);

            LoadProdutRequestTypes();
            base.PreInitialize(navegationParams_);
        }

        #endregion

        private void LoadProdutRequestTypes()
        {
            var productRequestTypesRequest = new GetEnabledProductRequestTypesRequest();
            ConsultarProdutoHabilitadoClienteProdutoDTO detailedProduct = _clientProducts.Find(s => s.CodigoProduto == _codigoProduto);

            productRequestTypesRequest.ProductGroup = Constants.GRUPO_PRODUTO_ELEGIVEL_HABILITADO;
            productRequestTypesRequest.EnabledTypedSaleIndicator = detailedProduct.IndicadorVendaDigitadaHabilitada;
            productRequestTypesRequest.FlexibleMaturityRate = detailedProduct.PercentualTaxaGarantia; // Taxa Prazo Flexível

            long ecNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out ecNumber))
            {
                ViewState = ViewStates.LoadingError;
                ErrorMessage = "Número de Estabelecimento Comercial inválido";
                _logger.LogError(ErrorMessage);
                return;
            }
            productRequestTypesRequest.ECNumber = ecNumber;

            var productRequestTypesModel = new EnabledProductRequestsTypesModel();
            productRequestTypesModel.Request = productRequestTypesRequest;

            var executionState = productRequestTypesModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                ViewState = ViewStates.Default;
                var requestsTypeList = new List<RequestType>();
                if (productRequestTypesModel.Response != null
                    && productRequestTypesModel.Response.ProductRequestTypes != null)
                {
                    foreach (var type in productRequestTypesModel.Response.ProductRequestTypes)
                    {
                        requestsTypeList.Add(new RequestType()
                        {
                            Id = type.Id,
                            Description = type.Name,
                            IntegrationRequestCode = type.IntegrationRequestCode
                        });
                    }

                    _meiIndicator = productRequestTypesModel.Response.MEIIndicator;
                    _branchOfActivityCode = productRequestTypesModel.Response.BranchOfActivityCode;
                }

                RequestsTypeList = requestsTypeList;
            }
            else if (executionState == ExecutionStatus.BusinessError && productRequestTypesModel.Response != null)
            {
                ViewState = ViewStates.LoadingError;
                ErrorMessage = productRequestTypesModel.Response.ErrorMessage;
                ErrorId = productRequestTypesModel.Response.CorrelationId.ToString();
                _logger.LogError(ErrorMessage);
            }
            else
            {
                ViewState = ViewStates.LoadingError;
                ErrorMessage = "TechnicalError occurred while executing: 'EnabledProductRequestsTypesModel'";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                _logger.LogError(ErrorMessage);
            }
        }

        private void SelectedItemCommandMethod(RequestType requestType_)
        {
            var requestType = SelectedRequest as RequestType;
            if (requestType != null)
            {
                var navParams = new Dictionary<string, object>();
                navParams.Add("product", _codigoProduto);
                navParams.Add("products", _clientProducts);
                navParams.Add("requestTypeId", requestType.IntegrationRequestCode);
                navParams.Add("demandId", requestType.Id);
                navParams.Add("meiIndicator", _meiIndicator);
                navParams.Add("branchOfActivityCode", _branchOfActivityCode);

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
                        case 0003:
                            navParams.Add("rates", _enabledProductRates);
                            if (_tipoProduto == Constants.TIPOGRUPOPRODUTO_CREDITO)
                            {
                                Navegate("RateChangeCreditoAVista", "RequestsRegion", "", navParams);
                            }
                            else
                            {
                                Navegate("RateChange", "RequestsRegion", "", navParams);
                            }
                            break;
                        case Constants.TIPO_DEMANDA_PRD_HABILITAR_VENDA_DIGITADA:

                            Navegate("EnabledTypedSale", "RequestsRegion", "", navParams);

                            break;
                        case Constants.TIPO_DEMANDA_PRD_DESABILITAR_VENDA_DIGITADA:
                            Navegate("DisabledTypedSale", "RequestsRegion", "", navParams);
                            break;
                        case Constants.TIPO_DEMANDA_PRD_SOLICITAR_NEGOCIACAO_DE_TAXA:
                            Navegate("RateNegotiationRequest", "RequestsRegion", "", navParams);
                            break;
                        case Constants.TIPO_DEMANDA_PRD_DESABILITARPRODUTO:
                            Navegate("DisableProduct", "RequestsRegion", "", navParams);
                            break;
                        case Constants.TIPO_DEMANDA_PRD_ALTERAR_PRODUTO:
                            switch (_tipoProduto)
                            {
                                case Constants.TIPOGRUPOPRODUTO_CREDITO:
                                    Navegate("ChangeProductOneLump", "RequestsRegion", "", navParams);
                                    break;
                                case Constants.TIPOGRUPOPRODUTO_PARCELADO:
                                    Navegate("ChangeProductInstallmentCredit", "RequestsRegion", "", navParams);
                                    break;
                                case Constants.TIPOGRUPOPRODUTO_SEGMENTADO:
                                    Navegate("ChangeProductInstallmentSegmentedCredit", "RequestsRegion", "", navParams);
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (getRequestReasonModel.Response != null)
                {
                    ViewState = ViewStates.ActionError;
                    ErrorId = getRequestReasonModel.Response.CorrelationId.ToString();
                    ErrorMessage = getRequestReasonModel.Response.ErrorMessage;
                    _logger.LogError(ErrorMessage);
                }
                else
                {
                    ViewState = ViewStates.ActionError;
                    ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                    ErrorMessage = "TechnicalError occurred while executing: 'GetRequestReasonModel'";
                    _logger.LogError(ErrorMessage);
                }
            }
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
