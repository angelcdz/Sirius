using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente
{
    [DataContract]
    public class ConsultarDetalheProdutoHabilitadoClienteRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoHabilitadoClienteResponse : ResponseBase
    {
        [DataMember]
        public ConsultarDetalheProdutoHabilitadoClienteProdutoDTO Produto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoHabilitadoClienteProdutoDTO
    {
        [DataMember]
        public string CodigoProduto
        { get; set; }

        //Bandeira
        [DataMember]
        public string NomeBandeira
        { get; set; }

        //Produto
        [DataMember]
        public string NomeProduto
        { get; set; }

        //Data de Habilitação
        [DataMember]
        public DateTime? DataHabilitacaoProdutoCliente
        { get; set; }

        //Habilitado para Venda Digitada
        [DataMember]
        public string IndicadorAceitaTransacaoDigitada
        { get; set; }

        // Indicador Venda Digitada
        [DataMember]
        public bool? IndicadorVendaDigitada
        { get; set; }

        //Utilizado nos últimos 30 dias
        [DataMember]
        public bool IndicadorVendaUltimoMes
        { get; set; }

        //Tipo de Cobrança
        [DataMember]
        public string NomeTipoLiquidacao
        { get; set; }

        //Prazo de Recebimento
        [DataMember]
        public string QuantidadeDiasPrazo
        { get; set; }

        //Taxas: Tarifa Adicional por Transação
        [DataMember]
        public double? ValorItem
        { get; set; }

        //Taxas: Grid
        [DataMember]
        public List<ConsultarDetalheProdutoHabilitadoClienteTaxaDTO> Taxas
        { get; set; }

        //Taxas: Quantidade Máxima de Parcelas
        [DataMember]
        public string QuantidadeParcelasAdministradora
        { get; set; }

        //Domicilio Bancário: Banco
        [DataMember]
        public string NomeBanco
        { get; set; }

        //Domicilio Bancário: Agencia
        [DataMember]
        public string NumeroAgencia
        { get; set; }

        //Domicilio Bancário: Conta
        [DataMember]
        public string NumeroContaCorrente
        { get; set; }

        /// <summary>
        /// Representa o Tipo do Grupo do Produto
        /// </summary>
        [DataMember]
        public string TipoGrupoProduto
        { get; set; }

    }

    [DataContract]
    public class ConsultarDetalheProdutoHabilitadoClienteTaxaDTO
    {
        //Taxas: código da faixa
        [DataMember]
        public string CodigoFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor inicial da Faixa
        [DataMember]
        public string NumeroInicialParcelaFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor final da Faixa
        [DataMember]
        public string NumeroFinalParcelaFaixa
        { get; set; }

        //Taxas: Quantidade de Parcelas Contratadas
        [DataMember]
        public string QuantidadeParcelasLoja
        { get; set; }

        //Taxas: Taxa Padrão
        [DataMember]
        public double? PercentualTaxaPadrao
        { get; set; }

        //Taxas: Taxa Contratada
        [DataMember]
        public double? PercentualTaxaFaixa
        { get; set; }

        //Taxas: Desconto
        [DataMember]
        public double? PercentualDesconto
        { get; set; }

        //Taxas: Taxa Matriz
        public double? TaxaMatriz
        { get; set; }
    }
}
