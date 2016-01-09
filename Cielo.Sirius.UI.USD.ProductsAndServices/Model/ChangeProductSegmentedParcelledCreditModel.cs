using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ChangeProductSegmentedParcelledCreditModel : ModelBase<AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>
    {
        protected override Func<AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>(productsService.AlterarProdutoCreditoParceladoSegmentado);
        }
    }
}
