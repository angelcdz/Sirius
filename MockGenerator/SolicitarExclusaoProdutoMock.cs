using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
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
    public class SolicitarExclusaoProdutoMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>>();

            var request = new SolicitarExclusaoProdutoRequest()
            {
                Protocolo = "101010",
                CodigoCliente = 1,
                CodigoProduto = "008",
                NomeSolicitante = "Andre",
                Origem = "CRM",
                TelefoneSolicitante = "99999000",
                CodigoEmpresa = "002",
                MotivoSolicitacao = "Teste"
                
            };

            var response = new SolicitarExclusaoProdutoResponse();

            response.Status = ExecutionStatus.Success;
            response.SistemaLegado = "OSB";
            response.StatusRetorno = "StatusRetorno";

            response.SolicitacaoCentralAtendimento = new SolicitarExclusaoProdutoDTO();

            response.SolicitacaoCentralAtendimento.CodigoSolicitacao = "1111";
            response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao = DateTime.Today;

            var mockSet = new MockSet<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\SolicitarExclusaoProdutoMock.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new SolicitarExclusaoProdutoResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\SolicitarExclusaoProdutoMockError.xml", response);
        }
    }
}
