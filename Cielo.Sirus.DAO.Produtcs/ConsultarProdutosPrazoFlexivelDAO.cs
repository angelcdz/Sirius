using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Contracts;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarProdutosPrazoFlexivelDAO : DAOOSBBase<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>
    {
        protected override ConsultarProdutosPrazoFlexivelResponse GetData(ConsultarProdutosPrazoFlexivelRequest requestData)
        {
            var response = new ConsultarProdutosPrazoFlexivelResponse();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            try
            {
                string proximoRegistro = string.Empty;
                string chavePaginacao = string.Empty;
                string codigoRetorno = string.Empty;
                string mensagemRetorno = string.Empty;

                do
                {
                    var serviceOutput = client.consultarProdutosPrazoFlexivel
                        (
                        codigoCliente: requestData.CodigoCliente,
                        proximoRegistro: ref proximoRegistro,
                        chavePaginacao: ref chavePaginacao,
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

                    int codGrupo = 0;
                    if (int.TryParse(serviceOutput.codigoGrupoPrazoFlexivel, out codGrupo))
                        response.CodigoGrupoPrazoFlexivel = codGrupo;

                    foreach (Produto1 dadosProduto in serviceOutput.dadosProdutos)
                    {
                        var produtoDTO = new ConsultarProdutosPrazoFlexivelProdutoDTO();

                        int codProd = 0;
                        if (int.TryParse(dadosProduto.codigoProduto, out codProd))
                            produtoDTO.CodigoProduto = codProd;

                        int codBandeira = 0;
                        if (int.TryParse(dadosProduto.codigoBandeira, out codBandeira))
                            produtoDTO.CodigoBandeira = codBandeira;

                        int qtdDiasPrazo = 0;
                        if (int.TryParse(dadosProduto.quantidadeDiasPrazo, out qtdDiasPrazo))
                            produtoDTO.QuantidadeDiasPrazo = qtdDiasPrazo;


                        produtoDTO.NomeProduto = dadosProduto.nomeProduto;                     
                        produtoDTO.NomeBandeira = dadosProduto.nomeBandeira;                     

                        if (dadosProduto.dadosTarifa != null)
                        {
                            var dadosTarifa = dadosProduto.dadosTarifa;

                            produtoDTO.PercentualTaxaGarantia = dadosTarifa.percentualTaxaGarantia;
                        }

                        response.Produtos.Add(produtoDTO);
                    }

                } while (!string.IsNullOrEmpty(proximoRegistro));

                response.Status = ExecutionStatus.Success;
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }

            return response;
        }
    }
}
