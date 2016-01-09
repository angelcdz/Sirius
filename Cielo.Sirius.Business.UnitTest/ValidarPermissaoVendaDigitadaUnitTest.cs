using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ValidarPermissaoVendaDigitadaUnitTest
    {
        [TestMethod]
        public void Successo()
        {
            var request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 1,
                CodigoRamoAtividade = "Test",
                IndicaOperacao = "S"
            };

            var business = new ValidarPermissaoVendaDigitadaBL();
            
            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual("A", response.TipoDeMensagem);

            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            //Assert.IsNull(response.FaultCode);
            //Assert.IsNull(response.FaultMessage);
        }

        [TestMethod]
        public void CodigoNaoExistente()
        {
            var request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = -1,
                CodigoRamoAtividade = "Test",
                IndicaOperacao = "S"
            };

            var business = new ValidarPermissaoVendaDigitadaBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.IsNull(response.TipoDeMensagem);

            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
