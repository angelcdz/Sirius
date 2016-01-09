
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.DAO.Products.WR.Faturamento;
using Cielo.Sirius.DAO.Products.WR.Faturamento.Extensions;
using Cielo.Sirius.Foundation;
using System;



namespace Cielo.Sirius.DAO.Products
{
    public class SolicitarNegociacaoTaxaDAO : DAOOSBBase<SolicitarNegociacaoTaxaRequest, SolicitarNegociacaoTaxaResponse>
    {
        protected override SolicitarNegociacaoTaxaResponse GetData(SolicitarNegociacaoTaxaRequest requestData)
        {
            // Cria objeto Response
            var response = new SolicitarNegociacaoTaxaResponse();

            //[Rule]: Chamada ao serviço FaturamentoService do barramento
            var client = new Cielo.Sirius.DAO.Products.WR.Faturamento.Servico();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Variáveis para recepção das informações recebidas do barramento
            string codigoRetorno;
            string sistemaLegado;
            string statusRetorno;
            string mensagemRetorno;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento;

            try
            {
                // Realiza chamada ao serviço no OSB
                codigoRetorno = client.solicitarNegociacaoTaxaProdutoComercial(
                    protocolo: requestData.Protocolo,
                    codigoCliente: requestData.CodigoCliente,
                    codigoProduto: requestData.CodigoProduto,
                    nomeContato: requestData.NomeContato,
                    percentualTaxaPropostaConcorrente: requestData.PercentualTaxaPropostaConcorrente,
                    celularContato: requestData.CelularContato,
                    telefoneContato: requestData.TelefoneContato,
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
                    response.StatusRetorno = statusRetorno;
                    response.SistemaLegado = sistemaLegado;
                    response.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                    response.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
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
