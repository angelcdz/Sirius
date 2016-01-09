using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ConsultInformationPatAleloModel : ModelBase<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>
    {
        protected override Func<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
           return new Func<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>(productsService.ConsultarInformacoesPatAleloCliente);
        }

    }
}
