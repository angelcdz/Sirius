using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class SolicitarNegociacaoTaxaDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 10M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}