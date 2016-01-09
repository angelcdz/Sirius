using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.Products
{
    public class GetServiceRequestTypesNonEnabledBL : BusinessLogicBase<GetNonEnabledServiceRequestTypesRequest, GetNonEnabledServiceRequestTypesResponse>
    {
        public override GetNonEnabledServiceRequestTypesResponse Execute(GetNonEnabledServiceRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetNonEnabledServiceRequestTypesDAO, GetNonEnabledServiceRequestTypesRequest,
                                        GetNonEnabledServiceRequestTypesResponse>();
            var responseData = dao.Execute(requestData);

            if (responseData.Status != Foundation.ExecutionStatus.Success)
            {
                return responseData;
            }

            return VerifyServiceRequestTypesNonEnabledRules(requestData, responseData);
        }

        private GetNonEnabledServiceRequestTypesResponse VerifyServiceRequestTypesNonEnabledRules(GetNonEnabledServiceRequestTypesRequest request,
                                                                                           GetNonEnabledServiceRequestTypesResponse response)
        {
            string serviceName = string.IsNullOrEmpty(request.ServiceName) ? string.Empty : request.ServiceName.Trim().ToUpper();
            // TODO:List filled with services that can't be enabled
            List<string> serviceList = new List<string>(new string[] { "ALE", "DOTZ", "LINKCI", "PROMOFIND", "PREMIA CTF BR", "CIELO PROMO", "MEI" });

            if (serviceList.Contains(serviceName))
            {
                response.ServiceRequestTypes.RemoveAll(s => s.IntegrationRequestCode == Constants.TIPO_DEMANDA_SVC_HABILITAR_SERVICO);
            }

            return response;
        }
    }
}
