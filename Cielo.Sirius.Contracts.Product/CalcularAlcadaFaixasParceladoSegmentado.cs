using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.CalcularAlcadaFaixasParceladoSegmentado
{
    [DataContract]
    public class CalcularAlcadaFaixasParceladoSegmentadoRequest : RequestBase
    {
        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public string MCC
        { get; set; }

        [DataMember]
        public string IlhaAtendimento
        { get; set; }

        [DataMember]
        public List<CalcularAlcadaFaixasParceladoSegmentadoTaxaDTO> Taxas
        { get; set; }
    }

    [DataContract]
    public class CalcularAlcadaFaixasParceladoSegmentadoResponse : ResponseBase
    {
        [DataMember]
        public List<CalcularAlcadaFaixasParceladoSegmentadoTaxaDTO> Taxas
        { get; set; }
    }
    
    [DataContract]
    public class CalcularAlcadaFaixasParceladoSegmentadoTaxaDTO : DTOBase
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

        //Taxas: Taxa Padrão
        [DataMember]
        public decimal PercentualTaxaPadrao
        { get; set; }

        //Taxas: Taxa Matriz
        public double? TaxaMatriz
        { get; set; }

        [DataMember]
        public decimal PercentualDescontoAlcada
        { get; set; }

        [DataMember]
        public decimal PercentualMinimoDescontoAlcada
        { get; set; }

        [DataMember]
        public decimal PercentualMaximoDescontoAlcada
        { get; set; }
    }
}
