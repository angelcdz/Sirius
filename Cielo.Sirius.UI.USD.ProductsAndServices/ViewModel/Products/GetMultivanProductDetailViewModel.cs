using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class GetMultivanProductDetailViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

        #endregion

        string _codigoProduto;
        string _tipoProduto;

        private Logger _logger = Logger.LoggerFor<GetMultivanProductDetailViewModel>();

        private IEnumerable<Response> _multivanProductDetail;
        public IEnumerable<Response> MultivanProductDetail
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

        bool _apresentarMultivan;
        public bool ApresentarMultivan
        {
            get { return _apresentarMultivan; }
            set
            {
                if (_apresentarMultivan == value)
                    return;
                _apresentarMultivan = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navegationParams_"></param>
        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            string _tipoLiquidacao = null;
            if (navegationParams_ != null && navegationParams_.ContainsKey("product") && navegationParams_.ContainsKey("productType") && navegationParams_.ContainsKey("tipoLiquidacao"))
            {
                _codigoProduto = navegationParams_["product"] as string;
                _tipoProduto = navegationParams_["productType"] as string;
                _tipoLiquidacao = navegationParams_["tipoLiquidacao"] as string;
                if (_tipoLiquidacao != null && _tipoLiquidacao.ToUpperInvariant() == Constants.TIPO_COBRANCA_MULTIVAN)
                {
                    ApresentarMultivan = true;
                    LoadMultivanProductDetail();
                }
            }
            base.PreInitialize(navegationParams_);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadMultivanProductDetail()
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

            var multivanProductDetailModel = new GetMultivanProductDetailModel();

            ConsultarDetalheProdutoMultivanContratadoClienteRequest getMultivanProductDetailRequests = new ConsultarDetalheProdutoMultivanContratadoClienteRequest();
            getMultivanProductDetailRequests.CodigoProduto = _codigoProduto;
            getMultivanProductDetailRequests.CodigoCliente = clientIdNumber;
            multivanProductDetailModel.Request = getMultivanProductDetailRequests;

            var executionState = multivanProductDetailModel.Execute();
            var response = multivanProductDetailModel.Response;

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                ViewState = ViewStates.Default;

                List<Response> multivanProductDetails = new List<Response>();
                foreach (var responseDetalheMultivan in response.DetalhesMultivan)
                {
                    multivanProductDetails.Add(new Response()
                    {
                        NomeEmpresa = string.IsNullOrEmpty(responseDetalheMultivan.NomeEmpresa) ? "---" : responseDetalheMultivan.NomeEmpresa,
                        NumeroCadastroEmpresa = string.IsNullOrEmpty(responseDetalheMultivan.NumeroCadastroEmpresa) ? "---" : responseDetalheMultivan.NumeroCadastroEmpresa,
                        InicioVigencia = (responseDetalheMultivan.InicioVigencia == null) ? "---" : ((DateTime)(responseDetalheMultivan.InicioVigencia)).ToString("dd/MM/yyyy"),
                        FimVigencia = (responseDetalheMultivan.FimVigencia == null) ? "---" : ((DateTime)(responseDetalheMultivan.FimVigencia)).ToString("dd/MM/yyyy")
                    });
                }

                MultivanProductDetail = multivanProductDetails;
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

        /// <summary>
        /// 
        /// </summary>
        public class Response
        {
            public string NomeEmpresa { get; set; }
            public string NumeroCadastroEmpresa { get; set; }
            public string InicioVigencia { get; set; }
            public string FimVigencia { get; set; }
        }
    }
}
