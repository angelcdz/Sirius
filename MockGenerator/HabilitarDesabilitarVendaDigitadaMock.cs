using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
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
    public class HabilitarDesabilitarVendaDigitadaMock : MockBase
    {
        [TestMethod]
        public void DesabilitarVendaDigitada()
        {
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",

                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "66",
                            IndicaAcao = "S",
                        }
                    };

                var response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success

                };

                var mockSet15 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "66",
                            IndicaAcao = "N",
                            NomeProduto = "ALIMENTAÇÃO (H)"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success,
                    DataPrevistaConclusaoSolicitacao = DateTime.Now.AddDays(10)
                };

                mockSet15 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet15.request = request;
                mockSet15.response = response;

                mockSets.Add(mockSet15);

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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",

                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "65",
                            IndicaAcao = "N"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    ErrorMessage = "Mensagem de erro de teste.",
                    Status = ExecutionStatus.BusinessError
                };

                var mockSet2 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet2.request = request;
                mockSet2.response = response;

                mockSets.Add(mockSet2);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011001,
                    IndicaOperacao = "H",
                    TituloDaOcorrencia = "0000222",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    ArvoreDeAssunto = "Desabilitação de Venda Digitada",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                    IdDemanda = new Guid("febe8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("92e30986-573f-e511-80cb-000d3ac00701"),
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",


                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "3",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success
                };

                var mockSet3 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet3.request = request;
                mockSet3.response = response;

                mockSets.Add(mockSet3);

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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "5",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success
                };

                var mockSet4 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet4.request = request;
                mockSet4.response = response;

                mockSets.Add(mockSet4);

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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "6",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success
                };

                var mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011023,
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "1008",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.BusinessError
                };

                mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011023,
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "1009",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.TechnicalError
                };
                mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011023,
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "66",
                            IndicaAcao = "N",
                            NomeProduto = "ERRO ALIMENTAÇÃO"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    ErrorMessage = "Mensagem de erro de teste.",
                    Status = ExecutionStatus.BusinessError
                };

                mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011023,
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "1010",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success
                };

                mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);

                request = new HabilitarDesabilitarVendaDigitadaRequest()
                {
                    CodigoCliente = 10011023,
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
                    Origem = "Dynamics CRM",
                    Protocolo = "0000222",
                };

                request.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "1011",
                            IndicaAcao = "S"
                        }
                    };

                response = new HabilitarDesabilitarVendaDigitadaResponse()
                {
                    Status = ExecutionStatus.Success
                };

                mockSet5 = new MockSet<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
                mockSet5.request = request;
                mockSet5.response = response;

                mockSets.Add(mockSet5);


                this.WriteObject(@"..\..\Generated\HabilitarDesabilitarVendaDigitadaMock.xml", mockSets);
            }
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new HabilitarDesabilitarVendaDigitadaResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

            this.WriteObject(@"..\..\Generated\HabilitarDesabilitarVendaDigitadaMockError.xml", response);
        }
    }
}
