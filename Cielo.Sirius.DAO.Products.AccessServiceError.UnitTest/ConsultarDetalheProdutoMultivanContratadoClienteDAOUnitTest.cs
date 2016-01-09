using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoMultivanContratadoClienteDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
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
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}