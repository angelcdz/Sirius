using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Contracts;

namespace Cielo.Sirius.DAO.Products
{
    public class SolicitarExclusaoProdutoDAO : DAOOSBBase<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>
    {
        protected override SolicitarExclusaoProdutoResponse GetData(SolicitarExclusaoProdutoRequest requestData)
        {
            var response = new SolicitarExclusaoProdutoResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            //Variaveis para armazenar o retorno do barramento
            string mensagemRetorno;
            string statusRetorno;
            string sistemaLegado;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento;

            try
            {
                //Chama a operacao "desabilitarProduto" do barramento e armazena o retorno no "codigoRetorno"
                var codigoRetorno = client.desabilitarProduto(
                    protocolo: requestData.Protocolo,
                    codigoCliente: requestData.CodigoCliente,
                    codigoProduto: requestData.CodigoProduto,
                    nomeSolicitante: requestData.NomeSolicitante,
                    origem: requestData.Origem,
                    telefoneSolicitante: requestData.TelefoneSolicitante,
                    codigoEmpresa: requestData.CodigoEmpresa,
                    motivoSolicitacao: requestData.MotivoSolicitacao,
                    descricaoRetornoMensagem: out mensagemRetorno,
                    statusRetorno: out statusRetorno,
                    sistemaLegado: out sistemaLegado,
                    solicitacaoCentralAtendimento: out solicitacaoCentralAtendimento
                   );

                //[Rule]: Business Error: Returns immediately
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = mensagemRetorno;
                    response.Status = ExecutionStatus.BusinessError;
                    return response;
                }
                else
                {
                    response.Status = ExecutionStatus.Success;
                    //Faz o "de/para" do retorno do barramento para a "newResponse" a ser retornada
                    response.SistemaLegado = sistemaLegado;
                    response.StatusRetorno = statusRetorno;
                    if (solicitacaoCentralAtendimento != null)
                    {
                        response.SolicitacaoCentralAtendimento = new SolicitarExclusaoProdutoDTO();
                        response.SolicitacaoCentralAtendimento.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                        response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
                    }
                }

            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return response;
        }
    }
}
