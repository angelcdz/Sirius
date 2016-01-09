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
    public class ConsultarDetalheProdutoElegivelClienteUnitTest
    {
        [TestMethod]
        public void ConsultarDetalheProdutoElegivelClienteSuccess()
        {
            var requestData = new ConsultarDetalheProdutoElegivelClienteRequest()
            {
                CodigoCliente = 1,
                CodigoProduto = "001",
                UserId = Guid.NewGuid()
            };

            var client = new ProdutosServiceClient();
            var response = client.ConsultarDetalheProdutoElegivelCliente(requestData);
            client.Close();
        }
    }

}
