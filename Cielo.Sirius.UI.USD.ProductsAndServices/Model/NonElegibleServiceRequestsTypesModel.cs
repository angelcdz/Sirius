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
    public class NonElegibleServiceRequestsTypesModel : ModelBase<GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse>
    {
        protected override Func<GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetNonEligibleServiceRequestTypesRequest, GetNonEligibleServiceRequestTypesResponse>(productsService.GetServiceRequestTypesNonElegible);
        }
    }
}
