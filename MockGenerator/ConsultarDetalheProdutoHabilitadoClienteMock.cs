using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using System.Collections.Generic;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Foundation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarDetalheProdutoHabilitadoClienteMock : MockBase
    {
        [TestMethod]
        public void Segmentado()
        {
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "01";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.Now.AddDays(-10);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "PARCELADO LOJA(H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "3";
            response.Produto.NomeBanco = "BANCO DO BRASIL";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.QuantidadeParcelasAdministradora = "6";
            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "6",
                PercentualDesconto = 2,
                PercentualTaxaFaixa = 1,
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "3"
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                NumeroFinalParcelaFaixa = "12",
                PercentualDesconto = 1,
                PercentualTaxaFaixa = 2,
                PercentualTaxaPadrao = 3,
                NumeroInicialParcelaFaixa = "6"
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoClienteSegmentado.xml", response);
        }

        [TestMethod]
        public void Parcelado()
        {
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "004";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.Now.AddDays(-22);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "CREDIÁRIO(H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****2-1";
            response.Produto.NumeroContaCorrente = "***45-6";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                PercentualTaxaFaixa = 3.3D,
                PercentualTaxaPadrao = 3.3,
                QuantidadeParcelasLoja = "12",
                PercentualDesconto = 0.2D
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoClienteParcelado.xml", response);
        }

        [TestMethod]
        public void Padrao()
        {
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "002";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.Now.AddDays(-44);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO(H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "5";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "CITIBANK";
            response.Produto.NumeroAgencia = "***7-8";
            response.Produto.NumeroContaCorrente = "****90-1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                PercentualTaxaFaixa = 4,
                PercentualTaxaPadrao = 4,
                PercentualDesconto = 0.1D
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoClientePadrao.xml", response);
        }

       
        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(H)";

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoClienteError.xml", response);
        }

        [TestMethod]
        public void Pedratado()
        {
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "002";
            response.Produto.DataHabilitacaoProdutoCliente = DateTime.Now.AddDays(-44);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTsdasdERCARD";
            response.Produto.NomeProduto = "CRÉDITO(H)";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "5";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "CITIBANK";
            response.Produto.NumeroAgencia = "***7-8";
            response.Produto.NumeroContaCorrente = "****90-1";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PREDATADO;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                PercentualTaxaFaixa = 4,
                PercentualTaxaPadrao = 4,
                PercentualDesconto = 0.1D
            });

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoCliente2.xml", response);
        }

        [TestMethod]
        public void ConsultaDetalheProdutoHabilitado()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>>();

            var request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            var mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "50"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "50";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA (H)";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "101"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "101";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;            

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BANCO DO BRASIL";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "3"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "3";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "VISA";
            response.Produto.NomeProduto = "PARCELADO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "6";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_PARCELADO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "6",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "5"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "SEGMENTADO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "2",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "3",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            //Mocks filtro demandas

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011002,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011003,
                CodigoProduto = "101"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "101";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011004,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011014,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011015,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011016,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011016,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011017,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011018,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011005,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011006,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011007,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011008,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011009,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011010,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011011,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011012,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011013,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "PRAZO FLEXÍVEL";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "5"
            };


            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "2",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "3",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1002"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "1002";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO TAXAS";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1003"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "1003";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO DOMICÍLIO BANCÁRIO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "2",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "3",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1004"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "1004";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO HISTÓRICO";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1005"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "1005";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO DEMANDA";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "2",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "3",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 10;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });


            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BANCO DO BRASIL";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "5"
            };


            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "ERRO MULTIVAN";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "2",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "3",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 1,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 10;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });


            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ERRO REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BANCO DO BRASIL";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011023,
                CodigoProduto = "1007"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO SLA PADRÃO INDISPONIVEL";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011023,
                CodigoProduto = "1008"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO SLA RETORNO INDIPONIVEL";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011023,
                CodigoProduto = "1009"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO OSB COM ERRO";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011023,
                CodigoProduto = "1010"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO RETORNO CRM";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011023,
                CodigoProduto = "1011"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "MASTERCARD";
            response.Produto.NomeProduto = "ERRO TELA ";
            response.Produto.NomeTipoLiquidacao = "VAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 3;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                QuantidadeParcelasLoja = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);




            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoCliente.xml", mockSets);
        }


        [TestMethod]
        public void ConsultaDetalheProdutoHabilitadoMultivanPatAlelo()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>>();

            var request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            var mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "NÃO";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BANCO DO BRASIL";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoClienteMultivanPatAlelo.xml", mockSets);
        }


        [TestMethod]
        public void ConsultaDetalheProdutoHabilitadoDesabilitarProduto()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>>();

            var request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "5"
            };

            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "5";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = false;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ALELO";
            response.Produto.NomeProduto = "CRÉDITO À VISTA";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = "1";
            response.Produto.NomeBanco = "SANTANDER";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 2;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3,
                QuantidadeParcelasLoja = "1"
            });

            var mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "65";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "Sim";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPERCARD";
            response.Produto.NomeProduto = "REFEIÇÃO";
            response.Produto.NomeTipoLiquidacao = "ADQUIRÊNCIA";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "ITAU";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 1;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "6";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "SIM";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "HIPER";
            response.Produto.NomeProduto = "SEGMENTADO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "45";
            response.Produto.QuantidadeParcelasAdministradora = "12";
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_SEGMENTADO;
            response.Produto.ValorItem = 4;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "3",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "4",
                NumeroFinalParcelaFaixa = "6",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 3,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                NumeroInicialParcelaFaixa = "7",
                NumeroFinalParcelaFaixa = "9",
                QuantidadeParcelasLoja = "12",
                PercentualTaxaPadrao = 2,
                PercentualTaxaFaixa = 6,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.Success;

            response.Produto = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();
            response.Produto.CodigoProduto = "66";
            response.Produto.DataHabilitacaoProdutoCliente = new DateTime(2014, 10, 20);
            response.Produto.IndicadorAceitaTransacaoDigitada = "Sim";
            response.Produto.IndicadorVendaDigitada = true;
            response.Produto.IndicadorVendaUltimoMes = true;
            response.Produto.NomeBandeira = "ELO";
            response.Produto.NomeProduto = "ALIMENTAÇÃO";
            response.Produto.NomeTipoLiquidacao = "MULTIVAN";
            response.Produto.QuantidadeDiasPrazo = "30";
            response.Produto.QuantidadeParcelasAdministradora = string.Empty;
            response.Produto.NomeBanco = "BRADESCO";
            response.Produto.NumeroAgencia = "****3-2";
            response.Produto.NumeroContaCorrente = "***12-3";
            response.Produto.TipoGrupoProduto = Constants.TIPOGRUPOPRODUTO_CREDITO;
            response.Produto.ValorItem = 0;

            response.Produto.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
            response.Produto.Taxas.Add(new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
            {
                CodigoFaixa = "1",
                PercentualTaxaPadrao = 2,
                PercentualDesconto = 2,
                TaxaMatriz = 3
            });

            mockSet = new MockSet<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoHabilitadoDesabilitarProduto.xml", mockSets);
        }
    }
}
