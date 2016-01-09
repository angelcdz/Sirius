using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;

namespace Cielo.Sirius.DAO.Products
{
    public class GetProductRequestTypesDAO : DAOCRMBase<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>
    {
        protected override GetEnabledProductRequestTypesResponse GetData(GetEnabledProductRequestTypesRequest requestData)
        {

            #region Mock Data
            //Workaround to get data while fetch/entity is not developed.
            //18/06/2015
            var responseData = new GetEnabledProductRequestTypesResponse();
            responseData.ProductRequestTypes = new List<GetEnabledProductRequestTypesDTO>() 
            {
                new GetEnabledProductRequestTypesDTO()
                {
                    IntegrationRequestCode = 106489,
                    Name = "Habilitação de Cartão não Presente (Venda Digitada)"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106490,
                    Name = "Desabilitar Cartão não Presente (Venda Digitada)"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106491,
                    Name = "Solicitação de Negociação de Taxa"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106492,
                    Name = "Habilitação de prazo flexível"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106493,
                    Name = "Alteração de prazo flexível"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106494,
                    Name = "Desabilitação de prazo flexível"
                },
                new GetEnabledProductRequestTypesDTO(){
                    IntegrationRequestCode = 106495,
                    Name = "Desabilitar Produto"
                }
            };

            responseData.Status = Foundation.ExecutionStatus.Success;
            #endregion



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
