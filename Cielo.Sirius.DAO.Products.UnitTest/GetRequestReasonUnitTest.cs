using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class GetRequestReasonUnitTest
    {
        [TestMethod]
        public void TestServicoDemandaSemMotivoCadastrado()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.GetRequestReason(new GetRequestReasonRequest()
            {
                DemandId = new Guid("00000000-0000-0000-0000-000000000000"),
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
            Assert.AreEqual(0, response.Reasons.Count);
        }

        [TestMethod]
        public void TestServicoDemanda1MotivoCadastrado()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.GetRequestReason(new GetRequestReasonRequest()
            {
                DemandId = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"), //Demanda: Habilitar Serviço
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
            Assert.AreEqual(1, response.Reasons.Count);
        }

        [TestMethod]
        public void TestServicoDemanda5MotivosCadastrados()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.GetRequestReason(new GetRequestReasonRequest()
            {
                DemandId = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"), //Demanda: Desabilitar Serviço
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
            Assert.AreEqual(5, response.Reasons.Count);
        }

        [TestMethod]
        public void TestServicoDemanda100MotivosCadastrados()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.GetRequestReason(new GetRequestReasonRequest()
            {
                DemandId = new Guid("f6be8be4-163a-e511-80f3-000d3ac01607"), //Demanda: Habilitar Produto
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
            Assert.AreEqual(100, response.Reasons.Count);
        }

        [TestMethod]
        public void TestServicoDemandaNaoExiste()
        {
            var svc = new ProdutosServiceClient();
            var response = svc.GetRequestReason(new GetRequestReasonRequest()
            {
                DemandId = Guid.Empty,
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
            Assert.AreEqual(0, response.Reasons.Count);
        }
    }
}
