using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class SolicitaAnaliseAlvaraDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new SolicitaAnaliseAlvaraRequest()
            {
                Protocolo = "12345",
                CodigoCliente = 10011001,
                NumeroTelefoneContato = "98413327",
                NomeContato = "Felipe",
                NomeEmailContato = "felipe@felipe.com",
                CodigoSituacaoCliente = "1",
                NomeProprietario = "Trovo",
              
                
            };
            var dao = DAOFactory.GetDAO<SolicitaAnaliseAlvaraDAO, SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento, "SolicitacaoCentralAtendimento is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento.CodigoSolicitacao, "CodigoSolicitacao is null");
            Assert.IsNotNull(response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao, "DataPrevistaConclusaoSolicitacao is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new SolicitaAnaliseAlvaraRequest()
            {
                Protocolo = "12345",
                CodigoCliente = 10011005,
                NumeroTelefoneContato = "98413327",
                NomeContato = "Felipe",
                NomeEmailContato = "felipe@felipe.com",
                CodigoSituacaoCliente = "1",
                NomeProprietario = "Trovo",
            

            };
            var dao = DAOFactory.GetDAO<SolicitaAnaliseAlvaraDAO, SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new SolicitaAnaliseAlvaraRequest()
            {
                Protocolo = "12345",
                CodigoCliente = 10011007,
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
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new SolicitaAnaliseAlvaraRequest()
            {
                Protocolo = "12345",
                CodigoCliente = 99999999,
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
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}
