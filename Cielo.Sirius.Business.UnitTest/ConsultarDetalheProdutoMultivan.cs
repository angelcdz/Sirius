using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarDetalheProdutoMultivan
    {
        [TestMethod]
        public void Sucesso()
        {
            var request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 1,
                CodigoProduto = "0001"
            };

            var business = new ConsultarDetalheProdutoMultivanContratadoClienteBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual(new DateTime(2015, 1, 1), response.DetalhesMultivan[0].FimVigencia);
            Assert.AreEqual(new DateTime(2015, 1, 2), response.DetalhesMultivan[0].InicioVigencia);
            Assert.AreEqual("NomeEmpresaTeste", response.DetalhesMultivan[0].NomeEmpresa);
            Assert.AreEqual("NumeroCadastroEmpresaTeste", response.DetalhesMultivan[0].NumeroCadastroEmpresa);

            Assert.AreEqual(new DateTime(2015, 1, 1), response.DetalhesMultivan[1].FimVigencia);
            Assert.AreEqual(new DateTime(2015, 1, 2), response.DetalhesMultivan[1].InicioVigencia);
            Assert.AreEqual("NomeEmpresaTeste1", response.DetalhesMultivan[1].NomeEmpresa);
            Assert.AreEqual("NumeroCadastroEmpresaTeste1", response.DetalhesMultivan[1].NumeroCadastroEmpresa);

            Assert.AreEqual(new DateTime(2015, 1, 1), response.DetalhesMultivan[2].FimVigencia);
            Assert.AreEqual(new DateTime(2015, 1, 2), response.DetalhesMultivan[2].InicioVigencia);
            Assert.AreEqual("NomeEmpresaTeste2", response.DetalhesMultivan[2].NomeEmpresa);
            Assert.AreEqual("NumeroCadastroEmpresaTeste2", response.DetalhesMultivan[2].NumeroCadastroEmpresa);

            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoNaoExiste()
        {
            var request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = -1
            };

            var business = new ConsultarDetalheProdutoMultivanContratadoClienteBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.IsNull(response.DetalhesMultivan);

            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
