using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarPrazoPadraoDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 100020140,
                TipoDemanda = 1,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.AreNotEqual(default(DateTime), response.DataSLA, "Response.DataSLA equals default value");
        }

        [TestMethod]
        public void BusinessError_DemandaInexistente()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 100020140,
                TipoDemanda = 99,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void BusinessError_SubDemandaInexistente()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 100020140,
                TipoDemanda = 1,
                SubTipoDemanda = "99"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 100020140,
                TipoDemanda = 999,
                SubTipoDemanda = "999"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not BusinessError");
            //Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.Status is not BusinessError");
        }
    }
}
