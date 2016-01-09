using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.HabilitarPrazoFlexivel;
using Cielo.Sirius.Foundation;


namespace MockGenerator
{
    [TestClass]
    public class ManterPrazoFlexivelMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<HabilitarPrazoFlexivelRequest, HabilitarPrazoFlexivelResponse>>();

            var response = new HabilitarPrazoFlexivelResponse();
            response.Status = ExecutionStatus.Success;

            var mockSet = new MockSet<HabilitarPrazoFlexivelRequest, HabilitarPrazoFlexivelResponse>();
            mockSet.request = new HabilitarPrazoFlexivelRequest()
            {
                CodigoCliente = 1,
                IndicaOperacao = "I",       //Aceita "I, A ou E"
                CodigoGrupoPrazoFlexivel = 1,
                QuantidadeDiasGrupoPrazoFlexivel = 10,
                PercentualTaxaGrupoPrazoFlexivel = 10
            };
            mockSet.response = response;
            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockManterPrazoFlexivel.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new HabilitarPrazoFlexivelResponse();
            response.Status = ExecutionStatus.Success;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-E)";

            this.WriteObject(@"..\..\Generated\MockManterPrazoFlexivelError.xml", response);
        }
    }
}
