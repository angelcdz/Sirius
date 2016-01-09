using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Business.Products;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class HabilitarDesabilitarVendaDigitadaUnitTest
    {
        [TestMethod]
        public void Successo()
        {
            var request = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 1,
                ArvoreDeAssunto = "Árvore de Assunto",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                Cliente = "Cliente",
                //EstabelecimentoComercial = "Estabelecimento Comercial",
                IndicaOperacao = "D",
                IlhaDeAtendimento = "Ilha de Atendimento",
                TituloDaOcorrencia = "Titulo da Ocorrência",
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                ParentCaseId = "be12ef3a-000f-e511-80c0-00155d0ef405"
            };

            request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            IndicaAcao = "D"
                        }
                    };

            var business = new HabilitarDesabilitarVendaDigitadaBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);
        }

        [TestMethod]
        public void BusinessError()
        {
            var request = new HabilitarDesabilitarVendaDigitadaRequest()
             {
                 CodigoCliente = 2,
                 ArvoreDeAssunto = "Árvore de Assunto",
                 CanalDeAtendimento = "Telefone",
                 CaseType = "Case Type",
                 Cliente = "Cliente",
                 //EstabelecimentoComercial = "Estabelecimento Comercial",
                 IndicaOperacao = "D",
                 IlhaDeAtendimento = "Ilha de Atendimento BE",
                 TituloDaOcorrencia = "Titulo da Ocorrência BE",
                 UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                 CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                 ParentCaseId = "be12ef3a-000f-e511-80c0-00155d0ef405"
             };

            request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "02",
                            IndicaAcao = "D"
                        }
                    };

            var business = new HabilitarDesabilitarVendaDigitadaBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.BusinessError);
        }

        [TestMethod]
        public void TechnicalError()
        {
            var request = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 3,
                ArvoreDeAssunto = "Árvore de Assunto",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                Cliente = "Cliente",
                //EstabelecimentoComercial = "Estabelecimento Comercial",
                IndicaOperacao = "D",
                IlhaDeAtendimento = "Ilha de Atendimento TE",
                TituloDaOcorrencia = "Titulo da Ocorrência TE",
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                ParentCaseId = "be12ef3a-000f-e511-80c0-00155d0ef405"
            };

            request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "03",
                            IndicaAcao = "D"
                        }
                    };

            var business = new HabilitarDesabilitarVendaDigitadaBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.TechnicalError);
        }

        [TestMethod]
        public void CodigoNaoExistente()
        {
            var request = new HabilitarDesabilitarVendaDigitadaRequest();
            request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>();

            var DadoVendaDigitada = new HabilitarDesabilitarVendaDigitadaDTO()
            {
                CodigoProduto = "CodigoProduto",
                IndicaAcao = "IndicaAcao"
            };

            request.CodigoCliente = -1;
            request.IndicaOperacao = "S";
            request.DadosVendaDigitada.Add(DadoVendaDigitada);
            //Resultados de acordo com o mock gerado

            var business = new HabilitarDesabilitarVendaDigitadaBL();

            var response = business.Execute(request);

            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
