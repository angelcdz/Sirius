using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.DAO.Products.UnitTest.CRM;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class DesabilitarServicoUnitTest
    {
        [TestMethod]
        public void DesabilitarServicoSucessoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableServiceAc);

            var response = new ProdutosServiceClient().DesabilitarServico(
                new DesabilitarServicoRequest()
                {
                    CodigoCliente = 10011001,
                    CodigoServico = "12",
                    TituloDaOcorrencia = "0000222",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    ArvoreDeAssunto = "Desabilitar Serviço",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                    IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarServicoSucessoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableServiceAc);

            var response = new ProdutosServiceClient().DesabilitarServico(
                new DesabilitarServicoRequest()
                {
                    CodigoCliente = 10011001,
                    CodigoServico = "12",
                    TituloDaOcorrencia = "0000222",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    ArvoreDeAssunto = "Desabilitar Serviço",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                    IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarServicoErroTecnicoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableServiceAc);

            var response = new ProdutosServiceClient().DesabilitarServico(new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarServicoErroTecnicoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableServiceAc);

            var response = new ProdutosServiceClient().DesabilitarServico(new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarServicoErroNegocioOSB()
        {
            var response = new ProdutosServiceClient().DesabilitarServico(new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "18",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
        }
    }
}
