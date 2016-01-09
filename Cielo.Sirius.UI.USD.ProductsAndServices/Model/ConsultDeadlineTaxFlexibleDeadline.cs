using System;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ConsultDeadlineTaxFlexibleDeadline : ModelBase<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>
    {
        protected override Func<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>(productsService.ConsultarPrazosTaxasPrazoFlexivel);
        }
    }
}
