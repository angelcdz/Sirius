using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarProdutoHabilitadoClienteDAO : DAOOSBBase<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>
    {
        protected override ConsultarProdutoHabilitadoClienteResponse GetData(ConsultarProdutoHabilitadoClienteRequest requestData)
        {
            // Inicializa objeto response
            var response = new ConsultarProdutoHabilitadoClienteResponse()
            {
                Produtos = new List<ConsultarProdutoHabilitadoClienteProdutoDTO>()
            };

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Out parameters declaration
            DateTime dataUltimaTransacao;
            bool dataUltimaTransacaoSpecified;
            string codigoRetorno;
            string descricaoRetornoMensagem;

            // Ref parameters declaration
            long numeroTotalRegistros = 0;
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                // Realiza chamada ao barramento (OSB)
                var serviceOutput = client.consultarProdutosHabilitadoCliente
                    (
                        codigoCliente: requestData.CodigoCliente,
                        numeroTotalRegistros: out numeroTotalRegistros,
                        dataUltimaTransacao: out dataUltimaTransacao,
                        dataUltimaTransacaoSpecified: out dataUltimaTransacaoSpecified,
                        codigoRetorno: out codigoRetorno,
                        descricaoRetornoMensagem: out descricaoRetornoMensagem
                    );

                //[Rule]: Business Error: Returns immediately
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = descricaoRetornoMensagem;
                    response.Status = ExecutionStatus.BusinessError;
                    return response;
                }

                // Preenche objeto de response com os parâmetros retornados do barramento
                response.DataUltimaTransacao = dataUltimaTransacao;
                response.NumeroTotalRegistros = numeroTotalRegistros;

                foreach (var produtoElement in serviceOutput)
                {
                    var produtoDTO = new ConsultarProdutoHabilitadoClienteProdutoDTO();

                    produtoDTO.IndicadorVendaUltimoMes = produtoElement.indicadorVendaUltimoMes;
                    produtoDTO.TipoGrupoProduto = produtoElement.tipoGrupoProduto;
                    produtoDTO.OrdemApresentacao = produtoElement.ordemApresentacao;

                    if (produtoElement.produtoContratadoCliente != null && produtoElement.produtoContratadoCliente.dadosProduto != null)
                    {
                        var dadosProduto = produtoElement.produtoContratadoCliente.dadosProduto;

                        produtoDTO.CodigoBandeira = dadosProduto.codigoBandeira;
                        produtoDTO.CodigoProduto = dadosProduto.codigoProduto;
                        produtoDTO.IndicadorVendaDigitada = dadosProduto.indicadorVendaDigitada;
                        produtoDTO.IndicadorVendaDigitadaHabilitada = dadosProduto.indicadorVendaDigitadaHabilitada;
                        produtoDTO.NomeBandeira = dadosProduto.nomeBandeira;
                        produtoDTO.NomeProduto = dadosProduto.nomeProduto;
                        produtoDTO.NomeTipoLiquidacao = dadosProduto.nomeTipoLiquidacao;
                        produtoDTO.PercentualDesconto = dadosProduto.percentualDesconto;
                        produtoDTO.PercentualTaxa = dadosProduto.percentualTaxa;
                        produtoDTO.QuantidadeDiasPrazo = dadosProduto.quantidadeDiasPrazo;

                        if (dadosProduto.dadosTarifa != null)
                        {
                            var dadosTarifa = dadosProduto.dadosTarifa;

                            produtoDTO.PercentualTaxaGarantia = dadosTarifa.percentualTaxaGarantia;
                            produtoDTO.PercentualTaxaPadrao = dadosTarifa.percentualTaxaPadrao;
                            produtoDTO.QuantidadeParcelasLoja = dadosTarifa.quantidadeParcelasLoja;
                            produtoDTO.ValorTarifa = dadosTarifa.valorTarifa;
                        }
                    }

                    response.Produtos.Add(produtoDTO);
                }

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
