using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest 
{
    [TestClass]
    public class ConsultarDetalheProdutoHabilitadoClienteDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new ConsultarDetalheProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011009,
                CodigoProduto = "20"
            };
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }        
    }
}
