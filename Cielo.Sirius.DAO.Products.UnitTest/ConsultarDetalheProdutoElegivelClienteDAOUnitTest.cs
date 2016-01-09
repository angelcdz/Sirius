using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoElegivelClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 1012389950,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.IsTrue(response.Produto.CodigoProduto == requestData.CodigoProduto, "Response.Produto.CodigoProduto is different from request");
            Assert.AreEqual(response.Produto.TipoGrupoProduto, "1", "TipoGrupoProduto does not equal 1");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count > 0, "Response.Produto.Taxas is empty");
        }

        [TestMethod]
        public void Success_TaxaDeParcelas()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 1012389950,
                CodigoProduto = "43"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.IsTrue(response.Produto.CodigoProduto == requestData.CodigoProduto, "Response.Produto.CodigoProduto is different from request");
            Assert.AreEqual(response.Produto.TipoGrupoProduto, "3", "TipoGrupoProduto does not equal 3");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count > 0, "Response.Produto.Taxas is empty");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 9999999999,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoInexistente()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 1023805895,
                CodigoProduto = "99"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoJaHabilitado()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 1000020140,
                CodigoProduto = "43"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
