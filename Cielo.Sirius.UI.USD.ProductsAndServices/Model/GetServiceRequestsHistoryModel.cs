using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.ProdutosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.Model
{
    public class GetServiceRequestsHistoryModel : ModelBase<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>
    {
        protected override Func<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse> GetServiceMethod()
        {
            var productsService = new ProdutosServiceClient();
            productsService.ClientCredentials.Windows.ClientCredential = GetDefaultCredential();
            return new Func<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>(productsService.GetServiceRequestsHistory);
        }
    }
}
