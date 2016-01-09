using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarServicoElegivelClienteUnitTest
    {
        [TestMethod]
        public void BLSuccesso()
        {
            var request = new ConsultarServicoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
                
            };

            var business = new ConsultarServicoElegivelClienteBL();
            
            var response = business.Execute(request);

            Assert.AreEqual(true, response.Status);
        }
    }
}
