using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

using Cielo.CredentialManager;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System.Diagnostics;

namespace Cielo.Sirius.Foundation.DAO
{
    public abstract class DAOCRMBase<RequestType, ResponseType> : DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase, new()
        where RequestType : RequestBase
    {
        Logger logger = Logger.LoggerFor<DAOCRMBase<RequestType, ResponseType>>();

        protected OrganizationServiceProxy service = null;

        public override ResponseType Execute(RequestType requestData)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            ResponseType response = null;

            try
            {
                logger.LogVerbose("Starting DAO-CRM Execution.");

                // Verify if UserId was informed
                if (requestData.UserId != null && requestData.UserId != Guid.Empty)
                {
                    service = GetCRMService(requestData.UserId);
                }
                else
                {
                    logger.LogError("The userid must be informed to access CRM services.");

                    response = new ResponseType();
                    response.Status = ExecutionStatus.TechnicalError;
                    response.ErrorCode = ErrorCodes.DAO_CRM_USER_NOT_INFORMED;
                    response.ErrorMessage = "The userid must be informed to access CRM services.";
                    return response;
                }

                response = this.GetData(requestData);

                logger.LogVerbose("Ending DAO-CRM Execution.");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during DAO-CRM execution: {0}", ex.Message);

                response = new ResponseType();
                response.Status = ExecutionStatus.TechnicalError;
                response.ErrorCode = ErrorCodes.DAO_CRM_GENERIC_ERROR;
                response.ErrorMessage = ex.Message;
            }
            finally
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                logger.LogVerbose("DAO-CRM execution runtime: {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }

            return response;
        }

        #region Get CRM Service

        /// <summary>
        /// Get CRM Service
        /// </summary>
        /// <param name="userId">User that will be Impersonate</param>
        /// <returns>OrganizationServiceProxy with CRM Service Context</returns>
        public OrganizationServiceProxy GetCRMService(Guid userId)
        {
            if (service == null)
            {
                CRMKeys crmKeys = RetrieveCRMKeys();

                IServiceManagement<IDiscoveryService> serviceManagement =
                               ServiceConfigurationFactory.CreateManagement<IDiscoveryService>(
                               new Uri(crmKeys.Url + "/XRMServices/2011/Discovery.svc"));
                AuthenticationProviderType endpointType = serviceManagement.AuthenticationType;

                // Set the credentials.
                AuthenticationCredentials authCredentials = GetCredentials(crmKeys);

                string organizationUri = String.Empty;

                // Get the discovery service proxy.
                using (DiscoveryServiceProxy discoveryProxy =
                    GetProxy<IDiscoveryService, DiscoveryServiceProxy>(serviceManagement, authCredentials))
                {
                    // Obtain organization information from the Discovery service. 
                    if (discoveryProxy != null)
                    {
                        // Obtain information about the organizations that the system user belongs to.
                        OrganizationDetailCollection orgs = DiscoverOrganizations(discoveryProxy);
                        // Obtains the Web address (Uri) of the target organization.
                        organizationUri = FindOrganization(crmKeys.Organization,
                            orgs.ToArray()).Endpoints[EndpointType.OrganizationService];
                    }
                }

                if (!String.IsNullOrWhiteSpace(organizationUri))
                {
                    IServiceManagement<IOrganizationService> orgServiceManagement =
                        ServiceConfigurationFactory.CreateManagement<IOrganizationService>(
                        new Uri(organizationUri));

                    // Set the credentials.
                    AuthenticationCredentials credentials = GetCredentials(crmKeys);

                    // Get the organization service proxy.
                    service = GetProxy<IOrganizationService, OrganizationServiceProxy>(orgServiceManagement, credentials);

                    // This statement is required to enable early-bound type support.
                    service.EnableProxyTypes();

                    var user = service.Retrieve("systemuser", userId, new ColumnSet("systemuserid"));

                    // Verify if UserId passed exists in CRM
                    if (user != null && user.Contains("systemuserid"))
                    {
                        // To impersonate another user, set the OrganizationServiceProxy.CallerId
                        // property to the ID of the other user.
                        service.CallerId = userId;
                    }
                }
            }

            return service;
        }

        /// <summary>
        /// Obtain the AuthenticationCredentials based on AuthenticationProviderType.
        /// </summary>
        /// <returns>Get filled credentials.</returns>
        private AuthenticationCredentials GetCredentials(CRMKeys crmUserCredential)
        {
            AuthenticationCredentials authCredentials = new AuthenticationCredentials();

            authCredentials.ClientCredentials.Windows.ClientCredential =
                        new System.Net.NetworkCredential(crmUserCredential.UserName,
                            crmUserCredential.Password,
                            crmUserCredential.Domain);

            return authCredentials;
        }

        /// <summary>
        /// Discovers the organizations that the calling user belongs to.
        /// </summary>
        /// <param name="service">A Discovery service proxy instance.</param>
        /// <returns>Array containing detailed information on each organization that 
        /// the user belongs to.</returns>
        public OrganizationDetailCollection DiscoverOrganizations(
            IDiscoveryService service)
        {
            if (service == null) 
                throw new ArgumentNullException("Discovery not found");
            RetrieveOrganizationsRequest orgRequest = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse orgResponse =
                (RetrieveOrganizationsResponse)service.Execute(orgRequest);

            return orgResponse.Details;
        }

        /// <summary>
        /// Finds a specific organization detail in the array of organization details
        /// returned from the Discovery service.
        /// </summary>
        /// <param name="orgUniqueName">The unique name of the organization to find.</param>
        /// <param name="orgDetails">Array of organization detail object returned from the discovery service.</param>
        /// <returns>Organization details or null if the organization was not found.</returns>
        /// <seealso cref="DiscoveryOrganizations"/>
        public OrganizationDetail FindOrganization(string orgUniqueName,
            OrganizationDetail[] orgDetails)
        {
            if (String.IsNullOrWhiteSpace(orgUniqueName))
                throw new ArgumentNullException("orgUniqueName");
            if (orgDetails == null)
                throw new ArgumentNullException("orgDetails");
            OrganizationDetail orgDetail = null;

            foreach (OrganizationDetail detail in orgDetails)
            {
                if (String.Compare(detail.UniqueName, orgUniqueName,
                    StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    orgDetail = detail;
                    break;
                }
            }
            return orgDetail;
        }

        /// <summary>
        /// Generic method to obtain discovery/organization service proxy instance.
        /// </summary>
        /// <typeparam name="TService">
        /// Set IDiscoveryService or IOrganizationService type to request respective service proxy instance.
        /// </typeparam>
        /// <typeparam name="TProxy">
        /// Set the return type to either DiscoveryServiceProxy or OrganizationServiceProxy type based on TService type.
        /// </typeparam>
        /// <param name="serviceManagement">An instance of IServiceManagement</param>
        /// <param name="authCredentials">The user's Microsoft Dynamics CRM logon credentials.</param>
        /// <returns></returns>
        private TProxy GetProxy<TService, TProxy>(
            IServiceManagement<TService> serviceManagement,
            AuthenticationCredentials authCredentials)
            where TService : class
            where TProxy : ServiceProxy<TService>
        {
            Type classType = typeof(TProxy);

            if (serviceManagement.AuthenticationType !=
                AuthenticationProviderType.ActiveDirectory)
            {
                AuthenticationCredentials tokenCredentials =
                    serviceManagement.Authenticate(authCredentials);
                // Obtain discovery/organization service proxy for Federated, LiveId and OnlineFederated environments. 
                // Instantiate a new class of type using the 2 parameter constructor of type IServiceManagement and SecurityTokenResponse.
                return (TProxy)classType
                    .GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(SecurityTokenResponse) })
                    .Invoke(new object[] { serviceManagement, tokenCredentials.SecurityTokenResponse });
            }

            // Obtain discovery/organization service proxy for ActiveDirectory environment.
            // Instantiate a new class of type using the 2 parameter constructor of type IServiceManagement and ClientCredentials.
            return (TProxy)classType
                .GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(ClientCredentials) })
                .Invoke(new object[] { serviceManagement, authCredentials.ClientCredentials });
        }

        /// <summary>
        /// Get CRM Keys
        /// </summary>
        /// <returns>CRMKeys object</returns>
        private CRMKeys RetrieveCRMKeys()
        {
            var crmKeys = new CRMKeys();
            Structs.Credential objCredential = new Structs.Credential();

            try
            {
                string crmUserCredentialKey = ConfigurationManager.AppSettings["CRMUserCredentialKey"];
                var rc = CredMan.CredRead(crmUserCredentialKey, Enums.CRED_TYPE.GENERIC, out objCredential);
                crmKeys.UserName = objCredential.UserName;
                crmKeys.Password = objCredential.CredentialBlob;
                crmKeys.Domain = ConfigurationManager.AppSettings["Domain"];
                crmKeys.Organization = ConfigurationManager.AppSettings["CRMOrganization"];
                crmKeys.Url = ConfigurationManager.AppSettings["CRMUrl"];
            }
            catch (Exception ex)
            {
                crmKeys.UserName = string.Empty;
                crmKeys.Password = string.Empty;
                crmKeys.Domain = string.Empty;
                crmKeys.Organization = string.Empty;
                crmKeys.Url = string.Empty;
                throw ex;
            }

            return crmKeys;
        }

        #endregion Get CRM Service

        #region Get/Retrieve CRM Records

        /// <summary>
        /// Get Records by FetchXML passed with parameter
        /// </summary>
        /// <param name="fetch">fetch with query that need to be retrieve form CRM</param>
        /// <returns>EntityCollection with all records returned of query</returns>
        public EntityCollection GetCRMRecords(StringBuilder fetch)
        {
            RetrieveMultipleRequest retriveMultiple;

            retriveMultiple = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetch.ToString())
            };

            return ((RetrieveMultipleResponse)service.Execute(retriveMultiple)).EntityCollection;
        }

        /// <summary>
        /// Get the First Record by FetchXML passed with parameter
        /// </summary>
        /// <param name="fetch">fetch with query that need to be retrieve form CRM</param>
        /// <returns>Entity with first record returned of query</returns>
        public Entity GetCRMFirstRecord(StringBuilder fetch)
        {
            RetrieveMultipleRequest retriveMultiple;

            retriveMultiple = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetch.ToString())
            };

            EntityCollection entityCollection = ((RetrieveMultipleResponse)service.Execute(retriveMultiple)).EntityCollection;

            return entityCollection.Entities.FirstOrDefault();
        }

        /// <summary>
        /// Get Records by EntityReference passed with parameter
        /// </summary>
        /// <param name="entityReference">entity reference that need to be retrieve form CRM</param>
        /// <returns>EntityCollection with all records returned of query</returns>
        public EntityCollection GetCRMRecords(EntityReference entityReference)
        {
            RetrieveMultipleRequest retriveMultiple;
            StringBuilder fetch;

            fetch = new StringBuilder();

            fetch.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetch.AppendFormat("<entity name='{0}'>", entityReference.LogicalName);
            fetch.Append("<all-attributes/>");
            fetch.Append("<filter type='and'>");
            fetch.AppendFormat("<condition attribute='{0}' operator='eq' uitype='{1}' value='{2}' />", (entityReference.LogicalName + "id"), entityReference.LogicalName, entityReference.Id);
            fetch.Append("</filter>");
            fetch.Append("</entity>");
            fetch.Append("</fetch>");

            retriveMultiple = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetch.ToString())
            };

            return ((RetrieveMultipleResponse)service.Execute(retriveMultiple)).EntityCollection;
        }

        /// <summary>
        /// Get Records by Entity passed with parameter
        /// </summary>
        /// <param name="entity">entity that need to be retrieve form CRM</param>
        /// <returns>EntityCollection with all records returned of query</returns>
        public EntityCollection GetCRMRecords(string entity)
        {
            RetrieveMultipleRequest retriveMultiple;
            StringBuilder fetch;

            fetch = new StringBuilder();

            fetch.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetch.AppendFormat("<entity name='{0}'>", entity);
            fetch.Append("<all-attributes/>");
            fetch.Append("<filter type='and'>");
            fetch.Append("</filter>");
            fetch.Append("</entity>");
            fetch.Append("</fetch>");

            retriveMultiple = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetch.ToString())
            };

            return ((RetrieveMultipleResponse)service.Execute(retriveMultiple)).EntityCollection;
        }

        #endregion Get/Retrieve CRM Records
    }
}
