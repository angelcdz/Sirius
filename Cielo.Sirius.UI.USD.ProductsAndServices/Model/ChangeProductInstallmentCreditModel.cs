using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParcelado;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    class ChangeProductInstallmentCreditModel : ModelBase<AlterarProdutoCreditoParceladoRequest, AlterarProdutoCreditoParceladoResponse>
    {
        protected override Func<AlterarProdutoCreditoParceladoRequest, AlterarProdutoCreditoParceladoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<AlterarProdutoCreditoParceladoRequest, AlterarProdutoCreditoParceladoResponse>(productsService.AlterarProdutoCreditoParcelado);
        }
    }
}