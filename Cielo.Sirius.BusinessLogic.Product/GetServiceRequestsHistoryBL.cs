using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class GetServiceRequestsHistoryBL : BusinessLogicBase<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>
    {
        public override GetServiceRequestsHistoryResponse Execute(GetServiceRequestsHistoryRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetServiceRequestsHistoryDAO, GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
