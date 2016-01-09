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
    class EnabledTypedSaleViewModel : ViewModelBase
    {

      
        #region Constants

        private const string INDICACAOOPERACAO = "H";
        private const string INDICAACAO = "S";
        private const string CANAL = "Telefone";
        private const string CASETYPE = "Solicitação";
        private const string ORIGEM = "Dynamics CRM";
       

        #endregion

        #region Fields

        private List<ConsultarProdutoHabilitadoClienteProdutoDTO> _clientProducts;
        private ObservableCollection<GridProduct> _listEnabledTypedSaleItens;
        private bool _hasInputError;

        private Logger _logger = Logger.LoggerFor<EnabledTypedSaleViewModel>();

        #endregion

        #region Properties

        private Guid DemandId
        { get; set; }

        private string CodigoProduto
        {
            get;
            set;
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

        public ObservableCollection<GridProduct> ListEnabledTypedSaleItens
        {
            get { return _listEnabledTypedSaleItens; }
            set
            {
                if (_listEnabledTypedSaleItens == value)
                    return;
                _listEnabledTypedSaleItens = value;
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

        private ICommand _SendEnabledTypedSaleCommand;

        /// <summary>
        /// Command of Button Send
        /// </summary>
        public ICommand SendEnabledTypedSaleCommand
        {
            get
            {

                if (_SendEnabledTypedSaleCommand == null)
                {

                    _SendEnabledTypedSaleCommand = new RelayCommand(
                        param => SendEnabledTypedSale(param),
                        param => true);
                }

                return _SendEnabledTypedSaleCommand;
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
            if (navegationParams_ != null && navegationParams_.ContainsKey("products") && navegationParams_["products"] != null)
            {
                ClientProducts = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();
                ClientProducts = (List<ConsultarProdutoHabilitadoClienteProdutoDTO>)navegationParams_["products"];
                GetListEnabledTypedSale(ClientProducts);
            }
            else
            {
                ErrorMessage = "Erro ao carregar Lista de Produtos";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

            LoadReasons(navegationParams_);

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
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
            }
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
        }

        /// <summary>
        /// Method to Enable sale typed
        /// </summary>
        /// <param name="param"></param>
        private void SendEnabledTypedSale(object param)
        {
            HasInputError = !AtLeastOneValueValid();

            if (HasInputError)
            {
                ErrorMessage = "É necessário selecionar ao menos um produto.";
                SetActionError();
                return;
            }

            if (SelectedReason == null)
            {
                ErrorMessage = "Por favor, selecionar um motivo.";
                SetActionError();
                HasInputError = true;
                return;
            }

            if (GetListIsChecked() == null || GetListIsChecked().Count <= 0)
            {
                ErrorMessage = "É necessário selecionar ao menos um produto.";
                SetActionError();
                HasInputError = true;
                return;
            }

            EnabledTypedSaleModel enableTypedSale = new EnabledTypedSaleModel();
            enableTypedSale.Request = new HabilitarDesabilitarVendaDigitadaRequest();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                SetActionError();
                return;
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

            string _protocolo = "";
            if ((string.IsNullOrEmpty(GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO))))
            {
                ErrorMessage = "Protocolo inválido";
                SetActionError();
                return;
            }
            else
                _protocolo = GetCrmContextValue(Constants.CONTEXTOCRM_PROTOCOLO);

            enableTypedSale.Request.CodigoCliente = clientIdNumber;
            enableTypedSale.Request.IndicaOperacao = INDICACAOOPERACAO;
            enableTypedSale.Request.IdDemanda = DemandId;
            enableTypedSale.Request.CanalDeAtendimento = CANAL;
            enableTypedSale.Request.CaseType = CASETYPE;
            enableTypedSale.Request.Cliente = _account;
            enableTypedSale.Request.DadosVendaDigitada = GetListIsChecked();
            enableTypedSale.Request.Origem = ORIGEM;
            enableTypedSale.Request.Protocolo = _protocolo;
            var executionState = enableTypedSale.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var paramsDic = new Dictionary<string, object>();

                if (enableTypedSale.Response.DataPrevistaConclusaoSolicitacao == null)
                {
                    paramsDic.Add("Message", "Solicitação Aberta");
                    paramsDic.Add("MessageDetail", "A previsão final para solução está indisponível");
                }
                else
                {
                    paramsDic.Add("Message", "Solicitação Aberta com Sucesso");
                    paramsDic.Add("MessageDetail", String.Format("{0}{1:dd/MM/yyyy}", "Data prevista para solução: ", enableTypedSale.Response.DataPrevistaConclusaoSolicitacao));
                }

                Navegate("ProductRequestSuccess", "RequestsRegion", "", paramsDic);
            }
            else 
            {
                ErrorMessage = enableTypedSale.Response.ErrorMessage;
                var paramsDic = new Dictionary<string, object>();
                paramsDic.Add("Message", "Não foi possível realizar a Solicitação.");
                paramsDic.Add("MessageDetail", ErrorMessage);
                Navegate("ProductRequestError", "RequestsRegion", "", paramsDic);
            }
        }

        /// <summary>
        /// Retrieve only enabled products from last screen
        /// </summary>
        /// <param name="navegationParams_"></param>
        private void GetListEnabledTypedSale(List<ConsultarProdutoHabilitadoClienteProdutoDTO> _products)
        {
            ObservableCollection<GridProduct> list = new ObservableCollection<GridProduct>();

            ListEnabledTypedSaleItens = new ObservableCollection<GridProduct>();
            var listProducts = _products.Where(x => x.IndicadorVendaDigitada == true && x.IndicadorVendaDigitadaHabilitada==false);

            foreach (var item in listProducts)
            {
                GridProduct product = new GridProduct();
                product.CodigoProduto = item.CodigoProduto;
                product.IndicaAcao = INDICAACAO;
                product.LineChecked = true;
                product.NomeBandeira = item.NomeBandeira;
                product.NomeProduto = item.NomeProduto;
                product.CodigoBandeira = item.CodigoBandeira;

                list.Add(product);
            }
            ListEnabledTypedSaleItens = list;
        }

        /// <summary>
        /// Get list of items checked
        /// </summary>
        /// <returns></returns>
        private List<HabilitarDesabilitarVendaDigitadaDTO> GetListIsChecked()
        {
            List<HabilitarDesabilitarVendaDigitadaDTO> ListChecked = new List<HabilitarDesabilitarVendaDigitadaDTO>();

            var list = ListEnabledTypedSaleItens.Where(x => x.LineChecked == true);

            foreach (var item in list)
            {
                HabilitarDesabilitarVendaDigitadaDTO habilitarDesabilitar = new HabilitarDesabilitarVendaDigitadaDTO();
                habilitarDesabilitar.CodigoProduto = item.CodigoProduto;
                habilitarDesabilitar.IndicaAcao = item.IndicaAcao;

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

            foreach (var item in ListEnabledTypedSaleItens)
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

