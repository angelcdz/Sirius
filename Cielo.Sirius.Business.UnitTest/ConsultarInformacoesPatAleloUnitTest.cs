using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class ConsultarInformacoesPatAleloUnitTest
    {
        [TestMethod]
        public void Successo() 
        {
            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 1,
            };

            var business = new ConsultarInformacoesPatAleloBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);

            Assert.IsTrue(response.DadosAlimentacao.Aberto24Horas);
            Assert.IsTrue(response.DadosAlimentacao.Acougue);
            Assert.IsTrue(response.DadosAlimentacao.Armazem);
            Assert.AreEqual("SIM",response.DadosAlimentacao.CheckOutsLoja);
            Assert.AreEqual(012, response.DadosAlimentacao.CodigoCliente);
            Assert.AreEqual("4002", response.DadosAlimentacao.CodigoProduto);
            Assert.AreEqual(DateTime.MinValue, response.DadosAlimentacao.DataAfiliacao);
            Assert.IsFalse(response.DadosAlimentacao.Domingo);
            Assert.IsTrue(response.DadosAlimentacao.Hipermercado);
            Assert.IsFalse(response.DadosAlimentacao.HorarioComercial);
            Assert.IsTrue(response.DadosAlimentacao.Hortimercado);
            Assert.AreEqual("SIM", response.DadosAlimentacao.IndicadorApresentacaoCartao);
            Assert.AreEqual("SIM", response.DadosAlimentacao.IndicadorServicoDelivery);
            Assert.AreEqual("Não", response.DadosAlimentacao.IndicadorVendaInternet);
            Assert.IsTrue(response.DadosAlimentacao.LaticinioFrios);
            Assert.IsFalse(response.DadosAlimentacao.Mercearia);
            Assert.IsTrue(response.DadosAlimentacao.Noturno);
            Assert.IsFalse(response.DadosAlimentacao.Outros);
            Assert.IsTrue(response.DadosAlimentacao.Padaria);
            Assert.IsTrue(response.DadosAlimentacao.Peixaria);
            Assert.IsTrue(response.DadosAlimentacao.Sabado);
            Assert.IsTrue(response.DadosAlimentacao.SegundaSexta);
            Assert.IsTrue(response.DadosAlimentacao.Supermercado);
            Assert.AreEqual("SIM", response.DadosAlimentacao.ValorAreaAtendimentoPublico);

            Assert.IsTrue(response.DadosRefeicao.Aberto24Horas);
            Assert.AreEqual(012, response.DadosRefeicao.CodigoCliente);
            Assert.AreEqual("4002", response.DadosRefeicao.CodigoProduto);
            Assert.AreEqual(DateTime.MinValue, response.DadosRefeicao.DataAfiliacao);
            Assert.IsFalse(response.DadosRefeicao.Domingo);
            Assert.IsFalse(response.DadosRefeicao.HorarioComercial);
            Assert.AreEqual("SIM", response.DadosRefeicao.IndicadorApresentacaoCartao);
            Assert.AreEqual("SIM", response.DadosRefeicao.IndicadorServicoDelivery);
            Assert.AreEqual("Não", response.DadosRefeicao.IndicadorVendaInternet);
            Assert.IsTrue(response.DadosRefeicao.Noturno);
            Assert.IsFalse(response.DadosRefeicao.Outros);
            Assert.IsTrue(response.DadosRefeicao.Padaria);
            Assert.IsTrue(response.DadosRefeicao.Sabado);
            Assert.IsTrue(response.DadosRefeicao.SegundaSexta);
            Assert.AreEqual("SIM", response.DadosRefeicao.ValorAreaAtendimentoPublico);
            Assert.IsTrue(response.DadosRefeicao.Bar);
            Assert.IsFalse(response.DadosRefeicao.FastFood);
            Assert.IsTrue(response.DadosRefeicao.Lanchonete);
            Assert.AreEqual("22", response.DadosRefeicao.QuantidadeDeAssento);
            Assert.AreEqual("1000", response.DadosRefeicao.QuantidadeDeMaximaRefeicao);
            Assert.AreEqual("100", response.DadosRefeicao.QuantidadeDeMesa);
            Assert.IsTrue(response.DadosRefeicao.Restaurante);

        }

        [TestMethod]
        public void CodigoClienteNaoExistente()
        {
            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = -1,
            };

            var business = new ConsultarInformacoesPatAleloBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }

        [TestMethod]
        public void BusinessError()
        {
            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 1,
            };

            var business = new ConsultarInformacoesPatAleloBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.BusinessError);
        }

        [TestMethod]
        public void TechnicalError()
        {
            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = -1,
            };

            var business = new ConsultarInformacoesPatAleloBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.TechnicalError);
        }

    }
}
