using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class AlterarProdutoCreditoParceladoSegmentadoDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new AlterarProdutoCreditoParceladoSegmentadoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011003,
                CodigoProduto = "72",
                QuantidadeParcelas = "6",
                Faixas = new List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO>
                {
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "1",
                        NumeroInicialParcelaFaixa = "1",
                        NumeroFinalParcelaFaixa = "3",
                        PercentualTaxaFaixa = 1.33
                    },
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "2",
                        NumeroInicialParcelaFaixa = "4",
                        NumeroFinalParcelaFaixa = "6",
                        PercentualTaxaFaixa = 2.44
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "Response.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new AlterarProdutoCreditoParceladoSegmentadoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011005,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                Faixas = new List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO>
                {
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new AlterarProdutoCreditoParceladoSegmentadoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011007,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                Faixas = new List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO>
                {
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new AlterarProdutoCreditoParceladoSegmentadoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                Faixas = new List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO>
                {
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}