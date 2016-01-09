using System;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetRequestReasonModel : ModelBase<GetRequestReasonRequest, GetRequestReasonResponse>
    {
        protected override Func<GetRequestReasonRequest, GetRequestReasonResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetRequestReasonRequest, GetRequestReasonResponse>(productsService.GetRequestReason);
        }
    }
}
