using System;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Contracts.DesabilitarServico;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class DisabelServiceModel : ModelBase<DesabilitarServicoRequest, DesabilitarServicoResponse>
    {
        protected override Func<DesabilitarServicoRequest, DesabilitarServicoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<DesabilitarServicoRequest, DesabilitarServicoResponse>(productsService.DesabilitarServico);
        }
    }
}
