using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.ServiceModel.Description;
using System.Text;

namespace Avanade.SmartApps.Logger
{
    class LoggingSDKDAL
    {

        public class ReturnLog
        {
            public bool Sucess { get; set; }
            public Exception Ex { get; set; }
        }

        public ReturnLog SaveLogCRM(Log objLog)
        {
            ReturnLog returnLog = new ReturnLog();
            try
            {
                using (OrganizationServiceProxy serviceProxy = GetOrganizationService())
                {
                    Entity e = new Entity("new_logging");

                    e.Attributes["new_idcorrelacao"] = objLog.IdCorrelacao;
                    e.Attributes["new_data"] = objLog.DataHora;
                    e.Attributes["new_ip"] = objLog.Ip;
                    e.Attributes["new_maquina"] = objLog.Maquina;
                    e.Attributes["new_usuario"] = objLog.Usuario;
                    e.Attributes["new_sistemaorigem"] = objLog.SistemaOrigem;
                    e.Attributes["new_tipodolog"] = objLog.Tipo;
                    e.Attributes["new_dados2"] = objLog.Dados;

                    serviceProxy.Create(e);

                    returnLog.Sucess = true;

                    return returnLog;
                }
            }
            catch (Exception ex)
            {
                returnLog.Ex = ex;
                returnLog.Sucess = false;
                return returnLog;
            }
        }

        public string GetCustomCrmConfig()
        {
            string xmlCustom = string.Empty;
            byte[] binary = null;

            OrganizationServiceProxy serviceProxy = GetOrganizationService();

            //Request the action "GetLog4Net"
            OrganizationRequest request = new OrganizationRequest("new_GetLog4NetConfiguration");

            //Get the response for the action
            OrganizationResponse response = serviceProxy.Execute(request);
            EntityReference webResourceReference = (EntityReference)response.Results["appender"];

            //Retrieve the webresource entity object
            Entity wb = serviceProxy.Retrieve("webresource", webResourceReference.Id, new ColumnSet("content"));

            binary = Convert.FromBase64String(wb.Attributes["content"].ToString());
            if (binary != null) xmlCustom = UnicodeEncoding.UTF8.GetString(binary);
            return xmlCustom;
        }

        private OrganizationServiceProxy GetOrganizationService()
        {
            DynamicsCRMDAO crmDao = new DynamicsCRMDAO();
            return crmDao.GetCRMService(Guid.NewGuid());

            //ClientCredentials credentials = new ClientCredentials();
            //credentials.Windows.ClientCredential.UserName = "Administrator";
            //credentials.Windows.ClientCredential.Domain = "CRM";
            //credentials.Windows.ClientCredential.Password = "ZXasqw111";
            //return new OrganizationServiceProxy(new Uri("http://win-lt2std568dd:5555/CRM/XRMServices/2011/Organization.svc"), null, credentials, null);
        }
    }
}
