using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation.DAO;
using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;

namespace Cielo.Sirius.DAO.Products
{
    public class GetNonEligibleProductRequestTypesDAO : DAOCRMBase<GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse>
    {
        protected override GetNonEligibleProductRequestTypesResponse GetData(GetNonEligibleProductRequestTypesRequest requestData)
        {
            GetNonEligibleProductRequestTypesResponse responseData = new GetNonEligibleProductRequestTypesResponse();
            responseData.Status = Foundation.ExecutionStatus.Success;

            return responseData;
        }

    }
}