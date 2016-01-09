using System;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Cielo.Sirius.Contracts.GetNegotiationData;

namespace Cielo.Sirius.Contracts.ConsultarDadosNegociacao
{
    [DataContract]
    public class ConsultarDadosNegociacaoRequest : RequestBase 
    {
        /// <summary>
        /// Código do Cliente (Customer EC Number)
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

        /// <summary>
        /// Código da Demanda (Request Type Code)
        /// </summary>
        [DataMember]
        public int TipoDemanda
        { get; set; }

        /// <summary>
        /// Id da demanda
        /// </summary>
        [DataMember]
        public Guid DemandId
        { get; set; }

        /// <summary>
        /// Ilha de Atendimento
        /// </summary>
        [DataMember]
        public string IlhaAtendimento
        { get; set; }

        /// <summary>
        /// EC Number (CRM)
        /// </summary>
        [DataMember]
        public Guid ECNumber
        { get; set; }
    }

    [DataContract]
    public class ConsultarDadosNegociacaoResponse : ResponseBase
    {
        [DataMember]
        public DateTime? DataPrevistaRetorno { get; set; }

        [DataMember]
        public bool IndicadorElegibilidade { get; set; }

        [DataMember]
        public DateTime? DataSLA { get; set; }

        [DataMember]
        public GetNegotiationDataResponse DadosCRM { get; set; }
    }
}
