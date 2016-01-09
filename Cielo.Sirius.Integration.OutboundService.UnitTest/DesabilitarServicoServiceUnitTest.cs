using Cielo.Sirius.Integration.OutboundService.UnitTest.ProdutosServicesReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Integration.OutboundService.UnitTest
{
    [TestClass]
    public class DesabilitarServicoServiceUnitTest
    {
        [TestMethod]
        public void DesabilitarServico()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest();

            requestData.CodigoCliente = 1;
            requestData.CodigoProduto = "001";
            requestData.UserId = new Guid();

            ProdutosServiceClient client = new ProdutosServiceClient();
            var response = client.ConsultarDetalheProdutoElegivelCliente(requestData);
        }
    }
}
