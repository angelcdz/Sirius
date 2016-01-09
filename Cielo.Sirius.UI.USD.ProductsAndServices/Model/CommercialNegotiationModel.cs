using System;
using Cielo.Sirius.Contracts.NegociacaoComercial;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class CommercialNegotiationModel : ModelBase<NegociacaoComercialRequest, NegociacaoComercialResponse>
    {
        protected override Func<NegociacaoComercialRequest, NegociacaoComercialResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<NegociacaoComercialRequest, NegociacaoComercialResponse>(productsService.NegociacaoComercial);
        }
    }
}
