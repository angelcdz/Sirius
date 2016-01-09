using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.DAO.Products.WR.Produto;
using Cielo.Sirius.DAO.Products.WR.Produto.Extensions;
using Cielo.Sirius.Foundation;
using System;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarInformacoesPatAleloDAO : DAOOSBBase<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>
    {
        protected override ConsultarInformacoesPatAleloResponse GetData(ConsultarInformacoesPatAleloRequest requestData)
        {
            var response = new ConsultarInformacoesPatAleloResponse();
            response.DadosAlimentacao = new PatAleloAlimentacaoDTO();
            response.DadosRefeicao = new PatAleloRefeicaoDTO();

            #region Inicialização dos atributos do response
            response.DadosAlimentacao.Aberto24Horas = false;
            response.DadosAlimentacao.Acougue = false;
            response.DadosAlimentacao.Armazem = false;
            response.DadosAlimentacao.CheckOutsLoja = string.Empty;
            response.DadosAlimentacao.CodigoCliente = null;
            response.DadosAlimentacao.CodigoProduto = string.Empty;
            response.DadosAlimentacao.DataAfiliacao = null;
            response.DadosAlimentacao.Domingo = false;
            response.DadosAlimentacao.Hipermercado = false;
            response.DadosAlimentacao.HorarioComercial = false;
            response.DadosAlimentacao.Hortimercado = false;
            response.DadosAlimentacao.IndicadorApresentacaoCartao = string.Empty;
            response.DadosAlimentacao.IndicadorServicoDelivery = string.Empty;
            response.DadosAlimentacao.IndicadorVendaInternet = string.Empty;
            response.DadosAlimentacao.LaticinioFrios = false;
            response.DadosAlimentacao.Mercearia = false;
            response.DadosAlimentacao.Noturno = false;
            response.DadosAlimentacao.Outros = false;
            response.DadosAlimentacao.Padaria = false;
            response.DadosAlimentacao.Peixaria = false;
            response.DadosAlimentacao.Sabado = false;
            response.DadosAlimentacao.SegundaSexta = false;
            response.DadosAlimentacao.Supermercado = false;
            response.DadosAlimentacao.ValorAreaAtendimentoPublico = string.Empty;
            response.DadosRefeicao.Aberto24Horas = false;
            response.DadosRefeicao.Bar = false;
            response.DadosRefeicao.CodigoCliente = null;
            response.DadosRefeicao.CodigoProduto = string.Empty;
            response.DadosRefeicao.DataAfiliacao = null;
            response.DadosRefeicao.Domingo = false;
            response.DadosRefeicao.FastFood = false;
            response.DadosRefeicao.HorarioComercial = false;
            response.DadosRefeicao.IndicadorApresentacaoCartao = string.Empty;
            response.DadosRefeicao.IndicadorServicoDelivery = string.Empty;
            response.DadosRefeicao.IndicadorVendaInternet = string.Empty;
            response.DadosRefeicao.Lanchonete = false;
            response.DadosRefeicao.Noturno = false;
            response.DadosRefeicao.Outros = false;
            response.DadosRefeicao.Padaria = false;
            response.DadosRefeicao.QuantidadeDeAssento = string.Empty;
            response.DadosRefeicao.QuantidadeDeMaximaRefeicao = string.Empty;
            response.DadosRefeicao.QuantidadeDeMesa = string.Empty;
            response.DadosRefeicao.Restaurante = false;
            response.DadosRefeicao.Sabado = false;
            response.DadosRefeicao.SegundaSexta = false;
            response.DadosRefeicao.ValorAreaAtendimentoPublico = string.Empty;
            #endregion

            // Passa as variaveis de retorno;
            DadosPatAleloVVAType dadosPatAleloVVAType = null;
            string codigoRetorno = string.Empty;
            string descricaoRetornoMensagem = string.Empty;

            var client = new Produto();
            client.cieloSoapHeader = this.GetSoapHeader();

            try
            {
                // Transforma parametro de entrada (requestData) para o tipo de entrada do serviço (request)
                var serviceOutput = client.consultarInformacaoPatAlelo
                (
                    codigoCliente: requestData.CodigoCliente,
                    dadosPatAleloVVA: out dadosPatAleloVVAType,
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
                else
                {
                    response.Status = ExecutionStatus.Success;

                    #region Converte resposta do serviço  para o tipo de retorno do metodo


                    //Exclusivos Alimentacao
                    response.DadosAlimentacao.CheckOutsLoja = dadosPatAleloVVAType.checkOutsLoja;

                    //Commom type Alimentacao
                    response.DadosAlimentacao.Aberto24Horas = serviceOutput.dadosPatAlelo.aberto24Horas;
                    response.DadosAlimentacao.Domingo = serviceOutput.dadosPatAlelo.domingo;
                    response.DadosAlimentacao.HorarioComercial = serviceOutput.dadosPatAlelo.horarioComercial;
                    response.DadosAlimentacao.Noturno = serviceOutput.dadosPatAlelo.noturno;
                    response.DadosAlimentacao.Outros = serviceOutput.dadosPatAlelo.outros;
                    response.DadosAlimentacao.Sabado = serviceOutput.dadosPatAlelo.sabado;
                    response.DadosAlimentacao.SegundaSexta = serviceOutput.dadosPatAlelo.segundaSexta;
                    response.DadosAlimentacao.Padaria = serviceOutput.dadosPatAlelo.padaria;


                    // dados tipo estabelecimento
                    response.DadosAlimentacao.Acougue = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.acougue;
                    response.DadosAlimentacao.Armazem = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.armazem;
                    response.DadosAlimentacao.Hipermercado = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.hipermercado;
                    response.DadosAlimentacao.Hortimercado = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.hortimercado;
                    response.DadosAlimentacao.LaticinioFrios = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.laticinioFrios;
                    response.DadosAlimentacao.Mercearia = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.mercearia;
                    response.DadosAlimentacao.Peixaria = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.peixaria;
                    response.DadosAlimentacao.Supermercado = dadosPatAleloVVAType.dadosTipoEstabelecimentoVVA.supermercado;

                    //patAlelo Alimentacao
                    response.DadosAlimentacao.CodigoProduto = dadosPatAleloVVAType.patAlelo.codigoProduto;
                    response.DadosAlimentacao.CodigoCliente = dadosPatAleloVVAType.patAlelo.codigoCliente;
                    response.DadosAlimentacao.ValorAreaAtendimentoPublico = dadosPatAleloVVAType.patAlelo.dadosLojaFisica.valorAreaAtendimentoPublico;
                    response.DadosAlimentacao.DataAfiliacao = dadosPatAleloVVAType.patAlelo.dataAfiliacao;
                    response.DadosAlimentacao.IndicadorApresentacaoCartao = dadosPatAleloVVAType.patAlelo.indicadorApresentacaoCartao;
                    response.DadosAlimentacao.IndicadorServicoDelivery = dadosPatAleloVVAType.patAlelo.indicadorServicoDelivery;
                    response.DadosAlimentacao.IndicadorVendaInternet = dadosPatAleloVVAType.patAlelo.IndicadorVendaInternet;


                    //Commom type refeicao
                    response.DadosRefeicao.Aberto24Horas = serviceOutput.dadosPatAlelo.aberto24Horas;
                    response.DadosRefeicao.Domingo = serviceOutput.dadosPatAlelo.domingo;
                    response.DadosRefeicao.HorarioComercial = serviceOutput.dadosPatAlelo.horarioComercial;
                    response.DadosRefeicao.Noturno = serviceOutput.dadosPatAlelo.noturno;
                    response.DadosRefeicao.Outros = serviceOutput.dadosPatAlelo.outros;
                    response.DadosRefeicao.Sabado = serviceOutput.dadosPatAlelo.sabado;
                    response.DadosRefeicao.SegundaSexta = serviceOutput.dadosPatAlelo.segundaSexta;
                    response.DadosRefeicao.Padaria = serviceOutput.dadosPatAlelo.padaria;


                    //patAlelo Refeicao
                    response.DadosRefeicao.CodigoProduto = dadosPatAleloVVAType.patAlelo.codigoProduto;
                    response.DadosRefeicao.CodigoCliente = dadosPatAleloVVAType.patAlelo.codigoCliente;
                    response.DadosRefeicao.ValorAreaAtendimentoPublico = dadosPatAleloVVAType.patAlelo.dadosLojaFisica.valorAreaAtendimentoPublico;
                    response.DadosRefeicao.DataAfiliacao = dadosPatAleloVVAType.patAlelo.dataAfiliacao;
                    response.DadosRefeicao.IndicadorApresentacaoCartao = dadosPatAleloVVAType.patAlelo.indicadorApresentacaoCartao;
                    response.DadosRefeicao.IndicadorServicoDelivery = dadosPatAleloVVAType.patAlelo.indicadorServicoDelivery;
                    response.DadosRefeicao.IndicadorVendaInternet = dadosPatAleloVVAType.patAlelo.IndicadorVendaInternet;
                    response.DadosRefeicao.QuantidadeDeAssento = dadosPatAleloVVAType.patAlelo.dadosLojaFisica.quantidadeAssento;
                    response.DadosRefeicao.QuantidadeDeMaximaRefeicao = dadosPatAleloVVAType.patAlelo.dadosLojaFisica.quantidadeMaximaRefeicao;
                    response.DadosRefeicao.QuantidadeDeMesa = dadosPatAleloVVAType.patAlelo.dadosLojaFisica.quantidadeMesa;


                    // dados tipo estabelecimento refeicao
                    response.DadosRefeicao.Bar = serviceOutput.dadosTipoEstabelecimentoVVR.bar;
                    response.DadosRefeicao.FastFood = serviceOutput.dadosTipoEstabelecimentoVVR.fastFood;
                    response.DadosRefeicao.Lanchonete = serviceOutput.dadosTipoEstabelecimentoVVR.lanchonete;
                    response.DadosRefeicao.Restaurante = serviceOutput.dadosTipoEstabelecimentoVVR.restaurante;

                    #endregion
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