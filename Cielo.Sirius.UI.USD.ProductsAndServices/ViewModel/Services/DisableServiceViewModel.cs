using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Contracts.GetRequestReason;
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
    class DisableServiceViewModel : ViewModelBase
    {

        private const string CANAL = "Telefone";
        private const string CASETYPE = "Solicitação";
        private const string ARVOREASSUNTO = "Desabilitar Serviço";
        private const string SISTEMAORIGEM = "CRM";

        private Logger _logger = Logger.LoggerFor<DisableServiceViewModel>();

        private string _codigoServico = null;

        private Guid DemandId
        { get; set; }

        private bool _hasInputError;
        public bool HasInputError
        {
            get { return _hasInputError; }
            set
            {
                if (_hasInputError == value)
                    return;
                _hasInputError = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<Reason> _reasonList;
        public IEnumerable<Reason> ReasonList
        {
            get { return _reasonList; }
            set
            {
                if (_reasonList == value)
                    return;
                _reasonList = value;
                OnPropertyChanged();
            }
        }
        private object _selectedReason;
        public object SelectedReason
        {
            get { return _selectedReason; }
            set
            {
                if (_selectedReason == value)
                    return;
                _selectedReason = value;
                OnPropertyChanged();
            }
        }

        private ICommand _DisableServiceCommand;
        public ICommand DisableServiceCommand
        {
            get
            {
                if (_DisableServiceCommand == null)
                {
                    _DisableServiceCommand = new RelayCommand(
                        param => DisableService(param),
                        param => true);
                }
                return _DisableServiceCommand;
            }
        }

        private string _solutionEstimatedDate;
        public string SolutionEstimatedDate
        {
            get { return _solutionEstimatedDate; }
            set
            {
                if (_solutionEstimatedDate == value)
                    return;
                _solutionEstimatedDate = value;
                OnPropertyChanged();
            }
        }

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            if (GetCodigoServico(navegationParams_))
            {
                LoadReasons(navegationParams_);
                LoadSolutionEstimatedDate(navegationParams_);
            }

            if (navegationParams_ != null
                && navegationParams_.ContainsKey("demandId")
                && navegationParams_["demandId"] != null
                && navegationParams_["demandId"].GetType() == typeof(Guid))
            {
                DemandId = (Guid)navegationParams_["demandId"];
            }

            base.PreInitialize(navegationParams_);
        }

        private void LoadReasons(Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null && navegationParams_.ContainsKey("ListaMotivos") && navegationParams_["ListaMotivos"] != null && navegationParams_["ListaMotivos"] as List<GetRequestReasonDTO> != null)
            {

                List<GetRequestReasonDTO> listaReasonDTO = (List<GetRequestReasonDTO>)navegationParams_["ListaMotivos"];

                // observable colection deve receber uma lista de dto
                var reasonListAux = new List<Reason>();

                foreach (GetRequestReasonDTO reasonDTO in listaReasonDTO)
                {
                    Reason r = new Reason();
                    r.NomeMotivo = reasonDTO.ReasonName;
                    r.Id = reasonDTO.ReasonId;
                    reasonListAux.Add(r);
                }

                ReasonList = reasonListAux;
            }
            else
            {
                ErrorMessage = "Erro ao carregar Lista de Motivos";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                _logger.LogError("Navegation parameter 'ListaMotivos' not found");
                ViewState = ViewStates.LoadingError;
            }
        }

        private void LoadSolutionEstimatedDate(Dictionary<string, object> navegationParams_)
        {
            int requestTypeId = 0;
            if (navegationParams_.ContainsKey("requestTypeId") &&
                navegationParams_["requestTypeId"] != null &&
                (int.TryParse(navegationParams_["requestTypeId"].ToString(), out requestTypeId)))
            {

                CalculateDefaultSLA(requestTypeId);
            }
        }

        private void CalculateDefaultSLA(int requestTypeId_)
        {
            SolutionEstimatedDate = "SLA indisponível.";

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido.";
                SolutionEstimatedDate = "Erro na consulta da data prevista para solução: " + ErrorMessage;
                _logger.LogError(ErrorMessage);
                return;
            }

            var defaultSlaModel = new DefaultRequestSLAModel();
            var getDefaultSLARequest = new ConsultarPrazoPadraoRequest();

            getDefaultSLARequest.TipoDemanda = requestTypeId_;
            getDefaultSLARequest.SubTipoDemanda = _codigoServico;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
        }

        private void DisableService(object param)
        {
            long clientIdNumber = new long();
            string _tituloDaOcorrencia = "";
            string _protocolo = "";
            string _ilhaDeAtendimento = "";
            //TODO Contador de Ocorrências (IDC)
            string _contador = "";

            if (SelectedReason == null)
            {
                HasInputError = true;
                ErrorMessage = "Por favor, selecionar um motivo.";
                return;
            }

            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                SetActionError();
                return;
            }

            if ((string.IsNullOrEmpty(_codigoServico)))
            {
                ErrorMessage = "Código do serviço inválido";
                SetActionError();
                return;
            }

            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO))))
            {
                ErrorMessage = "Ilha de atendimento inválida";
                SetActionError();
                return;
            }
            else
                _ilhaDeAtendimento = GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO);


            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO))))
            {
                ErrorMessage = "Protocolo inválido";
                SetActionError();
                return;
            }
            else
            {
                _tituloDaOcorrencia = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO) + _contador;
                _protocolo = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO);
            }

            string _account = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_ACCOUNT))))
            {
                ErrorMessage = "Cliente inválido";
                SetActionError();
                return;
            }
            else
                _account = GetCrmContextValue(Constants.CONTEXTOCRM_ACCOUNT);

            string _parentCaseId = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PARENTCASEID))))
            {
                ErrorMessage = "Código de Ocorrência de Atendimento inválido";
                SetActionError();
                return;
            }
            else
                _parentCaseId = GetCrmContextValue(Constants.CONTEXTOCRM_PARENTCASEID);

            var disableServiceModel = new DisabelServiceModel();
            disableServiceModel.Request = new DesabilitarServicoRequest();

            disableServiceModel.Request.CodigoCliente = clientIdNumber;
            disableServiceModel.Request.CodigoServico = _codigoServico;
            disableServiceModel.Request.IlhaDeAtendimento = _ilhaDeAtendimento;
            disableServiceModel.Request.TituloDaOcorrencia = _tituloDaOcorrencia;
            disableServiceModel.Request.ArvoreDeAssunto = ARVOREASSUNTO;
            disableServiceModel.Request.IdMotivo = ((Reason)SelectedReason).Id;
            disableServiceModel.Request.CanalDeAtendimento = CANAL;
            disableServiceModel.Request.CaseType = CASETYPE;
            disableServiceModel.Request.Cliente = _account;
            disableServiceModel.Request.ParentCaseId = _parentCaseId;
            disableServiceModel.Request.IdDemanda = DemandId;
            //disableServiceModel.Request.Protocolo = _protocolo;
            //disableServiceModel.Request.Origem = SISTEMAORIGEM;    


            var executionState = disableServiceModel.Execute();

            if (disableServiceModel.Response != null && disableServiceModel.Response.Status == ExecutionStatus.Success)
            {

                var navParams = new Dictionary<string, object>();
                string message = "Solicitação aberta";
                string messageDetail = "A previsão final para disposição está indisponível";
                if (disableServiceModel.Response != null)
                {
                    string slaDate = disableServiceModel.Response.DataPrevistaConclusaoSolicitacao != null ?
                        ((DateTime)disableServiceModel.Response.DataPrevistaConclusaoSolicitacao).ToString("dd/MM/yyyy")
                        : "SLA indisponível";
                    if (disableServiceModel.Response.DataPrevistaConclusaoSolicitacao != DateTime.MinValue)
                    {
                        message = "Solicitação aberta com sucesso";
                        messageDetail = string.Format("Data prevista para solução: {0}.", slaDate);
                    }
                }
                navParams.Add("Message", message);
                navParams.Add("MessageDetail", messageDetail);
                Navegate("ServiceRequestSuccess", "RequestsRegion", "", navParams);

            }
            else if (executionState == ExecutionStatus.BusinessError)
            {
                ErrorMessage = disableServiceModel.Response != null ?
                    disableServiceModel.Response.ErrorMessage : "";
                _logger.LogError(string.IsNullOrWhiteSpace(ErrorMessage) ? "Faild while execution 'DisabelServiceModel'." : ErrorMessage);
                var navParams = new Dictionary<string, object>();
                navParams.Add("Message", "Não foi possível realizar a solicitação");
                navParams.Add("MessageDetail", ErrorMessage);
                Navegate("ServiceRequestError", "RequestsRegion", "", navParams);
            }
            else
            {
                ErrorMessage = disableServiceModel.ErrorMessage ?? "Null or empty response of 'DisabelServiceModel'";
                SetActionError();
            }
        }

        private void SetActionError()
        {
            ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
            ViewState = ViewStates.ActionError;
            _logger.LogError(ErrorMessage);
        }

        private bool GetCodigoServico(Dictionary<string, object> param)
        {
            if (param["serviceId"] != null)
            {
                _codigoServico = param["serviceId"] as string;
                return true;
            }
            else
            {
                ErrorMessage = "Código do serviço inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError("Navegation parameter 'serviceId' not found.");
                return false;
            }
        }

        public class Reason
        {
            public Guid Id { get; set; }
            public string NomeMotivo { get; set; }
        }
    }
}
