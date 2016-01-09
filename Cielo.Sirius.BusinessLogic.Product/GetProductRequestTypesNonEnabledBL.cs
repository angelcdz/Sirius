using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetNonEnabledProductRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class GetProductRequestTypesNonEnabledBL : BusinessLogicBase<GetNonEnabledProductRequestTypesRequest, GetNonEnabledProductRequestTypesResponse>
    {
        public override GetNonEnabledProductRequestTypesResponse Execute(GetNonEnabledProductRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetNonEnabledProductRequestTypesDAO, GetNonEnabledProductRequestTypesRequest, GetNonEnabledProductRequestTypesResponse>();
            var response = dao.Execute(requestData);

            return response;
        }
    }
}
