using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Products
{
    public class DisableProductViewModel : ViewModelBase
    {
        #region Atributes

        private ConsultarProdutoHabilitadoClienteProdutoDTO produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
        private ICommand _disableProductCommand;
        private string _informationMessage;
        private bool _tableCompanyNameVisibility;
        private bool _textboxReasonVisibility;
        private bool _notLastAleloVisibility;
        private IEnumerable<Reason> _reasonList;
        private object _selectedReason;
        private string _flagCode;
        private string _reasonDescription;
        private string _defaultSLADate;
        private bool _hasInputError;

        private Logger _logger = Logger.LoggerFor<DisableProductViewModel>();

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

        /// <summary>
        /// Command of Button Send
        /// </summary>
        public ICommand DisableProductCommand
        {
            get
            {
                if (_disableProductCommand == null)
                {

                    _disableProductCommand = new RelayCommand(
                        param => SendDisableProduct(param),
                        param => true);
                }

                return _disableProductCommand;
            }
        }

        private string _requestorPhone;
        public string RequestorPhone
        {
            get
            {
                return _requestorPhone;
            }
            set
            {
                _requestorPhone = value;
                OnPropertyChanged();
            }
        }
        private string _requestorName;

        public string RequestorName
        {
            get
            {
                return _requestorName;
            }
            set
            {
                _requestorName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Lista de produtos habilitados do cliente
        /// </summary>
        public List<ConsultarProdutoHabilitadoClienteProdutoDTO> ClientProducts
        {
            get;
            set;
        }

        /// <summary>
        /// Information Message
        /// </summary>
        public string InformationMessage
        {
            get
            {
                return _informationMessage;
            }
            set
            {
                _informationMessage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// change visibility for company table
        /// </summary>
        public bool TableCompanyNameVisibility
        {
            get
            {
                return _tableCompanyNameVisibility;
            }
            set
            {
                _tableCompanyNameVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// change visibility for reason textbox
        /// </summary>
        public bool TextboxReasonVisibility
        {
            get
            {
                return _textboxReasonVisibility;
            }
            set
            {
                _textboxReasonVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// change visibility for contact textbox
        /// </summary>
        public bool NotLastAleloVisibility
        {
            get
            {
                return _notLastAleloVisibility;
            }
            set
            {
                _notLastAleloVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Multivan Detail
        /// </summary>
        private IEnumerable<ConsultarDetalheProdutoMultivanContratadoClienteDTO> _multivanProductDetail;
        public IEnumerable<ConsultarDetalheProdutoMultivanContratadoClienteDTO> MultivanProductDetail
        {
            get { return _multivanProductDetail; }
            set
            {
                if (_multivanProductDetail == value)
                    return;
                _multivanProductDetail = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Product code that was received from previous screen
        /// </summary>
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Reason list that fill combobox.
        /// </summary>

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

        /// <summary>
        /// Selected item from reason combobox
        /// </summary>
        public object SelectedReason
        {
            get
            {
                return _selectedReason;
            }
            set
            {
                _selectedReason = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Reason description from textbox for Alelo products
        /// </summary>
        public string ReasonDescription
        {
            get
            {
                return _reasonDescription;
            }
            set
            {
                _reasonDescription = value;
                OnPropertyChanged("ReasonDescription");
            }
        }

        /// <summary>
        /// Flag code
        /// </summary>
        public string FlagCode
        {
            get
            {
                return _flagCode;
            }
            set
            {
                _flagCode = value;
                OnPropertyChanged("FlagCode");
            }
        }

        /// <summary>
        /// DemandId
        /// </summary>
        private Guid DemandId
        { get; set; }

        /// <summary>
        /// Default SLA Date
        /// </summary>
        public string DefaultSLADate
        {
            get
            {
                return _defaultSLADate;
            }
            set
            {
                _defaultSLADate = value;
                OnPropertyChanged("DefaultSLADate");
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

        #endregion

        #region Base Methods - Init

        /// <summary>
        /// Method called before screen renderization
        /// </summary>
        /// <param name="navegationParams_"></param>
        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            FlagCode = String.Empty;
            ProductCode = String.Empty;
            DefaultSLADate = String.Empty;
            TextboxReasonVisibility = false;
            TableCompanyNameVisibility = false;

            ClientProducts = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();
            if (navegationParams_ != null)
            {
                if (!ValidadeNavigationParams(navegationParams_))
                    return;
            }
            LoadSolutionEstimatedDate(navegationParams_);

            NotLastAleloVisibility = true;
            RequestorName = GetCrmContextValue(Constants.CONTEXTOCRM_NOMECONTATO);
            RequestorPhone = GetCrmContextValue(Constants.CONTEXTOCRM_TELEFONE);

            InformationMessage = "Confirma a desabilitação do Produto? ";

            if (IsAlelo())
            {
                TextboxReasonVisibility = true;

                if (VerifyUniqueProductTypeAlelo())
                {
                    NotLastAleloVisibility = false;
                    InformationMessage = "Todos os produtos Alelo do cliente serão desabilitados. Para a reabilitação será necessário um novo processo de credenciamento com a bandeira. Confirmar com o cliente se ele deseja mesmo continuar.";
                }
            }



            if (!IsAlelo() && !IsMultivan())
            {
                InformationMessage = "Confirma a desabilitação do Produto? ";
            }

            if (ExistsReasonList(navegationParams_))
            {
                FillReasonDropDownList(navegationParams_);
            }
            else
            {
                ErrorMessage = "Could not find the 'ListaMotivos' navegation parameter.";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

            base.PreInitialize(navegationParams_);
        }

        private void LoadSolutionEstimatedDate(Dictionary<string, object> navegationParams_)
        {
            ProductCode = string.Empty;
            if (navegationParams_.ContainsKey("product") &&
                navegationParams_["product"] != null)
            {
                ProductCode = navegationParams_["product"].ToString();
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
            getDefaultSLARequest.SubTipoDemanda = ProductCode;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
        }

        private void ListMultivanCompanies()
        {
            //Procura na lista de todos os produto qual produto foi selecionado(linq)
            if (IsMultivan())
            {

                ConsultarDetalheProdutoMultivanContratadoClienteRequest requestMultivan = new ConsultarDetalheProdutoMultivanContratadoClienteRequest();

                requestMultivan.CodigoProduto = ProductCode;

                long clientIdNumber = new long();
                if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
                {
                    ErrorMessage = "Código do cliente inválido.";
                    _logger.LogError(ErrorMessage);
                    return;
                }
                requestMultivan.CodigoCliente = clientIdNumber;

                var getMultivanProductDetailModel = new GetMultivanProductDetailModel();
                getMultivanProductDetailModel.Request = requestMultivan;

                var executionState = getMultivanProductDetailModel.Execute();


                if (executionState.Equals(ExecutionStatus.BusinessError) || executionState.Equals(ExecutionStatus.TechnicalError) || executionState.Equals(ExecutionStatus.NotExecuted))
                {
                    var paramsDic = new Dictionary<string, object>();
                    paramsDic.Add("Message", "Não foi possível realizar a Solicitação.");
                    paramsDic.Add("MessageDetail", "Erro ao consultar informações de empresas que transacionam Elo. Informar ao cliente para tentar novamente mais tarde");
                    Navegate("ProductRequestError", "RequestsRegion", "", paramsDic);
                    return;
                }
                else
                {
                    TableCompanyNameVisibility = true;
                    MultivanProductDetail = getMultivanProductDetailModel.Response.DetalhesMultivan;
                    InformationMessage = "Cliente transaciona ELO com outras empresas. Deseja continuar?";
                }

            }
        }

        public override void PosInitialize(Dictionary<string, object> navegationParams_)
        {
            //This datagrid is commented, because this functionality was dropped from the Product Backlog Item
            //ListMultivanCompanies();
            base.PosInitialize(navegationParams_);
        }

        #endregion

        #region AuxilarMethods
        private bool ExistsReasonList(Dictionary<string, object> navegationParams_)
        {
            return navegationParams_ != null && navegationParams_.ContainsKey("ListaMotivos") && navegationParams_["ListaMotivos"] != null && navegationParams_["ListaMotivos"] as List<GetRequestReasonDTO> != null;
        }

        private void FillReasonDropDownList(Dictionary<string, object> navegationParams_)
        {
            List<GetRequestReasonDTO> listaReasonDTO = (List<GetRequestReasonDTO>)navegationParams_["ListaMotivos"];

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

        private bool ValidadeNavigationParams(Dictionary<string, object> navegationParams_)
        {

            if (navegationParams_.ContainsKey("products") &&
                navegationParams_["products"] != null)
            {
                ClientProducts = (List<ConsultarProdutoHabilitadoClienteProdutoDTO>)navegationParams_["products"];
            }

            if (navegationParams_.ContainsKey("product") &&
                navegationParams_["product"] != null)
            {
                ProductCode = navegationParams_["product"].ToString();
            }

            if (navegationParams_.ContainsKey("flagCode") && navegationParams_["flagCode"] != null)
            {
                FlagCode = navegationParams_["flagCode"].ToString();
            }

            if (navegationParams_.ContainsKey("demandId") &&
                navegationParams_["demandId"] != null &&
                navegationParams_["demandId"].GetType() == typeof(Guid))
            {
                DemandId = (Guid)navegationParams_["demandId"];
            }

            if (navegationParams_.ContainsKey("defaultSlaDate") &&
                navegationParams_["defaultSlaDate"] != null)
            {
                DefaultSLADate = navegationParams_["defaultSlaDate"].ToString();
            }


            produto = ClientProducts.Where(clientProduct => clientProduct.CodigoProduto == ProductCode).FirstOrDefault();
            if (produto == null)
            {
                ErrorMessage = "Produto não encontrado na lista de produtos";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return false;
            }
            return true;
        }

        private bool IsAlelo()
        {
            return produto.CodigoBandeira.Equals("2") || produto.CodigoBandeira.Equals("3");
        }

        // TODO The flagCode isnot comming by navparam, check if is really to use the property by product
        //private bool IsAlelo()
        //{
        //    //return FlagCode.Equals("2") || FlagCode.Equals("3");
        //}

        private bool IsMultivan()
        {
            return produto != null && produto.NomeTipoLiquidacao != null && (produto.NomeTipoLiquidacao.Equals("VAN") || produto.NomeTipoLiquidacao.Equals("ADQUIRENCIA") || produto.NomeTipoLiquidacao.Equals("MULTIVAN"));
        }


        #endregion

        #region Methods
        /// <summary>
        /// Method to disable sale typed
        /// </summary>
        /// <param name="param"></param>
        private void SendDisableProduct(object param)
        {
            if (TextboxReasonVisibility)
            {
                if (string.IsNullOrEmpty(ReasonDescription))
                {
                    HasInputError = true;
                    ErrorMessage = "É necessário informar o motivo para desabilitação do produto.";
                    return;
                }
            }

            if (SelectedReason == null)
            {
                HasInputError = true;
                ErrorMessage = "Selecione um motivo para desabilitar o produto";
                return;
            }

            DisableProductModel desabilitarProduto = new DisableProductModel();
            desabilitarProduto.Request = new DesabilitarProdutoRequest();

            desabilitarProduto.Request.Protocolo = GetCrmContextValue(Cielo.Sirius.Contracts.Constants.CONTEXTOCRM_PROTOCOLO);

            long CodigoCliente = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out CodigoCliente))
            {
                ErrorMessage = "Código do cliente inválido.";
                _logger.LogError(ErrorMessage);
                return;
            }

            int codigoProduto;
            if (!int.TryParse(ProductCode, out codigoProduto))
            {
                ErrorMessage = "Código do produto inválido.";
                _logger.LogError(ErrorMessage);
                return;
            }
            desabilitarProduto.Request.CodigoProduto = codigoProduto;
            desabilitarProduto.Request.CodigoCliente = CodigoCliente;
            desabilitarProduto.Request.NomeSolicitante = RequestorName;
            desabilitarProduto.Request.Origem = "Dynamics CRM";
            desabilitarProduto.Request.TelefoneSolicitante = RequestorPhone;
            desabilitarProduto.Request.CodigoEmpresa = "123456";
            if (IsAlelo())
            {
                desabilitarProduto.Request.MotivoSolicitacao = ReasonDescription;
            }
            else
            {
                desabilitarProduto.Request.MotivoSolicitacao = "Nova demanda";
            }
            desabilitarProduto.Request.DemandId = DemandId;
            desabilitarProduto.Request.RequestReasonId = ((Reason)SelectedReason).Id;
            desabilitarProduto.Request.IlhaDeAtendimento = GetCrmContextValue(Cielo.Sirius.Contracts.Constants.CONTEXTOCRM_ILHADEATENDIMENTO);
            desabilitarProduto.Request.ParentCaseId = GetCrmContextValue(Cielo.Sirius.Contracts.Constants.CONTEXTOCRM_PARENTCASEID);

            // The CRM action will fill this properties automatically 
            //desabilitarProduto.Request.TituloDaOcorrencia = GetCrmContextValue(Cielo.Sirius.Contracts.Constants.CONTEXTOCRM_TITULOCORRENCIA);
            //desabilitarProduto.Request.CanalDeAtendimento = "Telefone";
            //desabilitarProduto.Request.Cliente = GetCrmContextValue(Constants.CONTEXTOCRM_ACCOUNT);
            //desabilitarProduto.Request.CaseType = "Solicitação";
            //desabilitarProduto.Request.ArvoreDeAssunto = "Desabilitar Produtos";

            var executionState = desabilitarProduto.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var navParams = new Dictionary<string, object>();
                string message = "Solicitação aberta";
                string messageDetail = "A previsão final para disposição está indisponível";
                if (desabilitarProduto.Response != null
                    && desabilitarProduto.Response.SolicitacaoCentralAtendimento != null
                    && desabilitarProduto.Response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao != null)
                {
                    message = "Solicitação aberta com sucesso";
                    messageDetail = string.Format("Data prevista para solução: {0}.",
                        ((DateTime)desabilitarProduto.Response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao).ToString("dd/MM/yyyy"));
                }
                navParams.Add("Message", message);
                navParams.Add("MessageDetail", messageDetail);
                Navegate("ServiceRequestSuccess", "RequestsRegion", "", navParams);
            }
            else
            {
                ErrorMessage = desabilitarProduto.Response != null ?
                  desabilitarProduto.Response.ErrorMessage : "";
                _logger.LogError(String.IsNullOrWhiteSpace(ErrorMessage) ? "Faild while executiong 'DisableProductModel'." : ErrorMessage);
                var navParams = new Dictionary<string, object>();
                navParams.Add("Message", "Não foi possível realizar a solicitação");
                navParams.Add("MessageDetail", ErrorMessage);
                Navegate("ServiceRequestError", "RequestsRegion", "", navParams);
            }

        }

        /// <summary>
        /// Verify if selected product is the last one Alelo type
        /// </summary>
        private bool VerifyUniqueProductTypeAlelo()
        {
            bool isValid = false;
            if (ClientProducts != null && ClientProducts.Count > 0)
            {
                //Query to bring only Alelo products
                var listaProdutos = ClientProducts.FindAll(produto => (produto.CodigoBandeira.Equals("2") || produto.CodigoBandeira.Equals("3")));
                // 1- Verify if product list is not null; 2 - Verify if query result list has only one record; 3 - Verify if the selected product is that only one in query result list.
                isValid = (listaProdutos != null && listaProdutos.Count.Equals(1) && listaProdutos[0].CodigoProduto.Equals(ProductCode));
            }
            return isValid;
        }

        public class Reason
        {
            public Guid Id { get; set; }
            public string NomeMotivo { get; set; }
        }

        #endregion

    }

}