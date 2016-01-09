using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;
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
    class NonElegibleProductRequestsSelectorViewModel : ViewModelBase
    {
        private string _codigoProduto;
        private string _tipoProduto;
        private List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO> _nonElegibleProductRates;

        private Logger _logger = Logger.LoggerFor<NonElegibleProductRequestsSelectorViewModel>();

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

        #region Initialize

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            _codigoProduto = navegationParams_["product"] as string;
            _tipoProduto = navegationParams_["productType"] as string;
           
            Messenger.Register<List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>>(this,
                (nonElegibleProducDetailsDTO_) => _nonElegibleProductRates = nonElegibleProducDetailsDTO_);

            LoadProdutRequestTypes();
            base.PreInitialize(navegationParams_);
        }

        #endregion

        private void LoadProdutRequestTypes()
        {
            var productRequestTypesRequest = new GetNonEligibleProductRequestTypesRequest();
            productRequestTypesRequest.ProductGroup = Constants.GRUPO_PRODUTO_ELEGIVEL_HABILITADO;

            var productRequestTypesModel = new NonElegibleProductRequestsTypesModel();
            productRequestTypesModel.Request = productRequestTypesRequest;
            var executionState = productRequestTypesModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                ViewState = ViewStates.Default;

                var requestsTypeList = new List<RequestType>();
                if (productRequestTypesModel.Response != null 
                    && productRequestTypesModel.Response.ProductRequestTypes != null)
                {
                    foreach (var type in  productRequestTypesModel.Response.ProductRequestTypes)
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
                ErrorMessage = "TechnicalError occurred while executing: 'NonElegibleProductRequestsTypesModel'";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                _logger.LogError(ErrorMessage);
            }
        }

        private void SelectedItemCommandMethod(RequestType requestType_)
        {
            var rquestType = SelectedRequest as RequestType;
            if (rquestType != null)
            {
                var navParams = new Dictionary<string, object>();
                navParams.Add("product", _codigoProduto);
                navParams.Add("requestTypeId", rquestType.IntegrationRequestCode);
                navParams.Add("demandId", rquestType.Id);
                
                switch (rquestType.IntegrationRequestCode)
                {
                    case 0003:
                        navParams.Add("rates", _nonElegibleProductRates);
                        if (_tipoProduto == Constants.TIPOGRUPOPRODUTO_CREDITO)
                        {
                            Navegate("RateChangeCreditoAVista", "RequestsRegion", "", navParams);
                        }
                        else
                        {
                            Navegate("RateChange", "RequestsRegion", "", navParams);
                        }
                        break;
                    default:
                        break;
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
