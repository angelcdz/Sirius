using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.DAO.Products.WR.Produto;


namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class SolicitarExclusaoProdutoUnitTest
    {

        [TestMethod]
        public void TesteDAOErro()
        {
            var requestData = new SolicitarExclusaoProdutoRequest()
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

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            Produto client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            
            //Variaveis para armazenar o retorno do barramento
            string mensagemRetorno = null;
            string statusRetorno = null;
            string sistemaLegado = null;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = new SolicitacaoCentralAtendimento();

            try
            {
                //Chama a operacao "desabilitarProduto" do barramento e armazena o retorno no "codigoRetorno"
                //var codigoRetorno = client.desabilitarProduto(
                //    protocolo: requestData.Protocolo,
                //    codigoCliente: requestData.CodigoCliente,
                //    codigoProduto: requestData.CodigoProduto,
                //    nomeSolicitante: requestData.NomeSolicitante,
                //    origem: requestData.Origem,
                //    telefoneSolicitante: requestData.TelefoneSolicitante,
                //    codigoEmpresa: requestData.CodigoEmpresa,
                //    motivoSolicitacao: requestData.MotivoSolicitacao,
                //    descricaoRetornoMensagem: out mensagemRetorno,
                //    statusRetorno: out statusRetorno,
                //    sistemaLegado: out sistemaLegado,
                //    solicitacaoCentralAtendimento: out solicitacaoCentralAtendimento
                //   );
                var codigoRetorno = "99";

                //[Rule]: Business Error: Returns immediately
                if (codigoRetorno != "00")
                {
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = mensagemRetorno;
                    response.Status = ExecutionStatus.BusinessError;
                }
                else
                {
                    response.Status = ExecutionStatus.Success;
                }

                //Faz o "de/para" do retorno do barramento para a "newResponse" a ser retornada
                response.SistemaLegado = sistemaLegado;
                response.StatusRetorno = statusRetorno;
                response.SolicitacaoCentralAtendimento.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
            }
            finally
            {
            //    if (client != null)
            //        client.Dispose();
            }

            //return response;
        }

        [TestMethod]
        public void Successo()
        {
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

            var business = new SolicitarExclusaoProdutoBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual("OSB", response.SistemaLegado);
            Assert.AreEqual(true, response.Status);
            Assert.AreEqual("StatusRetorno", response.StatusRetorno);

            Assert.AreEqual("1111", response.SolicitacaoCentralAtendimento.CodigoSolicitacao);
            Assert.AreEqual(DateTime.Today, response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao);
        }

        [TestMethod]
        public void CodigoNaoExistente()
        {
            var request = new SolicitarExclusaoProdutoRequest()
            {
                Protocolo = "101010",
                CodigoCliente = -1,
                CodigoProduto = "008",
                NomeSolicitante = "Andre",
                Origem = "CRM",
                TelefoneSolicitante = "99999000",
                CodigoEmpresa = "002",
                MotivoSolicitacao = "Teste"
                
            };

            var business = new SolicitarExclusaoProdutoBL();

            var response = business.Execute(request);

            //Resultados de acordo com o mock gerado
            Assert.AreEqual(false, response.Status);
            Assert.IsNull(response.SistemaLegado);
            Assert.IsNull(response.SolicitacaoCentralAtendimento);
            Assert.IsNull(response.StatusRetorno);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
