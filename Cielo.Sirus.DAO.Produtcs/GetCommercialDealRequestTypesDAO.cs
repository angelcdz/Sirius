using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Contracts.GetCommercialDealRequestTypes;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class GetCommercialDealRequestTypesDAO : DAOCRMBase<GetCommercialDealRequestTypesRequest, GetCommercialDealRequestTypesResponse>
    {
        protected override GetCommercialDealRequestTypesResponse GetData(GetCommercialDealRequestTypesRequest requestData)
        {
            var fetchXML = new StringBuilder();
            fetchXML.AppendFormat(
            @"
            <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                <entity name='cielo_requestparameter'>
                    <attribute name='cielo_requestparameterid' />
                    <attribute name='cielo_name' />
                    <attribute name='cielo_integrationrequestcode' />
                    <filter type='and'>
                        <condition attribute='cielo_groupcode' operator='eq' value='{0}' />
                    </filter>
                </entity>
            </fetch>", requestData.GroupCode);

            // Get CRM records
            var dealRequestTypes = GetCRMRecords(fetchXML);

            var responseData = new GetCommercialDealRequestTypesResponse();
            responseData.CommercialDealRequestTypes = new List<GetCommercialDealRequestTypesDTO>();

            foreach (var item in dealRequestTypes.Entities)
            {
                var dealRequestType = new GetCommercialDealRequestTypesDTO();

                dealRequestType.Name = (item.Contains("cielo_name") ? (item["cielo_name"]).ToString() : string.Empty);
                dealRequestType.IntegrationRequestCode = (item.Contains("cielo_integrationrequestcode") ? ((int)item["cielo_integrationrequestcode"]) : 0);
                dealRequestType.Id = (item.Contains("cielo_requestparameterid") ? ((Guid)item["cielo_requestparameterid"]) : Guid.Empty);

                responseData.CommercialDealRequestTypes.Add(dealRequestType);
            }

            responseData.Status = ExecutionStatus.Success;

            return responseData;
        }
    }
}
