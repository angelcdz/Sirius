using System;
using System.Linq;

using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.Net;
using Cielo.Sirius.Contracts.DisableService;
using Cielo.Sirius.DAO.Products.CRM;
using Cielo.Sirius.Contracts.DisableProduct;
using System.IO;
using System.ServiceModel;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

using Microsoft.Crm.Sdk.Messages;

namespace Cielo.Sirius.DAO.Products
{
    public class DisableProductDAO : DAOCRMBase<DisableProductRequest, DisableProductResponse>
    {
        protected override DisableProductResponse GetData(DisableProductRequest requestData)
        {
            var action = new cielo_PrSvDisableProductAcRequest()
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
                    cielo_requestreasoncode = new EntityReference(cielo_requestreason.EntityLogicalName, requestData.ReasonId),
                    cielo_productcode = requestData.ProductCode.ToString(),
                    statuscode = new OptionSetValue(requestData.StatusReasonCode)
                },
                RequestParameterization = new EntityReference(cielo_requestparameter.EntityLogicalName, requestData.DemandId)
            };

            service.Execute(action);

            return new DisableProductResponse() { Status = ExecutionStatus.Success };
        }
    }
}
