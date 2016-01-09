using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.UnitTest
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
                CodigoCliente = 1000657105,
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
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000020140,
                CodigoProduto = "43",
                QuantidadeParcelas = "12",
                PercentualTaxa = 1.99M
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        }

        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000657148,
                CodigoProduto = "72",
                QuantidadeParcelas = "12",
                PercentualTaxa = 0.88M,
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
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 9999999999,
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
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoInexistente()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000020140,
                CodigoProduto = "99",
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
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoNaoHabilitado()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1023805895,
                CodigoProduto = "10",
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
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_FaixaInvalida()
        {
            var requestData = new AlterarParcelaFaixaProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 8000102429,
                CodigoProduto = "12",
                QuantidadeParcelas = "6",
                PercentualTaxa = 1.5M,
                DadosFaixaTaxaSegmentado = new List<AlterarParcelaFaixaProdutoDTO>
                {
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "1",
                        NumeroFinalParcelaFaixa = "1",
                        NumeroInicialParcelaFaixa = "2",
                        PercentualTaxaFaixa = 1.1
                    },
                    new AlterarParcelaFaixaProdutoDTO
                    {
                        CodigoFaixa = "2",
                        NumeroFinalParcelaFaixa = "5",
                        NumeroInicialParcelaFaixa = "6",
                        PercentualTaxaFaixa = 2.2
                    }
                }
            };
            var dao = DAOFactory.GetDAO<AlterarParcelaFaixaProdutoDAO, AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
