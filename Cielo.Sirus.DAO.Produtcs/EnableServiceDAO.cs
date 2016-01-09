using Cielo.Sirius.Contracts.EnableService;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.DAO.Products.CRM;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Cielo.Sirius.Foundation;
using System.IO;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Client;

namespace Cielo.Sirius.DAO.Products
{
    public class EnableServiceDAO : DAOCRMBase<EnableServiceRequest, EnableServiceResponse>
    {
        protected override EnableServiceResponse GetData(EnableServiceRequest requestData)
        {
            var action = new cielo_PrSvEnableServiceAcRequest()
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

            return new EnableServiceResponse() { Status = ExecutionStatus.Success };
        }
    }
}
