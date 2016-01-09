using System;
using System.Linq;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;

using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.Net;
using Cielo.Sirius.Contracts.EnableDisableTypedSale;
using Cielo.Sirius.DAO.Products.CRM;

namespace Cielo.Sirius.DAO.Products
{
    public class DisableTypedSaleDAO : DAOCRMBase<EnableDisableTypedSaleRequest, EnableDisableTypedSaleResponse>
    {
        protected override EnableDisableTypedSaleResponse GetData(EnableDisableTypedSaleRequest requestData)
        {
            var action = new cielo_PrSvDisableTypedSaleAcRequest()
            {
                Target = new EntityReference(Incident.EntityLogicalName, new Guid(requestData.ParentCaseId)),
                RequestCase = new Incident()
                {
                    cielo_requestreasoncode = new EntityReference(cielo_requestreason.EntityLogicalName, requestData.ReasonId),
                    cielo_teamid = new EntityReference(Team.EntityLogicalName, new Guid(requestData.AgentGroupCode)),
                    cielo_systemuserid = new EntityReference(SystemUser.EntityLogicalName, requestData.UserId),
                    OwnerId = new EntityReference(SystemUser.EntityLogicalName, requestData.UserId),
                    StatusCode = new OptionSetValue(requestData.StatusReasonCode)
                },
                ProductRequest = new cielo_productrequest()
                {
                    statuscode = new OptionSetValue(requestData.StatusReasonCode),
                    cielo_requestreasoncode = new EntityReference(cielo_requestreason.EntityLogicalName, requestData.ReasonId)
                },
                RequestParameterization = new EntityReference(cielo_requestparameter.EntityLogicalName, requestData.DemandId),
                AffectedProducts = new EntityCollection() { EntityName = Incident.EntityLogicalName}
            };

            foreach (var item in requestData.TypedSaleData)
            {
                action.AffectedProducts.Entities.Add(new cielo_requestproduct(){ cielo_productcode = item.ProductCode, cielo_productname = item.ProductName });
            }

            service.Execute(action);

            return new EnableDisableTypedSaleResponse() { Status = ExecutionStatus.Success };
        }
    }
}
