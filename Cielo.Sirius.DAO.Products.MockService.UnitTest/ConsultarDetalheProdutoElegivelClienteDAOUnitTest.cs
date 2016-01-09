using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoElegivelClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_TaxaAVista()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produto, "Response.Produto is null");
            Assert.AreEqual(response.Produto.TipoGrupoProduto, "1", "TipoGrupoProduto does not equal 1");
            Assert.IsNotNull(response.Produto.Taxas, "Response.Produto.Taxas is null");
            Assert.IsTrue(response.Produto.Taxas.Count > 0, "Response.Produto.Taxas is empty");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011005,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011007,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011008,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}