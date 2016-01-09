using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ManterPrazoFlexivel
{
    [DataContract]
    public class ManterPrazoFlexivelRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string IndicaOperacao
        { get; set; }

        [DataMember]
        public string CodigoGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public string QuantidadeDiasGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public double? PercentualTaxaGrupoPrazoFlexivel
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }
    }

    [DataContract]
    public class ManterPrazoFlexivelResponse : ResponseBase
    {
    }
}
