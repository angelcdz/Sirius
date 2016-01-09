using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;
using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;
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
    public class ConsultarProdutosPrazoFlexivelUnitTest
    {
        [TestMethod]
        public void Sucess_ListaUmElemento()
        {
            var response = new ProdutosServiceClient().ConsultarProdutosPrazoFlexivel(
                 new ConsultarProdutosPrazoFlexivelRequest()
                 {
                     CodigoCliente = 1,
                     UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                 }
             );

            //Resultados de acordo com o mock gerado
            Assert.AreEqual(2, response.CodigoGrupoPrazoFlexivel);
            Assert.AreEqual(111, response.Produtos[0].CodigoProduto);
            Assert.AreEqual("Retorno de Grupo com 1 elemento", response.Produtos[0].NomeProduto);
            Assert.AreEqual(899, response.Produtos[0].CodigoBandeira);
            Assert.AreEqual("Visa", response.Produtos[0].NomeBandeira);
            Assert.AreEqual(15, response.Produtos[0].QuantidadeDiasPrazo);
            Assert.AreEqual(2.5, response.Produtos[0].PercentualTaxaGarantia);
            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }
        
        [TestMethod]
        public void Sucess_ListaVinteElementos()
        {
            var response = new ProdutosServiceClient().ConsultarProdutosPrazoFlexivel(
                 new ConsultarProdutosPrazoFlexivelRequest()
                 {
                     CodigoCliente = 2,
                     UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                 }
             );

            //Resultados de acordo com o mock gerado
            Assert.AreEqual(3, response.CodigoGrupoPrazoFlexivel);
            Assert.AreEqual(222, response.Produtos[0].CodigoProduto);
            Assert.AreEqual("Produto Retorno de grupo com 20 elementos", response.Produtos[0].NomeProduto);
            Assert.AreEqual(899, response.Produtos[0].CodigoBandeira);
            Assert.AreEqual("Visa", response.Produtos[0].NomeBandeira);
            Assert.AreEqual(15, response.Produtos[0].QuantidadeDiasPrazo);
            Assert.AreEqual(2.5, response.Produtos[0].PercentualTaxaGarantia);
            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }
        
        [TestMethod]
        public void Sucess_ListaVazia()
        {
            var response = new ProdutosServiceClient().ConsultarProdutosPrazoFlexivel(
                 new ConsultarProdutosPrazoFlexivelRequest()
                 {
                     CodigoCliente = 3,
                     UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                 }
             );

            //Resultados de acordo com o mock gerado
            Assert.AreEqual(22, response.CodigoGrupoPrazoFlexivel);
            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }
        
        [TestMethod]
        public void Error_ListaBusinessError()
        {
            var response = new ProdutosServiceClient().ConsultarProdutosPrazoFlexivel(
                new ConsultarProdutosPrazoFlexivelRequest()
                {
                    CodigoCliente = 4,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError);
        }

        [TestMethod]
        public void Error_ListaTechnicalError()
        {
            var response = new ProdutosServiceClient().ConsultarProdutosPrazoFlexivel(
                new ConsultarProdutosPrazoFlexivelRequest()
                {
                    CodigoCliente = 5,
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError);
        }

    }
}
