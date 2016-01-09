using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoHabilitadoClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "20"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count == 1, string.Format("Response.Produto.Taxas.Count is not 1. Expected: 1, Actual: {0}", response.Produto.Taxas.Count));
            Assert.IsNotNull(response.Produto.Taxas.First(), "Response.Produto.Taxas.First is null");
            Assert.IsTrue(response.Produto.Taxas.First().PercentualTaxaFaixa > 0, "PercentualTaxaFaixa <= 0");
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011002,
                CodigoProduto = "43"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.AreEqual(response.Produto.TipoGrupoProduto, "3", "TipoGrupoProduto does not equal 3");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count == 1, "Response.Produto.Taxas.Count is not 1");
            Assert.IsNotNull(response.Produto.Taxas.First(), "Response.Produto.Taxas.First is null");
            Assert.IsTrue(response.Produto.Taxas.First().PercentualTaxaFaixa > 0, "PercentualTaxaFaixa <= 0");

            int quantidadeParcelas;
            Assert.IsTrue(int.TryParse(response.Produto.Taxas.First().QuantidadeParcelasLoja, out quantidadeParcelas), "QuantidadeParcelasLoja is not numeric");
            Assert.IsTrue(quantidadeParcelas > 0, "QuantidadeParcelasLoja <= 0");
        }

        [TestMethod]
        public void Success_TaxaDeParcelasSegmentadas()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011003,
                CodigoProduto = "43"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.AreEqual(response.Produto.TipoGrupoProduto, "4", "TipoGrupoProduto does not equal 4");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count > 1, "Response.Produto.Taxas.Count <= 1");

            response.Produto.Taxas.ForEach(
                taxa =>
                {
                    Assert.IsNotNull(taxa, "Response is null");
                    int numeroInicialParcelas;
                    Assert.IsTrue(int.TryParse(taxa.NumeroInicialParcelaFaixa, out numeroInicialParcelas), "NumeroInicialParcelas is not numeric");
                    Assert.IsTrue(numeroInicialParcelas > 0, "NumeroInicialParcelas <= 0");
                    int numeroFinalParcelas;
                    Assert.IsTrue(int.TryParse(taxa.NumeroFinalParcelaFaixa, out numeroFinalParcelas), "NumeroFinalParcelaFaixa is not numeric");
                    Assert.IsTrue(numeroFinalParcelas > 0, "NumeroFinalParcelaFaixa <= 0");
                    Assert.IsTrue(taxa.PercentualTaxaFaixa > 0, "PercentualTaxaFaixa <= 0");
                }
            );
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011005,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalError_OSB()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011007,
                CodigoProduto = "58"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.ErrorCode is not Techinical Error");
        }

        [TestMethod]
        public void TechnicalError_Timeout()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011008,
                CodigoProduto = "58"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}