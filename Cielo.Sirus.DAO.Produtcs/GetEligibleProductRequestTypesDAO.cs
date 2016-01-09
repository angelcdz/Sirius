using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Contracts.GetEligibleProductRequestTypes;


namespace Cielo.Sirius.DAO.Products
{
    public class GetEligibleProductRequestTypesDAO : DAOCRMBase<GetEligibleProductRequestTypesRequest, GetEligibleProductRequestTypesResponse>
    {
        protected override GetEligibleProductRequestTypesResponse GetData(GetEligibleProductRequestTypesRequest requestData)
        {
            GetEligibleProductRequestTypesResponse responseData = null;

            responseData = new GetEligibleProductRequestTypesResponse();
            responseData.ProductRequestTypes = new List<GetEligibleProductRequestTypesDTO>();
            responseData.Status = Foundation.ExecutionStatus.Success;

            responseData.ProductRequestTypes.Add(
                new GetEligibleProductRequestTypesDTO
                {
                    IntegrationRequestCode = 116489,
                    Name = "Habilitar",
                    Id = new Guid()
                }
                );


            //// Verify if UserId was informed
            //if (requestData.UserId != null && requestData.UserId != Guid.Empty)
            //{
            //    // Create a query to get Products that have Products Request (Solicitação de Produtos)
            //    var fetchXML = new StringBuilder();
            //    fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>");
            //    fetchXML.Append("<entity name='cielo_productrequest'>");
            //    fetchXML.Append("<attribute name='cielo_productcode' />");
            //    fetchXML.Append("<filter type='or'>");

            //    // Loop all Products exists in Request object
            //    fetchXML.AppendFormat("<condition attribute='cielo_productcode' operator='eq' value='{0}' />", requestData.ProductGroup);


            //    fetchXML.Append("</filter>");
            //    fetchXML.Append("<link-entity name='incident' from='incidentid' to='cielo_caseid' alias='ag'>");
            //    fetchXML.Append("<link-entity name='cielo_commercialestablishment' from='cielo_commercialestablishmentid' to='cielo_commercialestablishmentnumberid' alias='ah'>");
            //    fetchXML.Append("<filter type='and'>");
            //    fetchXML.AppendFormat("<condition attribute='cielo_ecnumber' operator='eq' value='{0}' />", requestData.CodigoCliente);
            //    fetchXML.Append("</filter>");
            //    fetchXML.Append("</link-entity>");
            //    fetchXML.Append("</link-entity>");
            //    fetchXML.Append("</entity>");
            //    fetchXML.Append("</fetch>");

            //    // Get CRM records
            //    var requestProducts = GetCRMRecords(fetchXML);

            //    responseData = new ExistsProductOpenRequestsResponse();
            //    responseData.ExistsProductOpenRequests = new List<ExistsProductOpenRequestsDTO>();

            //    // Loop results
            //    foreach (var item in requestProducts.Entities)
            //    {
            //        if (item.Contains("cielo_productcode"))
            //        {
            //            var productWithDemand = new ExistsProductOpenRequestsDTO();

            //            productWithDemand.CodigoProduto = item["cielo_productcode"].ToString();
            //            productWithDemand.IndicadorPossuiDemandasAbertas = true;
            //            responseData.ExistsProductOpenRequests.Add(productWithDemand);
            //        }
            //    }
            //}

            return responseData;
        }


    }
}