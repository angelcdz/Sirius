using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products
{
    public class HabilitarProdutoDAO : DAOOSBBase<HabilitarProdutoRequest, HabilitarProdutoResponse>
    {
        protected override HabilitarProdutoResponse GetData(HabilitarProdutoRequest requestData)
        {
            var response = new HabilitarProdutoResponse
            {
                SolicitacaoCentralAtendimento = new HabilitarProdutoSolicitacaoCentralAtendimentoDTO()
            };

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Out parameters declaration
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            SolicitacaoCentralAtendimento solicitacaoCentralAtendimento = null;

            try
            {
                var faixaTaxaSegmentadoList = new List<FaixaTaxaSegmentado1>();

                foreach (var faixaTaxaSegmentado in requestData.FaixasTaxaSegmentado)
                {
                    var faixaTaxaSegmentado1 = new FaixaTaxaSegmentado1();

                    faixaTaxaSegmentado1.codigoFaixa = faixaTaxaSegmentado.CodigoFaixa;
                    faixaTaxaSegmentado1.numeroInicialParcelaFaixa = faixaTaxaSegmentado.NumeroInicialParcelaFaixa;
                    faixaTaxaSegmentado1.numeroFinalParcelaFaixa = faixaTaxaSegmentado.NumeroFinalParcelaFaixa;
                    faixaTaxaSegmentado1.percentualTaxaFaixa = faixaTaxaSegmentado.PercentualTaxaFaixa;

                    faixaTaxaSegmentadoList.Add(faixaTaxaSegmentado1);
                }

                codigoRetorno = client.habilitarProduto(
                    protocolo                    : requestData.Protocolo,
                    codigoCliente                : requestData.CodigoCliente,
                    codigoProduto                : requestData.CodigoProduto,
                    quantidadeParcelas           : requestData.QuantidadeParcelas,
                    percentualTaxa               : requestData.PercentualTaxa,
                    dadosFaixaTaxaSegmentado     : faixaTaxaSegmentadoList.ToArray(),
                    nomeSolicitante              : requestData.NomeSolicitante,
                    origem                       : requestData.Origem,
                    telefoneSolicitante          : requestData.TelefoneSolicitante,
                    codigoEmpresa                : requestData.CodigoEmpresa,
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
                else
                {
                    response.StatusRetorno = statusRetorno;
                    response.SistemaLegado = sistemaLegado;
                    response.SolicitacaoCentralAtendimento.CodigoSolicitacao = solicitacaoCentralAtendimento.codigoSolicitacao;
                    response.SolicitacaoCentralAtendimento.DataPrevistaConclusaoSolicitacao = solicitacaoCentralAtendimento.dataPrevistaConclusaoSolicitacao;
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