using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnabledProductsModel : ModelBase<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>
    {
        protected override Func<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>(productsService.ConsultarProdutoHabilitadoCliente);
        }
    }
}
