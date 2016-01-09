using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.DAO.Products.CRM;

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class GetDiscountRateRestrictionDAO : DAOCRMBase<GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>
    {
        protected override GetDiscountRateRestrictionResponse GetData(GetDiscountRateRestrictionRequest requestData)
        {
            var action = new cielo_PrSvGetDiscountRateRestrictionAcRequest()
            {
                AgentGroup = requestData.AgentGroupCode,
                BranchActivity = requestData.BranchActivityCode,
                DefaultRate = requestData.DefaultRate,
                ProductCode = requestData.ProductCode
            };

            var response = (cielo_PrSvGetDiscountRateRestrictionAcResponse)service.Execute(action);

            return new GetDiscountRateRestrictionResponse()
            {
                Status = ExecutionStatus.Success,
                DiscountRateRestrictionPercentage = response.DiscountRateRestrictionPercentage,
                MaxDiscountRateRestrictionPercentage = response.MaximumRateRestrictionPercentage,
                MinDiscountRateRestrictionPercentage = response.MinimumRateRestrictionPercentage
            };

            //GetDiscountRateRestrictionResponse responseData = null;
            //Guid branchActivityId;
            //Guid agentGroupId;

            //if(!Guid.TryParse(requestData.BranchActivityCode, out branchActivityId))
            //{
            //    requestData.BranchActivityCode = GetBranchActivity(requestData.BranchActivityCode);
            //}

            //if (!Guid.TryParse(requestData.AgentGroupCode, out agentGroupId))
            //{
            //    requestData.AgentGroupCode = GetAgentGroup(requestData.AgentGroupCode);
            //}

            //// Get Discount Rate Restriction records (PRODUCT CODE + BRANCH OF ACTIVITY CODE + AGENT GROUP CODE)
            //var requestDiscountRateRestriction = GetDiscountRateRestriction(
            //    requestData.ProductCode, requestData.BranchActivityCode, requestData.AgentGroupCode);

            //// Verify if NOT exist one result
            //if (requestDiscountRateRestriction.Entities.Count == 0)
            //{
            //    // Get Discount Rate Restriction records (BRANCH OF ACTIVITY CODE + AGENT GROUP CODE)
            //    requestDiscountRateRestriction = GetDiscountRateRestriction(
            //        string.Empty, requestData.BranchActivityCode, requestData.AgentGroupCode);

            //    // Verify if NOT exist one result
            //    if (requestDiscountRateRestriction.Entities.Count == 0)
            //    {
            //        // Get Discount Rate Restriction records (AGENT GROUP CODE)
            //        requestDiscountRateRestriction = GetDiscountRateRestriction(
            //            string.Empty, string.Empty, requestData.AgentGroupCode);
            //    }
            //}

            // // Verify if exist one result
            //if (requestDiscountRateRestriction.Entities.Count > 0)
            //{
            //    // Verify if exist the attribute
            //    if (requestDiscountRateRestriction.Entities.First().Contains("cielo_discountraterestrictionpercentage"))
            //    {
            //        responseData = new GetDiscountRateRestrictionResponse();

            //        // Set Property
            //        responseData.DiscountRateRestrictionPercentage = Convert.ToDecimal(
            //            requestDiscountRateRestriction.Entities.First()["cielo_discountraterestrictionpercentage"].ToString());
            //    }
            //}

            //return responseData;
        }

        /// <summary>
        /// Get Discount Rate Restriction records 
        /// </summary>
        /// <param name="productCode">Product Code</param>
        /// <param name="branchActivityCode">Branch of Activity Code (MCC)</param>
        /// <param name="agentGroupCode">Agent Group Code</param>
        /// <returns>EntityCollection with Discount Rate Restriction records</returns>
        private EntityCollection GetDiscountRateRestriction(string productCode, string branchActivityCode, string agentGroupCode)
        {
            // Create a query to get Discount Rate Restriction to PRODUCT CODE / BRANCH OF ACTIVITY CODE / AGENT GROUP CODE
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetchXML.Append("<entity name='cielo_discountraterestriction'>");
            fetchXML.Append("<attribute name='cielo_name' />");
            fetchXML.Append("<attribute name='cielo_discountraterestrictionpercentage' />");
            fetchXML.Append("<attribute name='cielo_discountraterestrictionid' />");
            fetchXML.Append("<order attribute='cielo_discountraterestrictionpercentage' descending='true' />");
            fetchXML.Append("<filter type='and'>");

            if (!string.IsNullOrEmpty(productCode))
            {
                fetchXML.AppendFormat("<condition attribute='cielo_productcode' operator='eq' value='{0}' />", productCode);
            }
            else
            {
                fetchXML.Append("<condition attribute='cielo_productcode' operator='null' />");
            }

            if (!string.IsNullOrEmpty(branchActivityCode))
            {
                fetchXML.AppendFormat("<condition attribute='cielo_branchactivitycodeid' operator='eq' uitype='cielo_branchofactivity' value='{0}' />", branchActivityCode);
            }
            else
            {
                fetchXML.Append("<condition attribute='cielo_branchactivitycodeid' operator='null' />");
            }

            if (!string.IsNullOrEmpty(agentGroupCode))
            {
                fetchXML.AppendFormat("<condition attribute='cielo_agentgroupcodeid' operator='eq' uitype='team' value='{0}' />", agentGroupCode);
            }
            else
            {
                fetchXML.Append("<condition attribute='cielo_agentgroupcodeid' operator='null' />");
            }

            fetchXML.Append("</filter>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            return GetCRMRecords(fetchXML);
        }

        /// <summary>
        /// Get Branch of Activity by Code
        /// </summary>
        /// <param name="branchActivityCode">Branch of Activity Code</param>
        /// <returns>Entity that represent Branch of Activity record</returns>
        private string GetBranchActivity(string branchActivityCode)
        {
            var branchofActivityId = string.Empty;

            // Create a query to get Branch of Activity by Code
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetchXML.Append("<entity name='cielo_branchofactivity'>");
            fetchXML.Append("<attribute name='cielo_branchofactivityid' />");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_code' operator='eq' value='{0}' />", branchActivityCode);      
            fetchXML.Append("</filter>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            Entity branchActivity = GetCRMFirstRecord(fetchXML);

            if(branchActivity != null && branchActivity.Contains("cielo_branchofactivityid"))
            {
                branchofActivityId = branchActivity["cielo_branchofactivityid"].ToString();
            }
            else
            {
                throw new Exception("Branch of Activity Code not exits in CRM");
            }

            return branchofActivityId;
        }

        /// <summary>
        /// Get Agent Group by Code
        /// </summary>
        /// <param name="agentGroupCode">Agent Group Code</param>
        /// <returns>Entity that represent Agent Group record</returns>
        private string GetAgentGroup(string agentGroupCode)
        {
            var agentGroupId = string.Empty;

            // Create a query to get Agent Group by Code
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetchXML.Append("<entity name='team'>");
            fetchXML.Append("<attribute name='teamid' />");
            fetchXML.Append("<filter type='and'>");
            fetchXML.Append("<condition attribute='cielo_isagentgroup' operator='eq' value='1' />");  // Teams (AGENT GROUP)
            fetchXML.AppendFormat("<condition attribute='cielo_teamagentgroupcode' operator='eq' value='{0}' />", agentGroupCode);      
            fetchXML.Append("</filter>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");

            // Get CRM records
            Entity agentGroup = GetCRMFirstRecord(fetchXML);

            if(agentGroup != null && agentGroup.Contains("teamid"))
            {
                agentGroupId = agentGroup["teamid"].ToString();
            }
            else
            {
                throw new Exception("Agent Group Code not exits in CRM");
            }

            return agentGroupId;
        }
    }
}