using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.AlterarTaxasProdutoCreditoParceladoSegmentado
{
    [DataContract]
    public class AlterarTaxasProdutoCreditoParceladoSegmentadoRequest : RequestBase
    {
        [DataMember]
        public string Protocolo
        { get; set; }

        [DataMember]
        public string CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public List<Faixa> Faixas
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }
    }

    [DataContract]
    public class AlterarTaxasProdutoCreditoParceladoSegmentadoResponse : ResponseBase
    {
        [DataMember]
        public int CodigoRetorno
        { get; set; }

        [DataMember]
        public string DescricaoRetornoMensagem
        { get; set; }

        [DataMember]
        public DateTime dataPrevistaConclusaoSolicitacao
        { get; set; }
    }

    [DataContract]
    public class Faixa
    {
        //Taxas: Quantidade de Parcelas Contratadas
        [DataMember]
        public int QuantidadeParcelasLoja
        { get; set; }

        //Taxas: nova taxa
        [DataMember]
        public decimal PercentualTaxa
        { get; set; }

        //Taxas: Taxa Contratada
        [DataMember]
        public decimal PercentualTaxaFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor inicial da Faixa
        [DataMember]
        public int NumeroInicialParcelaFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor final da Faixa
        [DataMember]
        public int NumeroFinalParcelaFaixa
        { get; set; }

        //Taxas: código da faixa
        [DataMember]
        public string CodigoFaixa
        { get; set; }
    }
}
