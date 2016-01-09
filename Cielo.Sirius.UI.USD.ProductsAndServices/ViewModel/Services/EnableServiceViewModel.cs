using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.GetRequestReason;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class EnableServiceViewModel : ViewModelBase
    {
        private Logger _logger = Logger.LoggerFor<EnableServiceViewModel>();

        #region Constants

        private const string CANAL = "Telefone";
        private const string CASETYPE = "Solicitação";
        private const string ARVOREASSUNTO = "Habilitar Serviço";
        private const string ESTABELECIMENTOCOMERCIAL = "ECNumber";
        private const string SISTEMAORIGEM = "CRM";

        #endregion

        #region Properties

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

        private string _successMessage;

        public string SuccessMessage
        {
            get { return _successMessage; }
            set
            {
                _successMessage = value;
                OnPropertyChanged();
            }
        }

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

        private string _codigoServico;

        public string CodigoServico
        {
            get { return _codigoServico; }
            set { _codigoServico = value; }
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

        private Guid DemandId
        { get; set; }

        #endregion

        #region Commands

        private ICommand _enableServiceCommand;

        public ICommand EnableServiceCommand
        {
            get
            {

                if (_enableServiceCommand == null)
                {

                    _enableServiceCommand = new RelayCommand(
                        param => EnableService(param),
                        param => true);
                }

                return _enableServiceCommand;
            }

        }


        #endregion

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

        private void EnableService(object param)
        {
            EnableServiceModel enableService = new EnableServiceModel();
            enableService.Request = new HabilitarServicoRequest();

            if (SelectedReason == null)
            {
                ErrorMessage = "Por favor, selecionar um motivo.";
                HasInputError = true;
                return;
            }

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                SetActionError();
                return;
            }

            string _protocolo = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO))))
            {
                ErrorMessage = "Protocolo inválido";
                SetActionError();
                return;
            }
            else
                _protocolo = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO);

            string _ilhaDeAtendimento = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO))))
            {
                ErrorMessage = "Ilha de Atendimento inválida";
                SetActionError();
                return;
            }
            else
                _ilhaDeAtendimento = GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO);

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

            string _ContadorOcorrencias = string.Empty; //TO DO Definir o valor para o contador de ocorrencias.
            enableService.Request.CodigoCliente = clientIdNumber;
            enableService.Request.CodigoServico = CodigoServico;
            enableService.Request.TituloOcorrencia = _protocolo + _ContadorOcorrencias;
            enableService.Request.IlhaDeAtendimento = _ilhaDeAtendimento;
            enableService.Request.CanalDeAtendimento = CANAL;
            enableService.Request.IdMotivo = ((Reason)SelectedReason).Id;
            enableService.Request.IdDemanda = DemandId;
            enableService.Request.CaseType = CASETYPE;
            enableService.Request.ArvoreAssunto = ARVOREASSUNTO;
            enableService.Request.Cliente = _account;
            enableService.Request.ParentCaseId = _parentCaseId;
            //enableService.Request.Protocolo = _protocolo;
            //enableService.Request.Origem = SISTEMAORIGEM;

            var executionState = enableService.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                //TO DO Exibir mensagem de sucesso. Em definição pelo componente de exibicao
                //Mensagem de sucesso:
                //1. "Solicitação aberta com sucesso. Data prevista para solução <data de SLA retornada pelo serviço>"
                //2. "Solicitação aberta. A previsão final para solução está indisponível."
                // SuccessMessage = enableService.Response
                var navParams = new Dictionary<string, object>();
                string message = "Solicitação aberta";
                string messageDetail = "A previsão final para disposição está indisponível";
                if (enableService.Response != null && enableService.Response.DataSLA != DateTime.MinValue)
                {
                    if (enableService.Response.DataSLA != DateTime.MinValue)
                    {
                        message = "Solicitação aberta com sucesso";
                        messageDetail = string.Format("Data prevista para solução: {0}.", enableService.Response.DataSLA.ToString("dd/MM/yyyy"));
                    }
                }
                navParams.Add("Message", message);
                navParams.Add("MessageDetail", messageDetail);
                Navegate("ServiceRequestSuccess", "RequestsRegion", "", navParams);
            }
            else if (executionState == ExecutionStatus.BusinessError)
            {
                ErrorMessage = enableService.Response != null ?
                   enableService.Response.ErrorMessage : "";
                _logger.LogError(String.IsNullOrWhiteSpace(ErrorMessage) ? "Faild while executiong 'EnableServiceModel'." : ErrorMessage);
                var navParams = new Dictionary<string, object>();
                navParams.Add("Message", "Não foi possível realizar a solicitação");
                navParams.Add("MessageDetail", ErrorMessage);
                Navegate("ServiceRequestError", "RequestsRegion", "", navParams);
            }
            else
            {
                ErrorMessage = enableService.ErrorMessage ?? "Null or empty response of 'EnableServiceModel'";
                SetActionError();
            }
        }

        public class Reason
        {
            public Guid Id { get; set; }
            public string NomeMotivo { get; set; }
        }
    }
}
