using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarPrazosTaxasUnitTest
    {
        [TestMethod]
        public void Success_ListaVazia()
        {
            var response = new ProdutosServiceClient().ConsultarPrazosTaxasPrazoFlexivel(
                new ConsultarPrazosTaxasPrazoFlexivelRequest()
                {
                    CodigoCliente = 1,
                    CodigoGrupoPrazoFlexivel = 1,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.Success);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel.Count, 1);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel.Count, 0);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].IndicadorHabilitado, "H");
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].CodigoGrupoPrazoFlexivel, 1);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DescricaoGrupoPrazoFlexivel, "Grupo com retorno vazio");
        }

        [TestMethod]
        public void Success_ListaUmElemento()
        {
            var response = new ProdutosServiceClient().ConsultarPrazosTaxasPrazoFlexivel(
                new ConsultarPrazosTaxasPrazoFlexivelRequest()
                {
                    CodigoCliente = 2,
                    CodigoGrupoPrazoFlexivel = 2,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.Success);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel.Count, 1);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].IndicadorHabilitado, "H");
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].CodigoGrupoPrazoFlexivel, 2);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DescricaoGrupoPrazoFlexivel, "Grupo com retorno de um elemento");
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel.Count, 1);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel[0].PercentualTaxaGrupoPrazoFlexivel, 3d);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel[0].QuantidadeDiasGrupoPrazoFlexivel, 4);

        }

        [TestMethod]
        public void Success_ListaVinteElemento()
        {
            var response = new ProdutosServiceClient().ConsultarPrazosTaxasPrazoFlexivel(
                new ConsultarPrazosTaxasPrazoFlexivelRequest()
                {
                    CodigoCliente = 3,
                    CodigoGrupoPrazoFlexivel = 3,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.Success);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel.Count, 1);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].IndicadorHabilitado, "H");
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].CodigoGrupoPrazoFlexivel, 3);
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DescricaoGrupoPrazoFlexivel, "Grupo com retorno de vinte elementos");
            Assert.AreEqual(response.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel.Count, 20);

        }

        [TestMethod]
        public void Error_ListaBusinessError()
        {
            var response = new ProdutosServiceClient().ConsultarPrazosTaxasPrazoFlexivel(
                new ConsultarPrazosTaxasPrazoFlexivelRequest()
                {
                    CodigoCliente = 4,
                    CodigoGrupoPrazoFlexivel = 4,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError);

        }

        [TestMethod]
        public void Error_ListaTechnicalError()
        {
            var response = new ProdutosServiceClient().ConsultarPrazosTaxasPrazoFlexivel(
                new ConsultarPrazosTaxasPrazoFlexivelRequest()
                {
                    CodigoCliente = 5,
                    CodigoGrupoPrazoFlexivel = 5,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError);

        }

    }
}
