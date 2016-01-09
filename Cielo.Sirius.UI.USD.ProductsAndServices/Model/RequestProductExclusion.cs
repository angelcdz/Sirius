using System;
using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class RequestProductExclusion : ModelBase<SolicitarExclusaoProdutoRequest,SolicitarExclusaoProdutoResponse>
    {
        protected override Func<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>(productsService.SolicitarExclusaoProduto);
        }
    }
}
