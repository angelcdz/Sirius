using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetEnabledServiceRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.Products
{
    public class GetServiceRequestTypesEnabledBL : BusinessLogicBase<GetEnabledServiceRequestTypesRequest, GetEnabledServiceRequestTypesResponse>
    {
        public override GetEnabledServiceRequestTypesResponse Execute(GetEnabledServiceRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetEnabledServiceRequestTypesDAO, GetEnabledServiceRequestTypesRequest, 
                                        GetEnabledServiceRequestTypesResponse>();
            var responseData = dao.Execute(requestData);

            if (responseData.Status != Foundation.ExecutionStatus.Success)
            {
                return responseData;
            }

            return VerifyServiceRequestTypesEnabledRules(requestData, responseData);            
        }

        private GetEnabledServiceRequestTypesResponse VerifyServiceRequestTypesEnabledRules(GetEnabledServiceRequestTypesRequest request, 
                                                                                           GetEnabledServiceRequestTypesResponse response)
        {
            string serviceName = string.IsNullOrEmpty(request.ServiceName) ? string.Empty : request.ServiceName.Trim().ToUpper();
            // TODO:List filled with services that can't be disabled
            List<string> serviceList = new List<string>(new string[] { "ALE", "DOTZ", "LINKCI", "PROMOFIND", "PREMIA CTF BR", "CIELO PROMO", "MEI" });

            if (serviceList.Contains(serviceName))
            {
                response.ServiceRequestTypes.RemoveAll(s => s.IntegrationRequestCode == Constants.TIPO_DEMANDA_SVC_DESABILITAR_SERVICO);
            }

            return response;
        }
    }
}
