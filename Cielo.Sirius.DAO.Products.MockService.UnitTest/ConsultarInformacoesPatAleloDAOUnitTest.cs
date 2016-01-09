using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarInformacoesPatAleloDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 10011001,
            };
            var dao = DAOFactory.GetDAO<ConsultarInformacoesPatAleloDAO, ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.IsNotNull(response.DadosAlimentacao, "DadosAlimentacao is null");
            Assert.IsNotNull(response.DadosRefeicao, "DadosRefeicao is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 10011005,
            };
            var dao = DAOFactory.GetDAO<ConsultarInformacoesPatAleloDAO, ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 10011007,
            };
            var dao = DAOFactory.GetDAO<ConsultarInformacoesPatAleloDAO, ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 99999999,
            };
            var dao = DAOFactory.GetDAO<ConsultarInformacoesPatAleloDAO, ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}