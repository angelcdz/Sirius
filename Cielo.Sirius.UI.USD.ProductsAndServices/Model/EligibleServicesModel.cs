using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EligibleServicesModel : ModelBase<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>
    {
        protected override Func<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>(productsService.ConsultarServicoElegivelCliente);
        }
    }
}
