using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class AlterarParcelaFaixaProdutoDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011001,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.98M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "Response.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011002,
                CodigoProduto = "43",
                QuantidadeParcelas = "12",
                PercentualTaxa = 1.99M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "Response.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011003,
                CodigoProduto = "72",
                QuantidadeParcelas = "6",
                PercentualTaxa = 0M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "1",
                        NumeroInicialParcelaFaixa = "1",
                        NumeroFinalParcelaFaixa = "3",
                        PercentualTaxaFaixa = 1.33
                    },
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "2",
                        NumeroInicialParcelaFaixa = "4",
                        NumeroFinalParcelaFaixa = "6",
                        PercentualTaxaFaixa = 2.44
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "Response.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011005,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.98M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011007,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.98M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.98M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                },
                Origem = "CRM"
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}