using System;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnableServiceModel : ModelBase<HabilitarServicoRequest, HabilitarServicoResponse>
    {
        protected override Func<HabilitarServicoRequest, HabilitarServicoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<HabilitarServicoRequest, HabilitarServicoResponse>(productsService.HabilitarServico);
        }


    }
}
