using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.USD.UI.ProductsAndServices.ProdutosService;
using System;

namespace Cielo.Sirius.USD.UI.ProductsAndServices.Model
{
    public class ValidateTypedSalePermissionModel : ModelBase<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>
    {
        protected override Func<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>(productsService.ValidarPermissaoVendaDigitiada);
        }
    }
}
