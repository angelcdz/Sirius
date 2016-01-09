using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class RequestRatesPurviewModel : ModelBase<GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>
    {
        protected override Func<GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>(productsService.GetDiscountRateRestriction);
        }
    }
}
