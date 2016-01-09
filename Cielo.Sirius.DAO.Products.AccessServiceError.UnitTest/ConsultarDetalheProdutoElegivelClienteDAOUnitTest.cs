using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoElegivelClienteDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011009,
                CodigoProduto = "40"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}