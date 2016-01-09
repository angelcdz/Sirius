using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.DAO.Products.WR.Cliente;
using Cielo.Sirius.DAO.Products.WR.Cliente.Extensions;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.DAO.Products
{
    public class SolicitaAnaliseAlvaraDAO : DAOOSBBase<SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>
    {
        protected override SolicitaAnaliseAlvaraResponse GetData(SolicitaAnaliseAlvaraRequest requestData)
        {
            // Cria objeto Response
            var response = new SolicitaAnaliseAlvaraResponse();

            // Out parameters declaration
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = null;

            //[Rule]: Chamada ao serviço do barramento
            var client = new Cielo.Sirius.DAO.Products.WR.Cliente.ClienteService();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            try
            {
                codigoRetorno = client.solicitaAnaliseAlvara(
                    protocolo                    : requestData.Protocolo,
                    codigoCliente                : requestData.CodigoCliente,
                    numeroTelefoneContato        : requestData.NumeroTelefoneContato,
                    nomeContato                  : requestData.NomeContato,
                    nomeEmailContato             : requestData.NomeEmailContato,
                    codigoSituacaoCliente        : requestData.CodigoSituacaoCliente,
                    nomeProprietario             : requestData.NomeProprietario,
                    descricaoRetornoMensagem     : out mensagemRetorno,
                    statusRetorno                : out statusRetorno,
                    sistemaLegado                : out sistemaLegado,
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

                //Faz o "de/para" do retorno do barramento para a "newResponse" a ser retornada
                response.SolicitacaoCentralAtendimento = new SolicitaAnaliseAlvaraDTO
                {
                    CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao,
                    DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao
                };

                response.StatusRetorno = statusRetorno;
                response.SistemaLegado = sistemaLegado;
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