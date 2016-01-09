using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.ConsultarDadosNegociacao;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetNegotiationDataModel : ModelBase<ConsultarDadosNegociacaoRequest, ConsultarDadosNegociacaoResponse>
    {
        protected override Func<ConsultarDadosNegociacaoRequest, ConsultarDadosNegociacaoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ConsultarDadosNegociacaoRequest, ConsultarDadosNegociacaoResponse>(productsService.ConsultarDadosNegociacao);
        }
    }
}
