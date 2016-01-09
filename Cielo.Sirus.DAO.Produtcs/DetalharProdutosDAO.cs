using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAleloRefeicaoCliente;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAleloAlimentacaoCliente;
using Cielo.Sirius.Contracts.ConsultarInformacaoesPatAleloBaseCliente;
using Cielo.Sirius.DAO.Products.Extensions.ProdutoService;
using Cielo.Sirius.DAO.Products.ProdutoService;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.ClienteService;


namespace Cielo.Sirius.DAO.Products
{
  public class DetalharProdutosAlimentaçãoDAO : DAOOSBBase<ConsultarInformacoesPatAleloAlimentacaoClienteRequest, ConsultarInformacoesPatAleloAlimentacaoClienteResponse>
    {
      protected override ConsultarInformacoesPatAleloAlimentacaoClienteResponse GetData(ConsultarInformacoesPatAleloAlimentacaoClienteRequest requestData)
       {
            var newResponse = new ConsultarInformacoesPatAleloAlimentacaoClienteResponse();
            newResponse.DadosTipoEstabelecimentoVVA = new List<ConsultarInformacoesPatAleloAlimentacaoClienteDTO>();

         //// Ver se tá certo
         //newResponse.PatAlelo = new List<ConsultarInformacoesPatAleloAlimentacaoClienteDTO2>();
         ////Ver se tá certo
         // var newResponse2 = new ConsultarInformacoesPatAleloAlimentacaoClienteDTO2();
         // newResponse2.DadosLojaFisica = new List<ConsultarInformacoesPatAleloAlimentacaoClienteDTO3>();
 

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
             var cieloSoapHeader = this.GetSoapHeader();

            //[Rule]: Chamada ao serviço ConsultarProdutosClienteHabilitados do barramento
         
          Produto1Client client = new Produto1Client("ProdutoSOAP");

            string codigoRetorno = string.Empty;
            string mensagemRetorno = string.Empty;
          bool acougue = true;
          bool armazem = true;
          bool hipermercado = true;
          bool hortimercado = true; 
          bool LaticinioFrios = true;
          bool mercearia = true;
          bool peixaria = true;
          bool supermercado = true;

            try 
	        {
                do
                {
                    var request = new ConsultarInformacoesPatAleloAlimentacaoClienteRequest();
                    request.CodigoCliente = requestData.CodigoCliente;

                  
                DadosProdutoType[] produtosResponse = client. ( 
                   
                           cieloSoapHeader,
                           request,
                       out codigoRetorno ,
            out mensagemRetorno, 
          out acougue, 
          out armazem, 
          out hipermercado, 
          out hortimercado, 
          out LaticinioFrios, 
          out mercearia, 
          out peixaria, 
          out supermercado, 

                    //[Rule]: Business Error: Returns immediately
                    if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                    {
                        newResponse.FaultCode = codigoRetorno;
                        newResponse.FaultMessage = mensagemRetorno;
                        newResponse.Status = false;
                        return newResponse;
                    }

                    newResponse.Acougue = acougue;
                    newResponse.Armazem = armazem;
                    newResponse.Hipermercado = hipermercado;
                    newResponse.Hortimercado = hortimercado;
                    newResponse.LaticinioFrios = laticiniofrios;
                    newResponse.Mercearia = mercearia;
                    newResponse.Peixaria = peixaria;
                    newResponse.Supermercado = supermercado;
                   
                    if (produtosResponse != null)
                    {
                        foreach (ProdutoContratadoClienteType produtoResponse in produtosResponse)
                        {
                            var servicoDTO = new ConsultarServicoClienteElegivelServicoDTO();

                            servicoDTO.CodigoServico = servicoResponse.codigoServico;
                            servicoDTO.DescricaoServico = servicoResponse.descricaoServico;
                            servicoDTO.NomeServico = servicoResponse.nomeServico;

                            newResponse.Servicos.Add(servicoDTO);
                        }
                    }
                } while (newResponse.Servicos.Count < numeroTotalRegistros);
	        }
	        finally
            {
                client.Close();
            }

            newResponse.Status = true;
            return newResponse;
        }
    }
}

  public class DetalharProdutosRefeiçãoDAO : DAOBase<ConsultarInformacoesPatAleloRefeicaoClienteRequest, ConsultarInformacoesPatAleloRefeicaoClienteResponse>
  {
      protected override ConsultarInformacoesPatAleloRefeicaoClienteResponse GetData(ConsultarInformacoesPatAleloRefeicaoClienteRequest requestData)
      {
          throw new NotImplementedException();
      }
  }
}
