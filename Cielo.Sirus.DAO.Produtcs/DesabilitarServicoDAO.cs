using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.DAO.Products.WR.Servico;
using Cielo.Sirius.DAO.Products.WR.Servico.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class DesabilitarServicoDAO : DAOOSBBase<DesabilitarServicoRequest, DesabilitarServicoResponse>
    {
        protected override DesabilitarServicoResponse GetData(DesabilitarServicoRequest requestData)
        {
            var response = new DesabilitarServicoResponse();

            var client = new Servico();
            client.cieloSoapHeader = this.GetSoapHeader();

            //Out parameters
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = null;
            //Ref parameters
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                do
                {
                    codigoRetorno = client.desabilitarServico
                        (
                            codigoCliente: requestData.CodigoCliente,
                            codigoServico: requestData.CodigoServico,
                            protocolo: requestData.Protocolo,
                            origem: requestData.Origem,
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
                        response.StatusRetorno = statusRetorno;
                        response.SistemaLegado = sistemaLegado;
                        if (solicitacaoCentralAtendimento != null)
                        {
                            response.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                            response.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
                        }
                    }
                } while (!string.IsNullOrEmpty(proximoRegistro) && !string.IsNullOrEmpty(chavePaginacao));
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
