using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;

namespace Cielo.Sirius.DAO.Products.UnitTest.CRM
{
    public class CRMContext
    {
        private OrganizationServiceProxy _service;

        public CRMContext()
        {
            if (_service == null)
            {
                var cred = new ClientCredentials();
                cred.UserName.UserName = "Administrator";
                cred.UserName.Password = "Pass@word1";

                _service = new OrganizationServiceProxy(new Uri("http://localhost:5555/CIELOConfig/XRMServices/2011/Organization.svc"),
                                                        null,
                                                        cred,
                                                        null); 
            }
        }

        public void DisableAction(Actions action)
        {
            _service.Execute(new SetStateRequest()
                            {
                                EntityMoniker = new EntityReference(Workflow.EntityLogicalName, RetieveActionGuid(action)),
                                State = new OptionSetValue((int)WorkflowState.Draft),
                                Status = new OptionSetValue((int)ActionStatus.Draft)
                            });
        }

        public void EnableAction(Actions action)
        {
            _service.Execute(new SetStateRequest()
                    {
                        EntityMoniker = new EntityReference(Workflow.EntityLogicalName, RetieveActionGuid(action)),
                        State = new OptionSetValue((int) WorkflowState.Activated),
                        Status = new OptionSetValue((int) ActionStatus.Activated)
                    });
        }

        internal enum ActionStatus
        {
            Draft = 1,
            Activated = 2
        }

        internal Guid RetieveActionGuid(Actions action)
        {
            Guid returnValue = Guid.Empty;

            switch (action)
            {
                case Actions.PrSvDisableProductAc:
                    returnValue = new Guid("9d3eb947-466d-49aa-8a5f-bcb4593e402e");
                    break;
                case Actions.PrSvDisableServiceAc:
                    returnValue = new Guid("aa7fa958-dc74-463d-9ab9-341b8c3e04b2");
                    break;
                case Actions.PrSvEnableServiceAc:
                    returnValue = new Guid("43902389-9bb9-4a78-8814-4db50222a6aa");
                    break;
                case Actions.PrSvDisableTypedSaleAc:
                    returnValue = new Guid("7fc35b44-cab8-44fb-97b4-c95fa3afc23c");
                    break;
                case Actions.PrSvEnableTypedSaleAc:
                    returnValue = new Guid("81a13984-a7c4-4d90-b043-cd98930373bd");
                    break;
                case Actions.PrSvRateChengNegotiationRequestAc:
                    returnValue = new Guid("94d5a751-0094-4268-bf49-d2129d60ceb5");
                    break;
                case Actions.PrSvRequestLicenseAnalysisAc:
                    returnValue = new Guid("e34c98e3-5eca-44f5-a4b9-25c1e2815e32");
                    break;
            }

            return returnValue;
        }
    }
    public enum Actions
    {
        PrSvDisableProductAc,
        PrSvDisableServiceAc,
        PrSvEnableServiceAc,
        PrSvDisableTypedSaleAc,
        PrSvEnableTypedSaleAc,
        PrSvRateChengNegotiationRequestAc,
        PrSvRequestLicenseAnalysisAc,
    }
}


