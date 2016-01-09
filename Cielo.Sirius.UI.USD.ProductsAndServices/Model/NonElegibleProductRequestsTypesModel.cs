using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonElegibleProductRequestsTypesModel : ModelBase<GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse>
    {
        protected override Func<GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetNonEligibleProductRequestTypesRequest, GetNonEligibleProductRequestTypesResponse>(productsService.GetProductRequestTypesNonEligible);
        }
    }
}
