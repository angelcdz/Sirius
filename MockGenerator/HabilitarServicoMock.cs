using Cielo.Sirius.Contracts.HabilitarServico;
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
    public class HabilitarServicoMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            //8    ok
            //9    ok
            //10   concluído
            //11   concluído
            //13   erro
            //16   concluído
            //30   ok
            //31   sem data
            //32   erro
            //33   sem data
            //34   sem data
            //35   erro

            var mockSets = new List<MockSet<HabilitarServicoRequest, HabilitarServicoResponse>>();

            var request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "8",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //SolicitacaoCentralAtendimento solicitacao = new SolicitacaoCentralAtendimento();
            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            var response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "9",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",


            };


            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
                {
                    Status = ExecutionStatus.Success,
                    //SolicitacaoCentralAtendimento = solicitacao,
                    DataSLA=DateTime.Now.AddDays(3)
                };


            var mockSet2 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "10",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet3 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "11",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet4 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;

            mockSets.Add(mockSet4);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "13",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet5 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;

            mockSets.Add(mockSet5);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "16",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                //DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet6 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet6.request = request;
            mockSet6.response = response;

            mockSets.Add(mockSet6);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "35",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
            };

            var mockSet7 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet7.request = request;
            mockSet7.response = response;

            mockSets.Add(mockSet7);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "1",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };
            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet8 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet8.request = request;
            mockSet8.response = response;

            mockSets.Add(mockSet8);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "2",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet9 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet9.request = request;
            mockSet9.response = response;

            mockSets.Add(mockSet9);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "3",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet10 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet10.request = request;
            mockSet10.response = response;

            mockSets.Add(mockSet10);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "4",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",

            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet11 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet11.request = request;
            mockSet11.response = response;

            mockSets.Add(mockSet11);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "5",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",


            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet12 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet12.request = request;
            mockSet12.response = response;

            mockSets.Add(mockSet12);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "6",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",
                //Origem = "CRM",
                //Protocolo = "0000222",


            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                //DataSLA=DateTime.Now.AddDays(3)
            };

            var mockSet13 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet13.request = request;
            mockSet13.response = response;

            mockSets.Add(mockSet13);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "7",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",

                //Origem = "CRM",
                //Protocolo = "0000222",


            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                //DataSLA=DateTime.Now.AddDays(3)
            };


            var mockSet14 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet14.request = request;
            mockSet14.response = response;

            mockSets.Add(mockSet14);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "400",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",

                //Origem = "CRM",
                //Protocolo = "0000222",


            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = solicitacao,
                DataSLA = DateTime.Now.AddDays(3)
            };


            var mockSet15 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet15.request = request;
            mockSet15.response = response;

            mockSets.Add(mockSet15);


            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222",

                //Origem = "CRM",
                //Protocolo = "0000222",


            };

            //solicitacao.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            //solicitacao.CodigoSolicitacao = 001;

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success
            };


            var mockSet16 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet16.request = request;
            mockSet16.response = response;

            mockSets.Add(mockSet16);

            this.WriteObject(@"..\..\Generated\HabilitarServicoMock.xml", mockSets);
        }

        [TestMethod]
        public void ErrorDataHabilitarServico()
        {
            var response = new HabilitarServicoResponse();
            response.Status = ExecutionStatus.TechnicalError;

            this.WriteObject(@"..\..\Generated\MockHabilitarServicoError.xml", response);
        }

        [TestMethod]
        public void UnitTest()
        {
            var mockSets = new List<MockSet<HabilitarServicoRequest, HabilitarServicoResponse>>();

            var request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "8",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222"
            };

            var response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = new DateTime(2015, 08, 24)
            };

            var mockSet = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "9",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222"
            };

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.TechnicalError,
                DataSLA = new DateTime(2015, 08, 24)
            };


            var mockSet2 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new HabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "10",
                ArvoreAssunto = "Habilitar Serviço",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("08bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("eb974b25-553f-e511-80cb-000d3ac00701"),
                TituloOcorrencia = "0000222"

            };

            response = new HabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = new DateTime(2015, 08, 24)
            };

            var mockSet3 = new MockSet<HabilitarServicoRequest, HabilitarServicoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockHabilitarServicoUnitTest.xml", mockSets);
        }
    }
}
