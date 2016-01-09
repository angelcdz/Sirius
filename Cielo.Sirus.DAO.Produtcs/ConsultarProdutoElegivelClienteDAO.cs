using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarProdutoElegivelClienteDAO : DAOOSBBase<ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>
    {
        protected override ConsultarProdutoElegivelClienteResponse GetData(ConsultarProdutoElegivelClienteRequest requestData)
        {
            var response = new ConsultarProdutoElegivelClienteResponse()
            {
                Produtos = new List<ConsultarProdutoElegivelClienteProdutoDTO>()
            };

            var client = new Produto();
            client.cieloSoapHeader = this.GetSoapHeader();

            long numeroTotalRegistros = 0;
            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;

            try
            {
                var serviceOutput = client.consultarProdutosElegiveisCliente
                (
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

                response.NumeroTotalRegistros = numeroTotalRegistros;

                foreach (DadosProdutoType dadosProduto in serviceOutput)
                {
                    var produtoDTO = new ConsultarProdutoElegivelClienteProdutoDTO();

                    produtoDTO.OrdemApresentacao = dadosProduto.ordemApresentacao;

                    produtoDTO.CodigoBandeira = dadosProduto.codigoBandeira;
                    produtoDTO.CodigoProduto = dadosProduto.codigoProduto;
                    produtoDTO.IndicadorVendaDigitada = dadosProduto.indicadorVendaDigitada;
                    produtoDTO.NomeBandeira = dadosProduto.nomeBandeira;
                    produtoDTO.NomeProduto = dadosProduto.nomeProduto;
                    produtoDTO.NomeTipoLiquidacao = dadosProduto.nomeTipoLiquidacao;
                    produtoDTO.QuantidadeDiasPrazo = dadosProduto.quantidadeDiasPrazo;
                    produtoDTO.TipoGrupoProduto = dadosProduto.tipoGrupoProduto;

                    if (dadosProduto.dadosTarifa != null)
                    {
                        var dadosTarifa = dadosProduto.dadosTarifa;

                        produtoDTO.PercentualTaxaGarantia = dadosTarifa.percentualTaxaGarantia;
                        produtoDTO.PercentualTaxaPadrao = dadosTarifa.percentualTaxaPadrao;
                        produtoDTO.QuantidadeParcelasLoja = dadosTarifa.quantidadeParcelasLoja;
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
