using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class DisableProductModel : ModelBase<DesabilitarProdutoRequest, DesabilitarProdutoResponse>
    {
        protected override Func<DesabilitarProdutoRequest, DesabilitarProdutoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<DesabilitarProdutoRequest, DesabilitarProdutoResponse>(productsService.DesabilitarProduto);
        }
    }
}
