using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAleloRefeicao;
using Cielo.Sirius.DAO.Products.Extensions.ProdutoService;
using Cielo.Sirius.DAO.Products.ProdutoService;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarInformacoesPatAleloRefeicaoDAO : DAOOSBBase<ConsultarInformacoesPatAleloRefeicaoClienteRequest,ConsultarInformacoesPatAleloRefeicaoClienteResponse>
    {
        protected override ConsultarInformacoesPatAleloRefeicaoClienteResponse GetData(ConsultarInformacoesPatAleloRefeicaoClienteRequest requestData)
        {
            var newResponse = InitResponse();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            var cieloSoapHeader = this.GetSoapHeader();

            //[Rule]: Chamada ao serviço consultarInformacaoPatAlelo do barramento
            Produto1Client client = new Produto1Client("ProdutoSOAP");
            try
            {

                var request = new consultarInformacaoPatAleloRequest();
                request.codigoCliente = requestData.CodigoCliente;

                DadosPatAleloVVAType dadosPatAleloVVAType = null;
                string codigoRetorno = string.Empty;
                string descricaoRetornoMensagem = string.Empty;

                DadosPatAleloVVRType dados = client.consultarInformacaoPatAlelo(cieloSoapHeader, request, out dadosPatAleloVVAType, out codigoRetorno, out descricaoRetornoMensagem);
               
                //Commom type
                newResponse.Aberto24Horas = dados.dadosPatAlelo.aberto24Horas;
                newResponse.Domingo = dados.dadosPatAlelo.domingo;
                newResponse.HorarioComercial = dados.dadosPatAlelo.horarioComercial;
                newResponse.Noturno = dados.dadosPatAlelo.noturno;
                newResponse.Outros = dados.dadosPatAlelo.outros;
                newResponse.Padaria = dados.dadosPatAlelo.padaria;
                newResponse.Sabado = dados.dadosPatAlelo.sabado;
                newResponse.SegundaSexta = dados.dadosPatAlelo.segundaSexta;

                //PatAlelo
                ConsultarInformacoesPatAleloRefeicaoClienteDTO2 patAlelo = new ConsultarInformacoesPatAleloRefeicaoClienteDTO2();
                patAlelo.CodigoCliente = dados.patAlelo.codigoCliente;
                patAlelo.CodigoProduto = dados.patAlelo.codigoProduto;
                patAlelo.DadosLojaFisica = new List<ConsultarInformacoesPatAleloRefeicaoClienteDTO3>();
                patAlelo.DataAfiliacao = dados.patAlelo.dataAfiliacao;
                patAlelo.IndicadorApresentacaoCartao = dados.patAlelo.indicadorApresentacaoCartao;
                patAlelo.IndicadorServicoDelivery = dados.patAlelo.indicadorServicoDelivery;
                patAlelo.IndicadorVendaInternet = dados.patAlelo.IndicadorVendaInternet;

                // DadosLojaFisica
                patAlelo.DadosLojaFisica = new List<ConsultarInformacoesPatAleloRefeicaoClienteDTO3>();
                ConsultarInformacoesPatAleloRefeicaoClienteDTO3 dadoslojaFisica = new ConsultarInformacoesPatAleloRefeicaoClienteDTO3();
                dadoslojaFisica.ValorAreaAtendimentoPublico = dados.patAlelo.dadosLojaFisica.valorAreaAtendimentoPublico;
                dadoslojaFisica.QuantidadeDeAssento = dados.patAlelo.dadosLojaFisica.quantidadeAssento;
                dadoslojaFisica.QuantidadeDeMaximaRefeicao = dados.patAlelo.dadosLojaFisica.quantidadeMaximaRefeicao;
                dadoslojaFisica.QuantidadeDeMesa = dados.patAlelo.dadosLojaFisica.quantidadeMesa;
              
               // DadosTipoEstabelecimentoVVR
                ConsultarInformacoesPatAleloRefeicaoClienteDTO dadosTipoEstabelecimento = new ConsultarInformacoesPatAleloRefeicaoClienteDTO();
                dadosTipoEstabelecimento.Bar = dados.dadosTipoEstabelecimentoVVR.bar;
                dadosTipoEstabelecimento.FastFood = dados.dadosTipoEstabelecimentoVVR.fastFood;
                dadosTipoEstabelecimento.Lanchonete = dados.dadosTipoEstabelecimentoVVR.lanchonete;
                dadosTipoEstabelecimento.Restaurante = dados.dadosTipoEstabelecimentoVVR.restaurante;
                               
            }
            finally
            {
                client.Close();
            }

            newResponse.Status = true;
            return newResponse;
        }

        private static ConsultarInformacoesPatAleloRefeicaoClienteResponse InitResponse()
        {
            var newResponse = new ConsultarInformacoesPatAleloRefeicaoClienteResponse();
            newResponse.Aberto24Horas = false;
            newResponse.DadosTipoEstabelecimentoVVR = new List<ConsultarInformacoesPatAleloRefeicaoClienteDTO>();
            newResponse.Domingo = false;
            newResponse.HorarioComercial = false;
            newResponse.Noturno = false;
            newResponse.Outros = false;
            newResponse.Padaria = false;
            newResponse.PatAlelo = new List<ConsultarInformacoesPatAleloRefeicaoClienteDTO2>();
            newResponse.Sabado = false;
            newResponse.SegundaSexta = false;

            return newResponse;
        }
    }
}
