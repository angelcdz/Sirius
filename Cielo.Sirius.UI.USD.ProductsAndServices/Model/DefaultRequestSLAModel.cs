using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Foundation.USD;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class DefaultRequestSLAModel : ModelBase<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>
    {
        protected override Func<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>(productsService.ConsultarPrazoPadrao);
        }
    }
}
