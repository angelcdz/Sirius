using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.UnitTest.CRM;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class SolicitarNegociacaoTaxaUnitTest
    {
        #region Sprint 4
        //[TestMethod]
        //public void Success()
        //{
        //    var requestData = new SolicitarNegociacaoTaxaRequest()
        //    {
        //        Protocolo = "123456",
        //        CodigoCliente = 0001591967,
        //        CodigoProduto = "43",
        //        NomeContato = "NOME CONTATO",
        //        PercentualTaxaPropostaConcorrente = 10.1M,
        //        CelularContato = "99989-9999",
        //        TelefoneContato = "2222-2222"
        //    };
        //    var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
        //    var response = dao.Execute(requestData);

        //    Assert.IsNotNull(response, "Response is null");
        //    Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
        //    Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "DataPrevistaConclusaoSolicitacao is null");
        //    Assert.IsNotNull(response.CodigoSolicitacao, "CodigoSolicitacao is null");
        //}

        //[TestMethod]
        //public void BusinessError_EcInexistente()
        //{
        //    var requestData = new SolicitarNegociacaoTaxaRequest()
        //    {
        //        Protocolo = "123456",
        //        CodigoCliente = 9999999999,
        //        CodigoProduto = "43",
        //        NomeContato = "NOME CONTATO",
        //        PercentualTaxaPropostaConcorrente = 10.1M,
        //        CelularContato = "99989-9999",
        //        TelefoneContato = "2222-2222"
        //    };
        //    var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
        //    var response = dao.Execute(requestData);

        //    Assert.IsNotNull(response, "Response is null");
        //    Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        //}

        //[TestMethod]
        //public void BusinessError_TaxaInvalida()
        //{
        //    var requestData = new SolicitarNegociacaoTaxaRequest()
        //    {
        //        Protocolo = "123456",
        //        CodigoCliente = 0001591967,
        //        CodigoProduto = "43",
        //        NomeContato = "NOME CONTATO",
        //        PercentualTaxaPropostaConcorrente = 101M,
        //        CelularContato = "99989-9999",
        //        TelefoneContato = "2222-2222"
        //    };
        //    var dao = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
        //    var response = dao.Execute(requestData);

        //    Assert.IsNotNull(response, "Response is null");
        //    Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        //} 
        #endregion

        #region Sprint 5
        [TestMethod]
        public void SolicitarNegociacaoTaxaSucessoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvRateChengNegotiationRequestAc);

            var response = new ProdutosServiceClient().SolicitarNegociacaoTaxaProdutoComercial(
                new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "6",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
            Assert.AreEqual("Sistema Legado fake", response.SistemaLegado);
            Assert.AreEqual("Status Retorno fake", response.StatusRetorno);
        }

        [TestMethod]
        public void SolicitarNegociacaoTaxaSucessoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvRateChengNegotiationRequestAc);

            var response = new ProdutosServiceClient().SolicitarNegociacaoTaxaProdutoComercial(
                new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "6",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void SolicitarNegociacaoTaxaErroTecnicoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvRateChengNegotiationRequestAc);

            var response = new ProdutosServiceClient().SolicitarNegociacaoTaxaProdutoComercial(
                new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "6",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void SolicitarNegociacaoTaxaErroTecnicoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvRateChengNegotiationRequestAc);

            var response = new ProdutosServiceClient().SolicitarNegociacaoTaxaProdutoComercial(
                new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "6",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void SolicitarNegociacaoTaxaErroNegocioOSB()
        {
            var response = new ProdutosServiceClient().SolicitarNegociacaoTaxaProdutoComercial(
                new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "5",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
        } 
        #endregion
    }
}
