using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoMultivanContratadoClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_Habilitado()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "10"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DetalhesMultivan, "Response.DetalhesMultivan is null");
            Assert.IsTrue(response.DetalhesMultivan.Count > 0, "Response.DetalhesMultivan.Count <= 0");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011005,
                CodigoProduto = "10"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011007,
                CodigoProduto = "10"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 99999999,
                CodigoProduto = "10"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}