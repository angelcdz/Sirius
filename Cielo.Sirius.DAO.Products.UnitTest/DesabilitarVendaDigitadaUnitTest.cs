using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.DAO.Products.UnitTest.CRM;
using Cielo.Sirius.DAO.Products.UnitTest.ProdutosService;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
    [TestClass]
    public class DesabilitarVendaDigitadaUnitTest
    {
        [TestMethod]
        public void DesabilitarVendaDigitadaSucessoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableTypedSaleAc);

            var response = new ProdutosServiceClient().HabilitarDesabilitarVendaDigitada(
                new HabilitarDesabilitarVendaDigitadaRequest()
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
                    },
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarVendaDigitadaSucessoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableTypedSaleAc);

            var response = new ProdutosServiceClient().HabilitarDesabilitarVendaDigitada(
                new HabilitarDesabilitarVendaDigitadaRequest()
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
                    },
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                }
            );

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarVendaDigitadaErroTecnicoOSBErroCRM()
        {
            (new CRMContext()).DisableAction(Actions.PrSvDisableTypedSaleAc);

            var response = new ProdutosServiceClient().HabilitarDesabilitarVendaDigitada(
                new HabilitarDesabilitarVendaDigitadaRequest()
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
                    },
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.TechnicalError, response.Status);
        }

        [TestMethod]
        public void DesabilitarVendaDigitadaErroTecnicoOSBSucessoCRM()
        {
            (new CRMContext()).EnableAction(Actions.PrSvDisableTypedSaleAc);

            var response = new ProdutosServiceClient().HabilitarDesabilitarVendaDigitada(
                new HabilitarDesabilitarVendaDigitadaRequest()
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
                    },
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.Success, response.Status);
        }

        [TestMethod]
        public void DesabilitarVendaDigitadaErroNegocioOSB()
        {
            var response = new ProdutosServiceClient().HabilitarDesabilitarVendaDigitada(
                new HabilitarDesabilitarVendaDigitadaRequest()
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
                    },
                    UserId = new Guid("C243440B-1A32-E511-80CE-000D3AC01090")
                });

            Assert.AreEqual(ExecutionStatus.BusinessError, response.Status);
        }
    }
}
