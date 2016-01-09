using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonElegibleProductDetailsModel : ModelBase<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>
    {
        protected override Func<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>(productsService.ConsultarDetalheProdutoNaoElegivelCliente);
        }
    }
}
