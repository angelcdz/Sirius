using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Contracts.AlterarProdutoAVista;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ChangeProductOneLumpModel : ModelBase<AlterarProdutoAVistaRequest, AlterarProdutoAVistaResponse>
    {
        protected override Func<AlterarProdutoAVistaRequest, AlterarProdutoAVistaResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<AlterarProdutoAVistaRequest, AlterarProdutoAVistaResponse>(productsService.AlterarProdutoAVista);
        }

    }
}
