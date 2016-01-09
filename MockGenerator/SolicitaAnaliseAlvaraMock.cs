using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class SolicitaAnaliseAlvaraMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>>();

            var request = new SolicitaAnaliseAlvaraRequest()
            {
                CodigoCliente = 10011001,
                CodigoSituacaoCliente = "00",
                NomeContato = "Felipe",
                NomeEmailContato = "felipe@uol.com.br",
                NomeProprietario = "Felipe",
                NumeroTelefoneContato = "11 4545-4545",
                Protocolo = "59375793"
            };

            var response = new SolicitaAnaliseAlvaraResponse()
            {
                Status = ExecutionStatus.Success,
                SistemaLegado = "SistemaLegadoTeste",
                StatusRetorno = "StatusRetornoTeste",
                SolicitacaoCentralAtendimento = new SolicitaAnaliseAlvaraDTO()
                {
                    CodigoSolicitacao = "00",
                    DataPrevistaConclusaoSolicitacao = new DateTime(2015,01,01)
                }
            };


            var mockSet = new MockSet<SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);





            request = new SolicitaAnaliseAlvaraRequest()
            {
                CodigoCliente = 10011001,
                CodigoSituacaoCliente = "01",
                NomeContato = "Felipe",
                NomeEmailContato = "felipe@uol.com.br",
                NomeProprietario = "Felipe",
                NumeroTelefoneContato = "11 4545-4545",
                Protocolo = "59375793"
            };

            response = new SolicitaAnaliseAlvaraResponse()
            {
                Status = ExecutionStatus.Success,
                SistemaLegado = "SistemaLegadoTeste",
                StatusRetorno = "StatusRetornoTeste",
                SolicitacaoCentralAtendimento = new SolicitaAnaliseAlvaraDTO()
                {
                    CodigoSolicitacao = "01",
                    DataPrevistaConclusaoSolicitacao = DateTime.MinValue,
                }
            };

            mockSet = new MockSet<SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockSolicitaAnaliseAlvara.xml", mockSets);
        }
        [TestMethod]
        public void ErrorData()
        {
            var response = new SolicitaAnaliseAlvaraResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

            this.WriteObject(@"..\..\Generated\MockSolicitaAnaliseAlvaraError.xml", response);

        }
    }
}
