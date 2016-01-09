using System;
using System.Collections.Generic;
using System.Text;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Contracts.GetCommercialEstablishmentInformation;
using Microsoft.Xrm.Sdk;

namespace Cielo.Sirius.DAO.Products
{
    public class GetCommercialEstablishmentInformationDAO : DAOCRMBase<GetCommercialEstablishmentInformationRequest, GetCommercialEstablishmentInformationResponse>
    {
        protected override GetCommercialEstablishmentInformationResponse GetData(GetCommercialEstablishmentInformationRequest requestData)
        {
            GetCommercialEstablishmentInformationResponse responseData = null;

            // Verify if UserId was informed
            if (requestData.UserId != null && requestData.UserId != Guid.Empty)
            {
                var fetchXML = new StringBuilder();
                fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
                fetchXML.Append("<entity name='cielo_commercialestablishment'>");
                fetchXML.Append("<attribute name='cielo_membershipdate' />");
                fetchXML.Append("<attribute name='cielo_meiindicator' />");
                fetchXML.Append("<attribute name='cielo_branchofactivityid' />");
                fetchXML.Append("<filter type='and'>");
                fetchXML.AppendFormat("<condition attribute='cielo_ecnumber' operator='eq' value='{0}' />", requestData.CommercialEstablishmentNumber);
                fetchXML.Append("</filter>");
                fetchXML.Append("<link-entity name='cielo_branchofactivity' from='cielo_branchofactivityid' to='cielo_branchofactivityid' alias='boa'>");
                fetchXML.Append("<attribute name='cielo_code' />");
                fetchXML.Append("</link-entity>");
                fetchXML.Append("</entity>");
                fetchXML.Append("</fetch>");
                
                // Get CRM record
                Entity commEstabInformation = GetCRMFirstRecord(fetchXML);

                responseData = new GetCommercialEstablishmentInformationResponse();
                if (commEstabInformation != null)
                {
                    responseData.BranchOfActivityCode = commEstabInformation.Contains("boa.cielo_code") ? 
                        ((Microsoft.Xrm.Sdk.AliasedValue)commEstabInformation["boa.cielo_code"]).Value.ToString() : string.Empty;
                    responseData.MEIIndicator = commEstabInformation.Contains("cielo_meiindicator") ? 
                        (bool)commEstabInformation["cielo_meiindicator"] : false;
                    responseData.MembershipDate = commEstabInformation.Contains("cielo_membershipdate") ? 
                        (DateTime)commEstabInformation["cielo_membershipdate"] : DateTime.MinValue;
                }
                responseData.Status = Foundation.ExecutionStatus.Success;
            }

            return responseData;
        }


    }
}