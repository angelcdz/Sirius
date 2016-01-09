using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.DAO.Products.UnitTest.CRM;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class HabilitarServicoUnitTest
    {
        [TestMethod]
        public void HabilitarServicoSucessoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvEnableServiceAc);

            var response = new ProdutosServiceClient().HabilitarServico(
                new HabilitarServicoRequest()
                {
                    CodigoCliente = 10011001,
                    CodigoServico = "8",
                    ArvoreAssunto = "Habilitar Serviço",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                    TituloOcorrencia = "0000222",
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
            Assert.AreEqual(new DateTime(2015, 08, 24), response.DataSLA);
        }

        [TestMethod]
        public void HabilitarServicoSucessoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvEnableServiceAc);

            var response = new ProdutosServiceClient().HabilitarServico(
                new HabilitarServicoRequest()
                {
                    CodigoCliente = 10011001,
                    CodigoServico = "8",
                    ArvoreAssunto = "Habilitar Serviço",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                    TituloOcorrencia = "0000222",
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
            Assert.AreEqual(new DateTime(2015, 08, 24), response.DataSLA);
        }

        [TestMethod]
        public void HabilitarServicoErroTecnicoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvEnableServiceAc);

            var response = new ProdutosServiceClient().HabilitarServico(new HabilitarServicoRequest() 
            {
                CodigoCliente = 10011001,
                CodigoServico = "9",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
            Assert.AreEqual(new DateTime(2015, 08, 24), response.DataSLA);
        }

        [TestMethod]
        public void HabilitarServicoErroTecnicoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvEnableServiceAc);

            var response = new ProdutosServiceClient().HabilitarServico(new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "9",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
            Assert.AreEqual(new DateTime(2015, 08, 24), response.DataSLA);
        }

        [TestMethod]
        public void HabilitarServicoErroNegocioOSB()
        {
            var response = new ProdutosServiceClient().HabilitarServico(new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "10",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
            Assert.AreEqual(new DateTime(2015, 08, 24), response.DataSLA);
        }
    }
}
