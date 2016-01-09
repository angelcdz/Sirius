using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cielo.Sirius.DAO.Products
{
    public class GetEnabledProductRequestTypesDAO : DAOCRMBase<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>
    {
        protected override GetEnabledProductRequestTypesResponse GetData(GetEnabledProductRequestTypesRequest requestData)
        {
            GetEnabledProductRequestTypesResponse responseData = null;

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
                fetchXML.AppendFormat("<condition attribute='cielo_groupcode' operator='eq' value='{0}' />", requestData.ProductGroup);
                fetchXML.Append("</filter>");
                fetchXML.Append("</entity>");
                fetchXML.Append("</fetch>");

                // Get CRM records
                var productRequestTypes = GetCRMRecords(fetchXML);

                responseData = new GetEnabledProductRequestTypesResponse();
                responseData.ProductRequestTypes = new List<GetEnabledProductRequestTypesDTO>();
                GetEnabledProductRequestTypesDTO productRequestType = null;

                foreach (var item in productRequestTypes.Entities)
                {
                    productRequestType = new GetEnabledProductRequestTypesDTO();

                    productRequestType.Name = (item.Contains("cielo_name") ? (item["cielo_name"]).ToString() : string.Empty);
                    productRequestType.IntegrationRequestCode = (item.Contains("cielo_integrationrequestcode") ? ((int)item["cielo_integrationrequestcode"]) : 0);
                    productRequestType.Id = (item.Contains("cielo_requestparameterid") ? ((Guid)item["cielo_requestparameterid"]) : Guid.Empty);

                    responseData.ProductRequestTypes.Add(productRequestType);
                }

                responseData.Status = Foundation.ExecutionStatus.Success;
            }

            return responseData;
        }


    }
}