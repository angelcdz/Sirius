using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarDetalheProdutoNaoElegivelClienteMock : MockBase
    {
        [TestMethod]
        public void Segmentado()
        {
            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "0031";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO(N-E)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "6",
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "3"
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "12",
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "6"
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelClienteSegmentado.xml", response);
        }

        [TestMethod]
        public void Parcelado()
        {
            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "004";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "CREDIÁRIO(N-E)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 3.3,
                QuantidadeParcelasLoja = "12",
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelClienteParcelado.xml", response);
        }

        [TestMethod]
        public void Padrao()
        {
            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "002";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.MinValue;
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO(N-E)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "5";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 4,
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelClientePadrao.xml", response);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-E)";

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelClienteError.xml", response);
        }

        [TestMethod]
        public void ConsultaDetalheProdutoNaoElegivel()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>>();

            var request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            var mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "3"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "3";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "PARCELADO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "6";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "6",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "SEGMENTADO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            
            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1004"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "1004";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1005"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "1005";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO DEMANDA";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelCliente.xml", mockSets);

            //PAT Alelo com Multivan

            mockSets = new List<MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>>();

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";

            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "---";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "---";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoElegivelClientePATAleloComMultivan.xml", mockSets);


        }
    }
}
