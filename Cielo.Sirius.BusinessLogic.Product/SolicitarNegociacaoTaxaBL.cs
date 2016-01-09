using Cielo.Sirius.Contracts.RateChangeNegotiationRequest;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.Business.Products
{
    public class SolicitarNegociacaoTaxaBL : BusinessLogicBase<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>
    {
        public override SolicitarNegociacaoTaxaResponse Execute(SolicitarNegociacaoTaxaRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<SolicitarNegociacaoTaxaDAO, SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB == null || responseOSB.Status == ExecutionStatus.BusinessError)
                return responseOSB;

            var requestCRM = new RateChangeNegotiationRequestRequest()
            {

                CommercialEstablishmentNumber = requestData.CodigoCliente,
                CorrelationId = requestData.CorrelationId,
                UserId = requestData.UserId,
                ArticleSubjectCode = requestData.ArvoreDeAssunto,
                ServiceChannelCode = requestData.CanalDeAtendimento,
                ProcessTypeCode = requestData.CaseType,
                AccountID = requestData.Cliente,
                CaseName = requestData.TituloDaOcorrencia,
                AgentGroupCode = requestData.IlhaDeAtendimento,
                ParentCaseId = requestData.ParentCaseId,
                ReasonId = requestData.IdMotivo,
                DemandId = requestData.IdDemanda,

                //StatusReasonCode será 1 se a DAO de OSB rodar corretamente, que no Option Set do CRM significa "Integrado"
                //Se não rodar corretamente, deve ser atribuído o valor 2, que no Option Set do CRM significa "Não integrado"
                StatusReasonCode = responseOSB.Status == ExecutionStatus.Success ? 1 : 2,

                //Deve ser passada a data do SLA retornada do OSB
                ExpectedConclusionDate = responseOSB.DataPrevistaConclusaoSolicitacao
            };


            var daoCRM = DAOFactory.GetDAO<RateChangeNegotiationRequestDAO, RateChangeNegotiationRequestRequest, RateChangeNegotiationRequestResponse>();

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
