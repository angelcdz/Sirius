using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
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
    class NonElegibleProductDetailsViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

        #endregion

        #region Atributes

        string _codigoProduto;
        string _tipoProduto;
        private NonElegibleProductDetailsModel _producsDetailsModel;

        private Logger _logger = Logger.LoggerFor<NonElegibleProductDetailsViewModel>();

        #endregion

        #region Properties

        private Produto _product;
        public Produto Product
        {
            get { return _product; }
            set
            {
                if (_product == value)
                    return;
                _product = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<string> _demandList;
        public IEnumerable<string> DemandList
        {
            get { return _demandList; }
            set
            {
                if (_demandList == value)
                    return;
                _demandList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            _codigoProduto = navegationParams_["product"] as string;
            _tipoProduto = navegationParams_["productType"] as string;

            if (LoadEnabledProductDetails())
            {
                CheckNonElegibleProductDetails();
            }

            base.PreInitialize(navegationParams_);
        }

        private bool LoadEnabledProductDetails()
        {
            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return false;
            }

            _producsDetailsModel = new NonElegibleProductDetailsModel();

            ConsultarDetalheProdutoNaoElegivelClienteRequest requestNonElegibleProductDetails = new ConsultarDetalheProdutoNaoElegivelClienteRequest();
            requestNonElegibleProductDetails.CodigoProduto = _codigoProduto;
            requestNonElegibleProductDetails.CodigoCliente = clientIdNumber;
            _producsDetailsModel.Request = requestNonElegibleProductDetails;

            _producsDetailsModel.Execute();
            return true;
        }

        private void CheckNonElegibleProductDetails()
        {
            var response = _producsDetailsModel.Response;

            if (response != null && response.Status.Equals(ExecutionStatus.Success))
            {
                ViewState = ViewStates.Default;
             
                var product = new Produto();
                product.CodigoProduto = response.Produto.CodigoProduto ?? "---";
                product.Status = "Não Elegível";
                product.DataHabilitacao = response.Produto.DataHabilitacaoProdutoCliente.HasValue ? response.Produto.DataHabilitacaoProdutoCliente.Value.ToShortDateString() : string.Empty;
                product.HabilitadoVendaDigital = response.Produto.IndicadorAceitaTransacaoDigitada ?? "---";
                product.UtilizadoUltimos30Dias = response.Produto.IndicadorVendaUltimoMes ? "Sim" : "Não";
                product.Bandeira = response.Produto.NomeBandeira ?? "---";
                product.NomeProduto = response.Produto.NomeProduto ?? "---";
                product.TipoLiquidacao = response.Produto.NomeTipoLiquidacao ?? "---";
                product.QuantidadeDiasPrazo = response.Produto.QuantidadeDiasPrazo ?? "---";
                product.QuantidadeParcelas = response.Produto.QuantidadeParcelasAdministradora ?? "---";
                product.TarifaAdicional = response.Produto.ValorItem.HasValue ?
                    response.Produto.ValorItem.Value.ToString("N2") : string.Empty;
                product.TipoGrupoProduto = response.Produto.TipoGrupoProduto;

                Product = product;
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

        #region Aditional Classes

        public class Produto
        {
            // General product information
            public string CodigoProduto { get; set; }
            public string TipoGrupoProduto { get; set; }
            public string Bandeira { get; set; }
            public string NomeProduto { get; set; }
            public string TaxaPadrao { get; set; }
            public string TaxaContratada { get; set; }
            public string QuantidadeDiasPrazo { get; set; }
            public string TaxaGarantia { get; set; }
            public string QuantidadeParcelas { get; set; }
            public string TipoLiquidacao { get; set; }

            // General details
            public string Status { get; set; }
            public string DataHabilitacao { get; set; }
            public string HabilitadoVendaDigital { get; set; }
            public string UtilizadoUltimos30Dias { get; set; }

            // Bank details
            public string Banco { get; set; }
            public string Agencia { get; set; }
            public string Conta { get; set; }

            // PAT - Alimentacao details
            public string CheckoutsLoja { get; set; }
            public string Supermercado { get; set; }
            public string Armazem { get; set; }
            public string Laticinio { get; set; }
            public string Hipermercado { get; set; }
            public string Acogue { get; set; }
            public string Hortimercado { get; set; }
            public string Peixaria { get; set; }
            public string Mercearia { get; set; }

            // PAT - Refeição details
            public string MaximoRefeicoes { get; set; }
            public string NumeroMesas { get; set; }
            public string NumeroAssentos { get; set; }
            public string Lanchonete { get; set; }
            public string Afiliacao { get; set; }
            public string Restaurante { get; set; }
            public string FastFood { get; set; }
            public string Bar { get; set; }

            // PAT - all
            public string AreaAtendimento { get; set; }
            public string SegundaSexta { get; set; }
            public string Sabado { get; set; }
            public string Domingo { get; set; }
            public string Padaria { get; set; }
            public string Comercial { get; set; }
            public string Noturno { get; set; }
            public string Horas24 { get; set; }
            public string Delivery { get; set; }
            public string Outros { get; set; }
            public string ApresentaCartao { get; set; }
            public string Internet { get; set; }

            // Taxas
            public string TarifaAdicional { get; set; }

            public bool HasRequest { get; set; }
        }

        #endregion
    }
}
