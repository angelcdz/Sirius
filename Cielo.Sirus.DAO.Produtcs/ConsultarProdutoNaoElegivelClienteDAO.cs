using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarProdutoNaoElegivelClienteDAO : DAOOSBBase<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>
    {
        protected override ConsultarProdutoNaoElegivelClienteResponse GetData(ConsultarProdutoNaoElegivelClienteRequest requestData)
        {
            var response = new ConsultarProdutoNaoElegivelClienteResponse()
                {
                    Produtos = new List<ConsultarProdutoNaoElegivelClienteProdutoDTO>()
                };

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            long numeroTotalRegistros = 0;
            DateTime dataUltimaTransacao = DateTime.MinValue;
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;

            try
            {
                DadosProdutosType[] produtosResponse = client.consultarProdutosNaoElegiveisCliente(
                    codigoCliente: requestData.CodigoCliente,
                    numeroTotalRegistros: out numeroTotalRegistros,
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

                foreach (DadosProdutosType produtoResponse in produtosResponse)
                {
                    var produtoDTO = new ConsultarProdutoNaoElegivelClienteProdutoDTO();

                    if (produtoResponse.dadosProduto != null)
                    {
                        foreach (DadosProdutoType dadosProduto in produtoResponse.dadosProduto)
                        {
                            produtoDTO.OrdemApresentacao = dadosProduto.ordemApresentacao;

                            produtoDTO.CodigoProduto = dadosProduto.codigoProduto;
                            produtoDTO.TipoGrupoProduto = dadosProduto.tipoGrupoProduto;
                            produtoDTO.CodigoBandeira = dadosProduto.codigoBandeira;
                            produtoDTO.IndicadorVendaDigitada = dadosProduto.indicadorVendaDigitada;
                            produtoDTO.NomeBandeira = dadosProduto.nomeBandeira;
                            produtoDTO.NomeProduto = dadosProduto.nomeProduto;
                            produtoDTO.NomeTipoLiquidacao = dadosProduto.nomeTipoLiquidacao;
                            produtoDTO.QuantidadeDiasPrazo = dadosProduto.quantidadeDiasPrazo;

                            if (dadosProduto.dadosTarifa != null)
                            {
                                var dadosTarifa = dadosProduto.dadosTarifa;

                                produtoDTO.PercentualTaxaGarantia = dadosTarifa.percentualTaxaGarantia;
                                produtoDTO.PercentualTaxaPadrao = dadosTarifa.percentualTaxaPadrao;
                                produtoDTO.QuantidadeParcelasLoja = dadosTarifa.quantidadeParcelasLoja;
                            }

                            response.Produtos.Add(produtoDTO);
                        }
                    }
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
