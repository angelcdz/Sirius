using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarDetalheProdutoMultivanContratadoClienteDAO : DAOOSBBase<ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>
    {
        protected override ConsultarDetalheProdutoMultivanContratadoClienteResponse GetData(ConsultarDetalheProdutoMultivanContratadoClienteRequest requestData)
        {
            var response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse()
                {
                    DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>()
                };

            //[Rule]: Chamada ao serviço ConsultarDetalheProdutoMultivanContratadoCliente do barramento
            var client = new Produto();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                do
                {
                    DadosProdutoMultivanContratadoClienteType[] produtosMultivanResponse = client.consultarDetalheProdutoMultivanContratadoCliente(
                        codigoCliente: requestData.CodigoCliente,
                        codigoProduto: requestData.CodigoProduto,
                        proximoRegistro: ref proximoRegistro,
                        chavePaginacao: ref chavePaginacao,
                        codigoRetorno: out  codigoRetorno,
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

                        foreach (ProdutoMultivanContratadoCliente produtoMultivanResponse in produtosMultivanResponse)
                        {
                            if (produtoMultivanResponse != null)
                            {
                                var produtoMultivanDTO = new ConsultarDetalheProdutoMultivanContratadoClienteDTO();

                                produtoMultivanDTO.NumeroCadastroEmpresa = produtoMultivanResponse.CodigoClienteEmpresaReceptora;
                                produtoMultivanDTO.InicioVigencia = produtoMultivanResponse.DataInicioVigencia;
                                produtoMultivanDTO.FimVigencia = produtoMultivanResponse.DataFimVigencia;

                                if (produtoMultivanResponse.DadosEmpresaReceptora != null)
                                {
                                    var dadosEmpresa = produtoMultivanResponse.DadosEmpresaReceptora;
                                    produtoMultivanDTO.NomeEmpresa = dadosEmpresa.NomeEmpresaReceptora;
                                }
                                response.DetalhesMultivan.Add(produtoMultivanDTO);
                            }
                        }

                        response.Status = ExecutionStatus.Success;
                    }

                } while (!string.IsNullOrEmpty(proximoRegistro) && !string.IsNullOrEmpty(chavePaginacao));
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
