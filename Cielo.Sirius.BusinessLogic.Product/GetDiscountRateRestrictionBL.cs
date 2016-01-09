using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class GetDiscountRateRestrictionBL : BusinessLogicBase<GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>
    {
        public override GetDiscountRateRestrictionResponse Execute(GetDiscountRateRestrictionRequest requestData)
        {
            var dao = DAOFactory.GetDAO<GetDiscountRateRestrictionDAO, GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>();

            var response = dao.Execute(requestData);

            // Minimum Tax = Default Tax - ((Default Tax * Discount Rate Restriction Percentage) / 100
            response.MinDiscountRateRestrictionPercentage =
                requestData.DefaultRate - ((requestData.DefaultRate * response.DiscountRateRestrictionPercentage)/100);

            // Maximum Tax = Default Tax
            response.MaxDiscountRateRestrictionPercentage = requestData.DefaultRate;

            return response;
        }
    }
}
