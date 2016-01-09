using Cielo.Sirius.Contracts.GetEnabledServiceRequestTypes;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnabledServiceRequestsTypesModel : ModelBase<GetEnabledServiceRequestTypesRequest, GetEnabledServiceRequestTypesResponse>
    {
        protected override Func<GetEnabledServiceRequestTypesRequest, GetEnabledServiceRequestTypesResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetEnabledServiceRequestTypesRequest, GetEnabledServiceRequestTypesResponse>(productsService.GetServiceRequestTypesEnabled);
        }
    }
}
