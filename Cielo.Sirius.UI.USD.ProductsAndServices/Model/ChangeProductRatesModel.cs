using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ChangeProductRatesModel : ModelBase<AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>
    {
        protected override Func<AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>(productsService.AlterarTaxa);
        }

    }
}
