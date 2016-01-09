using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.WR.Servico;
using Cielo.Sirius.DAO.Products.WR.Servico.Extensions;
using Cielo.Sirius.DAO.Products.ProdutoService;
using Cielo.Sirius.Contracts;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarServicoElegivelClienteDAO : DAOOSBBase<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>
    {
        protected override ConsultarServicoElegivelClienteResponse GetData(ConsultarServicoElegivelClienteRequest requestData)
        {
            var response = new ConsultarServicoElegivelClienteResponse()
            {
                Servicos = new List<ConsultarServicoClienteElegivelServicoDTO>()
            };

            //[Rule]: Chamada ao serviço ConsultarServicoElegivelCliente do barramento
            var client = new Servico();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            long numeroTotalRegistros = 0;
            string vantagem = string.Empty;
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                do
                {
                    var servicosResponse = client.consultarServicoNaoElegivelCliente(
                        codigoCliente: requestData.CodigoCliente,
                        proximoRegistro: ref proximoRegistro,
                        chavePaginacao: ref chavePaginacao,
                        numeroTotalRegistros: out numeroTotalRegistros,
                        //vantagem: out vantagem,
                        codigoRetorno: out codigoRetorno,
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

                    response.NumeroTotalRegistros = numeroTotalRegistros;

                    if (servicosResponse != null)
                    {
                        foreach (var servicoResponse in servicosResponse)
                        {
                            var servicoDTO = new ConsultarServicoClienteElegivelServicoDTO();

                            servicoDTO.CodigoServico = servicoResponse.codigoServico;
                            servicoDTO.DescricaoServico = servicoResponse.descricaoServico;
                            servicoDTO.NomeServico = servicoResponse.nomeServico;
                            servicoDTO.Vantagem = servicoResponse.vantagem;

                            response.Servicos.Add(servicoDTO);
                        }
                    }
                } while (response.Servicos.Count < numeroTotalRegistros);

            }
            catch (Exception ex)
            {
                response.Status = ExecutionStatus.TechnicalError;
                response.ErrorMessage = ex.Message;
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