using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class GetServiceRequestsHistoryDAO : DAOCRMBase <GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>
    {

        protected override GetServiceRequestsHistoryResponse GetData(GetServiceRequestsHistoryRequest requestData)
        {
            GetServiceRequestsHistoryResponse responseData = null;

            // Create a query to get last 5 Service Requests (Solicitações de Serviço) of actual Service and Commercial Establishment (EC)
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' count='5' mapping='logical' distinct='false'>");
            fetchXML.Append("<entity name='cielo_servicerequest'>");
            fetchXML.Append("<attribute name='cielo_servicerequestid' />");
            fetchXML.Append("<attribute name='cielo_name' />");
            fetchXML.Append("<attribute name='createdon' />");
            fetchXML.Append("<order attribute='createdon' descending='true' />");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_servicecode' operator='eq' value='{0}' />", requestData.CodigoServico);
            fetchXML.Append("</filter>");
            fetchXML.Append("<link-entity name='incident' from='incidentid' to='cielo_caseid' visible='true' link-type='inner' alias='case'>");
            fetchXML.Append("<attribute name='title' />");
            fetchXML.Append("<link-entity name='incidentresolution' from='incidentid' to='incidentid' visible='true' link-type='outer' alias='caseresolution'>");
            fetchXML.Append("<attribute name='actualend' />");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("<link-entity name='cielo_commercialestablishment' from='cielo_commercialestablishmentid' to='cielo_commercialestablishmentnumberid' alias='ec'>");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_ecnumber' operator='eq' value='{0}' />", requestData.CodigoCliente);
            fetchXML.Append("</filter>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            var requestServices = GetCRMRecords(fetchXML);

            responseData = new GetServiceRequestsHistoryResponse();
            responseData.ServiceRequests = new List<GetServiceRequestsHistoryDTO>();

            // Loop results
            foreach (var item in requestServices.Entities)
            {
                var serviceRequest = new GetServiceRequestsHistoryDTO();

                serviceRequest.CaseTitle = (item.Contains("case.title") ? ((AliasedValue)item["case.title"]).Value.ToString() : string.Empty);
                serviceRequest.ServiceRequestName = (item.Contains("cielo_name") ? item["cielo_name"].ToString() : string.Empty);
                serviceRequest.CreatedOn = (item.Contains("createdon") ? (DateTime)item["createdon"] : DateTime.MinValue);
                serviceRequest.ClosedOn =
                    (item.Contains("caseresolution.actualend") ? Convert.ToDateTime(((AliasedValue)item["caseresolution.actualend"]).Value.ToString()) : DateTime.MinValue);

                responseData.ServiceRequests.Add(serviceRequest);
            }

            // Set status for TRUE
            responseData.Status = ExecutionStatus.Success;

            return responseData;
        }

    }
}
