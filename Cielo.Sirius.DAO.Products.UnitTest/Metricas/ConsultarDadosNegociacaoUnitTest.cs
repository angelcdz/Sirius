using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarDadosNegociacao;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarDadosNegociacaoUnitTest
    {
        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void Success()
        {
            var requestData = new ConsultarDadosNegociacaoRequest()
            {
                CodigoCliente = 10011001,
                DemandId = new Guid("f6be8be4-163a-e511-80f3-000d3ac01607"),
                ECNumber = new Guid("4F76FF78-743C-E511-80F9-000D3AC0010E"),
                IlhaAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                //IlhaAtendimento = "9b54f2d3-5335-e511-80e5-000d3ac01b55",
                TipoDemanda = 123456,
                UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
            };
            var proxy = new Proxy.ProdutosServiceClient();
            var response = proxy.ConsultarDadosNegociacao(requestData);

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }
    }
}
