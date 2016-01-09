
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class GetProductRequestTypesNonEligibleBL : BusinessLogicBase<GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse>
    {
        public override GetNonEligibleProductRequestTypesResponse Execute(GetNonEligibleProductRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetNonEligibleProductRequestTypesDAO, GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse>();

            requestData.ProductGroup = Constants.GRUPO_PRODUTO_NAOELEGIVEL;

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
