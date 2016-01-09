using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarPrazosTaxasPrazoFlexivelUnitTest
    {
        [TestMethod]
        public void Sucesso()
        {
            var request = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 1
            };

            var business = new ConsultarPrazosTaxasPrazoFlexivelBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual("0001", response.GruposProdutoPrazoFlexivel[0].CodigoGrupoPrazoFlexivel);
            Assert.AreEqual("Flexivel", response.GruposProdutoPrazoFlexivel[0].DescricaoGrupoPrazoFlexivel);
            Assert.AreEqual("N",response.GruposProdutoPrazoFlexivel[0].IndicadorHabilitado);
            Assert.AreEqual(9999, response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel[0].PercentualTaxaGrupoPrazoFlexivel);
            Assert.AreEqual("100", response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel[0].QuantidadeDiasGrupoPrazoFlexivel);


            Assert.AreEqual("0002", response.GruposProdutoPrazoFlexivel[1].CodigoGrupoPrazoFlexivel);
            Assert.AreEqual("Não Flexivel", response.GruposProdutoPrazoFlexivel[1].DescricaoGrupoPrazoFlexivel);
            Assert.AreEqual("N", response.GruposProdutoPrazoFlexivel[1].IndicadorHabilitado);
            Assert.AreEqual(9999, response.GruposProdutoPrazoFlexivel[1].DadosTarifasGrupoProdutoPrazoFlexivel[0].PercentualTaxaGrupoPrazoFlexivel);
            Assert.AreEqual("100", response.GruposProdutoPrazoFlexivel[1].DadosTarifasGrupoProdutoPrazoFlexivel[0].QuantidadeDiasGrupoPrazoFlexivel);

            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoNaoExiste()
        {
            var request = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = -1
            };

            var business = new ConsultarPrazosTaxasPrazoFlexivelBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.IsNull(response.GruposProdutoPrazoFlexivel);

            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
