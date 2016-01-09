using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonEnabledProductDetailsModel : ModelBase<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>
    {
        protected override Func<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>(productsService.ConsultarDetalheProdutoElegivelCliente);
        }
    }
}
