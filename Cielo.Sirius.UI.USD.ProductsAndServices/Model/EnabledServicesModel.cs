using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class EnabledServicesModel : ModelBase<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>
    {
        protected override Func<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>(productsService.ConsultarServicoHabilitadoCliente);
        }
    }
}
