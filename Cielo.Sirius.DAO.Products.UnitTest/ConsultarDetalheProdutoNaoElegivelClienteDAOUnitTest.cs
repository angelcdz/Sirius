using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoNaoElegivelClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 1012389950,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
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
            var requestData = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 1012389950,
                CodigoProduto = "43"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
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
            var requestData = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 9999999999,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoInexistente()
        {
            var requestData = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 1006983721,
                CodigoProduto = "99"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoElegivelOuJaHabilitado()
        {
            var requestData = new ConsultarDetalheProdutoNaoElegivelClienteRequest()
            {
                CodigoCliente = 1023124669,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
