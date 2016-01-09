using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.DAO.Products.WR.Servico;
using Cielo.Sirius.DAO.Products.WR.Servico.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarServicoNaoElegivelClienteDAO : DAOOSBBase<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>
    {
        protected override ConsultarServicoNaoElegivelClienteResponse GetData(ConsultarServicoNaoElegivelClienteRequest requestData)
        {
            var response = new ConsultarServicoNaoElegivelClienteResponse()
            {
                Servicos = new List<ConsultarServicoNaoElegivelClienteServicoDTO>()
            };

            //[Rule]: Chamada ao serviço ConsultarServicoNaoElegivelCliente do barramento
            var client = new Servico();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            long numeroTotalRegistros = 0;
            string codigoRetorno      = string.Empty;
            string mensagemRetorno    = string.Empty;
            string proximoRegistro    = string.Empty;
            string chavePaginacao     = string.Empty;
            string vantagem           = string.Empty;


            if (requestData == null)
            {
                response.ErrorCode = ErrorCodes.DAO_OSB_GENERIC_ERROR;
                response.ErrorMessage = "Erro ao consultar informações de Serviços.\nInformar ao cliente para tentar novamente mais tarde.";
                response.Status = ExecutionStatus.BusinessError;
                return response;
            }

            try
            {
                do
                {
                    var servicosResponse = client.consultarServicoNaoElegivelCliente(
                        codigoCliente           : requestData.CodigoCliente,
                        proximoRegistro         : ref proximoRegistro,
                        chavePaginacao          : ref chavePaginacao,
                        numeroTotalRegistros    : out numeroTotalRegistros,
                        codigoRetorno           : out codigoRetorno,
                        descricaoRetornoMensagem: out mensagemRetorno
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
                    }


                    response.ProximoRegistro      = proximoRegistro;
                    response.ChavePaginacao       = chavePaginacao;
                    response.NumeroTotalRegistros = numeroTotalRegistros;

                    foreach (var servicoResponse in servicosResponse)
                    {
                        if (servicoResponse != null)
                        {
                            var servicoDTO = new ConsultarServicoNaoElegivelClienteServicoDTO();

                            servicoDTO.CodigoServico    = servicoResponse.codigoServico;
                            servicoDTO.DescricaoServico = servicoResponse.descricaoServico;
                            servicoDTO.NomeServico = servicoResponse.nomeServico;
                            servicoDTO.Vantagem = servicoResponse.vantagem;

                            response.Servicos.Add(servicoDTO);
                        }
                    }
                } while (response.Servicos.Count() < numeroTotalRegistros);
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