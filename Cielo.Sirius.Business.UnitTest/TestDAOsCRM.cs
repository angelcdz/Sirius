using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.HabilitarServico;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class TestDAOsCRM
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bl = new HabilitarServicoBL();
            bl.Execute(new HabilitarServicoRequest() {});
        }
    }
}
