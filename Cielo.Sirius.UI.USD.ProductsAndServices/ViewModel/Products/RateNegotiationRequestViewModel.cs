using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    public class RateNegotiationRequestViewModel : ViewModelBase
    {
        private Logger _logger = Logger.LoggerFor<RateNegotiationRequestViewModel>();

        #region Properties

        private string _ECNumber;
        private string _numeroProtocoloCRM;
        private string _nomeContato;
        private string _telefone;
        private string _celular;
        private string _codigoProduto;
        private bool _hasRatesErros;
        private long _clientIdNumber;

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
        private Guid DemandId
        { get; set; }
        public bool HasRatesErros
        {
            get { return _hasRatesErros; }
            set
            {
                if (_hasRatesErros == value)
                    return;
                _hasRatesErros = value;
                OnPropertyChanged();
            }
        }

        private string _validationErrorMessage;
        public string ValidationErrorMessage
        {
            get { return _validationErrorMessage; }
            set
            {
                if (_validationErrorMessage == value)
                    return;
                _validationErrorMessage = value;
                OnPropertyChanged();
            }
        }

        private string _taxaDesejada;
        public string TaxaDesejada
        {
            get { return _taxaDesejada; }
            set
            {
                if (_taxaDesejada == value)
                    return;
                _taxaDesejada = value;
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

        #endregion

        #region Commands

        private ICommand _SendDemand;
        public ICommand SendDemand
        {
            get
            {

                if (_SendDemand == null)
                {

                    _SendDemand = new RelayCommand(
                        param => SendRateNegociationRequest(param),
                        param => true);
                }

                return _SendDemand;
            }
        }

        #endregion

        #region Methods

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            HasRatesErros = false;

            _codigoProduto = string.Empty;
            if (navegationParams_.ContainsKey("product") &&
                navegationParams_["product"] != null)
            {
                _codigoProduto = navegationParams_["product"].ToString();
            }
            else
            {
                ErrorMessage = "Código do cliente inválido";
                SetLoadingError();
                return;
            }

            LoadSolutionEstimatedDate(navegationParams_);

            if (LoadRatesNegociationMethod())
            {
                LoadReasons(navegationParams_);
            }
            else
            {
                ErrorMessage = "Código do cliente inválido";
                SetLoadingError();
                return;
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
                ErrorMessage = "Could not find the 'ListaMotivos' navegation parameter.";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
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
            getDefaultSLARequest.SubTipoDemanda = _codigoProduto;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
        }

        private bool LoadRatesNegociationMethod()
        {
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out _clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                SetLoadingError();
                return false;
            }

            if (string.IsNullOrEmpty(_codigoProduto))
            {
                ErrorMessage = "Código do produto inválido";
                SetLoadingError();
                return false;
            }

            //TODO Se Canal de Atendimento = Canal Expresso preencher ao invés de nome do Contato e telefone e celular preencher campos
            // de NomeAssessor e CodigoAssessor
            _nomeContato = GetCrmContextValue(Constants.CONTEXTOCRM_NOMECONTATO);

            if (string.IsNullOrEmpty(_nomeContato))
            {
                ErrorMessage = "Nome do Contato inválido";
                SetLoadingError();
                return false;
            }

            _telefone = GetCrmContextValue(Constants.CONTEXTOCRM_TELEFONE);
            if (string.IsNullOrEmpty(_telefone))
            {
                ErrorMessage = "Número de telefone inválido";
                SetLoadingError();
                return false;
            }

            _celular = GetCrmContextValue(Constants.CONTEXTOCRM_CELULAR);
            if (string.IsNullOrEmpty(_celular))
            {
                ErrorMessage = "Número de celular inválido";
                SetLoadingError();
                return false;
            }

            _ECNumber = GetCrmContextValue(Constants.CONTEXTOCRM_ACCOUNT);
            if (string.IsNullOrEmpty(_ECNumber))
            {
                ErrorMessage = "Número de estabelecimento inválido";
                SetLoadingError();
                return false;
            }

            _numeroProtocoloCRM = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO);
            if (string.IsNullOrEmpty(_numeroProtocoloCRM))
            {
                ErrorMessage = "Protocolo inválido";
                SetLoadingError();
                return false;
            }

            return true;
        }

        private void SendRateNegociationRequest(object param)
        {
            RateNegotiationRequestModel rateNegotiationRequest = new RateNegotiationRequestModel();
            rateNegotiationRequest.Request = new SolicitarNegociacaoTaxaRequest();

            decimal taxaDesejadaDecimal = new decimal();
            if (!decimal.TryParse(TaxaDesejada, out taxaDesejadaDecimal))
            {
                ErrorMessage = "*Taxa inserida para a parcela está fora do intervalo de valores permitidos";
                HasRatesErros = true;
                return;
            }

            if (taxaDesejadaDecimal <= 0)
            {
                ErrorMessage = "É necessário preencher a Taxa Desejada com um valor acima de zero";
                HasRatesErros = true;
                return;
            }

            if (SelectedReason == null)
            {
                ErrorMessage = "Por favor, selecionar um motivo.";
                HasRatesErros = true;
                return;
            }

            rateNegotiationRequest.Request.IdMotivo = (Guid)((Reason)SelectedReason).Id;
            rateNegotiationRequest.Request.CodigoCliente = _clientIdNumber;
            rateNegotiationRequest.Request.PercentualTaxaPropostaConcorrente = taxaDesejadaDecimal;
            rateNegotiationRequest.Request.CelularContato = _celular;
            rateNegotiationRequest.Request.CodigoProduto = _codigoProduto;
            rateNegotiationRequest.Request.NomeContato = _nomeContato;
            rateNegotiationRequest.Request.Protocolo = _numeroProtocoloCRM;
            rateNegotiationRequest.Request.TelefoneContato = _telefone;
            rateNegotiationRequest.Request.IdDemanda = DemandId;
            rateNegotiationRequest.Request.NomeAssessor = string.Empty;//TODO implementar regra de assessor e contato
            rateNegotiationRequest.Request.CodigoAssessor = string.Empty;//TOTO implementar regra de assessor e contato

            var executionState = rateNegotiationRequest.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {

                var paramsDic = new Dictionary<string, object>();

                if (rateNegotiationRequest.Response.StatusRetorno.Contains("Concluído"))
                {

                    var requestConclusionDate = "Solicitação efetivada online";
                    paramsDic.Add("Message", "Já está disponível ao cliente.");
                    paramsDic.Add("MessageDetail", requestConclusionDate);
                }
                else if (rateNegotiationRequest.Response.DataPrevistaConclusaoSolicitacao != null)
                {

                    var requestConclusionDate = "Data prevista para solução: " + rateNegotiationRequest.Response.DataPrevistaConclusaoSolicitacao.Value.ToString("dd/mm/yyyy");
                    paramsDic.Add("Message", "Solicitação aberta com Sucesso.");
                    paramsDic.Add("MessageDetail", requestConclusionDate);
                }
                else
                {
                    var requestConclusionDate = "A previsão final para solução está indisponível.";
                    paramsDic.Add("Message", "Solicitação aberta");
                    paramsDic.Add("MessageDetail", requestConclusionDate);

                }

                Navegate("ProductRequestSuccess", "RequestsRegion", "", paramsDic);
            }
            else
            {
                ErrorMessage = rateNegotiationRequest.Response.ErrorMessage;
                var paramsDic = new Dictionary<string, object>();
                paramsDic.Add("Message", "Não foi possível realizar a Solicitação.");
                paramsDic.Add("MessageDetail", ErrorMessage);
                Navegate("ProductRequestError", "RequestsRegion", "", paramsDic);
            }
        }

        private void SetLoadingError()
        {
            ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
            ViewState = ViewStates.LoadingError;
            _logger.LogError(ErrorMessage);
        }

        public class Reason
        {
            public Guid Id { get; set; }
            public string NomeMotivo { get; set; }
        }

        #endregion
    }
}
