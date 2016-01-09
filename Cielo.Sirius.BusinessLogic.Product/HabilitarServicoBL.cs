using Cielo.Sirius.Contracts.EnableService;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.Business.Products
{
    public class HabilitarServicoBL : BusinessLogicBase<HabilitarServicoRequest, HabilitarServicoResponse>
    {
        public override HabilitarServicoResponse Execute(HabilitarServicoRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<HabilitarServicoDAO, HabilitarServicoRequest, HabilitarServicoResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB == null || responseOSB.Status == ExecutionStatus.BusinessError)
                return responseOSB;

            var requestCRM = new EnableServiceRequest()
            {
                ArticleSubjectCode = requestData.ArvoreAssunto,
                ServiceChannelCode = requestData.CanalDeAtendimento,
                ProcessTypeCode = requestData.CaseType,
                AccountID = requestData.Cliente,
                CommercialEstablishmentNumber = requestData.CodigoCliente,
                AgentGroupCode = requestData.IlhaDeAtendimento,
                ParentCaseId = requestData.ParentCaseId,
                CaseName = requestData.TituloOcorrencia,
                UserId = requestData.UserId,
                ReasonId = requestData.IdMotivo,
                DemandId = requestData.IdDemanda,

                //StatusReasonCode será 1 se a DAO de OSB rodar corretamente, que no Option Set do CRM significa "Integrado"
                //Se não rodar corretamente, deve ser atribuído o valor 2, que no Option Set do CRM significa "Não integrado"
                StatusReasonCode = responseOSB.Status == ExecutionStatus.Success ? 1 : 2,

                //Deve ser passada a data do SLA retornada do OSB
                //ExpectedConclusionDate = responseOSB.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao
                ExpectedConclusionDate = responseOSB.DataSLA
            };

            var daoCRM = DAOFactory.GetDAO<EnableServiceDAO, EnableServiceRequest, EnableServiceResponse>();

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
