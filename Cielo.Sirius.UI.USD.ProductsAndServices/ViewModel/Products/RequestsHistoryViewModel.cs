using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class RequestsHistoryViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

        #endregion

        string _codigoProduto;
        string _tipoProduto;

        private Logger _logger = Logger.LoggerFor<RequestsHistoryViewModel>();

        private IEnumerable<Request> _requestsHistory;
        public IEnumerable<Request> RequestsHistory
        {
            get { return _requestsHistory; }
            set
            {
                if (_requestsHistory == value)
                    return;
                _requestsHistory = value;
                OnPropertyChanged();
            }
        }

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null && navegationParams_.ContainsKey("product") && navegationParams_.ContainsKey("productType"))
            {
                _codigoProduto = navegationParams_["product"] as string;
                _tipoProduto = navegationParams_["productType"] as string;
                LoadRequestsHistory();
            }
            base.PreInitialize(navegationParams_);
        }

        private void LoadRequestsHistory()
        {
            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

            var requestsHistoryModel = new RequestsHistoryModel();

            GetProductRequestsHistoryRequest getRequestsHistoryRequests = new GetProductRequestsHistoryRequest();
            getRequestsHistoryRequests.CodigoProduto = _codigoProduto;
            getRequestsHistoryRequests.CodigoCliente = clientIdNumber;
            requestsHistoryModel.Request = getRequestsHistoryRequests;

            var executionState = requestsHistoryModel.Execute();
            var response = requestsHistoryModel.Response;

            if (response != null && response.Status.Equals(ExecutionStatus.Success))
            {
                ViewState = ViewStates.Default;

                List<Request> requestsHistory = new List<Request>();
                foreach (var request in response.ProductRequests)
                {
                    requestsHistory.Add(new Request()
                    {
                        CreatedOn = request.CreatedOn.ToShortDateString(),
                        ClosedOn = request.ClosedOn.ToShortDateString(),
                        ProductRequestName = string.IsNullOrEmpty(request.ProductRequestName) ? "---" : request.ProductRequestName,
                        ServiceCallNumber = string.IsNullOrEmpty(request.ServiceCallNumber) ? "---" : request.ServiceCallNumber
                    });
                }
                RequestsHistory = requestsHistory;
            }
            else if (response != null && response.Status.Equals(ExecutionStatus.BusinessError))
            {
                ViewState = ViewStates.LoadingError;
                ErrorId = response.CorrelationId.ToString();
                ErrorMessage = response.ErrorMessage;
            }
            else
            {
                ViewState = ViewStates.CustomError;
                ErrorMessage = LOADING_DEFAULT_ERROR_MSG;
            }
        }

        public class Request
        {
            public string ServiceCallNumber { get; set; }
            public string ProductRequestName { get; set; }
            public string CreatedOn { get; set; }
            public string ClosedOn { get; set; }
        }
    }
}
