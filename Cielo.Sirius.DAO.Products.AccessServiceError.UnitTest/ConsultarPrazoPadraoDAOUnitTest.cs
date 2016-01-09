using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class ConsultarPrazoPadraoDAOUnitTest
    {        
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011009,
                TipoDemanda = 1,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
        
    }
}
