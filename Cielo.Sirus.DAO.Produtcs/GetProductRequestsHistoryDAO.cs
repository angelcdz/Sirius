using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class GetProductRequestsHistoryDAO : DAOCRMBase<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>
    {
        protected override GetProductRequestsHistoryResponse GetData(GetProductRequestsHistoryRequest requestData)
        {
            GetProductRequestsHistoryResponse responseData = null;

            // Create a query to get last 5 Products Request (Solicitação de Produtos) of actual Product and Client (EC)
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' count='5' mapping='logical' distinct='false'>");
            fetchXML.Append("<entity name='cielo_productrequest'>");
            fetchXML.Append("<attribute name='cielo_productrequestid' />");
            fetchXML.Append("<attribute name='cielo_name' />");
            fetchXML.Append("<attribute name='createdon' />");
            fetchXML.Append("<order attribute='createdon' descending='true' />");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_productcode' operator='eq' value='{0}' />", requestData.CodigoProduto);
            fetchXML.Append("</filter>");
            fetchXML.Append("<link-entity name='incident' from='incidentid' to='cielo_caseid' visible='true' link-type='inner' alias='case'>");
            fetchXML.Append("<attribute name='cielo_servicecallnumber' />");
            fetchXML.Append("<link-entity name='incidentresolution' from='incidentid' to='incidentid' visible='true' link-type='outer' alias='caseresolution'>");
            fetchXML.Append("<attribute name='actualend' />");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("<link-entity name='cielo_commercialestablishment' from='cielo_commercialestablishmentid' to='cielo_commercialestablishmentnumberid' alias='ec'>");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_ecnumber' operator='eq' value='{0}' />",requestData.CodigoCliente);
            fetchXML.Append("</filter>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            var requestProducts = GetCRMRecords(fetchXML);

            responseData = new GetProductRequestsHistoryResponse();
            responseData.ProductRequests = new List<GetProductRequestsHistoryDTO>();

            // Loop results
            foreach (var item in requestProducts.Entities)
            {
                var productRequest = new GetProductRequestsHistoryDTO();

                productRequest.ServiceCallNumber = (item.Contains("case.cielo_servicecallnumber") ? ((AliasedValue)item["case.cielo_servicecallnumber"]).Value.ToString() : string.Empty);
                productRequest.ProductRequestName = (item.Contains("cielo_name") ? item["cielo_name"].ToString() : string.Empty);
                productRequest.CreatedOn = (item.Contains("createdon") ? (DateTime)item["createdon"] : DateTime.MinValue);
                productRequest.ClosedOn = 
                    (item.Contains("caseresolution.actualend") ? Convert.ToDateTime(((AliasedValue)item["caseresolution.actualend"]).Value.ToString()) : DateTime.MinValue);

                responseData.ProductRequests.Add(productRequest);
            }

            // Set status for TRUE
            responseData.Status = ExecutionStatus.Success;

            return responseData;
        }
    }
}
