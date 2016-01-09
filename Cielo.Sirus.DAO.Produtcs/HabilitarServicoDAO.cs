using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.DAO.Products.WR.Servico;
using Cielo.Sirius.DAO.Products.WR.Servico.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class HabilitarServicoDAO : DAOOSBBase<HabilitarServicoRequest, HabilitarServicoResponse>
    {
        protected override HabilitarServicoResponse GetData(HabilitarServicoRequest requestData)
        {
            // Cria objeto Response
            var response = new HabilitarServicoResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Servico();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Variáveis para recepção das informações recebidas do barramento
            string mensagemRetorno;
            string chavePaginacao = string.Empty;
            string proximoRegistro = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = null;
            try
            {
                do
                {
                    // Realiza chamada ao serviço no OSB
                    var codigoRetorno = client.habilitarServico(
                        codigoCliente: requestData.CodigoCliente,
                        codigoServico: requestData.CodigoServico,
                        protocolo: requestData.Protocolo,
                            origem: requestData.Origem,

                        descricaoRetornoMensagem: out mensagemRetorno,
                            statusRetorno: out statusRetorno,
                            sistemaLegado: out sistemaLegado,
                            solicitacaoCentralAtendimento: out solicitacaoCentralAtendimento
                    );

                    //[Rule]: Lógica de erro de negócio:
                    if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                    {
                        response.ErrorCode = codigoRetorno;
                        response.ErrorMessage = mensagemRetorno;
                        response.Status = ExecutionStatus.BusinessError;
                    }
                    else
                    {
                        response.Status = ExecutionStatus.Success;
                        response.StatusRetorno = statusRetorno;
                        response.SistemaLegado = sistemaLegado;
                        if (solicitacaoCentralAtendimento != null)
                        {
                            response.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                            if (solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao != null && solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao.HasValue)
                                response.DataSLA = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao.Value;
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
