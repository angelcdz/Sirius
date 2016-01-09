using System;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class ValidatePermissionTypedSaleModel : ModelBase<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>
    {
        protected override Func<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>(productsService.ValidarPermissaoVendaDigitiada);
        }
    }
}
