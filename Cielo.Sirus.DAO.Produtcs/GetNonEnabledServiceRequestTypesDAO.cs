using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cielo.Sirius.DAO.Products
{
    public class GetNonEnabledServiceRequestTypesDAO : DAOCRMBase<GetNonEnabledServiceRequestTypesRequest, GetNonEnabledServiceRequestTypesResponse>
    {
        protected override GetNonEnabledServiceRequestTypesResponse GetData(GetNonEnabledServiceRequestTypesRequest requestData)
        {
            GetNonEnabledServiceRequestTypesResponse responseData = null;

            // Verify if UserId was informed
            if (requestData.UserId != null && requestData.UserId != Guid.Empty)
            {
                var fetchXML = new StringBuilder();
                fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>");
                fetchXML.Append("<entity name='cielo_requestparameter'>");
                fetchXML.Append("<attribute name='cielo_requestparameterid' />");
                fetchXML.Append("<attribute name='cielo_name' />");
                fetchXML.Append("<attribute name='cielo_integrationrequestcode' />");
                fetchXML.Append("<filter type='and'>");
                fetchXML.AppendFormat("<condition attribute='cielo_groupcode' operator='eq' value='{0}' />", requestData.ServiceGroup);
                fetchXML.Append("</filter>");
                fetchXML.Append("</entity>");
                fetchXML.Append("</fetch>");

                // Get CRM records
                var serviceRequestTypes = GetCRMRecords(fetchXML);

                responseData = new GetNonEnabledServiceRequestTypesResponse();
                responseData.ServiceRequestTypes = new List<GetNonEnabledServiceRequestTypesDTO>();
                GetNonEnabledServiceRequestTypesDTO serviceRequestType = null;

                foreach (var item in serviceRequestTypes.Entities)
                {
                    serviceRequestType = new GetNonEnabledServiceRequestTypesDTO();

                    serviceRequestType.Name = (item.Contains("cielo_name") ? (item["cielo_name"]).ToString() : string.Empty);
                    serviceRequestType.IntegrationRequestCode = (item.Contains("cielo_integrationrequestcode") ? ((int)item["cielo_integrationrequestcode"]) : 0);
                    serviceRequestType.Id = (item.Contains("cielo_requestparameterid") ? ((Guid)item["cielo_requestparameterid"]) : Guid.Empty);

                    responseData.ServiceRequestTypes.Add(serviceRequestType);
                }

                responseData.Status = Foundation.ExecutionStatus.Success;
            }


            return responseData;
        }
    }
}
