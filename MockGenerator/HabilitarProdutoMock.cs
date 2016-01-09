using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    [TestClass]
    public class HabilitarProdutoMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<HabilitarProdutoRequest, HabilitarProdutoResponse>>();

            var request = new HabilitarProdutoRequest();
            request.CodigoCliente = 1;
            request.CodigoEmpresa = "002";
            request.CodigoProduto = "008";
            request.Protocolo = "101010";
            request.QuantidadeParcelas = "3";
            request.PercentualTaxa = 1.5m;
            request.Origem = "CRM";
            request.NomeSolicitante = "Felipe";
            request.TelefoneSolicitante = "99999000";
            request.FaixasTaxaSegmentado = new List<HabilitarProdutoFaixaTaxaSegmentadoDTO>();
            request.FaixasTaxaSegmentado.Add(new HabilitarProdutoFaixaTaxaSegmentadoDTO()
            {
                CodigoFaixa = "089",
                PercentualTaxaFaixa = 1.5d,
                NumeroInicialParcelaFaixa = "1",
                NumeroFinalParcelaFaixa = "4",
            });

            var response = new HabilitarProdutoResponse();
            response.Status = ExecutionStatus.Success;
            response.StatusRetorno = "1";
            response.SistemaLegado = "OSB";

            response.SolicitacaoCentralAtendimento = new HabilitarProdutoSolicitacaoCentralAtendimentoDTO
            {
                CodigoSolicitacao = "33",
                DataPrevistaConclusaoSolicitacao = DateTime.Today,
            };

            var mockSet = new MockSet<HabilitarProdutoRequest, HabilitarProdutoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\HabilitarProdutoMock.xml", mockSets);

        }

        [TestMethod]
        public void ErrorData()
        {
        }
    }
}
