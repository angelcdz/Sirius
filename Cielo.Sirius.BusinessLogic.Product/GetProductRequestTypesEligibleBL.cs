
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetEligibleProductRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class GetProductRequestTypesEligibleBL : BusinessLogicBase<GetEligibleProductRequestTypesRequest, GetEligibleProductRequestTypesResponse>
    {
        public override GetEligibleProductRequestTypesResponse Execute(GetEligibleProductRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetEligibleProductRequestTypesDAO, GetEligibleProductRequestTypesRequest, GetEligibleProductRequestTypesResponse>();

            requestData.ProductGroup = Constants.GRUPO_PRODUTO_ELEGIVEL_NAOHABILITADO;

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
