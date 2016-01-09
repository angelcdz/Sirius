using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class RateNegotiationRequestModel : ModelBase<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>
    {
        protected override Func<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>(productsService.SolicitarNegociacaoTaxaProdutoComercial);
        }
    }
}