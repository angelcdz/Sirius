using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class ValidarPermissaoVendaDigitadaDAO : DAOOSBBase<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>
    {
        protected override ValidarPermissaoVendaDigitadaResponse GetData(ValidarPermissaoVendaDigitadaRequest requestData)
        {
            var response = new ValidarPermissaoVendaDigitadaResponse();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            var cieloSoapHeader = this.GetSoapHeader();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();
            client.cieloSoapHeader = cieloSoapHeader;

            string descricaoRetornoMensagem = String.Empty;
            string tipoMensagemRetorno = String.Empty;
            try
            {
                string codigoRetorno = client.validarPermissaoVendaDigitada(
                    codigoCliente           : requestData.CodigoCliente,
                    indicaOperacao          : requestData.IndicaOperacao,
                    codigoRamoAtividade     : requestData.CodigoRamoAtividade,
                    descricaoRetornoMensagem: out descricaoRetornoMensagem,
                    tipoMensagemRetorno     : out tipoMensagemRetorno
                 );

                //[Rule]: Business Error: Returns immediately
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.Status = ExecutionStatus.BusinessError;
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = descricaoRetornoMensagem;
                    return response;
                }
                else
                {
                    response.Status = ExecutionStatus.Success;
                    response.TipoDeMensagem = tipoMensagemRetorno;
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