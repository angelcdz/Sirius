using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
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
    class ServiceRequestsHistoryViewModel : ViewModelBase
    {
        string _serviceId;
        private Logger _logger = Logger.LoggerFor<ServiceRequestsHistoryViewModel>();

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
            if (navegationParams_ != null && navegationParams_.ContainsKey("service"))
            {
                _serviceId = navegationParams_["serviceId"] as string;
            }
            LoadRequestsHistory();
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

            var requestsHistoryModel = new GetServiceRequestsHistoryModel();

            GetServiceRequestsHistoryRequest getRequestsHistoryRequests = new GetServiceRequestsHistoryRequest();
            getRequestsHistoryRequests.CodigoServico = _serviceId;
            getRequestsHistoryRequests.CodigoCliente = clientIdNumber;
            requestsHistoryModel.Request = getRequestsHistoryRequests;

            var executionState = requestsHistoryModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                List<Request> requestsHistory = new List<Request>();
                var response = (GetServiceRequestsHistoryResponse)(requestsHistoryModel.Response);
                foreach (var request in response.ServiceRequests)
                {
                    requestsHistory.Add(new Request()
                    {
                        CreatedOn = request.CreatedOn.ToShortDateString(),
                        ClosedOn = 
                            (request.ClosedOn.Day == 1 &&
                              request.ClosedOn.Month == 1 &&
                              request.ClosedOn.Year == 1) 
                              ? string.Empty 
                              : request.ClosedOn.ToShortDateString(),
                        ProductRequestName = string.IsNullOrEmpty(request.ServiceRequestName) ? "---" : request.ServiceRequestName,
                        ServiceCallNumber = string.IsNullOrEmpty(request.CaseTitle) ? "---" : request.CaseTitle
                    });
                }
                RequestsHistory = requestsHistory;

                ViewState = ViewStates.Default;
            }
            else if (requestsHistoryModel.Response != null)
            {
                ErrorMessage = requestsHistoryModel.ErrorMessage;
                ErrorId = requestsHistoryModel.Response.CorrelationId.ToString();
                ViewState = ViewStates.LoadingError;
            }
            else
            {
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
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
