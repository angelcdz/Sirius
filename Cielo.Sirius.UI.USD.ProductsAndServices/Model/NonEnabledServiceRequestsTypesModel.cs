using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonEnabledServiceRequestsTypesModel : ModelBase<GetNonEnabledServiceRequestTypesRequest, GetNonEnabledServiceRequestTypesResponse>
    {
        protected override Func<GetNonEnabledServiceRequestTypesRequest, GetNonEnabledServiceRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetNonEnabledServiceRequestTypesRequest, GetNonEnabledServiceRequestTypesResponse>(productsService.GetServiceRequestTypesNonEnabled);
        }
    }
}
