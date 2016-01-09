using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class InsertManualUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var response = new InsertManualDAO().Execute(new HabilitarDesabilitarVendaDigitadaRequest() { 
                                                            UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405") 
                                                        });
        }
    }
}
