using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class HabilitarProdutoDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011001,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.5M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento, "Response.SolicitacaoCentralAtendimento is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao, "Response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011002,
                CodigoProduto = "43",
                QuantidadeParcelas = "12",
                PercentualTaxa = 1.99M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento, "Response.SolicitacaoCentralAtendimento is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao, "Response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011003,
                CodigoProduto = "72",
                QuantidadeParcelas = "6",
                PercentualTaxa = 0M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "1",
                        NumeroInicialParcelaFaixa = "1",
                        NumeroFinalParcelaFaixa = "3",
                        PercentualTaxaFaixa = 1.11
                    },
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "2",
                        NumeroInicialParcelaFaixa = "4",
                        NumeroFinalParcelaFaixa = "6",
                        PercentualTaxaFaixa = 2.22
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento, "Response.SolicitacaoCentralAtendimento is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao, "Response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011005,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.5M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011007,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.5M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.5M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}