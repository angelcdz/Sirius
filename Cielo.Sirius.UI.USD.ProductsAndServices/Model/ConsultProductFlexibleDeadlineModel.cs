using System;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ConsultProductFlexibleDeadlineModel : ModelBase<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>
    {
        protected override Func<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>(productsService.ConsultarProdutosPrazoFlexivel);
        }
    }
}
