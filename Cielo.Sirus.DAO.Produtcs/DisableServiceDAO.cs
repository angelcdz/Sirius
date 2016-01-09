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
using Cielo.Sirius.Contracts.DisableService;
using Cielo.Sirius.DAO.Products.CRM;
using Microsoft.Xrm.Client;

namespace Cielo.Sirius.DAO.Products
{
    public class DisableServiceDAO : DAOCRMBase<DisableServiceRequest, DisableServiceResponse>
    {
        protected override DisableServiceResponse GetData(DisableServiceRequest requestData)
        {
            var action = new cielo_PrSvDisableServiceAcRequest()
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
                ServiceRequest = new cielo_servicerequest()
                {
                    cielo_requestreasoncode = new EntityReference(cielo_requestreason.EntityLogicalName, requestData.ReasonId),
                    statuscode = new OptionSetValue(requestData.StatusReasonCode)
                },
                RequestParameterization = new EntityReference(cielo_requestparameter.EntityLogicalName, requestData.DemandId)
            };

            service.Execute(action);

            return new DisableServiceResponse() { Status = ExecutionStatus.Success };
        }
    }
}
