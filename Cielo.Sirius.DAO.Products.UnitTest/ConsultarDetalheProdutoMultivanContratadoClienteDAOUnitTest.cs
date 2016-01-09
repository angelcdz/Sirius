using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoMultivanContratadoClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_Habilitado()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 1003028168,
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
                CodigoCliente = 9999999999,
                CodigoProduto = "10"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_ProdutoInexistente()
        {
            var requestData = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 1003028168,
                CodigoProduto = "99"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
