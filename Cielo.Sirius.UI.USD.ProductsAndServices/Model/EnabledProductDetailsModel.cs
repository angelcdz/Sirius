using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnabledProductDetailsModel : ModelBase<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>
    {
        protected override Func<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>(productsService.ConsultarDetalheProdutoHabilitadoCliente);
        }
    }
}
