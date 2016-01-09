using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class NonElegibleServicesModel : ModelBase<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>
    {
        protected override Func<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>(productsService.ConsultarServicoNaoElegivelCliente);
        }
    }
}
