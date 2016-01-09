using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class SolicitaAnaliseAlvaraUnitTest
    {
        [TestMethod]
        public void Sucesso()
        {
            var request = new SolicitaAnaliseAlvaraRequest()
            {
                CodigoCliente = 1,
                CodigoSituacaoCliente = "CodigoSituacaoClienteTeste",
                NomeContato = "NomeContatoTeste",
                NomeEmailContato = "NomeEmailContatoTeste",
                NomeProprietario = "NomeProprietarioTeste",
                NumeroTelefoneContato = "NumeroTelefoneContatoTeste",
                Protocolo = "ProtocoloTeste"
            };

            var business = new SolicitaAnaliseAlvaraBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual("SistemaLegadoTeste", response.SistemaLegado);
            Assert.AreEqual("StatusRetornoTeste", response.StatusRetorno);
            Assert.AreEqual(new DateTime(2015, 1, 1), response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao);
            Assert.AreEqual("CodigoSolicitacaoTeste", response.SolicitacaoCentralAtendimento.CodigoSolicitacao);

            Assert.IsTrue(response.Status == ExecutionStatus.Success);
            Assert.IsNull(response.ErrorCode);
            Assert.IsNull(response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoNaoExistente()
        {
            var request = new SolicitaAnaliseAlvaraRequest()
            {
                CodigoCliente = -1,
            };

            var business = new SolicitaAnaliseAlvaraBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.IsNull(response.SistemaLegado);
            Assert.IsNull(response.StatusRetorno);
            Assert.IsNull(response.SolicitacaoCentralAtendimento);

            Assert.IsFalse(response.Status == ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
