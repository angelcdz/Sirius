using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class AlterarProdutoCreditoParceladoSegmentadoDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new AlterarProdutoCreditoParceladoSegmentadoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 10011009,
                CodigoProduto = "19",
                QuantidadeParcelas = "0",
                Faixas = new List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO>
                {
                    new AlterarProdutoCreditoParceladoSegmentadoFaixaDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}