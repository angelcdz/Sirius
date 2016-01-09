using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarDetalheProdutoElegivelClienteDAO : DAOOSBBase<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>
    {
        protected override ConsultarDetalheProdutoElegivelClienteResponse GetData(ConsultarDetalheProdutoElegivelClienteRequest requestData)
        {
            // Cria objeto Response
            var response = new ConsultarDetalheProdutoElegivelClienteResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteElegivels do barramento
            var client = new Produto();
            client.cieloSoapHeader = this.GetSoapHeader();

            // Variáveis para recepção das informações recebidas do barramento
            Cliente cliente;
            string codigoRetorno;
            string mensagemRetorno;
            ProdutoContratadoCliente produtoContratadoCliente;

            try
            {
                // Realiza chamada ao serviço no OSB
                var serviceOutput = client.consultarDetalheProdutoElegivelCliente
                (
                    codigoCliente           : requestData.CodigoCliente,
                    codigoProduto           : requestData.CodigoProduto,
                    cliente                 : out cliente,
                    produtoContratadoCliente: out produtoContratadoCliente,
                    codigoRetorno           : out codigoRetorno,
                    descricaoRetornoMensagem: out mensagemRetorno
                );

                //[Rule]: Business Error:
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.ErrorCode = codigoRetorno;
                    response.ErrorMessage = mensagemRetorno;
                    response.Status = ExecutionStatus.BusinessError;
                }
                else
                {
                    if (serviceOutput != null && produtoContratadoCliente != null)
                    {
                        var produtoDTO = new ConsultarDetalheProdutoElegivelClienteProdutoDTO();

                        produtoDTO.CodigoProduto                    = serviceOutput.codigoProduto;
                        produtoDTO.NomeProduto                      = serviceOutput.nomeProduto;
                        produtoDTO.NomeBandeira                     = serviceOutput.nomeBandeira;
                        produtoDTO.DataHabilitacaoProdutoCliente    = serviceOutput.dataHabilitacaoProdutoCliente;
                        produtoDTO.NomeTipoLiquidacao               = serviceOutput.nomeTipoLiquidacao;
                        produtoDTO.QuantidadeDiasPrazo              = serviceOutput.quantidadeDiasPrazo;
                        produtoDTO.IndicadorAceitaTransacaoDigitada = produtoContratadoCliente.indicadorAceitaTransacaoDigitada;
                        produtoDTO.IndicadorVendaDigitada           = serviceOutput.indicadorVendaDigitada;
                        produtoDTO.ValorItem                        = serviceOutput.dadosTarifa != null ? serviceOutput.dadosTarifa.valorItem : null;
                        produtoDTO.QuantidadeParcelasAdministradora = serviceOutput.dadosTarifa != null ? serviceOutput.dadosTarifa.quantidadeParcelasAdministradora : null;
                        produtoDTO.TipoGrupoProduto                 = serviceOutput.tipoGrupoProduto;

                        produtoDTO.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();

                        if (serviceOutput.dadosTarifa != null)
                        {
                            produtoDTO.Taxas = new List<ConsultarDetalheProdutoElegivelClienteTaxaDTO>();
                            ConsultarDetalheProdutoElegivelClienteTaxaDTO taxaDTO;

                            switch (serviceOutput.tipoGrupoProduto)
                            {
                                case "3":
                                    taxaDTO = new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
                                    {
                                        QuantidadeParcelasLoja = serviceOutput.dadosTarifa.quantidadeParcelasLoja,
                                        PercentualTaxaPadrao   = serviceOutput.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxa         = (double?)serviceOutput.percentualTaxa,
                                        PercentualDesconto     = (double?)serviceOutput.percentualDesconto
                                    };
                                    produtoDTO.Taxas.Add(taxaDTO);
                                    break;

                                case "1":
                                    taxaDTO = new ConsultarDetalheProdutoElegivelClienteTaxaDTO()
                                    {
                                        PercentualTaxaPadrao = serviceOutput.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxa       = (double?)serviceOutput.percentualTaxa,
                                        PercentualDesconto   = (double?)serviceOutput.percentualDesconto
                                    };
                                    produtoDTO.Taxas.Add(taxaDTO);
                                    break;
                            }
                        }

                        response.Produto = produtoDTO;
                    }

                    response.Status = ExecutionStatus.Success;
                }
            }
            finally
            {
                // Fecha objecto client
                if (client != null)
                    client.Dispose();
            }

            return response;
        }
    }
}