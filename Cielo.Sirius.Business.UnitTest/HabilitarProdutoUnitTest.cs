using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class HabilitarProdutoUnitTest
    {
        [TestMethod]
        public void Sucesso()
        {
            var request = new HabilitarProdutoRequest();
            request.FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>();

            var FaixaTaxaSegmentado = new HabilitarProdutoFaixaTaxaSegmentadoDTO()
            {
                PercentualTaxaFaixa = 1.5d,
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "4",
                CodigoFaixa = "089",
            };

            request.Protocolo = "101010";
            request.CodigoCliente = 1;
            request.CodigoProduto = "008";
            request.QuantidadeParcelas = "3";
            request.PercentualTaxa = 1.5m;
            request.NomeSolicitante = "Felipe";
            request.Origem = "CRM";
            request.TelefoneSolicitante = "99999000";
            request.CodigoEmpresa = "002";

            request.FaixasTaxaSegmentado.Add(FaixaTaxaSegmentado);

            var business = new HabilitarProdutoBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("OSB", response.SistemaLegado);
            Assert.AreEqual(33, response.SolicitacaoCentralAtendimento.CodigoSolicitacao);
            Assert.AreEqual(DateTime.Today, response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao);

        }

        [TestMethod]
        public void CodigoClienteNaoExistente()
        {
            var request = new HabilitarProdutoRequest();
            request.FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>();

            var FaixaTaxaSegmentado = new HabilitarProdutoFaixaTaxaSegmentadoDTO()
            {
                PercentualTaxaFaixa = 1.5d,
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa= "4",
                CodigoFaixa = "089",
            };

            request.Protocolo = "101010";
            request.CodigoCliente = -1;
            request.CodigoProduto = "008";
            request.QuantidadeParcelas = "3";
            request.PercentualTaxa = 1.5m;
            request.NomeSolicitante = "Felipe";
            request.Origem = "CRM";
            request.TelefoneSolicitante = "99999000";
            request.CodigoEmpresa = "002";

            request.FaixasTaxaSegmentado.Add(FaixaTaxaSegmentado);


            var business = new HabilitarProdutoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoProdutoNulo()
        {
            var request = new HabilitarProdutoRequest();
            request.FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>();

            var FaixaTaxaSegmentado = new HabilitarProdutoFaixaTaxaSegmentadoDTO()
            {
                PercentualTaxaFaixa = 1.5d,
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "4",
                CodigoFaixa = "089",
            };

            request.Protocolo = "101010";
            request.CodigoCliente = 1;
            request.CodigoProduto = null;
            request.QuantidadeParcelas = "3";
            request.PercentualTaxa = 1.5m;
            request.NomeSolicitante = "Felipe";
            request.Origem = "CRM";
            request.TelefoneSolicitante = "99999000";
            request.CodigoEmpresa = "002";

            request.FaixasTaxaSegmentado.Add(FaixaTaxaSegmentado);


            var business = new HabilitarProdutoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }


    }
}
