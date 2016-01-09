using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetMultivanProductDetailModel : ModelBase<ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>
    {
        protected override Func<ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>(productsService.ConsultarDetalheProdutoMultivanContratadoCliente);
        }
    }
}
