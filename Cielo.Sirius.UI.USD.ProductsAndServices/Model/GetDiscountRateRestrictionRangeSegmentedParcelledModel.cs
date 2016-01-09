using Cielo.Sirius.Contracts.CalcularAlcadaFaixasParceladoSegmentado;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetDiscountRateRestrictionRangeSegmentedParcelledModel : ModelBase<CalcularAlcadaFaixasParceladoSegmentadoRequest, CalcularAlcadaFaixasParceladoSegmentadoResponse>
    {
        protected override Func<CalcularAlcadaFaixasParceladoSegmentadoRequest, CalcularAlcadaFaixasParceladoSegmentadoResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<CalcularAlcadaFaixasParceladoSegmentadoRequest, CalcularAlcadaFaixasParceladoSegmentadoResponse>(productsService.CalcularAlcadaFaixasParceladoSegmentado);
        }
    }
}