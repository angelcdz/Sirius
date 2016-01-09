using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarDetalheProdutoNaoHabilitadoClienteMock : MockBase
    {
        [TestMethod]
        public void ConsultaDetalheProdutoNaoHabilitado()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>>();

            var request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            var response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            var mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "3"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "3";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "PARCELADO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "6";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "6",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "SEGMENTADO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1004"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "1004";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1005"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "1005";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO DEMANDA";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 5;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 1,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = false;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoHabilitadoCliente.xml", mockSets);

            //PAT Alelo com Multivan

            mockSets = new List<MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>>();

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "---";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "---";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
            {
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2
            });

            mockSet = new MockSet<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoNaoHabilitadoClientePATAleloComMultivan.xml", mockSets);


        }
    }
}
