using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ValidarPermissaoVendaDigitadaDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "1",
                IdMotivo = Guid.NewGuid(),
                IndicaOperacao = "H"
            };
            var dao = DAOFactory.GetDAO<ValidarPermissaoVendaDigitadaDAO, ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsTrue(!string.IsNullOrEmpty(response.TipoDeMensagem), "Response.TipoDeMensagem is empty");
            Assert.IsTrue(response.TipoDeMensagem == "E" || response.TipoDeMensagem == "A", "Response.TipoDeMensagem is invalid");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011005,
                CodigoRamoAtividade = "1",
                IdMotivo = Guid.NewGuid(),
                IndicaOperacao = "H"
            };
            var dao = DAOFactory.GetDAO<ValidarPermissaoVendaDigitadaDAO, ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011007,
                CodigoRamoAtividade = "1",
                IdMotivo = Guid.NewGuid(),
                IndicaOperacao = "H"
            };
            var dao = DAOFactory.GetDAO<ValidarPermissaoVendaDigitadaDAO, ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 99999999,
                CodigoRamoAtividade = "1",
                IdMotivo = Guid.NewGuid(),
                IndicaOperacao = "H"
            };
            var dao = DAOFactory.GetDAO<ValidarPermissaoVendaDigitadaDAO, ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}