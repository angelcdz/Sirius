using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using System.Collections.Generic;
using Cielo.Sirius.Contracts;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarDetalheProdutoElegivelClienteMock : MockBase
    {
        [TestMethod]
        public void Segmentado()
        {
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "0016";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CREDIÁRIO(N-H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "3",
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "1"
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "25",
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "3"
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoElegivelClienteSegmentado.xml", response);
        }

        [TestMethod]
        public void Parcelado()
        {
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "004";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "PARCELADO LOJA(N-H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 3.3,
                QuantidadeParcelasLoja = "12",
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoElegivelClienteParcelado.xml", response);
        }

        [TestMethod]
        public void Padrao()
        {
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "002";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO(N-H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "5";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 4,
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoElegivelClientePadrao.xml", response);
        }


        [TestMethod]
        public void Predatado()
        {
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "002";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO(N-H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "5";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PREDATADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 4,
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoElegivelClientePredatado.xml", response);
        }


        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoElegivelClienteError.xml", response);
        }
    }
}
