using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class DesabilitarProdutoDAO : DAOOSBBase<DesabilitarProdutoRequest, DesabilitarProdutoResponse>
    {
        protected override DesabilitarProdutoResponse GetData(DesabilitarProdutoRequest requestData)
        {
            var response = new DesabilitarProdutoResponse
            {
                SolicitacaoCentralAtendimento = new DesabilitarProdutoSolicitacaoCentralAtendimentoDTO()
            };

            //[Rules]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            //Out parameters declaration
            string mensagemRetorno;
            string statusRetorno;
            string sistemaLegado;

            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = null;

            try
            {
                var codigoRetorno = client.desabilitarProduto(
                    protocolo: requestData.Protocolo,
                    codigoCliente: requestData.CodigoCliente,
                    codigoProduto: requestData.CodigoProduto.ToString(), //Workaround til we get our service references updated
                    nomeSolicitante: requestData.NomeSolicitante,
                    origem: requestData.Origem,
                    telefoneSolicitante: requestData.TelefoneSolicitante,
                    codigoEmpresa: requestData.CodigoEmpresa,
                    motivoSolicitacao: requestData.MotivoSolicitacao,
                    descricaoRetornoMensagem: out mensagemRetorno,
                    statusRetorno: out statusRetorno,
                    sistemaLegado: out sistemaLegado,
                    solicitacaoCentralAtendimento: out solicitacaoCentralAtendimento);

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
                    response.StatusRetorno = statusRetorno;
                    response.SistemaLegado = sistemaLegado;
                    if (solicitacaoCentralAtendimento != null)
                    {
                        response.SolicitacaoCentralAtendimento.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                        response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
                    }

                    response.Status = ExecutionStatus.Success;
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
