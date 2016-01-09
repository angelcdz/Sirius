using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class DesabilitarProdutoDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new DesabilitarProdutoRequest
            {
                Protocolo           = "123456",
                CodigoCliente       = 99999999,
                CodigoProduto       = 19,
                NomeSolicitante     = "SOLICITANTE",
                Origem              = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa       = "1",
                MotivoSolicitacao   = "CANCELAMENTO",
                IlhaDeAtendimento   = "ILHA_ATEND",
                ParentCaseId        = "PAI",
                RequestReasonId     = Guid.NewGuid(),
                DemandId            = Guid.NewGuid()
            };
            var dao = DAOFactory.GetDAO<DesabilitarProdutoDAO, DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}