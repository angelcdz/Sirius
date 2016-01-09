using Microsoft.Uii.AifServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.USD
{
    public abstract class ModelBase<RequestType, ResponseType>
        where RequestType : RequestBase
        where ResponseType : ResponseBase
    {
        Logger _logger = Logger.LoggerFor<ModelBase<RequestType, ResponseType>>();

        public ResponseType Response { get; private set; }
        public RequestType Request { get; set; }

        public string ErrorMessage { get; protected set; }
        public string ErrorCode { get; protected set; }

        protected abstract Func<RequestType, ResponseType> GetServiceMethod();

        protected virtual bool ValidadeRequest()
        {
            return true;
        }

        protected virtual bool ValidadeResponse()
        {
            return true;
        }

        public ExecutionStatus Execute(bool useCache_ = false)
        {
            if (!ValidadeRequest())
                return ExecutionStatus.BusinessError;

            ExecutionStatus result;
            try
            {
                var serviceMethod = GetServiceMethod();

                if (useCache_)
                {
                    // TODO: Obter o numero do protocolo de atendimento para utilizar como chave para o cache
                    string cacheKey = "";

                    Response = Cache.SmartRequest(cacheKey, Request, GetServiceMethod());
                    _logger.LogInformation("Service method: '{0}' executed with cache.", serviceMethod.Method.Name);
                }
                else
                {
                    Request.UserId = AifServiceContainer.Instance.GetService<Microsoft.Uii.AifServices.AuthenticationService>().WhoAmI.UserId;
                    Request.CorrelationId = Trace.CorrelationManager.ActivityId;
                    Response = serviceMethod(Request);
                    _logger.LogInformation("Service method: '{0}' executed without cache.", serviceMethod.Method.Name);
                }

                if (Response != null)
                {
                    ErrorMessage = Response.ErrorMessage;
                    ErrorCode = Response.ErrorCode;
                    result = Response.Status;
                }
                else
                {
                    _logger.LogError("The service method: '{0}' response is 'null'", serviceMethod.Method.Name);
                    ErrorMessage = "Falha ao carregar as informações.";
                    return ExecutionStatus.TechnicalError;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured on Model '{0}' execution", this.GetType().FullName);
                ErrorMessage = "Falha ao carregar as informações.";
                return ExecutionStatus.TechnicalError;
            }

            if (!ValidadeResponse())
                return ExecutionStatus.BusinessError;

            return result;
        }

        /// <summary>
        /// Retrieve the USD user credentials
        /// </summary>
        /// <returns>
        /// Object that contains USD User Credentials
        /// </returns>
        protected NetworkCredential GetDefaultCredential()
        {
            //Declarando as variáveis do método
            NetworkCredential returnValue = null;

            try
            {
                ContextService uiiContextService = (ContextService)AifServiceContainer.Instance.GetService<Microsoft.Uii.AifServices.IContextService>();

                //Carregando as informações do método
                returnValue = GetWindowsClientCredential(uiiContextService);

                //Verificando se as informações da credencial foram informadas
                returnValue = returnValue == null ? GetUserClientCredential(uiiContextService) : returnValue;
            }
            catch (Exception ex)
            {
                //TODO:(MR) Colocar tratamento de erro
                _logger.LogError(ex, "An error occured on Model '{0}' execution in the GetDefaultCredential method", this.GetType().FullName);
                throw;
            }

            // Retornando as informações da credencial utilizada no USD
            return returnValue;
        }

        /// <summary>
        /// Retrieve the USD User Credential for Dynamics CRM Online Connection
        /// </summary>
        /// <param name="uiiContextService">
        /// USD Service Context--> AifServiceContainer.Instance.GetService >Microsoft.Uii.AifServices.IContextService>()
        /// </param>
        /// <returns>
        /// Object that contains USD User Credentials
        /// </returns>
        private NetworkCredential GetUserClientCredential(Microsoft.Uii.AifServices.ContextService uiiContextService)
        {
            //Declarando as variáveis do método
            NetworkCredential returnValue = null;

            try
            {
                //Carregando as informações do usuário
                returnValue = uiiContextService.CrmServiceClient.OrganizationServiceProxy.ClientCredentials.Windows.ClientCredential;

                //Verificando as credenciais do usuários estão presentes
                returnValue = string.IsNullOrEmpty(returnValue.UserName) ? null : returnValue;
            }
            catch (Exception ex)
            {
                //TODO:(MR) Adicionar tratamento de erro
                _logger.LogError(ex, "An error occured on Model '{0}' execution in the GetUserClientCredential method", this.GetType().FullName);
                throw ex;
            }

            //Retornando o valor gerado pela funcionalidade
            return returnValue;
        }

        /// <summary>
        /// Retrieve the USD User Credential for Dynamics CRM On Primese Connection
        /// </summary>
        /// <returns>
        /// Object that contains USD User Credentials
        /// </returns>
        private NetworkCredential GetWindowsClientCredential(Microsoft.Uii.AifServices.ContextService uiiContextService)
        {
            //Declarando as variáveis do método
            NetworkCredential returnValue = null;

            try
            {
                //Carregando as informações do usuário
                returnValue = uiiContextService.CrmServiceClient.OrganizationServiceProxy.ClientCredentials.Windows.ClientCredential;

                //Verificando as credenciais do usuários estão presentes
                returnValue = string.IsNullOrEmpty(returnValue.UserName) ? null : returnValue;
            }
            catch (Exception ex)
            {
                //TODO:(MR) Adicionar tratamento de erro
                _logger.LogError(ex, "An error occured on Model '{0}' execution in the GetWindowsClientCredential method", this.GetType().FullName);
                throw ex;
            }

            //Retornando o valor gerado pela funcionalidade
            return returnValue;
        }
    }
}
