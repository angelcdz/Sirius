using Cielo.Sirius.Contracts.ConsultarElegibilidadeCriacaoDemanda;
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
    public class ConsultarElegibilidadeCriacaoDemandaMock : MockBase
    {

        [TestMethod] 
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarElegibilidadeCriacaoDemandaRequest, ConsultarElegibilidadeCriacaoDemandaResponse>>();

            var request = new ConsultarElegibilidadeCriacaoDemandaRequest()
            {
                CodigoCliente = 10011001,
                TipoDemanda = 123456
            };

            var response = new ConsultarElegibilidadeCriacaoDemandaResponse()
            {
                IndicadorElegibilidade = true,
                Status = ExecutionStatus.Success
            };

            var mockSet = new MockSet<ConsultarElegibilidadeCriacaoDemandaRequest, ConsultarElegibilidadeCriacaoDemandaResponse>();
            mockSet.request = request;
            mockSet.response = response;
            mockSets.Add(mockSet);

            request = new ConsultarElegibilidadeCriacaoDemandaRequest()
            {
                CodigoCliente = 10011002,
                TipoDemanda = 123456
            };

            response = new ConsultarElegibilidadeCriacaoDemandaResponse()
            {
                IndicadorElegibilidade = false,
                Status = ExecutionStatus.Success
            };

            mockSet = new MockSet<ConsultarElegibilidadeCriacaoDemandaRequest, ConsultarElegibilidadeCriacaoDemandaResponse>();
            mockSet.request = request;
            mockSet.response = response;
            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\ConsultarElegibilidadeCriacaoDemandaMock.xml", mockSets);

        }
    }
}
