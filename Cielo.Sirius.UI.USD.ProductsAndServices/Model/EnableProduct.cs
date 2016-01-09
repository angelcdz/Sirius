using System;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnableProduct : ModelBase<HabilitarProdutoRequest, HabilitarProdutoResponse>
    {
        protected override Func<HabilitarProdutoRequest, HabilitarProdutoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<HabilitarProdutoRequest, HabilitarProdutoResponse>(productsService.HabilitarProduto);
        }
    }
}
