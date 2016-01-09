using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.DAO.Products.CRM;
using Cielo.Sirius.DAO.Products.UnitTest.CRM;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class DesabilitarProdutoUnitTest
    {
        [TestMethod]
        public void DesabilitarProdutoSucessoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableProductAc);

            var response = new ProdutosServiceClient().DesabilitarProduto(
                new DesabilitarProdutoRequest()
                {
                    Protocolo = "0000222",
                    CodigoCliente = 10011001,
                    CodigoProduto = 3,
                    NomeSolicitante = "Cielo",
                    Origem = "Dynamics CRM",
                    TelefoneSolicitante = "985435678",
                    CodigoEmpresa = "123456",
                    MotivoSolicitacao = "Nova demanda",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                    DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarProdutoSucessoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableProductAc);

            var response = new ProdutosServiceClient().DesabilitarProduto(
                new DesabilitarProdutoRequest()
                {
                    Protocolo = "0000222",
                    CodigoCliente = 10011001,
                    CodigoProduto = 3,
                    NomeSolicitante = "Cielo",
                    Origem = "Dynamics CRM",
                    TelefoneSolicitante = "985435678",
                    CodigoEmpresa = "123456",
                    MotivoSolicitacao = "Nova demanda",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                    DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607"),
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarProdutoErroTecnicoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableProductAc);

            var response = new ProdutosServiceClient().DesabilitarProduto(new DesabilitarProdutoRequest() 
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarProdutoErroTecnicoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableProductAc);

            var response = new ProdutosServiceClient().DesabilitarProduto(new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarProdutoErroNegocioOSB()
        {
            var response = new ProdutosServiceClient().DesabilitarProduto(new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 66,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
        }
    }
}
