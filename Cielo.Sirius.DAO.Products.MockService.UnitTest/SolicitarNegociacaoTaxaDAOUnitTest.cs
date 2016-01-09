using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class SolicitarNegociacaoTaxaDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 10011001,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 10.1M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "DataPrevistaConclusaoSolicitacao is null");
            Assert.IsNotNull(response.CodigoSolicitacao, "CodigoSolicitacao is null");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 10011005,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 10.1M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 10011007,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 10.1M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 10.1M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}