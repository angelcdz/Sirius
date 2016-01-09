using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.NegociacaoComercial
{
    [DataContract]
    public class NegociacaoComercialRequest : RequestBase
    {
        #region OSB
        [DataMember]
        public int CodigoEvento { get; set; }
        [DataMember]
        public int Dependencia { get; set; }
        [DataMember]
        public string Linha1 { get; set; }
        [DataMember]
        public string Linha2 { get; set; }
        [DataMember]
        public string Linha3 { get; set; }
        [DataMember]
        public string Linha4 { get; set; }
        [DataMember]
        public string Linha5 { get; set; }
        [DataMember]
        public string Linha6 { get; set; }
        #endregion

        #region Case Atribs
        [DataMember]
        public string Protocolo { get; set; }
        [DataMember]
        public long NumeroEC { get; set; } // Tbm usado no OSB
        [DataMember]
        public Guid Cliente { get; set; }
        [DataMember]
        public Guid IlhaAtendimento { get; set; }
        [DataMember]
        public string CanalAtendimento { get; set; } // Tbm usado no OSB
        //UserId
        [DataMember]
        public Guid Contato { get; set; }
        [DataMember]
        public string NomeAssessor { get; set; }
        [DataMember]
        public string CodigoAssessor { get; set; }
        #endregion

        #region Request Atribs
        [DataMember]
        public Guid ItemNegociacao { get; set; }
        [DataMember]
        public Guid Concorrente { get; set; }
        [DataMember]
        public string ValorConcorrente { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        #endregion

        #region Both Atribs
        [DataMember]
        public Guid Motivo { get; set; }
        [DataMember]
        public Guid Demanda { get; set; }
        [DataMember]
        public DateTime? DataPrevistaSolicitacao { get; set; }
        #endregion
    }

    [DataContract]
    public class NegociacaoComercialResponse : ResponseBase
    {
        [DataMember]
        public long IdDemandaOSB { get; set; }
    }
}
