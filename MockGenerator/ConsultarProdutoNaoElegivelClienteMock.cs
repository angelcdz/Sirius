using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarProdutoNaoElegivelClienteMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>>();

            mockSets.Add(GetMocksetforCustomer(10011001, null));
            mockSets.Add(GetMocksetforCustomer(10011002, new string[] { "66", "65" }));
            mockSets.Add(GetMocksetforCustomer(10011003, new string[] { "66", "65" }));
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
            mockSets.Add(GetErrorMocksetforCustomer(10011022, "DetalhesError"));
            mockSets.Add(GetErrorMocksetforCustomer(10011025, "TechnicalError"));


            this.WriteObject(@"..\..\Generated\MockConsultarProdutoNaoElegivelCliente.xml", mockSets);
        }

        #region Mock data for Customers

        public MockSet<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse> GetMocksetforCustomer(long codigoCliente, string[] codigosProdutos)
        {
            var request = new ConsultarProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarProdutoNaoElegivelClienteResponse();
            response.Status = ExecutionStatus.Success;

            response.Produtos = new List<ConsultarProdutoNaoElegivelClienteProdutoDTO>();

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

            var mockSet = new MockSet<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion


        #region Mock Error data for Customers

        public MockSet<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse> GetErrorMocksetforCustomer(long codigoCliente, string typeError)
        {
            var request = new ConsultarProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarProdutoNaoElegivelClienteResponse();


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
                    response.Produtos = new List<ConsultarProdutoNaoElegivelClienteProdutoDTO>();

                    response.Produtos.AddRange(GetErrorProductList());
                    response.NumeroTotalRegistros = response.Produtos.Count;
                    break;


            //   case "BusinessError":
            //       response.Status = ExecutionStatus.BusinessError;
            //       break;
            //
            }

            var mockSet = new MockSet<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion


        #region Product List Generation

        private List<ConsultarProdutoNaoElegivelClienteProdutoDTO> GetFullProductList()
        {
            var produtos = new List<ConsultarProdutoNaoElegivelClienteProdutoDTO>();

            var produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ALIMENTAÇÃO (N-E)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "1";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "REFEIÇÃO (N-E)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "2";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "3";
            produto.NomeProduto = "PARCELADO (N-E)";
            produto.CodigoBandeira = "1";
            produto.NomeBandeira = "VISA";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "6";
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "3";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "5";
            produto.NomeProduto = "CRÉDITO À VISTA (N-E)";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "4";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "6";
            produto.NomeProduto = "SEGMENTADO (N-E)";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "5";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ALIMENTAÇÃO (N-E)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = false;
            produto.OrdemApresentacao = "6";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "REFEIÇÃO (N-E)";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = false;
            produto.OrdemApresentacao = "7";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            //Gerando mais 10 itens para o scroll
            for (var produtoId = 90; produtoId <= 99; produtoId++)
            {
                produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
                produto.CodigoProduto = produtoId.ToString();
                produto.NomeProduto = "SCROLL (N-E)";
                produto.CodigoBandeira = "1";
                produto.NomeBandeira = "VISA";
                produto.PercentualTaxaPadrao = 2;
                produto.QuantidadeDiasPrazo = "30";
                produto.PercentualTaxaGarantia = 5;
                produto.QuantidadeParcelasLoja = string.Empty;
                produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
                produto.IndicadorPossuiDemandasAbertas = false;
                produto.IndicadorVendaDigitada = false;
                produto.OrdemApresentacao = "0";
                produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
                produtos.Add(produto);
            }

            return produtos;
        }

        #endregion


        #region Error Product List Generation

        private List<ConsultarProdutoNaoElegivelClienteProdutoDTO> GetErrorProductList()
        {
            var produtos = new List<ConsultarProdutoNaoElegivelClienteProdutoDTO>();

            var produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "66";
            produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "1";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "65";
            produto.NomeProduto = "ERRO REFEIÇÃO";
            produto.CodigoBandeira = "7";
            produto.NomeBandeira = "ELO";
            produto.PercentualTaxaPadrao = 2;
            produto.QuantidadeDiasPrazo = "30";
            produto.PercentualTaxaGarantia = 5;
            produto.QuantidadeParcelasLoja = string.Empty;
            produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "2";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "5";
            produto.NomeProduto = "ERRO DETALHES";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "4";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "6";
            produto.NomeProduto = "ERRO MULTIVAN";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "5";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);


            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "1002";
            produto.NomeProduto = "ERRO TAXAS";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "4";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "1003";
            produto.NomeProduto = "ERRO DOMICÍLIO BANCÁRIO";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "5";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "1004";
            produto.NomeProduto = "ERRO HISTÓRICO";
            produto.CodigoBandeira = "2";
            produto.NomeBandeira = "MASTERCARD";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "1";
            produto.NomeTipoLiquidacao = "VAN";
            produto.IndicadorPossuiDemandasAbertas = false;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "4";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            produtos.Add(produto);

            produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
            produto.CodigoProduto = "1005";
            produto.NomeProduto = "ERRO DEMANDA";
            produto.CodigoBandeira = "3";
            produto.NomeBandeira = "HIPER";
            produto.PercentualTaxaPadrao = 3;
            produto.QuantidadeDiasPrazo = "45";
            produto.PercentualTaxaGarantia = 3;
            produto.QuantidadeParcelasLoja = "12";
            produto.NomeTipoLiquidacao = "MULTIVAN";
            produto.IndicadorPossuiDemandasAbertas = true;
            produto.IndicadorVendaDigitada = true;
            produto.OrdemApresentacao = "5";
            produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            produtos.Add(produto);

            //Gerando mais 10 itens para o scroll
            for (var produtoId = 90; produtoId <= 99; produtoId++)
            {
                produto = new ConsultarProdutoNaoElegivelClienteProdutoDTO();
                produto.CodigoProduto = produtoId.ToString();
                produto.NomeProduto = "SCROLL (N-E)";
                produto.CodigoBandeira = "1";
                produto.NomeBandeira = "VISA";
                produto.PercentualTaxaPadrao = 2;
                produto.QuantidadeDiasPrazo = "30";
                produto.PercentualTaxaGarantia = 5;
                produto.QuantidadeParcelasLoja = string.Empty;
                produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
                produto.IndicadorPossuiDemandasAbertas = false;
                produto.IndicadorVendaDigitada = false;
                produto.OrdemApresentacao = "0";
                produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
                produtos.Add(produto);
            }

            return produtos;
        }

        #endregion


        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "9999";
            response.ErrorMessage = "RECORD NOT FOUND (N-E)";

            this.WriteObject(@"..\..\Generated\MockConsultarProdutoNaoElegivelClienteError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusiness()
        {
            var response = new ConsultarProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT (N-E)";

            this.WriteObject(@"..\..\Generated\MockConsultarProdutoNaoElegivelClienteErrorBusiness.xml", response);
        }
    }
}
