using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
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
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class NonEnabledProductsViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

        #endregion

        #region Fields

        private ObservableCollection<Produto> _selectedProducts;
        private NonEnabledProductsModel _nonEnabledProductsModel;

        private Logger _logger = Logger.LoggerFor<NonEnabledProductsViewModel>();

        #endregion

        #region Properties

        private ObservableCollection<Produto> _displayedProducts;
        public ObservableCollection<Produto> DisplayedProducts
        {
            get { return _displayedProducts; }
            set
            {
                if (_displayedProducts == value)
                    return;
                _displayedProducts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Produto> _enabledProducts;
        public ObservableCollection<Produto> EnabledProducts
        {
            get { return _enabledProducts; }
            private set
            {
                if (_enabledProducts == value)
                    return;
                _enabledProducts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _levyTypeList;
        public ObservableCollection<string> LevyTypeList
        {
            get { return _levyTypeList; }
            private set
            {
                if (_levyTypeList == value)
                    return;
                _levyTypeList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _BandeiraList;
        public ObservableCollection<string> BandeiraList
        {
            get { return _BandeiraList; }
            private set
            {
                if (_BandeiraList == value)
                    return;
                _BandeiraList = value;
                OnPropertyChanged();
            }
        }

        private string _BandeiraSearchText;
        public string BandeiraSearchText
        {
            get { return _BandeiraSearchText; }
            set
            {
                if (_BandeiraSearchText == value)
                    return;
                _BandeiraSearchText = value;
                OnPropertyChanged();
            }
        }

        private string _productSearchText;
        public string ProductSearchText
        {
            get { return _productSearchText; }
            set
            {
                if (_productSearchText == value)
                    return;
                _productSearchText = value;
                OnPropertyChanged();
            }
        }

        private string _rateSearchText;
        public string RateSearchText
        {
            get { return _rateSearchText; }
            set
            {
                if (_rateSearchText == value)
                    return;
                _rateSearchText = value;
                OnPropertyChanged();
            }
        }

        private string _contractedRateSearchFilter;
        public string ContractedRateSearchFilter
        {
            get { return _contractedRateSearchFilter; }
            set
            {
                if (_contractedRateSearchFilter == value)
                    return;
                _contractedRateSearchFilter = value;
                OnPropertyChanged();
            }
        }

        private string _receiptTermSearchFilter;
        public string ReceiptTermSearchFilter
        {
            get { return _receiptTermSearchFilter; }
            set
            {
                if (_receiptTermSearchFilter == value)
                    return;
                _receiptTermSearchFilter = value;
                OnPropertyChanged();
            }
        }

        private string _flexibleReceiptTermSearchFilter;
        public string FlexibleReceiptTermSearchFilter
        {
            get { return _flexibleReceiptTermSearchFilter; }
            set
            {
                if (_flexibleReceiptTermSearchFilter == value)
                    return;
                _flexibleReceiptTermSearchFilter = value;
                OnPropertyChanged();
            }
        }

        private string _plotsSearchFilter;
        public string PlotsSearchFilter
        {
            get { return _plotsSearchFilter; }
            set
            {
                if (_plotsSearchFilter == value)
                    return;
                _plotsSearchFilter = value;
                OnPropertyChanged();
            }
        }

        private string _levyTypeFilter;
        public string LevyTypeFilter
        {
            get { return _levyTypeFilter; }
            set
            {
                if (_levyTypeFilter == value)
                    return;
                _levyTypeFilter = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand _filterCommand;
        public ICommand FilterCommand
        {
            get
            {
                if (_filterCommand == null)
                {
                    _filterCommand = new RelayCommand(
                        param => FilterMethod(param),
                        param => true
                        );
                }
                return _filterCommand;
            }
        }

        private ICommand _selectedProduct;
        public ICommand SelectedProduct
        {
            get
            {
                if (_selectedProduct == null)
                {
                    _selectedProduct = new RelayCommand(
                        param =>
                        {
                            var paramsDic = new Dictionary<string, object>();
                            paramsDic.Add("product", ((Produto)param).CodigoProduto);
                            paramsDic.Add("productType", ((Produto)param).TipoProduto);
                            paramsDic.Add("flagCode", ((Produto)param).CodigoBandeira);
                            paramsDic.Add("tipoLiquidacao", ((Produto)param).NomeTipoLiquidacao);

                            Navegate("NonEnabledProductDetails", "ProductsAndServicesMainRegion", "", paramsDic);
                        },
                        param => param is Produto
                    );
                }
                return _selectedProduct;
            }
        }

        #endregion

        #region Initialize

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            if (GetNonEnabledProducts())
            {
                CheckNonEnabledProducts();
            }
           
            base.PreInitialize(navegationParams_);
        }

        #endregion

        #region Private Mathods

        private bool GetNonEnabledProducts()
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

            // Call the model to get the products list
            _nonEnabledProductsModel = new NonEnabledProductsModel();

            ConsultarProdutoElegivelClienteRequest requestNonEnabledProducts = new ConsultarProdutoElegivelClienteRequest();
            requestNonEnabledProducts.CodigoCliente = clientIdNumber;
            _nonEnabledProductsModel.Request = requestNonEnabledProducts;

            _nonEnabledProductsModel.Execute();
            return true;
        }

        private void ShowNonEnabledProducts(List<ConsultarProdutoElegivelClienteProdutoDTO> clientProducts)
        {
            if (clientProducts == null)
            {
                clientProducts = new List<ConsultarProdutoElegivelClienteProdutoDTO>();
            }

            // Arrange products data
            ObservableCollection<Produto> enabledProducts = new ObservableCollection<Produto>();
            foreach (var product in clientProducts)
            {
                Produto nonEnabledProduct = new Produto();
                nonEnabledProduct.CodigoProduto = string.IsNullOrEmpty(product.CodigoProduto) ? "---" : product.CodigoProduto;
                nonEnabledProduct.Bandeira = string.IsNullOrEmpty(product.NomeBandeira) ? "---" : product.NomeBandeira;
                nonEnabledProduct.CodigoBandeira = product.CodigoBandeira;
                nonEnabledProduct.NomeTipoLiquidacao = product.NomeTipoLiquidacao;
                nonEnabledProduct.NomeProduto = string.IsNullOrEmpty(product.NomeProduto) ? "---" : product.NomeProduto;
                //nonEnabledProduct.TipoProduto = product.TipoGrupoProduto;

                if (product.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_SEGMENTADO)
                {
                    nonEnabledProduct.TaxaPadrao = "---";
                }
                else
                {
                    nonEnabledProduct.TaxaPadrao = ((decimal)product.PercentualTaxaPadrao / 100).ToString("P");
                    nonEnabledProduct.SortTaxaPadrao = product.PercentualTaxaPadrao;
                }

                double qtdDiasPrazo = 0.0;
                if (double.TryParse(product.QuantidadeDiasPrazo, out qtdDiasPrazo))
                {
                    nonEnabledProduct.QuantidadeDiasPrazo = qtdDiasPrazo.ToString("N0");
                    nonEnabledProduct.SortQuantidadeDiasPrazo = qtdDiasPrazo;
                }
                else
                {
                    nonEnabledProduct.QuantidadeDiasPrazo = "---";
                    nonEnabledProduct.SortQuantidadeDiasPrazo = -1;
                }

                nonEnabledProduct.TaxaGarantia = ((double)product.PercentualTaxaGarantia / 100).ToString("P");
                nonEnabledProduct.SortTaxaGarantia = product.PercentualTaxaGarantia;

                nonEnabledProduct.QuantidadeParcelas = string.IsNullOrEmpty(product.QuantidadeParcelasLoja) ? "---" : product.QuantidadeParcelasLoja;
                nonEnabledProduct.TipoLiquidacao = string.IsNullOrEmpty(product.NomeTipoLiquidacao) ? "---" : product.NomeTipoLiquidacao;
                nonEnabledProduct.HasRequest = product.IndicadorPossuiDemandasAbertas;

                enabledProducts.Add(nonEnabledProduct);
            }

            // Update the UI
            EnabledProducts = enabledProducts;
            _selectedProducts = EnabledProducts;
            DisplayedProducts = EnabledProducts;
            UpdateComboBoxFilters();
        }

        private void CheckNonEnabledProducts()
        {
             var response = _nonEnabledProductsModel.Response;

             if (response != null && response.Status.Equals(ExecutionStatus.Success))
             {
                 ViewState = ViewStates.Default;
                 ShowNonEnabledProducts(_nonEnabledProductsModel.Response.Produtos);
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

        private void FilterMethod(object param)
        {
            var newDisplayedProducts = new ObservableCollection<Produto>();

            // Clean filters
            DisplayedProducts = _selectedProducts;

            // Filter Bandeira
            if (!string.IsNullOrEmpty(BandeiraSearchText))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (BandeiraSearchText == product.Bandeira)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter Product
            if (!string.IsNullOrEmpty(ProductSearchText))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (ProductSearchText == product.NomeProduto)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter TaxaPadrao
            if (!string.IsNullOrEmpty(RateSearchText))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (RateSearchText == product.TaxaPadrao)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter Receipt Term 
            if (!string.IsNullOrEmpty(ReceiptTermSearchFilter))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (ReceiptTermSearchFilter == product.QuantidadeDiasPrazo)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter Flexible Receipt Term
            if (!string.IsNullOrEmpty(FlexibleReceiptTermSearchFilter))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (FlexibleReceiptTermSearchFilter == product.TaxaGarantia)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter QuantidadeParcelas 
            if (!string.IsNullOrEmpty(PlotsSearchFilter))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (PlotsSearchFilter == product.QuantidadeParcelas)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }

            // Filter Levy Type 
            if (!string.IsNullOrEmpty(LevyTypeFilter))
            {
                newDisplayedProducts = new ObservableCollection<Produto>();

                foreach (var product in DisplayedProducts)
                {
                    if (LevyTypeFilter == product.TipoLiquidacao)
                    {
                        newDisplayedProducts.Add(product);
                    }
                }

                DisplayedProducts = newDisplayedProducts;
            }
        }

        private string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }

        private void UpdateComboBoxFilters()
        {
            BandeiraList = new ObservableCollection<string>(_selectedProducts.Select(product => product.Bandeira).Distinct());
            BandeiraList.Insert(0, string.Empty);

            LevyTypeList = new ObservableCollection<string>(_selectedProducts.Select(product => product.TipoLiquidacao).Distinct());
            LevyTypeList.Insert(0, string.Empty);
        }

        #endregion

        #region Aditional Classes

        public class Produto
        {
            public string CodigoProduto { get; set; }
            public string TipoProduto { get; set; }
            public string Bandeira { get; set; }
            public string CodigoBandeira { get; set; }
            public string NomeTipoLiquidacao { get; set; }
            public string NomeProduto { get; set; }
            public string TaxaPadrao { get; set; }
            public string QuantidadeDiasPrazo { get; set; }
            public string TaxaGarantia { get; set; }
            public string QuantidadeParcelas { get; set; }
            public string TipoLiquidacao { get; set; }
            public bool HasRequest { get; set; }

            // Sort
            public double? SortTaxaGarantia { get; set; }
            public double SortQuantidadeDiasPrazo { get; set; }
            public double? SortTaxaPadrao { get; set; }
        }

        #endregion
    }
}
