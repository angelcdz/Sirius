using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
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
    public class SolicitarNegociacaoTaxaMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>>();

            var request = new SolicitarNegociacaoTaxaRequest();
            var response = new SolicitarNegociacaoTaxaResponse();

            var mockSet1 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

            request.CelularContato ="985424789";
            request.CodigoCliente = 10011001;
            request.CodigoProduto = "65";
            request.NomeContato = "Cielo";
            request.PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1);
            request.Protocolo = "0000222";
            request.TelefoneContato = "985435678";
                        
            request.IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607");
            request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

            response.Status = ExecutionStatus.Success;
            response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            response.CodigoSolicitacao = "1";
            response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            response.SistemaLegado = "Sistema Legado fake";
            response.StatusRetorno = "Concluído";

            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);


            request = new SolicitarNegociacaoTaxaRequest();
            response = new SolicitarNegociacaoTaxaResponse();

            var mockSet2 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

            request.CelularContato = null;
            request.CodigoCliente = 10011001;
            request.CodigoProduto = "6";
            request.NomeContato = "Cielo";
            request.PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5);
            request.Protocolo = "0000222";
            request.TelefoneContato = null;
            request.ArvoreDeAssunto = "Negociação de Taxa";
            request.CanalDeAtendimento = "Telefone";
            request.CaseType = "Solicitação";
            request.TituloDaOcorrencia = "Titulo de ocorrencia";
            request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

            request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
            request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
            request.IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090";
            request.IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607");
            request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

            response.Status = ExecutionStatus.BusinessError;
            response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            response.CodigoSolicitacao = "1";
            response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            response.SistemaLegado = "Sistema Legado fake";
            response.StatusRetorno = "Status Retorno fake";

            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new SolicitarNegociacaoTaxaRequest();
            response = new SolicitarNegociacaoTaxaResponse();

            var mockSet3 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

            request.CelularContato = null;
            request.CodigoCliente = 10011001;
            request.CodigoProduto = "5";
            request.NomeContato = "Cielo";
            request.PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5);
            request.Protocolo = "0000222";
            request.TelefoneContato = null;
            request.ArvoreDeAssunto = "Negociação de Taxa";
            request.CanalDeAtendimento = "Telefone";
            request.CaseType = "Solicitação";
            request.TituloDaOcorrencia = "Titulo de ocorrencia";
            request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

            request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
            request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
            request.IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090";
            request.IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607");
            request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

            response.Status = ExecutionStatus.Success;
            response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            response.CodigoSolicitacao = "1";
            response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            response.SistemaLegado = "Sistema Legado fake";
            response.StatusRetorno = "Status Retorno fake";

            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            request = new SolicitarNegociacaoTaxaRequest();
            response = new SolicitarNegociacaoTaxaResponse();

            var mockSet4 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

            request.CelularContato = null;
            request.CodigoCliente = 10011001;
            request.CodigoProduto = "3";
            request.NomeContato = "Cielo";
            request.PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5);
            request.Protocolo = "0000222";
            request.TelefoneContato = null;
            request.ArvoreDeAssunto = "Negociação de Taxa";
            request.CanalDeAtendimento = "Telefone";
            request.CaseType = "Solicitação";
            request.TituloDaOcorrencia = "Titulo de ocorrencia";
            request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

            request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
            request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
            request.IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090";
            request.IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607");
            request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

            response.Status = ExecutionStatus.Success;
            response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
            response.CodigoSolicitacao = "1";
            response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
            response.SistemaLegado = "Sistema Legado fake";
            response.StatusRetorno = "Status Retorno fake";

            mockSet4.request = request;
            mockSet4.response = response;
            mockSets.Add(mockSet4);

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaError.xml", response);

        #region ListadeMocks OLD

        //    var mockSet1 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Daniel";
        //    request.PercentualTaxaPropostaConcorrente = 100;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto1";
        //    request.CanalDeAtendimento = "Canal de atendimento1";
        //    request.CaseType = "Tipo de ocorrencia1";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia1";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");



        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";


        //    mockSet1.request = request;
        //    mockSet1.response = response;
        //    mockSets.Add(mockSet1);

        //    var mockSet2 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Debborah";
        //    request.PercentualTaxaPropostaConcorrente = 100;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto2";
        //    request.CanalDeAtendimento = "Canal de atendimento2";
        //    request.CaseType = "Tipo de ocorrencia2";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia2";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");


        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet1.request = request;
        //    mockSet1.response = response;
        //    mockSets.Add(mockSet2);

        //    var mockSet3 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "3";
        //    request.NomeContato = "Marcela";
        //    request.PercentualTaxaPropostaConcorrente = 100;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto3";
        //    request.CanalDeAtendimento = "Canal de atendimento3";
        //    request.CaseType = "Tipo de ocorrencia3";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia3";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "5";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet1.request = request;
        //    mockSet1.response = response;
        //    mockSets.Add(mockSet3);

        //    var mockSet4 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto4";
        //    request.CanalDeAtendimento = "Canal de atendimento4";
        //    request.CaseType = "Tipo de ocorrencia4";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia4";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet4.request = request;
        //    mockSet4.response = response;
        //    mockSets.Add(mockSet4);


        //    var mockSet5 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto5";
        //    request.CanalDeAtendimento = "Canal de atendimento5";
        //    request.CaseType = "Tipo de ocorrencia5";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia5";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.BusinessError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet5.request = request;
        //    mockSet5.response = response;
        //    mockSets.Add(mockSet5);


        //    var mockSet6 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto6";
        //    request.CanalDeAtendimento = "Canal de atendimento6";
        //    request.CaseType = "Tipo de ocorrencia6";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia5";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.NotExecuted;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet6.request = request;
        //    mockSet6.response = response;
        //    mockSets.Add(mockSet6);

        //    var mockSet7 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto7";
        //    request.CanalDeAtendimento = "Canal de atendimento7";
        //    request.CaseType = "Tipo de ocorrencia7";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia7";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.Warning;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet7.request = request;
        //    mockSet7.response = response;
        //    mockSets.Add(mockSet7);

        //    var mockSet8 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet8.request = request;
        //    mockSet8.response = response;
        //    mockSets.Add(mockSet8);


        //    var mockSet9 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");


        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet9.request = request;
        //    mockSet9.response = response;
        //    mockSets.Add(mockSet9);

        //    var mockSet10 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet8.request = request;
        //    mockSet8.response = response;
        //    mockSets.Add(mockSet8);

        //    var mockSet11 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "3";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet11.request = request;
        //    mockSet11.response = response;
        //    mockSets.Add(mockSet11);

        //    var mockSet12 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet12.request = request;
        //    mockSet12.response = response;
        //    mockSets.Add(mockSet12);

        //    var mockSet13 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet13.request = request;
        //    mockSet13.response = response;
        //    mockSets.Add(mockSet13);

        //    var mockSet14 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet14.request = request;
        //    mockSet14.response = response;
        //    mockSets.Add(mockSet14);

        //    var mockSet15 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet15.request = request;
        //    mockSet15.response = response;
        //    mockSets.Add(mockSet15);

        //    var mockSet16 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet16.request = request;
        //    mockSet16.response = response;
        //    mockSets.Add(mockSet16);




        //    var mockSet17 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet17.request = request;
        //    mockSet17.response = response;
        //    mockSets.Add(mockSet17);

        //    var mockSet18 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "3";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet18.request = request;
        //    mockSet18.response = response;
        //    mockSets.Add(mockSet18);


        //    var mockSet19 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet19.request = request;
        //    mockSet19.response = response;
        //    mockSets.Add(mockSet19);

        //    var mockSet20 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet20.request = request;
        //    mockSet20.response = response;
        //    mockSets.Add(mockSet20);

        //    var mockSet21 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "66";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet21.request = request;
        //    mockSet21.response = response;
        //    mockSets.Add(mockSet21);

        //    var mockSet22 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "65";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet22.request = request;
        //    mockSet22.response = response;
        //    mockSets.Add(mockSet22);

        //    var mockSet23 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet23.request = request;
        //    mockSet23.response = response;
        //    mockSets.Add(mockSet23);


        //    var mockSet24 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet24.request = request;
        //    mockSet24.response = response;
        //    mockSets.Add(mockSet24);



        //    var mockSet25 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet25.request = request;
        //    mockSet25.response = response;
        //    mockSets.Add(mockSet25);

        //    var mockSet26 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet26.request = request;
        //    mockSet26.response = response;
        //    mockSets.Add(mockSet26);

        //    var mockSet27 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "6";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet27.request = request;
        //    mockSet27.response = response;
        //    mockSets.Add(mockSet27);


        //    var mockSet28 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet28.request = request;
        //    mockSet28.response = response;
        //    mockSets.Add(mockSet28);

        //    var mockSet29 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "3";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet29.request = request;
        //    mockSet29.response = response;
        //    mockSets.Add(mockSet29);

        //    var mockSet30 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet30.request = request;
        //    mockSet30.response = response;
        //    mockSets.Add(mockSet30);

        //    var mockSet31 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "5";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet31.request = request;
        //    mockSet31.response = response;
        //    mockSets.Add(mockSet31);

        //    var mockSet32 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011001;
        //    request.CodigoProduto = "3";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet32.request = request;
        //    mockSet32.response = response;
        //    mockSets.Add(mockSet32);


        //    mockSet32 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011023;
        //    request.CodigoProduto = "1008";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.BusinessError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet32.request = request;
        //    mockSet32.response = response;
        //    mockSets.Add(mockSet32);

        //    mockSet32 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011023;
        //    request.CodigoProduto = "1009";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.TechnicalError;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet32.request = request;
        //    mockSet32.response = response;
        //    mockSets.Add(mockSet32);

        //    mockSet32 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011023;
        //    request.CodigoProduto = "1010";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet32.request = request;
        //    mockSet32.response = response;
        //    mockSets.Add(mockSet32);

        //    mockSet32 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

        //    request.CelularContato = "11963994947";
        //    request.CodigoCliente = 10011023;
        //    request.CodigoProduto = "1011";
        //    request.NomeContato = "Carlos";
        //    request.PercentualTaxaPropostaConcorrente = 2.5m;
        //    request.Protocolo = "1234567890";
        //    request.TelefoneContato = "11963994947";
        //    request.ArvoreDeAssunto = "Arvore de Assunto8";
        //    request.CanalDeAtendimento = "Canal de atendimento8";
        //    request.CaseType = "Tipo de ocorrencia8";
        //    request.TituloDaOcorrencia = "Titulo da ocorrencia8";
        //    request.UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    request.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");

        //    request.Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9";
        //    request.ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";
        //    request.IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55";
        //    request.IdDemanda = new Guid("900bf8be4-163a-e511-80f3-000d3ac01607");
        //    request.IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701");

        //    response.Status = ExecutionStatus.Success;
        //    response.CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405");
        //    response.CodigoSolicitacao = "1";
        //    response.DataPrevistaConclusaoSolicitacao = DateTime.Now;
        //    response.SistemaLegado = "Sistema Legado fake";
        //    response.StatusRetorno = "Status Retorno fake";

        //    mockSet32.request = request;
        //    mockSet32.response = response;
        //    mockSets.Add(mockSet32);
            
       this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxa.xml", mockSets);

            #endregion
        }
        
            
        [TestMethod]
        public void ErrorData()
        {
            var response = new SolicitarNegociacaoTaxaResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT";

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaError.xml", response);
        }

        [TestMethod]
        public void ErrorDataWarning()
        {
            var response = new SolicitarNegociacaoTaxaResponse();
            response.Status = ExecutionStatus.Warning;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT";

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaWarningError.xml", response);
        }

        [TestMethod]
        public void ErrorDataNotExecuted()
        {
            var response = new SolicitarNegociacaoTaxaResponse();
            response.Status = ExecutionStatus.NotExecuted;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT";

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaNotExecutedError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusinessError()
        {
            var response = new SolicitarNegociacaoTaxaResponse();
            response.Status = ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT";

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaBusinessError.xml", response);
        }

        [TestMethod]
        public void UnitTest()
        {
            var mockSets = new List<MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>>();

            var request = new SolicitarNegociacaoTaxaRequest()
                {
                    CelularContato = null,
                    CodigoCliente = 10011001,
                    CodigoProduto = "6",
                    NomeContato = "Cielo",
                    PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                    Protocolo = "0000222",
                    TelefoneContato = null,
                    ArvoreDeAssunto = "Negociação de Taxa",
                    CanalDeAtendimento = "Telefone",
                    CaseType = "Solicitação",
                    TituloDaOcorrencia = "Titulo de ocorrencia",
                    Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                    ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                    IlhaDeAtendimento = "9f54f2d3-5335-e511-80e5-000d3ac01b55",
                    IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                    IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701")
                };

            var response = new SolicitarNegociacaoTaxaResponse()
            {
                Status = ExecutionStatus.Success,
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CodigoSolicitacao = "1",
                DataPrevistaConclusaoSolicitacao = DateTime.Now,
                SistemaLegado = "Sistema Legado fake",
                StatusRetorno = "Status Retorno fake"
            };

            var mockSet1 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);


            request = new SolicitarNegociacaoTaxaRequest()
            {
                CelularContato = null,
                CodigoCliente = 10011001,
                CodigoProduto = "6",
                NomeContato = "Cielo",
                PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                Protocolo = "0000222",
                TelefoneContato = null,
                ArvoreDeAssunto = "Negociação de Taxa",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                TituloDaOcorrencia = "Titulo de ocorrencia",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701")
                
            };
            response = new SolicitarNegociacaoTaxaResponse()
            {
                Status = ExecutionStatus.TechnicalError,
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CodigoSolicitacao = "1",
                DataPrevistaConclusaoSolicitacao = DateTime.Now,
                SistemaLegado = "Sistema Legado fake",
                StatusRetorno = "Status Retorno fake"
            };

            var mockSet2 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new SolicitarNegociacaoTaxaRequest()
            {
                CelularContato = null,
                CodigoCliente = 10011001,
                CodigoProduto = "5",
                NomeContato = "Cielo",
                PercentualTaxaPropostaConcorrente = Convert.ToDecimal(1.5),
                Protocolo = "0000222",
                TelefoneContato = null,
                ArvoreDeAssunto = "Negociação de Taxa",
                CanalDeAtendimento = "Telefone",
                CaseType = "Solicitação",
                TituloDaOcorrencia = "Titulo de ocorrencia",
                Cliente = "99367d71-08ad-4aec-8e73-55ae151614f9",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                IdDemanda = new Guid("00bf8be4-163a-e511-80f3-000d3ac01607"),
                IdMotivo = new Guid("94e30986-573f-e511-80cb-000d3ac00701")
            };
            response = new SolicitarNegociacaoTaxaResponse()
            {
                Status = ExecutionStatus.BusinessError,
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CodigoSolicitacao = "1",
                DataPrevistaConclusaoSolicitacao = DateTime.Now,
                SistemaLegado = "Sistema Legado fake",
                StatusRetorno = "Status Retorno fake"
            };

            var mockSet3 = new MockSet<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();
            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockSolicitarNegociacaoTaxaUnitTest.xml", mockSets);
        }

    }
}