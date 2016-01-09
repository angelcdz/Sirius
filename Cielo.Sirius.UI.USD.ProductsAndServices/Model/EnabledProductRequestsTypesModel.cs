using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnabledProductRequestsTypesModel : ModelBase<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>
    {
        protected override Func<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>(productsService.GetProductRequestTypesEnabled);
        }
    }
}
