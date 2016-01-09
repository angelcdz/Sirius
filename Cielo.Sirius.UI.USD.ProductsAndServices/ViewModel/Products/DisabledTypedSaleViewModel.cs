using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class DisabledTypedSaleViewModel : ViewModelBase
    {
        private Logger _logger = Logger.LoggerFor<DisabledTypedSaleViewModel>();

        #region Properties

        private const string INDICACAOOPERACAO = "D";
        private const string INDICAACAO = "N";
        private const string CANAL = "Telefone";
        private const string CASETYPE = "Solicitação";
        private const string ARVOREASSUNTO = "Desabilitação de Venda Digitada";
        private const string ORIGEM = "Dynamics CRM";

        private List<ConsultarProdutoHabilitadoClienteProdutoDTO> _clientProducts;
        private ObservableCollection<GridProduct> _listDisabledTypedSaleItens;
        private bool _hasInputError;

        private string CodigoProduto
        {
            get;
            set;
        }
        
        private Guid DemandId
        { get; set; }

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

        public ObservableCollection<GridProduct> ListDisabledTypedSaleItens
        {
            get { return _listDisabledTypedSaleItens; }
            set
            {
                if (_listDisabledTypedSaleItens == value)
                    return;
                _listDisabledTypedSaleItens = value;
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

        public List<ConsultarProdutoHabilitadoClienteProdutoDTO> ClientProducts
        {
            get { return _clientProducts; }
            set { _clientProducts = value; }
        }

        #endregion

        #region Command

        private ICommand _SendDisabledTypedSaleCommand;

        /// <summary>
        /// Command of Button Send
        /// </summary>
        public ICommand SendDisabledTypedSaleCommand
        {
            get
            {

                if (_SendDisabledTypedSaleCommand == null)
                {

                    _SendDisabledTypedSaleCommand = new RelayCommand(
                        param => SendDisabledTypedSale(param),
                        param => true);
                }

                return _SendDisabledTypedSaleCommand;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializing screen
        /// </summary>
        /// <param name="navegationParams_"></param>
        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            LoadSolutionEstimatedDate(navegationParams_);
            if (navegationParams_["products"] != null)
            {
                ClientProducts = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();
                ClientProducts = (List<ConsultarProdutoHabilitadoClienteProdutoDTO>)navegationParams_["products"];
                GetListDisabledTypedSale(ClientProducts);
            }
            else
            {
                ErrorMessage = "Could not find the 'products' navegation parameter.";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

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

            if (navegationParams_ != null
                && navegationParams_.ContainsKey("demandId")
                && navegationParams_["demandId"] != null
                && navegationParams_["demandId"].GetType() == typeof(Guid))
            {
                DemandId = (Guid)navegationParams_["demandId"];
            }

            base.PreInitialize(navegationParams_);
        }

        private void LoadSolutionEstimatedDate(Dictionary<string, object> navegationParams_)
        {
            CodigoProduto = string.Empty;
            if (navegationParams_.ContainsKey("product") &&
                navegationParams_["product"] != null)
            {
                CodigoProduto = navegationParams_["product"].ToString();
            }

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
            getDefaultSLARequest.SubTipoDemanda = CodigoProduto;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
            else
            {
                //This is a mapped error and does not blocks the execution
                SolutionEstimatedDate = "Data prevista para solução: SLA indisponível.";
            }
        }

        /// <summary>
        /// Method to disable sale typed
        /// </summary>
        /// <param name="param"></param>
        private void SendDisabledTypedSale(object param)
        {
            HasInputError = !AtLeastOneValueValid();

            if (HasInputError)
            {
                ErrorMessage = "É necessário selecionar ao menos um produto.";
                return;
            }

            if (SelectedReason == null)
            {
                HasInputError = true;
                ErrorMessage = "Por favor, selecionar um motivo.";
                return;
            }

            DisabledTypedSaleModel disableTypedSale = new DisabledTypedSaleModel();
            disableTypedSale.Request = new HabilitarDesabilitarVendaDigitadaRequest();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                SetActionError();
                return;
            }

            string _ilhaDeAtendimento = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO))))
            {
                ErrorMessage = "Ilha de atendimento inválida";
                SetActionError();
                return;
            }
            else
                _ilhaDeAtendimento = GetCrmContextValue(Constants.CONTEXTOCRM_ILHADEATENDIMENTO);


            if (GetListIsChecked() == null || GetListIsChecked().Count <= 0)
            {
                ErrorMessage = "É necessário selecionar ao menos um produto.";
                SetActionError();
                return;
            }
            string _tituloDaOcorrencia = "";
            //TODO Contador de Ocorrências (IDC)
            string _contador = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO))))
            {
                ErrorMessage = "Protocolo inválido";
                SetActionError();
                return;
            }
            else
            {
                _tituloDaOcorrencia = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO) + _contador;
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
           
            string _protocolo = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO))))
            {
                ErrorMessage = "Protocolo inválido";
                SetActionError();
                return;
            }
            else
                _protocolo = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO);

            disableTypedSale.Request.CodigoCliente = clientIdNumber;
            disableTypedSale.Request.IndicaOperacao = INDICACAOOPERACAO;
            disableTypedSale.Request.TituloDaOcorrencia = _tituloDaOcorrencia;
            disableTypedSale.Request.CanalDeAtendimento = CANAL;
            disableTypedSale.Request.CaseType = CASETYPE;
            disableTypedSale.Request.ArvoreDeAssunto = ARVOREASSUNTO;
            disableTypedSale.Request.Cliente = _account;
            disableTypedSale.Request.ParentCaseId = _parentCaseId;
            disableTypedSale.Request.IlhaDeAtendimento = _ilhaDeAtendimento;
            disableTypedSale.Request.IdDemanda = DemandId;
            disableTypedSale.Request.IdMotivo = (Guid)((Reason)SelectedReason).Id;
            disableTypedSale.Request.DadosVendaDigitada = GetListIsChecked();
            disableTypedSale.Request.Origem = ORIGEM;
            disableTypedSale.Request.Protocolo = _protocolo;
           
            var executionState = disableTypedSale.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var paramsDic = new Dictionary<string, object>();

                if(disableTypedSale.Response.DataPrevistaConclusaoSolicitacao==null)
                {
                    paramsDic.Add("Message", "Solicitação Aberta");
                    paramsDic.Add("MessageDetail", "A previsão final para solução está indisponível");
                }
                else
                {
                    paramsDic.Add("Message", "Solicitação Aberta com Sucesso");
                    paramsDic.Add("MessageDetail",String.Format("{0}{1:dd/MM/yyyy}","Data prevista para solução: ", disableTypedSale.Response.DataPrevistaConclusaoSolicitacao));
                }
              
                Navegate("ProductRequestSuccess", "RequestsRegion", "", paramsDic);
            }
            else if (executionState == ExecutionStatus.BusinessError)
            {
                ErrorMessage = disableTypedSale.Response.ErrorMessage;
                var paramsDic = new Dictionary<string, object>();
                paramsDic.Add("Message", "Não foi possível realizar a Solicitação.");
                paramsDic.Add("MessageDetail", ErrorMessage);
                Navegate("ProductRequestError", "RequestsRegion", "", paramsDic);
            }
            else
            {
                ErrorMessage = disableTypedSale.ErrorMessage ?? "Null or empty response of 'DisabledTypedSaleModel'";
                SetActionError();
            }
        }

        /// <summary>
        /// Retrieve only enabled products from last screen
        /// </summary>
        /// <param name="navegationParams_"></param>
        private void GetListDisabledTypedSale(List<ConsultarProdutoHabilitadoClienteProdutoDTO> _products)
        {
            ObservableCollection<GridProduct> list = new ObservableCollection<GridProduct>();

            ListDisabledTypedSaleItens = new ObservableCollection<GridProduct>();
            var listProducts = _products.Where(x => x.IndicadorVendaDigitada == true && x.IndicadorVendaDigitadaHabilitada==true);

            foreach (var item in listProducts)
            {
                GridProduct product = new GridProduct();
                product.CodigoProduto = item.CodigoProduto;
                product.IndicaAcao = INDICAACAO;
                product.LineChecked = false;
                product.NomeBandeira = item.NomeBandeira;
                product.NomeProduto = item.NomeProduto;
                product.CodigoBandeira = item.CodigoBandeira;
                product.LineChecked = true;

                list.Add(product);
            }
            ListDisabledTypedSaleItens = list;
        }

        /// <summary>
        /// Get list of items checked
        /// </summary>
        /// <returns></returns>
        private List<HabilitarDesabilitarVendaDigitadaDTO> GetListIsChecked()
        {
            List<HabilitarDesabilitarVendaDigitadaDTO> ListChecked = new List<HabilitarDesabilitarVendaDigitadaDTO>();

            var list = ListDisabledTypedSaleItens.Where(x => x.LineChecked == true);

            foreach (var item in list)
            {
                HabilitarDesabilitarVendaDigitadaDTO habilitarDesabilitar = new HabilitarDesabilitarVendaDigitadaDTO();
                habilitarDesabilitar.CodigoProduto = item.CodigoProduto;
                habilitarDesabilitar.IndicaAcao = item.IndicaAcao;
                habilitarDesabilitar.NomeProduto = item.NomeProduto;

                ListChecked.Add(habilitarDesabilitar);
            }

            return ListChecked;
        }

        /// <summary>
        /// Verify if at least one item of products to disable was selected
        /// </summary>
        private bool AtLeastOneValueValid()
        {
            bool _value = false;

            foreach (var item in ListDisabledTypedSaleItens)
            {
                _value = item.LineChecked;
                if (_value == true)
                    break;
            }

            return _value;
        }

        private void SetActionError()
        {
            ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
            ViewState = ViewStates.ActionError;
            _logger.LogError(ErrorMessage);
        }


        #endregion

        #region Other Classes

        public class Reason
        {
            public Guid Id { get; set; }
            public string NomeMotivo { get; set; }

        }

        /// <summary>
        /// Class of Grid of Products
        /// </summary>
        public class GridProduct
        {
            /// <summary>
            /// NomeBandeira
            /// </summary>
            public string NomeBandeira { get; set; }
            /// <summary>
            /// NomeProduto
            /// </summary>
            public string NomeProduto { get; set; }

            /// <summary>
            /// IsSelected
            /// </summary>
            public bool LineChecked { get; set; }
            /// <summary>
            /// IndicaAcao
            /// </summary>
            public string IndicaAcao { get; set; }

            /// <summary>
            /// Codigo Produto
            /// </summary>
            public string CodigoProduto { get; set; }

            /// <summary>
            /// Codigo Bandeira
            /// </summary>
            public string CodigoBandeira { get; set; }
        }

        #endregion
    }

}

