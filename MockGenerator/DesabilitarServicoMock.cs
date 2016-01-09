using Cielo.Sirius.Contracts.DesabilitarServico;
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
    public class DesabilitarServicoMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>>();

            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "12",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //////SolicitacaoCentralAtendimento //Solicitacao = new //SolicitacaoCentralAtendimento();
            ////Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            ////Solicitacao.Codigo//Solicitacao = 001;

            var response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ////SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet2 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

          response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet3 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "18",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet4 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;

            mockSets.Add(mockSet4);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "19",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet5 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;

            mockSets.Add(mockSet5);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "20",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //Retorno em andamento com Data  
            };

            var mockSet6 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet6.request = request;
            mockSet6.response = response;

            mockSets.Add(mockSet6);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "21",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO: Retorno concluido  
            };

            var mockSet7 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet7.request = request;
            mockSet7.response = response;

            mockSets.Add(mockSet7);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "22",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO: retorno sem data   
            };

            var mockSet8 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet8.request = request;
            mockSet8.response = response;

            mockSets.Add(mockSet8);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "23",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.TechnicalError,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Error  
            };

            var mockSet9 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet9.request = request;
            mockSet9.response = response;

            mockSets.Add(mockSet9);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "24",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet10 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet10.request = request;
            mockSet10.response = response;

            mockSets.Add(mockSet10);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "25",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.TechnicalError,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Indisponivel 
            };

            var mockSet11 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet11.request = request;
            mockSet11.response = response;

            mockSets.Add(mockSet11);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "26",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet12 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet12.request = request;
            mockSet12.response = response;

            mockSets.Add(mockSet12);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "27",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO:Mensagem de SLA Previsto   
            };

            var mockSet13 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet13.request = request;
            mockSet13.response = response;

            mockSets.Add(mockSet13);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "28",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO: Retorno data em andamento  
            };

            var mockSet14 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet14.request = request;
            mockSet14.response = response;

            mockSets.Add(mockSet14);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "29",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO: Retorno concluido 
            };

            var mockSet15 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet15.request = request;
            mockSet15.response = response;

            mockSets.Add(mockSet15);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "36",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                //TO DO: Retorno concluido 
            };

            var mockSet16 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet16.request = request;
            mockSet16.response = response;

            mockSets.Add(mockSet16);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "37",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.TechnicalError,
                //SolicitacaoCentralAtendimento = //Solicitacao,
                   
            };

            this.WriteObject(@"..\..\Generated\MockDesabilitarServico.xml", mockSets);
        }

        [TestMethod]
        public void BusinessError()
        {
            var mockSets = new List<MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>>();

            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "12",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //////SolicitacaoCentralAtendimento //Solicitacao = new //SolicitacaoCentralAtendimento();
            ////Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            ////Solicitacao.Codigo//Solicitacao = 001;

            var response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet2 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet3 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "18",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet4 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;

            mockSets.Add(mockSet4);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "19",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."  
            };

            var mockSet5 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;

            mockSets.Add(mockSet5);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "20",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet6 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet6.request = request;
            mockSet6.response = response;

            mockSets.Add(mockSet6);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "21",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet7 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet7.request = request;
            mockSet7.response = response;

            mockSets.Add(mockSet7);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "22",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet8 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet8.request = request;
            mockSet8.response = response;

            mockSets.Add(mockSet8);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "23",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet9 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet9.request = request;
            mockSet9.response = response;

            mockSets.Add(mockSet9);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "24",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet10 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet10.request = request;
            mockSet10.response = response;

            mockSets.Add(mockSet10);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "25",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet11 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet11.request = request;
            mockSet11.response = response;

            mockSets.Add(mockSet11);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "26",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet12 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet12.request = request;
            mockSet12.response = response;

            mockSets.Add(mockSet12);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "27",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet13 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet13.request = request;
            mockSet13.response = response;

            mockSets.Add(mockSet13);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "28",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet14 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet14.request = request;
            mockSet14.response = response;

            mockSets.Add(mockSet14);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "29",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet15 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet15.request = request;
            mockSet15.response = response;

            mockSets.Add(mockSet15);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "36",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };

            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."
            };

            var mockSet16 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet16.request = request;
            mockSet16.response = response;

            mockSets.Add(mockSet16);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "37",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607"),
                //Origem = "CRM",
                //Protocolo = "0000222",
            };


            //Solicitacao = new //SolicitacaoCentralAtendimento();
            //Solicitacao.DataPrevistaConclusao//Solicitacao = DateTime.Now;
            //Solicitacao.Codigo//Solicitacao = 001;

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "A integração retornou com erro."

            };

            this.WriteObject(@"..\..\Generated\MockDesabilitarServicoBusinessError.xml", mockSets);
        }
        
        [TestMethod]
        public void ErrorDataDesabilitarServico()
        {
            var response = new DesabilitarServicoResponse();
            response.Status = ExecutionStatus.TechnicalError;

            this.WriteObject(@"..\..\Generated\DesabilitarServicoError.xml", response);
        }

        [TestMethod]
        public void UnitTest()
        {
            var mockSets = new List<MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>>();

            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "12",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607")
            };


            var response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet1 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet1.request = request;
            mockSet1.response = response;

            mockSets.Add(mockSet1);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "15",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet2 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;

            mockSets.Add(mockSet2);

            request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 10011001,
                CodigoServico = "18",
                TituloDaOcorrencia = "0000222",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                ArvoreDeAssunto = "Desabilitar Serviço",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IdMotivo = new Guid("ef974b25-553f-e511-80cb-000d3ac00701"),
                IdDemanda = new Guid("0abf8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarServicoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet3 = new MockSet<DesabilitarServicoRequest, DesabilitarServicoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;

            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockDesabilitarServicoUnitTest.xml", mockSets);
        }
    }
}
