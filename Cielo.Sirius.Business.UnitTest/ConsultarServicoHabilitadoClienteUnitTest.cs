using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarServicoHabilitadoClienteUnitTest
    {
        [TestMethod]
        public void BLSuccesso()
        {
            var request = new ConsultarServicoHabilitadoClienteRequest()
            {
                CodigoCliente = 10011001,
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
                
            };

            var business = new ConsultarServicoHabilitadoClienteBL();
            
            var response = business.Execute(request);

            Assert.AreEqual(true, response.Status);
        }

        [TestMethod]
        public void CodigoClienteNaoExistente()
        {
            var request = new ConsultarServicoHabilitadoClienteRequest()
            {
                CodigoCliente = -1,
            };

            var business = new ConsultarServicoHabilitadoClienteBL();
            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            //Assert.AreEqual("RECORD NOT FOUND", response.FaultMessage);
        }

    }
}
