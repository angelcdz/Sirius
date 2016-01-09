using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetNegotiationData;
using Cielo.Sirius.DAO.Products.WR.Equipamento;
using Cielo.Sirius.DAO.Products.WR.Equipamento.Extensions;
using Cielo.Sirius.Foundation.DAO;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Cielo.Sirius.DAO.Products.CRM;
using System;
using System.Collections.Generic;
using Cielo.Sirius.Foundation;
using System.Reflection;
using Microsoft.Xrm.Sdk.Client;

namespace Cielo.Sirius.DAO.Products
{
    public class GetNegotiationDataDAO : DAOCRMBase<GetNegotiationDataRequest, GetNegotiationDataResponse>
    {
        protected override GetNegotiationDataResponse GetData(GetNegotiationDataRequest requestData)
        {
            var requestAction = new cielo_CmNeGetNegotiationDataActionRequest()
            {
                AgentGroup = new EntityReference(Team.EntityLogicalName, new Guid(requestData.AgentGroupCode)),
                CommercialEstablishment = new EntityReference(cielo_commercialestablishment.EntityLogicalName, requestData.ECNumber),
                RequestParameterization = new EntityReference(cielo_requestparameter.EntityLogicalName, requestData.DemandId)
            };

            var responseAction = (cielo_CmNeGetNegotiationDataActionResponse)service.Execute(requestAction);

            if (responseAction == null) return new GetNegotiationDataResponse(){ Status = ExecutionStatus.TechnicalError };

            var response = new GetNegotiationDataResponse() { Status = ExecutionStatus.Success };
            response.DoOffersExist = (bool) responseAction.DoOffersExist;
            response.Competitors = new List<GetNegotiationDataCompetitorsDTO>();
            response.DealItems = new List<GetNegotiationDataDealItemsDTO>();
            response.Reasons = new List<GetNegotiationDataReasonsDTO>();

            if (responseAction.Competitors != null)
                foreach (var item in responseAction.Competitors.Entities)
                    response.Competitors.Add(new GetNegotiationDataCompetitorsDTO()
                    {
                        CompetitorId = item.Contains("competitorid") ? (Guid)item["competitorid"] : Guid.Empty,
                        CompetitorName = item.Contains("name") ? (string)item["name"] : String.Empty,
                    });

            if (responseAction.DealItems != null)
            foreach (var item in responseAction.DealItems.Entities)
                response.DealItems.Add(new GetNegotiationDataDealItemsDTO()
                {
                    DealItemId = item.Contains("cielo_dealitemid") ? (Guid)item["cielo_dealitemid"] : Guid.Empty,
                    DealItemName = item.Contains("cielo_dealitem") ? (string)item["cielo_dealitem"] : String.Empty
                });

            if (responseAction.Reasons != null)
            foreach (var item in responseAction.Reasons.Entities)
                response.Reasons.Add(new GetNegotiationDataReasonsDTO()
                {
                    ReasonId = item.Contains("cielo_requestreasonid") ? (Guid)item["cielo_requestreasonid"] : Guid.Empty,
                    ReasonName = item.Contains("cielo_name") ? (string)item["cielo_name"] : String.Empty
                });

            return response;
        }
    }
}
