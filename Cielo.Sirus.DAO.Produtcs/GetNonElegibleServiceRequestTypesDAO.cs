using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products
{
    public class GetNonElegibleServiceRequestTypesDAO : DAOCRMBase<GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse>
    {
        protected override GetNonEligibleServiceRequestTypesResponse GetData(GetNonEligibleServiceRequestTypesRequest requestData)
        {
            var responseData = new GetNonEligibleServiceRequestTypesResponse();
            responseData.ServiceRequestTypes = new List<GetNonEligibleServiceRequestTypesDTO>();
            responseData.Status = Foundation.ExecutionStatus.Success;

            return responseData;
        }
    }
}
