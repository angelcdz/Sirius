using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products.MockService.UnitTest
{
    [TestClass]
    public class HabilitarDesabilitarVendaDigitadaDAOUnitTest
    {
        [TestMethod]
        public void Success()
        {
            var requestData = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                IndicaOperacao = "H",
                Protocolo = "3243432312",
                Origem = "CRM",
                TituloDaOcorrencia = "Titulo da Ocorrencia",
                Cliente = "Cliente",
                IlhaDeAtendimento = "Ilha de atendimento",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                ArvoreDeAssunto = "Arvore de Assunto",
                ParentCaseId = "3213123",
                IdMotivo = Guid.NewGuid(),
                IdDemanda = Guid.NewGuid(),
            };
            requestData.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            IndicaAcao = "S",
                        }
            };
            var dao = DAOFactory.GetDAO<HabilitarDesabilitarVendaDigitadaDAO, HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.Success, "Response.Status is not Success");
            Assert.IsNotNull(response.DataPrevistaConclusaoSolicitacao, "Response.DataPrevistaConclusaoSolicitacao is null");
        }

        [TestMethod]
        public void BusinessError()
        {
            var requestData = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011005,
                IndicaOperacao = "H",
                Protocolo = "3243432312",
                Origem = "CRM",
                TituloDaOcorrencia = "Titulo da Ocorrencia",
                Cliente = "Cliente",
                IlhaDeAtendimento = "Ilha de atendimento",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                ArvoreDeAssunto = "Arvore de Assunto",
                ParentCaseId = "3213123",
                IdMotivo = Guid.NewGuid(),
                IdDemanda = Guid.NewGuid(),
            };
            requestData.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            IndicaAcao = "S",
                        }
            };
            var dao = DAOFactory.GetDAO<HabilitarDesabilitarVendaDigitadaDAO, HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.BusinessError, "Response.Status is not BusinessError");
        }

        [TestMethod]
        public void TechnicalErro_OSB()
        {
            var requestData = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011007,
                IndicaOperacao = "H",
                Protocolo = "3243432312",
                Origem = "CRM",
                TituloDaOcorrencia = "Titulo da Ocorrencia",
                Cliente = "Cliente",
                IlhaDeAtendimento = "Ilha de atendimento",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                ArvoreDeAssunto = "Arvore de Assunto",
                ParentCaseId = "3213123",
                IdMotivo = Guid.NewGuid(),
                IdDemanda = Guid.NewGuid(),
            };
            requestData.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            IndicaAcao = "S",
                        }
            };
            var dao = DAOFactory.GetDAO<HabilitarDesabilitarVendaDigitadaDAO, HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
        }

        [TestMethod]
        public void TechnicalErro_Timeout()
        {
            var requestData = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 99999999,
                IndicaOperacao = "H",
                Protocolo = "3243432312",
                Origem = "CRM",
                TituloDaOcorrencia = "Titulo da Ocorrencia",
                Cliente = "Cliente",
                IlhaDeAtendimento = "Ilha de atendimento",
                CanalDeAtendimento = "Telefone",
                CaseType = "Case Type",
                ArvoreDeAssunto = "Arvore de Assunto",
                ParentCaseId = "3213123",
                IdMotivo = Guid.NewGuid(),
                IdDemanda = Guid.NewGuid(),
            };
            requestData.DadosVendaDigitada = new List<HabilitarDesabilitarVendaDigitadaDTO>
                    {
                        new HabilitarDesabilitarVendaDigitadaDTO()
                        {
                            CodigoProduto = "01",
                            IndicaAcao = "S",
                        }
            };
            var dao = DAOFactory.GetDAO<HabilitarDesabilitarVendaDigitadaDAO, HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>();
            var response = dao.Execute(requestData);

            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(response.Status, ExecutionStatus.TechnicalError, "Response.Status is not TechnicalError");
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_TIMEOUT_ERROR");
        }
    }
}