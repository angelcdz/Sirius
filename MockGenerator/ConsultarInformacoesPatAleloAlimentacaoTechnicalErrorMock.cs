using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarInformacoesPatAleloAlimentacaoTechnicalErrorMock : MockBase
    {
        [TestMethod]
        public void Alimentacao()
        {
            var mockSets = new List<MockSet<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>>();

            var request = new ConsultarInformacoesPatAleloRequest()
            {
                CodigoCliente = 1
            };

            var response = new ConsultarInformacoesPatAleloResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorMessage = "Erro ao consultar as informações de PAT Alelo Alimentação";

            var mockSet = new MockSet<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\ConsultarInformacoesPatAleloAlimentacaoSuccessMock.xml", mockSets);
        }
    }
}
