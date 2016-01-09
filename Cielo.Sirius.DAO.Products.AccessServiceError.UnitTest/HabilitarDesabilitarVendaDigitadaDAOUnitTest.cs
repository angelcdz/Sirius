using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products.AccessServiceError.UnitTest
{
    [TestClass]
    public class HabilitarDesabilitarVendaDigitadaDAOUnitTest
    {
        [TestMethod]
        public void TechnicalErro_AccessError()
        {
            var requestData = new HabilitarDesabilitarVendaDigitadaRequest()
            {
                CodigoCliente = 10011009,                
                IndicaOperacao = "D",
                Protocolo = "3243432312",
                Origem = "CRM",
                TituloDaOcorrencia = "Titulo da Ocorrencia",
                Cliente = "Cliente",
                IlhaDeAtendimento = "Ilha de atendimento",
                CanalDeAtendimento =  "Telefone",
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
            Assert.AreEqual(response.ErrorCode, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR, "Response.ErrorCode is not DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR");
        }
    }
}
