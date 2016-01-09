using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products.UnitTest
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
                CodigoCliente = 0001591967,
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
                CodigoCliente = 9999999999,
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
        public void BusinessError_TaxaInvalida()
        {
            var requestData = new SolicitarNegociacaoTaxaRequest()
            {
                Protocolo = "123456",
                CodigoCliente = 0001591967,
                CodigoProduto = "43",
                NomeContato = "NOME CONTATO",
                PercentualTaxaPropostaConcorrente = 101M,
                CelularContato = "99989-9999",
                TelefoneContato = "2222-2222"
            };
            var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
