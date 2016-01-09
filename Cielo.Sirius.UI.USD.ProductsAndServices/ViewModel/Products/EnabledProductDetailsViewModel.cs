﻿using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class EnabledProductDetailsViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

        #endregion

        #region Atributes

        private string _codigoProduto;
        private string _tipoProduto;
        private EnabledProductDetailsModel _producsDetailsModel;

        private Logger _logger = Logger.LoggerFor<EnabledProductDetailsViewModel>();

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

        private bool _hasFaixaParcelas;
        public bool HasFaixaParcelas
        {
            get { return _hasFaixaParcelas; }
            set
            {
                if (_hasFaixaParcelas == value)
                    return;
                _hasFaixaParcelas = value;
                OnPropertyChanged();
            }
        }

        

        #endregion

        #region Initialize

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            _codigoProduto = navegationParams_["product"] as string;
            _tipoProduto = navegationParams_["productType"] as string;

            if (LoadEnabledProductDetails())
            {
                CheckEnabledProductDetails();
            }
            
            base.PreInitialize(navegationParams_);
        }

        #endregion

        private bool LoadEnabledProductDetails()
        {
            _producsDetailsModel = new EnabledProductDetailsModel();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return false;
            }

            ConsultarDetalheProdutoHabilitadoClienteRequest enabledOriductDetailsRequest = new ConsultarDetalheProdutoHabilitadoClienteRequest();
            enabledOriductDetailsRequest.CodigoProduto = _codigoProduto;
            enabledOriductDetailsRequest.CodigoCliente = clientIdNumber;
            _producsDetailsModel.Request = enabledOriductDetailsRequest;

            _producsDetailsModel.Execute();
            return true;
        }

        private void CheckEnabledProductDetails()
        {
            var response = _producsDetailsModel.Response;

            if (response != null && response.Status.Equals(ExecutionStatus.Success))
            {
                ViewState = ViewStates.Default;

                var product = new Produto();
                product.CodigoProduto = response.Produto.CodigoProduto ?? "---";
                product.Status = "Elegível e Habilitado";
                product.DataHabilitacao = response.Produto.DataHabilitacaoProdutoCliente.HasValue ? response.Produto.DataHabilitacaoProdutoCliente.Value.ToShortDateString() : "---";
                product.HabilitadoVendaDigital = response.Produto.IndicadorAceitaTransacaoDigitada;
                product.UtilizadoUltimos30Dias = response.Produto.IndicadorVendaUltimoMes ? "Sim" : "Não";
                product.Bandeira = response.Produto.NomeBandeira ?? "---";
                product.NomeProduto = response.Produto.NomeProduto ?? "---";
                product.TipoLiquidacao = response.Produto.NomeTipoLiquidacao ?? "---";
                product.QuantidadeDiasPrazo = response.Produto.QuantidadeDiasPrazo ?? "---";
                product.QuantidadeParcelas = response.Produto.QuantidadeParcelasAdministradora ?? "---";
                product.Banco = response.Produto.NomeBanco ?? "---";
                product.Agencia = response.Produto.NumeroAgencia ?? "---";
                product.Conta = response.Produto.NumeroContaCorrente ?? "---";
                product.TarifaAdicional = response.Produto.ValorItem.HasValue ?
                    response.Produto.ValorItem.Value.ToString("N2") : string.Empty;
                product.TipoGrupoProduto = response.Produto.TipoGrupoProduto;

                // Parcelado or Segmentado
                HasFaixaParcelas = product.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_PARCELADO || product.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_SEGMENTADO;

                product.Taxas = new List<Taxa>();
                foreach (var taxa in response.Produto.Taxas)
                {
                    var newTaxa = new Taxa();
                    if (product.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_SEGMENTADO)
                    {
                        newTaxa.FaixaParcelas = (taxa.NumeroInicialParcelaFaixa ?? string.Empty) + "x - " + (taxa.NumeroFinalParcelaFaixa ?? string.Empty) + "x";
                    }
                    else if (product.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_PARCELADO)
                    {
                        newTaxa.FaixaParcelas = "Até " + taxa.QuantidadeParcelasLoja ?? string.Empty;
                    }

                    newTaxa.Desconto = taxa.PercentualDesconto.HasValue ? taxa.PercentualDesconto.Value.ToString("P2") : String.Empty;
                    newTaxa.TaxaContratada = taxa.PercentualTaxaFaixa.HasValue ? taxa.PercentualTaxaFaixa.Value.ToString("P2") : String.Empty;
                    newTaxa.TaxaPadrao = taxa.PercentualTaxaPadrao.HasValue ? taxa.PercentualTaxaPadrao.Value.ToString("P2") : String.Empty;

                    product.Taxas.Add(newTaxa);
                }

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

            var rates = _producsDetailsModel.Response != null && _producsDetailsModel.Response.Produto != null ?
                _producsDetailsModel.Response.Produto.Taxas : null;
            Messenger.Send<List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>>(rates);
        }

        public override void PosInitialize(Dictionary<string, object> navegationParams_)
        {
            var productDetails = _producsDetailsModel.Response != null && _producsDetailsModel.Response.Produto != null ?
                _producsDetailsModel.Response.Produto : null;
            Messenger.Send<ConsultarDetalheProdutoHabilitadoClienteProdutoDTO>(productDetails);

            base.PosInitialize(navegationParams_);
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
            public List<Taxa> Taxas { get; set; }
            public string TarifaAdicional { get; set; }

            public bool HasRequest { get; set; }
        }

        public class Taxa
        {
            public string FaixaParcelas { get; set; }
            public string TaxaPadrao { get; set; }
            public string TaxaContratada { get; set; }
            public string Desconto { get; set; }
        }

        #endregion
    }
}
