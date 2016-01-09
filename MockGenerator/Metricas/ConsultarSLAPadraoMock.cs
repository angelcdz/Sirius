using Cielo.Sirius.Contracts.ConsultarSLAPadrao;
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
    public class ConsultarSLAPadraoMock : MockBase
    {

        [TestMethod] 
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarSLAPadraoRequest, ConsultarSLAPadraoResponse>>();

            var request = new ConsultarSLAPadraoRequest()
            {
                CodigoCliente = 10011001,
                TipoDemanda = 123456
            };

            var response = new ConsultarSLAPadraoResponse() { DataSLA = new DateTime(2015, 09, 25), Status = ExecutionStatus.Success };

            var mockSet = new MockSet<ConsultarSLAPadraoRequest, ConsultarSLAPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;
            mockSets.Add(mockSet);

            request = new ConsultarSLAPadraoRequest()
            {
                CodigoCliente = 10011002,
                TipoDemanda = 123456
            };

            response = new ConsultarSLAPadraoResponse() { DataSLA = null, Status = ExecutionStatus.Success };

            mockSet = new MockSet<ConsultarSLAPadraoRequest, ConsultarSLAPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;
            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\ConsultarSLAPadraoMock.xml", mockSets);

        }
    }
}
