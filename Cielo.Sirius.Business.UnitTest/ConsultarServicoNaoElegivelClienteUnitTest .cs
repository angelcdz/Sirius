using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarServicoNaoElegivelClienteUnitTest
    {
        [TestMethod]
        public void BLSuccesso()
        {
            var request = new ConsultarServicoNaoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
                
            };

            var business = new ConsultarServicoNaoElegivelClienteBL();
            
            var response = business.Execute(request);

            Assert.AreEqual(true, response.Status);
        }
    }
}
