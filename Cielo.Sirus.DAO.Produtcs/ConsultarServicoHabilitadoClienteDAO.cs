using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.DAO.Products.WR.Servico;
using Cielo.Sirius.DAO.Products.WR.Servico.Extensions;
using Cielo.Sirius.Contracts;


namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarServicoHabilitadoClienteDAO : DAOOSBBase<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>
    {
        protected override ConsultarServicoHabilitadoClienteResponse GetData(ConsultarServicoHabilitadoClienteRequest requestData)
        {
            var response = new ConsultarServicoHabilitadoClienteResponse()
            {
                Servicos = new List<ConsultarServicoHabilitadoClienteServicoDTO>()
            };

            var client = new Servico();
            client.cieloSoapHeader = this.GetSoapHeader();

            //out parameters
            long numeroTotalRegistros = 0;
            DateTime dataUltimaTransacao = DateTime.MinValue;
            bool dataUltimaTransacaoSpecified = false;
            bool indicadorVendaUltimoMes = false;
            bool indicadorVendaUltimoMesSpecified = false;
            string vantagem = string.Empty;
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;

            //ref parameters
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                do
                {
                    ServicoType[] serviceOutput = client.consultarServicoHabilitadoCliente
                    (
                        codigoCliente: requestData.CodigoCliente,
                        proximoRegistro: ref proximoRegistro,
                        chavePaginacao: ref chavePaginacao,
                        numeroTotalRegistros: out numeroTotalRegistros,
                        dataUltimaTransacao: out dataUltimaTransacao,
                        dataUltimaTransacaoSpecified: out dataUltimaTransacaoSpecified,
                        indicadorVendaUltimoMes: out indicadorVendaUltimoMes,
                        indicadorVendaUltimoMesSpecified: out indicadorVendaUltimoMesSpecified,
                       // vantagem: out vantagem,
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
                    
                    response.NumeroTotalRegistros = numeroTotalRegistros;
                    response.DataUltimaTransacao = dataUltimaTransacao;                    
                    response.IndicadorVendaUltimoMes = indicadorVendaUltimoMes;
                    
                    foreach (ServicoType servicoResponse in serviceOutput)
                    {
                        var servicoDTO = new ConsultarServicoHabilitadoClienteServicoDTO();

                        servicoDTO.CodigoServico = servicoResponse.codigoServico;
                        servicoDTO.DataHabilitacaoServico = servicoResponse.dataHabilitacaoServico;
                        servicoDTO.DescricaoServico = servicoResponse.descricaoServico;
                        servicoDTO.NomeServico = servicoResponse.nomeServico;
                        servicoDTO.Vantagem = servicoResponse.vantagem;

                        response.Servicos.Add(servicoDTO);
                    }

                } while (response.Servicos.Count() < numeroTotalRegistros);

                response.Status = ExecutionStatus.Success;
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
