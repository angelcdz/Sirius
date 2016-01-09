using System;
using System.Linq;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;

using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.Net;
using Cielo.Sirius.Contracts.EnableDisableTypedSale;
using Cielo.Sirius.DAO.Products.CRM;

namespace Cielo.Sirius.DAO.Products
{
    public class EnableDisableTypedSaleDAO : DAOCRMBase<EnableDisableTypedSaleRequest, EnableDisableTypedSaleResponse>
    {
        protected override EnableDisableTypedSaleResponse GetData(EnableDisableTypedSaleRequest requestData)
        {
            var action = new cielo_PrSvDisableTypedSaleAcRequest()
            {
                Target = new EntityReference(Incident.EntityLogicalName, new Guid(requestData.ParentCaseId))
                {
                    Name = Incident.EntityLogicalName
                },
                RequestCase = new Incident()
                {
                    StatusCode = requestData.StatusReasonCode
                },
                ProductRequest = new cielo_productrequest()
                {
                    statuscode = requestData.StatusReasonCode
                }
            };

            service.Execute(action);

            return new EnableDisableTypedSaleResponse() { Status = ExecutionStatus.Success };
        }
    }
}
