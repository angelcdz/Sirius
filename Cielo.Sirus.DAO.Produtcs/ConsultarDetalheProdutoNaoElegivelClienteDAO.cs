using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarDetalheProdutoNaoElegivelClienteDAO : DAOOSBBase<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>
    {
        protected override ConsultarDetalheProdutoNaoElegivelClienteResponse GetData(ConsultarDetalheProdutoNaoElegivelClienteRequest requestData)
        {
            // Cria objeto Response
            var response = new ConsultarDetalheProdutoNaoElegivelClienteResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteNaoElegivel do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            // Variáveis para recepção das informações recebidas do barramento
            DadosProdutoType retornoServico;
            string codigoRetorno;
            string mensagemRetorno;

            try
            {
                // Realiza chamada ao serviço no OSB
                retornoServico = client.consultarDetalheProdutoNaoElegivelCliente(
                    codigoCliente           : requestData.CodigoCliente,
                    codigoProduto           : requestData.CodigoProduto,
                    codigoRetorno           : out codigoRetorno,
                    descricaoRetornoMensagem: out mensagemRetorno);

                //[Rule]: Lógica de erro de negócio:
                if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                {
                    response.ErrorCode    = codigoRetorno;
                    response.ErrorMessage = mensagemRetorno;
                    response.Status       = ExecutionStatus.BusinessError;
                }
                else
                {
                    response.Status = ExecutionStatus.Success;

                    if (retornoServico != null)
                    {
                        var produtoDTO = new ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO();

                        produtoDTO.CodigoProduto                    = retornoServico.codigoProduto;
                        produtoDTO.TipoGrupoProduto                 = retornoServico.tipoGrupoProduto;
                        produtoDTO.NomeProduto                      = retornoServico.nomeProduto;
                        produtoDTO.NomeBandeira                     = retornoServico.nomeBandeira;
                        produtoDTO.DataHabilitacaoProdutoCliente    = retornoServico.dataHabilitacaoProdutoCliente;
                        produtoDTO.NomeTipoLiquidacao               = retornoServico.nomeTipoLiquidacao;
                        produtoDTO.QuantidadeDiasPrazo              = retornoServico.quantidadeDiasPrazo;
                        produtoDTO.ValorItem                        = retornoServico.dadosTarifa != null ? retornoServico.dadosTarifa.valorItem : null;
                        produtoDTO.QuantidadeParcelasAdministradora = retornoServico.dadosTarifa != null ? retornoServico.dadosTarifa.quantidadeParcelasAdministradora : null;

                        produtoDTO.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();

                        if (retornoServico.dadosTarifa != null)
                        {
                            produtoDTO.Taxas = new List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO>();
                            ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO taxaDTO;

                            switch (retornoServico.tipoGrupoProduto)
                            {
                                case "3":
                                    taxaDTO = new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
                                    {
                                        QuantidadeParcelasLoja = retornoServico.dadosTarifa.quantidadeParcelasLoja,
                                        PercentualTaxaPadrao   = retornoServico.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxa         = (double?)retornoServico.percentualTaxa,
                                        PercentualDesconto     = (double?)retornoServico.percentualDesconto
                                    };
                                    produtoDTO.Taxas.Add(taxaDTO);
                                    break;

                                case "1":
                                    taxaDTO = new ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO()
                                    {
                                        PercentualTaxaPadrao = retornoServico.dadosTarifa.percentualTaxaPadrao,
                                        PercentualTaxa       = (double?)retornoServico.percentualTaxa,
                                        PercentualDesconto   = (double?)retornoServico.percentualDesconto
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
                if (client != null)
                    client.Dispose();
            }

            return response;
        }
    }
}