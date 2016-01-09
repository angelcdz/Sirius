using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.DesabilitarServico;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class TestDAOsCRMHabDesServicos
    {
        [TestMethod]
        public void HabServico()
        {
            var request = new HabilitarServicoRequest()
            {
                ArvoreAssunto = "ArvoreAssuntoTest",
                CanalDeAtendimento = "CanalDeAtendimentoTest",
                CaseType = "CaseTypeTest",
                Cliente = "ClienteTest",
                CodigoCliente = 10011001, //Tem que ser esse, pra conseguir achar o GUID desse cara no CRM
                CodigoServico = "CodigoServicoTest",
                CorrelationId = new Guid("00000000-0000-0000-0000-000000000000"),
                EstabelecimentoComercial = "EstabelecimentoComercialTest",
                IlhaDeAtendimento = "IlhaDeAtendimentoTest",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597", //Ocorrencia que criei para testes
                TituloOcorrencia = "Minha Primeira Ocorrência",
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            };
            var srv = new ProdutosServiceClient();
            var response = srv.HabilitarServico(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabServico()
        {
            var request = new DesabilitarServicoRequest()
            {
                CanalDeAtendimento = "CanalDeAtendimentoTest",
                CaseType = "CaseTypeTest",
                Cliente = "ClienteTest",
                CodigoCliente = 10011001,
                CodigoServico = "CodigoServicoTest",
                CorrelationId = new Guid("00000000-0000-0000-0000-000000000000"),
                IlhaDeAtendimento = "IlhaDeAtendimentoTest",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597", //Ocorrencia que criei para testes
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            };
            var srv = new ProdutosServiceClient();
            var response = srv.DesabilitarServico(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }
    }
}
