using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.HabilitarPrazoFlexivel
{
    [DataContract]
    public class HabilitarPrazoFlexivelRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string IndicaOperacao
        { get; set; }

        [DataMember]
        public int CodigoGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public int QuantidadeDiasGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public double PercentualTaxaGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public string Protocolo
        { get; set; }

        [DataMember]
        public string Origem
        { get; set; }
    }

    [DataContract]
    public class HabilitarPrazoFlexivelResponse : ResponseBase
    {
        [DataMember]
        public string StatusRetorno
        { get; set; }

        [DataMember]
        public string SistemaLegado
        { get; set; }

        [DataMember]
        public int CodigoSolicitacao
        { get; set; }

        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao
        { get; set; }
    }
}