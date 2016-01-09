using Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonElegibleProductsModel : ModelBase<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>
    {
        protected override Func<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>(productsService.ConsultarProdutoNaoElegivelCliente);
        }
    }
}
