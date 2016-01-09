using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace MockGenerator
{
    [TestClass]
    public class DesabilitarVendaDigitadaMock : MockBase
    {
        [TestMethod]
        public void DesabilitarVendaDigitadaUnitTest()
        {
            var mockSets = new List<MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>>();

            var request = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                IndicaOperacao = "D",
                TituloDaOcorrencia = "0000222",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitação de Venda Digitada",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("febe8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("92e30986-573f-e511-80cb-000d3ac00701"),
                DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "02",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "03",
                            NomeProduto = "Presentation"
                        }
                    }
            };

            var response = new HabilitarDesabilitarVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success

            };

            var mockSet1 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            mockSet1.request = request;
            mockSet1.response = response;

            mockSets.Add(mockSet1);

            request = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                IndicaOperacao = "D",
                TituloDaOcorrencia = "0000222",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitação de Venda Digitada",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("febe8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("92e30986-573f-e511-80cb-000d3ac00701"),
                DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "04",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "05",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "06",
                            NomeProduto = "Presentation"
                        }
                    }
            };

            response = new HabilitarDesabilitarVendaDigitadaResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet2 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                IndicaOperacao = "D",
                TituloDaOcorrencia = "0000222",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitação de Venda Digitada",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("febe8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("92e30986-573f-e511-80cb-000d3ac00701"),
                DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "07",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "08",
                            NomeProduto = "Presentation"
                        },
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "09",
                            NomeProduto = "Presentation"
                        }
                    }
            };

            response = new HabilitarDesabilitarVendaDigitadaResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet3 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockDesabilitarVendaDigitadaUnitTest.xml", mockSets);
        }
    }
}
