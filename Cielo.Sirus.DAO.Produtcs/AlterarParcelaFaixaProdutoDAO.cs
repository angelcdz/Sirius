using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products
{
    public class AlterarParcelaFaixaProdutoDAO : DAOOSBBase<AlterarParcelaFaixaProdutoRequest, AlterarParcelaFaixaProdutoResponse>
    {
        protected override AlterarParcelaFaixaProdutoResponse GetData(AlterarParcelaFaixaProdutoRequest requestData)
        {
            var response = new AlterarParcelaFaixaProdutoResponse();

            var client = new Produto();
            //Include the SOAP header in the client parameters
            client.cieloSoapHeader = this.GetSoapHeader();

            // Out parameters declaration
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string statusRetorno = string.Empty;
            string sistemaLegado = string.Empty;
            string codigoSolicitacao = string.Empty;
            DateTime? dataPrevistaConclusaoSolicitacao = null;
            bool dataPrevistaConclusaoSolicitacaoSpecified = false;

            // Ref parameters declaration
            var listFaixaTaxaSegmentado = new List<FaixaTaxaSegmentado1>();

            foreach (var itemFaixaTaxaSegmentado in requestData.DadosFaixaTaxaSegmentado)
            {
                var faixaTaxaRequest = new FaixaTaxaSegmentado1();

                faixaTaxaRequest.codigoFaixa = itemFaixaTaxaSegmentado.CodigoFaixa;
                faixaTaxaRequest.numeroFinalParcelaFaixa = itemFaixaTaxaSegmentado.NumeroFinalParcelaFaixa;
                faixaTaxaRequest.numeroInicialParcelaFaixa = itemFaixaTaxaSegmentado.NumeroInicialParcelaFaixa;
                faixaTaxaRequest.percentualTaxaFaixa = itemFaixaTaxaSegmentado.PercentualTaxaFaixa;

                listFaixaTaxaSegmentado.Add(faixaTaxaRequest);
            }

            var dadosFaixaTaxaSegmentado = listFaixaTaxaSegmentado.ToArray();

            try
            {
                codigoRetorno = client.alterarParcelaFaixaProduto
                (
                    protocolo                                : requestData.Protocolo,
                    codigoCliente                            : requestData.CodigoCliente,
                    codigoProduto                            : requestData.CodigoProduto,
                    quantidadeParcelas                       : requestData.QuantidadeParcelas,
                    percentualTaxa                           : requestData.PercentualTaxa,
                    dadosFaixaTaxaSegmentado                 : dadosFaixaTaxaSegmentado,
                    origem                                   : requestData.Origem,
                    descricaoRetornoMensagem                 : out mensagemRetorno,
                    statusRetorno                            : out statusRetorno,
                    sistemaLegado                            : out sistemaLegado,
                    codigoSolicitacao                        : out codigoSolicitacao,
                    dataPrevistaConclusaoSolicitacao         : out dataPrevistaConclusaoSolicitacao,
                    dataPrevistaConclusaoSolicitacaoSpecified: out dataPrevistaConclusaoSolicitacaoSpecified
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
                    response.CodigoSolicitacao = codigoSolicitacao;
                    response.DataPrevistaConclusaoSolicitacao = dataPrevistaConclusaoSolicitacao;
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