using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class ConsultarProdutoElegivelClienteDAOUnitTest
    {        
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new ConsultarProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011009,
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}
