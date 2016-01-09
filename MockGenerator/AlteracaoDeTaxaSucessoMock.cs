using Cielo.Sirius.Contracts.AlterarTaxasProdutoCreditoParceladoSegmentado;
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
    public class AlteracaoDeTaxaSucessoMock : MockBase
    {

        [TestMethod] 
        public void BasicData()
        {
            var mockSets = new List<MockSet<AlterarTaxasProdutoCreditoParceladoSegmentadoRequest, AlterarTaxasProdutoCreditoParceladoSegmentadoResponse>>();

            var request = new AlterarTaxasProdutoCreditoParceladoSegmentadoRequest();
            request.CodigoCliente = "1";
            request.CodigoProduto = "001";
            request.Protocolo = "33550028897";
            request.Faixas = new List<Faixa>();
            request.Faixas.Add(new Faixa()
            {

                QuantidadeParcelasLoja = 4,
                PercentualTaxa = 1,
                PercentualTaxaFaixa = 3,
                NumeroInicialParcelaFaixa = 3,
                NumeroFinalParcelaFaixa = 6,
                CodigoFaixa = "1",

            });
            var response = new AlterarTaxasProdutoCreditoParceladoSegmentadoResponse();
            response.Status = ExecutionStatus.Success;
            response.CodigoRetorno = 10;
            response.DescricaoRetornoMensagem = "Mensagem teste Sucesso";


            var mockSet = new MockSet<AlterarTaxasProdutoCreditoParceladoSegmentadoRequest, AlterarTaxasProdutoCreditoParceladoSegmentadoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            var mockSet2 = new MockSet<AlterarTaxasProdutoCreditoParceladoSegmentadoRequest, AlterarTaxasProdutoCreditoParceladoSegmentadoResponse>();

            request.CodigoCliente = "2";
            request.CodigoProduto = "001";
            request.Protocolo = "33550028897";
            request.Faixas = new List<Faixa>();
            request.Faixas.Add(new Faixa()
            {

                QuantidadeParcelasLoja = 4,
                PercentualTaxa = 1,
                PercentualTaxaFaixa = 3,
                NumeroInicialParcelaFaixa = 3,
                NumeroFinalParcelaFaixa = 6,
                CodigoFaixa = "1",

            });

            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            var mockSet3 = new MockSet<AlterarTaxasProdutoCreditoParceladoSegmentadoRequest, AlterarTaxasProdutoCreditoParceladoSegmentadoResponse>();

            request.CodigoCliente = "3";
            request.CodigoProduto = "001";
            request.Protocolo = "33550028897";
            request.Faixas = new List<Faixa>();
            request.Faixas.Add(new Faixa()
            {

                QuantidadeParcelasLoja = 4,
                PercentualTaxa = 1,
                PercentualTaxaFaixa = 3,
                NumeroInicialParcelaFaixa = 3,
                NumeroFinalParcelaFaixa = 6,
                CodigoFaixa = "1",

            });

            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\AlteracaoDeTaxaSucessoMock.xml", mockSets);

        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new AlterarTaxasProdutoCreditoParceladoSegmentadoResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT";

            this.WriteObject(@"..\..\Generated\AlteracaoDeTaxaSucessoMock.xml", response);
        }


    }
}
