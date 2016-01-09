using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Client;

using Cielo.Sirius.Contracts.ExistsServiceOpenDemand;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class ExistsServiceOpenDemandDAO : DAOCRMBase<ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>
    {
        protected override ExistsServiceOpenDemandResponse GetData(ExistsServiceOpenDemandRequest requestData)
        {
            ExistsServiceOpenDemandResponse responseData = null;

            // Create a query to get Products that have Products Request (Solicitação de Produtos)
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>");
            fetchXML.Append("<entity name='cielo_servicerequest'>");
            fetchXML.Append("<attribute name='cielo_servicecode' />");

            fetchXML.Append("<link-entity name='incident' from='incidentid' to='cielo_caseid' alias='ag'>");
            fetchXML.Append("<filter type='and'>");
            fetchXML.Append("<condition attribute='statecode' operator='eq' value='0' />"); // Open Case
            fetchXML.Append("</filter>");
            fetchXML.Append("<link-entity name='cielo_commercialestablishment' from='cielo_commercialestablishmentid' to='cielo_commercialestablishmentnumberid' alias='ah'>");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_ecnumber' operator='eq' value='{0}' />", requestData.CodigoCliente);
            fetchXML.Append("</filter>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            var requestProducts = GetCRMRecords(fetchXML);

            responseData = new ExistsServiceOpenDemandResponse();
            responseData.ErrorCode = "00";
            responseData.ErrorMessage = null;

            // Loop results
            foreach (var item in requestProducts.Entities)
            {
                if (item.Contains("cielo_servicecode"))
                {
                    var serviceWithDemand = new ExistsServiceOpenDemandDTO();

                    serviceWithDemand.CodigoServico = item["cielo_servicecode"].ToString();
                    serviceWithDemand.IndicadorPossuiDemandasAbertas = true;
                    responseData.ExistsServiceOpenRequests.Add(serviceWithDemand);
                }
            }

            // Set status for TRUE
            responseData.Status = ExecutionStatus.Success;

            return responseData;
        }
    }
}
