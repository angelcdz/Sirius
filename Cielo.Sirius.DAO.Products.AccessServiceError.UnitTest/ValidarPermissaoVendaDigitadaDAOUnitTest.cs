using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class ValidarPermissaoVendaDigitadaDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
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
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}