using Cielo.Sirius.Contracts.ExistsServiceOpenDemand;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockGenerator
{
    [TestClass]
    public class ExistsServiceOpenRequests : MockBase
    {
        [TestMethod]
        public void ElegiveisHabilitados()
        {
            var mockSets = new List<MockSet<ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>>();

            var request = new ExistsServiceOpenDemandRequest() 
            {
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CodigoCliente = 10011001
            };

            request.CodigoServicos = new List<string>();
            for (int i = 100; i <= 150; i++)
            {
                request.CodigoServicos.Add(i.ToString().PadLeft(4, '0'));
            }

            var response = new ExistsServiceOpenDemandResponse();
            response.Status = ExecutionStatus.Success;

            for (int i = 100; i <= 250; i++)
            {
                bool indicador = true;
                //verifica se é par
                indicador = (i % 2).Equals(0);

                request.CodigoServicos.Add(i.ToString().PadLeft(4, '0'));
                response.ExistsServiceOpenRequests.Add(new ExistsServiceOpenDemandDTO() { CodigoServico = i.ToString().PadLeft(4, '0'), IndicadorPossuiDemandasAbertas = indicador });
            }

            var mockSet = new MockSet<ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockExistsServiceOpenDemand.xml", mockSets);
        }

        [TestMethod]
        public void ElegiveisNaoHabilitados()
        {
            var mockSets = new List<MockSet<ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>>();

            var request = new ExistsServiceOpenDemandRequest()
            {
                CodigoCliente = 10011001
            };

            request.CodigoServicos = new List<string>();
            for (int i = 151; i <= 199; i++)
            {
                request.CodigoServicos.Add(i.ToString().PadLeft(4, '0'));
            }

            var response = new ExistsServiceOpenDemandResponse();
            response.Status = ExecutionStatus.Success;

            for (int i = 151; i <= 199; i++)
            {
                bool indicador = true;
                //verifica se é par
                indicador = (i % 2).Equals(0);

                request.CodigoServicos.Add(i.ToString().PadLeft(4, '0'));
                response.ExistsServiceOpenRequests.Add(new ExistsServiceOpenDemandDTO() { CodigoServico = i.ToString().PadLeft(4, '0'), IndicadorPossuiDemandasAbertas = indicador });
            }

            var mockSet = new MockSet<ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockExistsServiceOpenDemandENH.xml", mockSets);
        }
    }
}
