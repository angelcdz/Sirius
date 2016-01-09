using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
//using Cielo.Sirius.DAO.Products.EquipamentoService;
//using Cielo.Sirius.DAO.Products.Extensions.EquipamentoService;
using Cielo.Sirius.DAO.Products.WR.Equipamento;
using Cielo.Sirius.DAO.Products.WR.Equipamento.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarPrazoPadraoDAO : DAOOSBBase<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>
    {
        protected override ConsultarPrazoPadraoResponse GetData(ConsultarPrazoPadraoRequest requestData)
        {
            var response = new ConsultarPrazoPadraoResponse();
        
            //[Rule]: Chamada ao serviço consultarPrazoPadrao do barramento
            var client = new Cielo.Sirius.DAO.Products.WR.Equipamento.EquipamentoService();
            client.cieloSoapHeader = this.GetSoapHeader();

            long subTipoDemanda = 0;
            //long tipoDemanda = 0;

            //Out parameters
            DateTime prazoPadrao;
            bool dataSLASpecified;
            string codigoRetorno;
            string mensagemRetorno;

            #region Validação do RequestData
            if (!long.TryParse(requestData.SubTipoDemanda, out subTipoDemanda))
            {
                throw new ArgumentException("O valor informado para o subTipoDemanda é um número inválido", "subTipoDemanda");
            }
            
            //if (!long.TryParse(requestData.TipoDemanda, out tipoDemanda))
            //{
            //    throw new ArgumentException("O valor informado para o tipoDemanda é um número inválido", "tipoDemanda");
            //}
            #endregion

            try
            {
                client.consultarPrazoPadrao
                (
                    codigoCliente: requestData.CodigoCliente,
                    tipoDemanda: requestData.TipoDemanda,
                    subTipoDemanda: subTipoDemanda,
                    dataSLA: out prazoPadrao,
                    dataSLASpecified: out dataSLASpecified,
                    codigoRetorno: out codigoRetorno,
                    descricaoRetornoMensagem: out mensagemRetorno
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
                    response.DataSLA = prazoPadrao;
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
