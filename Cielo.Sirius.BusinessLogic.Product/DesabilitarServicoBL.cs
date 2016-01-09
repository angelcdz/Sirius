using System;
using System.Collections.Generic;

using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Contracts.DisableService;

namespace Cielo.Sirius.Business.Products
{
    public class DesabilitarServicoBL : BusinessLogicBase<DesabilitarServicoRequest, DesabilitarServicoResponse>
    {
        public override DesabilitarServicoResponse Execute(DesabilitarServicoRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<DesabilitarServicoDAO, DesabilitarServicoRequest, DesabilitarServicoResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            //Verifica se houve erro de negócio. Caso tenha ocorrido, retorna o response com business error
            if (responseOSB != null && responseOSB.Status == ExecutionStatus.BusinessError)
            {
                return responseOSB;
            }

            var requestCRM = new DisableServiceRequest
            {
                //UserId = requestData.UserId,
                CorrelationId = requestData.CorrelationId,
                ServiceChannelCode = requestData.CanalDeAtendimento,
                CaseName = requestData.TituloDaOcorrencia,
                CommercialEstablishmentNumber = requestData.CodigoCliente.ToString(),
                AgentGroupCode = requestData.IlhaDeAtendimento,
                ArticleSubjectCode = requestData.ArvoreDeAssunto,
                ParentCaseId = requestData.ParentCaseId,
                UserId = requestData.UserId,
                ReasonId = requestData.IdMotivo,
                DemandId = requestData.IdDemanda,

                //StatusReasonCode será 1 se a DAO de OSB rodar corretamente, que no Option Set do CRM significa "Integrado"
                //Se não rodar corretamente, deve ser atribuído o valor 2, que no Option Set do CRM significa "Não integrado"
                StatusReasonCode = responseOSB.Status == ExecutionStatus.Success ? 1 : 2,

                //Deve ser passada a data do SLA retornada do OSB
                //ExpectedConclusionDate = responseOSB.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao
                ExpectedConclusionDate = responseOSB.DataPrevistaConclusaoSolicitacao
            };

            var daoCRM = DAOFactory.GetDAO<DisableServiceDAO, DisableServiceRequest, DisableServiceResponse>();

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
