using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class ConsultarProdutoElegivelClienteDAOUnitTest
    {
        [TestMethod]
        public void Success_ParceladoOuAVista()
        {
            var requestData = new ConsultarProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011001,
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.Produtos, "Response.Produtos is null");

            response.Produtos.ForEach(
                produto =>
                {
                    Assert.IsFalse(string.IsNullOrEmpty(produto.CodigoProduto), "CodigoProduto is null or empty");
                    Assert.IsFalse(string.IsNullOrEmpty(produto.TipoGrupoProduto), "TipoGrupoProduto is null or empty");

                    int ordemApresentacao;
                    Assert.IsTrue(int.TryParse(produto.OrdemApresentacao, out ordemApresentacao), "OrdemApresentacao is not numeric");
                }
            );
            Assert.IsTrue(response.Produtos.Any(produto => produto.TipoGrupoProduto == "1" || produto.TipoGrupoProduto == "3"), "TipoGrupoProduto not found");
        }

        [TestMethod]
        public void BusinessError_EcInexistente()
        {
            var requestData = new ConsultarProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011005
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new ConsultarProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011007
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new ConsultarProdutoElegivelClienteRequest()
            {
                CodigoCliente = 10011008
            };
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}