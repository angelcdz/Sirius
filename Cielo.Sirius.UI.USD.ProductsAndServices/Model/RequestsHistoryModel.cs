using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class RequestsHistoryModel : ModelBase<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>
    {
        protected override Func<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>(productsService.GetProductRequestsHistory);
        }
    }
}
