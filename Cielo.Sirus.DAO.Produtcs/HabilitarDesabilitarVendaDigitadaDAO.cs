using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class HabilitarDesabilitarVendaDigitadaDAO : DAOOSBBase<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>
    {
        protected override HabilitarDesabilitarVendaDigitadaResponse GetData(HabilitarDesabilitarVendaDigitadaRequest requestData)
        {
            var response = new HabilitarDesabilitarVendaDigitadaResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Out parameters declaration
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            string codigoSolicitacao = string.Empty;
            DateTime? dataPrevistaConclusaoSolicitacao = null;
            bool dataPrevistaConclusaoSolicitacaoSpecified = false;
            VendaDigitadaType[] vendasDigitadas = null;

            //Converter os dados armazenados na lista de DTO do "requestData" em um array
            if (requestData.DadosVendaDigitada != null)
            {
                vendasDigitadas = requestData.DadosVendaDigitada.Select(
                    vendaDigitada =>
                        new VendaDigitadaType
                        {
                            codigoProduto = vendaDigitada.CodigoProduto,
                            indicaAcao = vendaDigitada.IndicaAcao
                        }
                ).ToArray();
            }

            try
            {
                //Chama a operacao "habilitarDesabilitarVendaDigitada" do barramento e armazena o retorno no "codigoRetorno"
                var codigoRetorno = client.habilitarDesabilitarVendaDigitada(
                    codigoCliente                            : requestData.CodigoCliente,
                    indicaOperacao                           : requestData.IndicaOperacao,
                    dadosVendaDigitada                       : vendasDigitadas,
                    protocolo                                : requestData.Protocolo,
                    origem                                   : requestData.Origem,
                    descricaoRetornoMensagem                 : out mensagemRetorno,
                    statusRetorno                            : out statusRetorno,
                    sistemaLegado                            : out sistemaLegado,
                    codigoSolicitacao                        : out codigoSolicitacao,
                    dataPrevistaConclusaoSolicitacao         : out dataPrevistaConclusaoSolicitacao,
                    dataPrevistaConclusaoSolicitacaoSpecified: out dataPrevistaConclusaoSolicitacaoSpecified
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
                    response.StatusRetorno = statusRetorno;
                    response.SistemaLegado = sistemaLegado;
                    response.CodigoSolicitacao = codigoSolicitacao;
                    response.DataPrevistaConclusaoSolicitacao = dataPrevistaConclusaoSolicitacao;
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