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
    public class GetServiceRequestTypesNonElegibleBL : BusinessLogicBase<GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse>
    {
        public override GetNonEligibleServiceRequestTypesResponse Execute(GetNonEligibleServiceRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetNonElegibleServiceRequestTypesDAO, GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse>();

            requestData.ServiceGroup = Constants.GRUPO_SERVICO_NAOELEGIVEL;

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
