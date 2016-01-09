using System;
using System.Web.Services.Protocols;

namespace Cielo.Sirius.Foundation.Extensions
{
    public static class SoapExceptionExtensions
    {
        public static bool TryExtractOSBError<ResponseType>(this SoapException ex, out ResponseType response)
            where ResponseType : ResponseBase, new()
        {
            response = new ResponseType();

            try
            {
                int totalNodes = ex.Detail.ChildNodes.Count;
                int i = 0;
                while (ex.Detail.ChildNodes[i]["comum:codigo"] == null && i < totalNodes) i++;

                response.ErrorCode    = ex.Detail.ChildNodes[i]["comum:codigo"].InnerText;
                response.ErrorMessage = ex.Detail.ChildNodes[i]["comum:descricao"].InnerText;
                response.Status       = ex.Detail.ChildNodes[i]["comum:tipo"].InnerText == "NEGOCIO" ? ExecutionStatus.BusinessError : ExecutionStatus.TechnicalError;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}