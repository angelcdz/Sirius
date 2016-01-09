using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarPrazoFlexivel;
using Cielo.Sirius.DAO.Products.WR.Cliente.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class ManterPrazoFlexivelDAO : DAOOSBBase<HabilitarPrazoFlexivelRequest, HabilitarPrazoFlexivelResponse>
    {
        protected override HabilitarPrazoFlexivelResponse GetData(HabilitarPrazoFlexivelRequest requestData)
        {
            var response = new HabilitarPrazoFlexivelResponse();

            // Out parameters declaration
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            string codigoSolicitacao = string.Empty;
            DateTime? dataPrevistaConclusaoSolicitacao = null;
            bool dataPrevistaConclusaoSolicitacaoSpecified = false;

            //[Rule]: Chamada ao serviço manterPrazoFlexivel do barramento
            var client = new Cielo.Sirius.DAO.Products.WR.Cliente.ClienteService();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            try
            {
                codigoRetorno = client.manterPrazoFlexivel(
                    codigoCliente                            : requestData.CodigoCliente,
                    IndicaOperacao                           : requestData.IndicaOperacao,
                    codigoGrupoPrazoFlexivel                 : requestData.CodigoGrupoPrazoFlexivel.ToString(),
                    quantidadeDiasGrupoPrazoFlexivel         : requestData.QuantidadeDiasGrupoPrazoFlexivel.ToString(),
                    percentualTaxaGrupoPrazoFlexivel         : requestData.PercentualTaxaGrupoPrazoFlexivel,
                    percentualTaxaGrupoPrazoFlexivelSpecified: requestData.PercentualTaxaGrupoPrazoFlexivel != null,
                    protocolo                                : requestData.Protocolo,
                    origem                                   : requestData.Origem,
                    descricaoRetornoMensagem                 : out mensagemRetorno,
                    statusRetorno                            : out statusRetorno,
                    sistemaLegado                            : out sistemaLegado,
                    codigoSolicitacao                        : out codigoSolicitacao,
                    dataPrevistaConclusaoSolicitacao         : out dataPrevistaConclusaoSolicitacao,
                    dataPrevistaConclusaoSolicitacaoSpecified: out dataPrevistaConclusaoSolicitacaoSpecified
                );

                //[Rule] : Business Error:
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = mensagemRetorno;
                    response.Status = ExecutionStatus.BusinessError;
                }
                else
                {
                    response.StatusRetorno = statusRetorno;
                    response.SistemaLegado = sistemaLegado;
                    int codSolicitacaoAuxiliar = 0;
                    if(int.TryParse(codigoSolicitacao, out codSolicitacaoAuxiliar))
                        response.CodigoSolicitacao = codSolicitacaoAuxiliar;

                    if (dataPrevistaConclusaoSolicitacao != null)
                        response.DataPrevistaConclusaoSolicitacao = (DateTime)dataPrevistaConclusaoSolicitacao;

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