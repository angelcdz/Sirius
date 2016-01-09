using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class ConsultarProdutoHabilitadoClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_ParceladoOuAVista()
        {
            var requestData = new ConsultarProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 1000020140,
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoHabilitadoClienteDAO, ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produtos, "Response.Produtos is null");
            Assert.AreEqual(response.NumeroTotalRegistros, response.Produtos.Count, "NumeroTotalRegistros does not equal Response.Produtos.Count");

            response.Produtos.ForEach(
                produto =>
                {
                    Assert.IsNotNull(produto.PercentualTaxa, "PercentualTaxa is null");
                    Assert.IsFalse(string.IsNullOrEmpty(produto.CodigoProduto), "CodigoProduto is null or empty");
                    Assert.IsFalse(string.IsNullOrEmpty(produto.TipoGrupoProduto), "TipoGrupoProduto is null or empty");

                    int ordemApresentacao;
                    Assert.IsTrue(int.TryParse(produto.OrdemApresentacao, out ordemApresentacao), "OrdemApresentacao is not numeric");
                }
            );
            Assert.IsTrue(response.Produtos.Any(produto => produto.TipoGrupoProduto == "1" || produto.TipoGrupoProduto == "3"), "TipoGrupoProduto not found");
        }

        [TestMethod]
        public void Success_ParceladoSegmentado()
        {
            var requestData = new ConsultarProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 1000020140,
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoHabilitadoClienteDAO, ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produtos, "Response.Produtos is null");
            Assert.AreEqual(response.NumeroTotalRegistros, response.Produtos.Count, "NumeroTotalRegistros does not equal Response.Produtos.Count");

            response.Produtos.ForEach(
                produto =>
                {
                    Assert.IsNotNull(produto.PercentualTaxa, "PercentualTaxa is null");
                    Assert.IsFalse(string.IsNullOrEmpty(produto.CodigoProduto), "CodigoProduto is null or empty");
                    Assert.IsFalse(string.IsNullOrEmpty(produto.TipoGrupoProduto), "TipoGrupoProduto is null or empty");
                    
                    int ordemApresentacao;
                    Assert.IsTrue(int.TryParse(produto.OrdemApresentacao, out ordemApresentacao), "OrdemApresentacao is not numeric");
                }
            );
            Assert.IsTrue(response.Produtos.Any(produto => produto.TipoGrupoProduto == "4"));
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarProdutoHabilitadoClienteRequest()
            {
                CodigoCliente = 9999999999
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoHabilitadoClienteDAO, ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }
    }
}
