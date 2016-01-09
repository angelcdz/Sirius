using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarPrazoPadraoDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
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
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011005,
                TipoDemanda = 99,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011007,
                TipoDemanda = 1,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 99999999,
                TipoDemanda = 1,
                SubTipoDemanda = "1"
            };
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}