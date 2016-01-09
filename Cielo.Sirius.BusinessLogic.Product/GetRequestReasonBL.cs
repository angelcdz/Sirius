using System;
using System.Collections.Generic;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.GetRequestReason;

namespace Cielo.Sirius.Business.Products
{
    public class GetRequestReasonBL : BusinessLogicBase<GetRequestReasonRequest, GetRequestReasonResponse>
    {
        public override GetRequestReasonResponse Execute(GetRequestReasonRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetRequestReasonDAO, GetRequestReasonRequest, GetRequestReasonResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
