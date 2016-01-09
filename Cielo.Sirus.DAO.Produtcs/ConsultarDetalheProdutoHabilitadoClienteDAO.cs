using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarDetalheProdutoHabilitadoClienteDAO : DAOOSBBase<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>
    {
        protected override ConsultarDetalheProdutoHabilitadoClienteResponse GetData(ConsultarDetalheProdutoHabilitadoClienteRequest requestData)
        {
            // Cria objeto Response
            var response = new ConsultarDetalheProdutoHabilitadoClienteResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Variáveis para recepção das informações recebidas do barramento
            IEnumerable<ProdutoContratadoClienteType> retornoServico;
            Banco banco;
            Cliente cliente;
            string codigoRetorno;
            string mensagemRetorno;
            Produto1 produto;

            try
            {
                // Realiza chamada ao serviço no OSB
                retornoServico = client.consultarDetalheProdutoHabilitadoCliente(
                    codigoCliente           : requestData.CodigoCliente,
                    codigoProduto           : requestData.CodigoProduto,
                    produto                 : out produto,
                    banco                   : out banco,
                    cliente                 : out cliente,
                    codigoRetorno           : out codigoRetorno,
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

                    ProdutoContratadoClienteType responseProduto = retornoServico.SingleOrDefault();

                    if (responseProduto != null && responseProduto.produtoContratadoCliente != null && responseProduto.produtoContratadoCliente.dadosProduto != null)
                    {
                        var dadosProduto = responseProduto.produtoContratadoCliente.dadosProduto;
                        var produtoDTO = new ConsultarDetalheProdutoHabilitadoClienteProdutoDTO();

                        produtoDTO.CodigoProduto                    = dadosProduto.codigoProduto;
                        produtoDTO.NomeProduto                      = dadosProduto.nomeProduto;
                        produtoDTO.NomeBandeira                     = dadosProduto.nomeBandeira;
                        produtoDTO.DataHabilitacaoProdutoCliente    = dadosProduto.dataHabilitacaoProdutoCliente;
                        produtoDTO.IndicadorVendaUltimoMes          = responseProduto.indicadorVendaUltimoMes;
                        produtoDTO.NomeTipoLiquidacao               = dadosProduto.nomeTipoLiquidacao;
                        produtoDTO.QuantidadeDiasPrazo              = dadosProduto.quantidadeDiasPrazo;
                        produtoDTO.IndicadorAceitaTransacaoDigitada = responseProduto.produtoContratadoCliente.indicadorAceitaTransacaoDigitada;
                        produtoDTO.IndicadorVendaDigitada           = dadosProduto.indicadorVendaDigitada;
                        produtoDTO.ValorItem                        = dadosProduto.dadosTarifa != null ? dadosProduto.dadosTarifa.valorItem : null;
                        produtoDTO.QuantidadeParcelasAdministradora = dadosProduto.dadosTarifa != null ? dadosProduto.dadosTarifa.quantidadeParcelasAdministradora : null;
                        produtoDTO.TipoGrupoProduto                 = responseProduto.tipoGrupoProduto;

                        // Dados bancários
                        produtoDTO.NomeBanco           = banco != null ? banco.nomeBanco : null;
                        produtoDTO.NumeroAgencia       = dadosProduto.dadosBancarios != null ? dadosProduto.dadosBancarios.numeroAgencia : null;
                        produtoDTO.NumeroContaCorrente = dadosProduto.dadosBancarios != null ? dadosProduto.dadosBancarios.numeroContaCorrente : null;

                        produtoDTO.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();

                        if (dadosProduto.dadosTarifa != null)
                        {
                            produtoDTO.Taxas = new List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO>();
                            ConsultarDetalheProdutoHabilitadoClienteTaxaDTO taxaDTO;

                            switch (responseProduto.tipoGrupoProduto)
                            {
                                case "4":

                                    if (dadosProduto.dadosTarifa.dadosFaixasTaxaSegmentado != null)
                                    {
                                        foreach (var dadosTaxaSegmentado in dadosProduto.dadosTarifa.dadosFaixasTaxaSegmentado)
                                        {
                                            taxaDTO = new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
                                            {
                                                NumeroInicialParcelaFaixa = dadosTaxaSegmentado.numeroInicialParcelaFaixa,
                                                NumeroFinalParcelaFaixa   = dadosTaxaSegmentado.numeroFinalParcelaFaixa,
                                                PercentualTaxaPadrao      = dadosProduto.dadosTarifa.percentualTaxaPadrao,
                                                PercentualTaxaFaixa       = dadosTaxaSegmentado.percentualTaxaFaixa,
                                                PercentualDesconto        = dadosTaxaSegmentado.percentualDescontoSegmentado,
                                                CodigoFaixa               = dadosTaxaSegmentado.codigoFaixa
                                            };
                                            produtoDTO.Taxas.Add(taxaDTO);
                                        };
                                    }
                                    break;

                                case "3":
                                    taxaDTO = new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
                                    {
                                        QuantidadeParcelasLoja = dadosProduto.dadosTarifa.quantidadeParcelasLoja,
                                        PercentualTaxaPadrao   = dadosProduto.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxaFaixa    = (double?)dadosProduto.percentualTaxa,
                                        PercentualDesconto     = (double?)dadosProduto.percentualDesconto
                                    };
                                    produtoDTO.Taxas.Add(taxaDTO);
                                    break;

                                case "1":
                                    taxaDTO = new ConsultarDetalheProdutoHabilitadoClienteTaxaDTO()
                                    {
                                        PercentualTaxaPadrao = dadosProduto.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxaFaixa  = (double?)dadosProduto.percentualTaxa,
                                        PercentualDesconto   = (double?)dadosProduto.percentualDesconto
                                    };
                                    produtoDTO.Taxas.Add(taxaDTO);
                                    break;
                            }
                        }

                        response.Produto = produtoDTO;
                    }
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