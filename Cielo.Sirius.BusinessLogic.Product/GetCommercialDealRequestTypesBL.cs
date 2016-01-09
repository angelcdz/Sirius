using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetCommercialDealRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.Business.Products
{
    public class GetCommercialDealRequestTypesBL : BusinessLogicBase<GetCommercialDealRequestTypesRequest, GetCommercialDealRequestTypesResponse>
    {
        public override GetCommercialDealRequestTypesResponse Execute(GetCommercialDealRequestTypesRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetCommercialDealRequestTypesDAO, GetCommercialDealRequestTypesRequest, GetCommercialDealRequestTypesResponse>();
            var response = dao.Execute(requestData);
            return response;
        }
    }
}
