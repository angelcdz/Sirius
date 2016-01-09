using Cielo.Sirius.Contracts.DesabilitarServico;
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
    public class DesabilitarServicoDAOUnitTest
    {
        [TestMethod]
        public void TestDesabilitarServicoSucesso()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.DesabilitarServico(new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "12",
                TituloDaOcorrencia = "0000222",
                Cliente = "be12ef3a-000f-e511-80c0-00155d0ef405",
                IlhaDeAtendimento = "Ilha de Atendimento",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "na10ev7a-010d-g541-81f0-01275d0ik193",
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);
        }

        [TestMethod]
        public void TestDesabilitarServicoInexistente()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.DesabilitarServico(new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = string.Empty,
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.BusinessError);
        }
    }
}
