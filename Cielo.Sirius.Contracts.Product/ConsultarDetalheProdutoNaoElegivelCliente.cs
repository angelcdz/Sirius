using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente
{
    [DataContract]
    public class ConsultarDetalheProdutoNaoElegivelClienteRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoNaoElegivelClienteResponse : ResponseBase
    {
        [DataMember]
        public ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO Produto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoNaoElegivelClienteProdutoDTO
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
        public List<ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO> Taxas
        { get; set; }

        //Taxas: Quantidade Máxima de Parcelas
        [DataMember]
        public string QuantidadeParcelasAdministradora
        { get; set; }

        [DataMember]
        public string TipoGrupoProduto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoNaoElegivelClienteTaxaDTO
    {
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
        public double? PercentualTaxa
        { get; set; }

        //Taxas: Desconto
        [DataMember]
        public double? PercentualDesconto
        { get; set; }
    }
}
