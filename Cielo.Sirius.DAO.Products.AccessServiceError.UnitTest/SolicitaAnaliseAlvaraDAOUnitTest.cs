using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class SolicitaAnaliseAlvaraDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new SolicitaAnaliseAlvaraRequest()
            {
                Protocolo = "12345",
                CodigoCliente = 10011009,
                NumeroTelefoneContato = "98413327",
                NomeContato = "Felipe",
                NomeEmailContato = "felipe@felipe.com",
                CodigoSituacaoCliente = "1",
                NomeProprietario = "Trovo",
              

            };
            var dao = DAOFactory.GetDAO<SolicitaAnaliseAlvaraDAO, SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}
