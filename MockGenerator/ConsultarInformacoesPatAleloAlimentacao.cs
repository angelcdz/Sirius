using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
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
    public class ConsultarInformacoesPatAleloAlimentacao : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>>();

            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 1
            };

            var response = new ConsultarInformacoesPatAleloResponse();
            response.Status = ExecutionStatus.Success;

            response.DadosAlimentacao = new PatAleloAlimentacaoDTO();

            var dadosAlimentacao = new PatAleloAlimentacaoDTO();

            dadosAlimentacao.Aberto24Horas = true;
            dadosAlimentacao.Acougue = true;
            dadosAlimentacao.Armazem = true;
            dadosAlimentacao.CheckOutsLoja = "SIM";
            dadosAlimentacao.CodigoCliente = 012;
            dadosAlimentacao.CodigoProduto = "4002";
            dadosAlimentacao.DataAfiliacao = DateTime.MinValue;
            dadosAlimentacao.Domingo = false;
            dadosAlimentacao.Hipermercado = true;
            dadosAlimentacao.HorarioComercial = false;
            dadosAlimentacao.Hortimercado = true;
            dadosAlimentacao.IndicadorApresentacaoCartao = "SIM";
            dadosAlimentacao.IndicadorServicoDelivery = "SIM";
            dadosAlimentacao.IndicadorVendaInternet = "Não";
            dadosAlimentacao.LaticinioFrios = true;
            dadosAlimentacao.Mercearia = false;
            dadosAlimentacao.Noturno = true;
            dadosAlimentacao.Outros = false;
            dadosAlimentacao.Padaria = true;
            dadosAlimentacao.Peixaria = true;
            dadosAlimentacao.Sabado = true;
            dadosAlimentacao.SegundaSexta = true;
            dadosAlimentacao.Supermercado = true;
            dadosAlimentacao.ValorAreaAtendimentoPublico = "SIM";

            response.DadosAlimentacao = dadosAlimentacao;

            response.DadosRefeicao = new PatAleloRefeicaoDTO();

            var dadosRefeicao = new PatAleloRefeicaoDTO();

            dadosRefeicao.Aberto24Horas = true;
            dadosRefeicao.CodigoCliente = 012;
            dadosRefeicao.CodigoProduto = "4002";
            dadosRefeicao.DataAfiliacao = DateTime.MinValue;
            dadosRefeicao.Domingo = false;
            dadosRefeicao.HorarioComercial = false;
            dadosRefeicao.IndicadorApresentacaoCartao = "SIM";
            dadosRefeicao.IndicadorServicoDelivery = "SIM";
            dadosRefeicao.IndicadorVendaInternet = "Não";
            dadosRefeicao.Noturno = true;
            dadosRefeicao.Outros = false;
            dadosRefeicao.Padaria = true;
            dadosRefeicao.Sabado = true;
            dadosRefeicao.SegundaSexta = true;
            dadosRefeicao.ValorAreaAtendimentoPublico = "SIM";
            dadosRefeicao.Bar = true;
            dadosRefeicao.FastFood = false;
            dadosRefeicao.Lanchonete = true;
            dadosRefeicao.QuantidadeDeAssento = "22";
            dadosRefeicao.QuantidadeDeMaximaRefeicao = "1000";
            dadosRefeicao.QuantidadeDeMesa = "100";
            dadosRefeicao.Restaurante = true;

            response.DadosRefeicao = dadosRefeicao;

            var mockSet = new MockSet<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\ConsultarInformacoesPatAleloAlimentacao.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarInformacoesPatAleloResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(H)";

            this.WriteObject(@"..\..\Generated\ConsultarInformacoesPatAleloAlimentacaoError.xml", response);
        }
    }
}
