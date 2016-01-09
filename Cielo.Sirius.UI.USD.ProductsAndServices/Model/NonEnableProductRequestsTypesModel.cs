using Cielo.Sirius.Contracts.GetNonEnabledProductRequestTypes;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonEnableProductRequestsTypesModel : ModelBase<GetNonEnabledProductRequestTypesRequest, GetNonEnabledProductRequestTypesResponse>
    {
        protected override Func<GetNonEnabledProductRequestTypesRequest, GetNonEnabledProductRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetNonEnabledProductRequestTypesRequest, GetNonEnabledProductRequestTypesResponse>(productsService.GetProductRequestTypesNonEnabled);
        }
    }
}
