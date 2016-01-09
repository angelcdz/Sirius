using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

using Cielo.CredentialManager;
using Cielo.Sirius.Foundation.Configuration;
using Cielo.Sirius.Foundation.Extensions;
using System.Diagnostics;
using System.Net;

namespace Cielo.Sirius.Foundation
{
    public abstract class DAOOSBBase<RequestType, ResponseType> : DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase, new()
        where RequestType : RequestBase
    {
        Logger logger = Logger.LoggerFor<DAOOSBBase<RequestType, ResponseType>>();

        protected string ServiceUrl
        { get; set; }

        protected DataAccessConfigurationElement Config
        { get; set; }

        public DAOOSBBase()
        {
            this.Config = DataAccessConfiguration.Settings.DataAccessComponents[this.GetType().Name];

            if (this.Config == null)
            {
                throw new ConfigurationErrorsException(string.Format("Missing DataAccess configuration element for DAO '{0}'.", this.GetType().Name));
            }

            if (this.Config.Parameters["serviceUrl"] == null || string.IsNullOrEmpty(this.Config.Parameters["serviceUrl"].Value))
            {
                logger.LogWarning("Parameter 'serviceUrl' for DAO '{0}' not configured. Default endpoint configuration will be used.", this.GetType().Name);
            }
            else
            {
                this.ServiceUrl = this.Config.Parameters["serviceUrl"].Value;
            }
        }

        public override ResponseType Execute(RequestType requestData)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            ResponseType response = null;

            try
            {
                logger.LogVerbose("Starting DAO-OSB Execution.");

                response = this.GetData(requestData);

                logger.LogVerbose("Ending DAO-OSB Execution.");

                return response;
            }
            catch (WebException webException)
            {
                logger.LogError(webException, "An error occurred during DAO-OSB execution: {0}", webException.Message);

                if (webException.Status == WebExceptionStatus.Timeout)
                {
                    this.HandleTechnicalError(webException, out response, ErrorCodes.DAO_OSB_CALL_TIMEOUT_ERROR);
                }
                else if (webException.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    this.HandleTechnicalError(webException, out response, ErrorCodes.DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR);
                }
                else
                {
                    this.HandleTechnicalError(webException, out response);
                }
            }
            catch (SoapException soapException)
            {
                logger.LogError(soapException, "An error occurred during DAO-OSB execution: {0}", soapException.Message);

                if (!soapException.TryExtractOSBError(out response))
                {
                    this.HandleTechnicalError(soapException, out response, ErrorCodes.DAO_OSB_CALL_SOAP_ERROR);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during DAO-OSB execution: {0}", ex.Message);

                this.HandleTechnicalError(ex, out response);
            }
            finally
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                logger.LogVerbose("DAO-OSB execution runtime: {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }

            return response;
        }

        /// <summary>
        /// Method or operation is used to retrieve OSBCredentials from Windows Credential
        /// </summary>
        public OSBCredentials RetrieveOSBCredentials()
        {
            string credendialKey = Parameters["credentialKey"];

            if (string.IsNullOrEmpty(credendialKey))
            {
                throw new ConfigurationErrorsException(string.Format("Missing 'credentialKey' parameter for '{0}' configuration.", this.GetType().Name));
            }

            string realm = Parameters["realm"];

            if (string.IsNullOrEmpty(realm))
            {
                throw new ConfigurationErrorsException(string.Format("Missing 'realm' parameter for '{0}' configuration.", this.GetType().Name));
            }

            OSBCredentials objOsbCredentials = new OSBCredentials();
            Structs.Credential objCredential = new Structs.Credential();

            var rc = CredMan.CredRead(credendialKey, Enums.CRED_TYPE.GENERIC, out objCredential);
            var returnStatus = CheckReturnCode(rc);

            if (returnStatus == Enums.CRED_ERRORS.ERROR_SUCCESS.ToString())
            {
                objOsbCredentials.Username = objCredential.UserName;
                objOsbCredentials.Password = objCredential.CredentialBlob;
                objOsbCredentials.Realm = realm;
                objOsbCredentials.ReturnCode = CheckReturnCode(rc);
            }
            else
            {
                throw new ApplicationException(string.Format("Error getting Windows Credentials. {0}: {1}.", rc, returnStatus));
            }

            return objOsbCredentials;
        }

        /// <summary>
        /// Checks the Return code after retrieving the Windows Credentials for any error.
        /// </summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        private string CheckReturnCode(int rc)
        {
            switch (rc)
            {
                case unchecked((int)Enums.CRED_ERRORS.ERROR_BAD_USERNAME):
                    return Enums.CRED_ERRORS.ERROR_BAD_USERNAME.ToString();

                case unchecked((int)Enums.CRED_ERRORS.ERROR_INVALID_FLAGS):
                    return Enums.CRED_ERRORS.ERROR_INVALID_FLAGS.ToString();

                case unchecked((int)Enums.CRED_ERRORS.ERROR_INVALID_PARAMETER):
                    return Enums.CRED_ERRORS.ERROR_INVALID_PARAMETER.ToString();

                case unchecked((int)Enums.CRED_ERRORS.ERROR_NOT_FOUND):
                    return Enums.CRED_ERRORS.ERROR_NOT_FOUND.ToString();

                case unchecked((int)Enums.CRED_ERRORS.ERROR_NO_SUCH_LOGON_SESSION):
                    return Enums.CRED_ERRORS.ERROR_NO_SUCH_LOGON_SESSION.ToString();

                case unchecked((int)Enums.CRED_ERRORS.ERROR_SUCCESS):
                    return Enums.CRED_ERRORS.ERROR_SUCCESS.ToString();

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Handle technical errors
        /// </summary>
        /// <param name="ex">Exception thrown</param>
        /// <param name="response">Response reference</param>
        /// <param name="errorCode">Error code. Default value = DAO_OSB_GENERIC_ERROR</param>
        private void HandleTechnicalError(Exception ex, out ResponseType response, string errorCode = ErrorCodes.DAO_OSB_GENERIC_ERROR)
        {
            response = new ResponseType();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = errorCode;
            response.ErrorMessage = ex.Message;
        }
    }
}