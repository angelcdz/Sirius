using System;

using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetPatAleloInformationModel : ModelBase<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>
    {
        protected override Func<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>(productsService.ConsultarInformacoesPatAleloCliente);
        }
    }
}
