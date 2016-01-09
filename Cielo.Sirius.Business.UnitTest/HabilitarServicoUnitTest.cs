using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.HabilitarServico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class HabilitarServicoUnitTest
    {
        [TestMethod]
        public void Sucesso()
        {
            var request = new HabilitarServicoRequest()
            {
                CodigoCliente = 1,
                CodigoServico = "1"
            };

            var business = new HabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);
        }

        [TestMethod]
        public void CodigoClienteNaoExistente()
        {
            var request = new HabilitarServicoRequest()
            {
                CodigoCliente = -1,
                CodigoServico = "1"
            };

            var business = new HabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoServicoNaoExistente()
        {
            var request = new HabilitarServicoRequest()
            {
                CodigoCliente = 1,
                CodigoServico = "-1"
            };

            var business = new HabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status ==  Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}