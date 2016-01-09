using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.DAO.Products.CRM;
using Microsoft.Xrm.Sdk;
using System.IO;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class GetRequestReasonDAO : DAOCRMBase<GetRequestReasonRequest,GetRequestReasonResponse>
    {
        protected override GetRequestReasonResponse GetData(GetRequestReasonRequest requestData)
        {
            var fetchXML = new StringBuilder();
            fetchXML.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>");
            fetchXML.Append("<entity name='cielo_requestreason'>");
            fetchXML.Append("<attribute name='cielo_name' />");
            fetchXML.Append("<attribute name='cielo_requestreasonid' />");
            fetchXML.Append("<link-entity name='subject' from='subjectid' to='cielo_articlesubjectcodeid' alias='aa'>");
            fetchXML.Append("<link-entity name='cielo_requestparameter' from='cielo_subjectid' to='subjectid' alias='ab'>");
            fetchXML.Append("<filter type='and'>");
            fetchXML.AppendFormat("<condition attribute='cielo_requestparameterid' operator='eq' uitype='cielo_requestparameter' value='{0}' />", requestData.DemandId.ToString());
            fetchXML.Append("</filter>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</link-entity>");
            fetchXML.Append("</entity>");
            fetchXML.Append("</fetch>");


            // Get CRM records
            var serviceRequestTypes = GetCRMRecords(fetchXML);

            var responseData = new GetRequestReasonResponse();
            responseData.Reasons = new List<GetRequestReasonDTO>();

            foreach (var item in serviceRequestTypes.Entities)
            {
                var requestReason = new GetRequestReasonDTO();

                requestReason.ReasonName = (item.Contains("cielo_name") ? (item["cielo_name"]).ToString() : string.Empty);
                requestReason.ReasonId = (item.Contains("cielo_requestreasonid") ? ((Guid)item["cielo_requestreasonid"]) : Guid.Empty);

                responseData.Reasons.Add(requestReason);
            }

            if (responseData.Reasons.Count <= 0) 
                responseData.Status = Foundation.ExecutionStatus.BusinessError;
            else 
                responseData.Status = Foundation.ExecutionStatus.Success;

            return responseData;
        }
    }
}
