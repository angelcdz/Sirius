using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.UnitTest
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
                CodigoCliente = 1000657105,
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
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000020140,
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
        }

        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000657148,
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
        }

        [TestMethod]
        public void Success_Alelo()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1022817962,
                CodigoProduto = "58",
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
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 9999999999,
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
        public void BusinessError_FaixaInvalida()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 8000102429,
                CodigoProduto = "12",
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
                        CodigoFaixa = "1",
                        NumeroFinalParcelaFaixa = "1",
                        NumeroInicialParcelaFaixa = "2",
                        PercentualTaxaFaixa = 1.1
                    },
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "2",
                        NumeroFinalParcelaFaixa = "5",
                        NumeroInicialParcelaFaixa = "6",
                        PercentualTaxaFaixa = 2.2
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoNaoElegivel()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 1000657164,
                CodigoProduto = "45",
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
        public void BusinessError_ProdutoJaHabilitado()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 0000121118,
                CodigoProduto = "70",
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
    }
}
