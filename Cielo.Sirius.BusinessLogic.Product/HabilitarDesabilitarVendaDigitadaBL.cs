using System;
using System.Collections.Generic;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.EnableDisableTypedSale;
using Cielo.Sirius.Foundation.DAO;

namespace Cielo.Sirius.Business.Products
{
    public class HabilitarDesabilitarVendaDigitadaBL : BusinessLogicBase<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>
    {
        public override HabilitarDesabilitarVendaDigitadaResponse Execute(HabilitarDesabilitarVendaDigitadaRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<HabilitarDesabilitarVendaDigitadaDAO, 
                                            HabilitarDesabilitarVendaDigitadaRequest, 
                                            HabilitarDesabilitarVendaDigitadaResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB == null || responseOSB.Status == ExecutionStatus.BusinessError)
                return responseOSB;

            var requestCRM = new EnableDisableTypedSaleRequest()
            {
                CommercialEstablishmentNumber = requestData.CodigoCliente,
                CorrelationId = requestData.CorrelationId,
                ArticleSubjectCode = requestData.ArvoreDeAssunto,
                ServiceChannelCode = requestData.CanalDeAtendimento,
                ProcessTypeCode = requestData.CaseType,
                AccountID = requestData.Cliente,
                CaseName = requestData.TituloDaOcorrencia,
                AgentGroupCode = requestData.IlhaDeAtendimento,
                ParentCaseId = requestData.ParentCaseId,
                UserId = requestData.UserId,
                ReasonId = requestData.IdMotivo,
                DemandId = requestData.IdDemanda,

                //StatusReasonCode será 1 se a DAO de OSB rodar corretamente, que no Option Set do CRM significa "Integrado"
                //Se não rodar corretamente, deve ser atribuído o valor 791880001, que no Option Set do CRM significa "Não integrado"
                //StatusReasonCode = responseOSB.Status == ExecutionStatus.Success ? 1 : 791880001,
                StatusReasonCode = 1,

                //Deve ser passada a data do SLA retornada do OSB
                ExpectedConclusionDate = responseOSB.DataPrevistaConclusaoSolicitacao,

                TypedSaleData = new List<EnableDisableTypedSaleDTO>()
            };

            foreach (var item in requestData.DadosVendaDigitada)
            {
                requestCRM.TypedSaleData.Add(new EnableDisableTypedSaleDTO()
                {
                    IndicatorAction = item.IndicaAcao,
                    ProductCode = item.CodigoProduto,
                    ProductName = item.NomeProduto
                });
            }

            DAOBase<EnableDisableTypedSaleRequest, EnableDisableTypedSaleResponse> daoCRM;

            if (requestData.IndicaOperacao == "D")
                daoCRM = DAOFactory.GetDAO<DisableTypedSaleDAO,
                                            EnableDisableTypedSaleRequest,
                                            EnableDisableTypedSaleResponse>();
            else if (requestData.IndicaOperacao == "H")
                daoCRM = DAOFactory.GetDAO<EnableTypedSaleDAO,
                                            EnableDisableTypedSaleRequest,
                                            EnableDisableTypedSaleResponse>();
            else
            {
                responseOSB.Status = ExecutionStatus.BusinessError;
                return responseOSB;
            }

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
