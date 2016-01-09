using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class HabilitarProdutoDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new HabilitarProdutoRequest
            {
                Protocolo = "123456",
                CodigoCliente = 99999999,
                CodigoProduto = "70",
                QuantidadeParcelas = "0",
                PercentualTaxa = 1.5M,
                NomeSolicitante = "SOLICITANTE",
                Origem = "CRM",
                TelefoneSolicitante = "99999-9999",
                CodigoEmpresa = "1",
                FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>
                {
                    new HabilitarProdutoFaixaTaxaSegmentadoDTO
                    {
                        CodigoFaixa = "0",
                        NumeroFinalParcelaFaixa = "0",
                        NumeroInicialParcelaFaixa = "0",
                        PercentualTaxaFaixa = 0
                    }
                }
            };
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}