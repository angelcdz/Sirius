using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class GetProductRequestsHistoryBL : BusinessLogicBase<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>
    {
        public override GetProductRequestsHistoryResponse Execute(GetProductRequestsHistoryRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetProductRequestsHistoryDAO, GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
