using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarProdutoHabilitadoClienteMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>>();

            mockSets.Add(GetMocksetforCustomer(10011001, null));
            mockSets.Add(GetMocksetforCustomer(10011002, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011003, new string[] { "66", "65","101" }));
            mockSets.Add(GetMocksetforCustomer(10011004, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011005, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011006, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011007, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011008, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011009, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011010, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011011, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011012, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011013, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011014, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011015, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011016, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011017, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011018, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011019, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011021, new string[] { "66", "65" }));
            mockSets.Add(GetErrorMocksetforCustomer(10011024, "BusinessError"));
            mockSets.Add(GetErrorMocksetforCustomer(10011020, "DetalhesError"));
            mockSets.Add(GetErrorMocksetforCustomer(10011025, "TechnicalError"));
            mockSets.Add(GetErrorMocksetforCustomer(10011022, "DetalhesError"));
            mockSets.Add(GetErrorMocksetforCustomer(10011023, "DetalhesError"));

            this.WriteObject(@"..\..\Generated\MockConsultarProdutoHabilitadoCliente.xml", mockSets);
        }

        #region Mock data for Customers

        public MockSet<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse> GetMocksetforCustomer(long codigoCliente, string[] codigosProdutos)
        {
            var request = new ConsultarProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarProdutoHabilitadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DataUltimaTransacao = DateTime.Now.AddDays(-2);

            response.Produtos = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();

            if (codigosProdutos != null)
            {
                var produtos = from produto in GetFullProductList()
                               where codigosProdutos.Contains(produto.CodigoProduto)
                               select produto;

                response.Produtos.AddRange(produtos);
            }
            else
            {
                response.Produtos.AddRange(GetFullProductList());
            }

            response.NumeroTotalRegistros = response.Produtos.Count;

            var mockSet = new MockSet<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion


        #region Mock BusinessError data for Customers

        public MockSet<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse> GetErrorMocksetforCustomer(long codigoCliente, string typeError)
        {
            var request = new ConsultarProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarProdutoHabilitadoClienteResponse();

            switch (typeError)
            {
                case "BusinessError":
                    response.Status = ExecutionStatus.BusinessError;
                    break;

                case "TechnicalError":
                    response.Status = ExecutionStatus.TechnicalError;
                    break;


                case "DetalhesError":
                    response.Status = ExecutionStatus.Success;
                    response.Produtos = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();

                    response.Produtos.AddRange(GetErrorProductList());
                    response.NumeroTotalRegistros = response.Produtos.Count;
                    break;


                //   case "BusinessError":
                //       response.Status = ExecutionStatus.BusinessError;
                //       break;
                //
            }

            var mockSet = new MockSet<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion


        #region Product List Generation

        private List<ConsultarProdutoHabilitadoClienteProdutoDTO> GetFullProductList()
        {
            var produtos = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();

            var produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ALIMENTAÇÃO (H)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";            
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "1";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "REFEIÇÃO (H)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 3;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "2";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;            
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "3";
            produto.NomeProduto = "PARCELADO (H)";
            produto.CodigoBandeira = "1";
            produto.NomeBandeira = "VISA";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "6";
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "3";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "50";
            produto.NomeProduto = "CRÉDITO À VISTA (H)";
            produto.CodigoBandeira = "6";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "6";
            produto.NomeProduto = "SEGMENTADO (H)";
            produto.CodigoBandeira = "8";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "5";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ALIMENTAÇÃO (H)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = false;
            produto.IndicadorVendaDigitadaHabilitada = false;
            produto.OrdemApresentacao = "6";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "REFEIÇÃO (H)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 3;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = false;
            produto.IndicadorVendaDigitadaHabilitada = false;
            produto.OrdemApresentacao = "7";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "101";
            produto.NomeProduto = "PRODUTO PRAZO FLEXÍVEL (H)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";            
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 0;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "8";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "5";
            produto.NomeProduto = "CRÉDITO À VISTA (H)";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "ALELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 1;
            produto.IndicadorVendaDigitada = true;
            produto.PercentualTaxa = 1;
            produto.IndicadorVendaDigitadaHabilitada = false;
            produto.OrdemApresentacao = "9";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "REFEIÇÃO (H)";
            produto.CodigoBandeira = "4";
            produto.NomeBandeira = "HIPERCARD";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 3;
            produto.PercentualTaxa = 1;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 1;
            produto.IndicadorVendaDigitada = false;
            produto.IndicadorVendaDigitadaHabilitada = false;
            produto.OrdemApresentacao = "10";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "6";
            produto.NomeProduto = "SEGMENTADO";
            produto.CodigoBandeira = "8";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.PercentualTaxa = 2;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "11";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            //Gerando mais 10 itens para o scroll
            for (var produtoId = 90; produtoId <= 99; produtoId++)
            {
                produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
                produto.CodigoProduto = produtoId.ToString();
                produto.NomeProduto = "SCROLL (H)";
                produto.CodigoBandeira = "1";
                produto.NomeBandeira = "VISA";
                produto.PercentualTaxaPadrao = 2;
                produto.QuantidadeDiasPrazo = "30";
                produto.PercentualTaxaGarantia = 5;
                produto.QuantidadeParcelasLoja = string.Empty;
                produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
                produto.ValorTarifa = 3;
                produto.IndicadorPossuiDemandasAbertas = false;
                produto.PercentualDesconto = 2;
                produto.PercentualTaxa = 3;
                produto.IndicadorVendaDigitada = false;
                produto.IndicadorVendaDigitadaHabilitada = false;
                produto.OrdemApresentacao = "0";
                produto.IndicadorVendaUltimoMes = true;
                produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
                produtos.Add(produto);
            }

            return produtos;
        }

        #endregion

        #region Error Product List Generation

        private List<ConsultarProdutoHabilitadoClienteProdutoDTO> GetErrorProductList()
        {
            var produtos = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>();

            var produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 2;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "1";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);





            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "ERRO REFEIÇÃO";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.ValorTarifa = 3;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "2";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "5";
            produto.NomeProduto = "ERRO DETALHES";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "6";
            produto.NomeProduto = "ERRO MULTIVAN";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "5";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);


            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1002";
            produto.NomeProduto = "ERRO TAXAS";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1003";
            produto.NomeProduto = "ERRO DOMICÍLIO BANCÁRIO";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "5";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);


            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1004";
            produto.NomeProduto = "ERRO HISTÓRICO";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1005";
            produto.NomeProduto = "ERRO DEMANDA";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "5";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1007";
            produto.NomeProduto = "ERRO SLA PADRÃO INDISPONIVEL";
            produto.CodigoBandeira = "1007";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1008";
            produto.NomeProduto = "ERRO SLA RETORNO INDIPONIVEL";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1009";
            produto.NomeProduto = "ERRO OSB COM ERRO";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1010";
            produto.NomeProduto = "ERRO RETORNO CRM";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
            produto.CodigoProduto = "1011";
            produto.NomeProduto = "ERRO TELA";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.ValorTarifa = 2;
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.PercentualDesconto = 3;
            produto.PercentualTaxa = 3;
            produto.IndicadorVendaDigitada = true;
            produto.IndicadorVendaDigitadaHabilitada = true;
            produto.OrdemApresentacao = "4";
            produto.IndicadorVendaUltimoMes = true;
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);


            //Gerando mais 10 itens para o scroll
            for (var produtoId = 90; produtoId <= 99; produtoId++)
            {
                produto = new ConsultarProdutoHabilitadoClienteProdutoDTO();
                produto.CodigoProduto = produtoId.ToString();
                produto.NomeProduto = "SCROLL (H)";
                produto.CodigoBandeira = "1";
                produto.NomeBandeira = "VISA";
                produto.PercentualTaxaPadrao = 2;
                produto.QuantidadeDiasPrazo = "30";
                produto.PercentualTaxaGarantia = 5;
                produto.QuantidadeParcelasLoja = string.Empty;
                produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
                produto.ValorTarifa = 3;
                produto.IndicadorPossuiDemandasAbertas = false;
                produto.PercentualDesconto = 2;
                produto.PercentualTaxa = 3;
                produto.IndicadorVendaDigitada = false;
                produto.IndicadorVendaDigitadaHabilitada = false;
                produto.OrdemApresentacao = "0";
                produto.IndicadorVendaUltimoMes = true;
                produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
                produtos.Add(produto);
            }

            return produtos;
        }

        #endregion



        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "9999";
            response.ErrorMessage = "RECORD NOT FOUND (H)";

            this.WriteObject(@"..\..\Generated\MockConsultarProdutoHabilitadoClienteError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusiness()
        {
            var response = new ConsultarProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT (H)";

            this.WriteObject(@"..\..\Generated\MockConsultarProdutoHabilitadoClienteErrorBusiness.xml", response);
        }
    }
}
