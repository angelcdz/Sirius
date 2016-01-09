using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonEnabledProductsModel : ModelBase<ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>
    {
        protected override Func<ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>(productsService.ConsultarProdutoElegivelCliente);
        }
    }
}
