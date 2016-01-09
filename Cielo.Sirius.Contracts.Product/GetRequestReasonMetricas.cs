using System;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cielo.Sirius.Contracts.GetRequestReasonMetricas
{
    [DataContract]
    public class GetRequestReasonMetricasRequest : RequestBase
    {
        /// <summary>
        /// Id da demanda
        /// </summary>
        [DataMember]
        public Guid DemandId
        { get; set; }

    }

    [DataContract]
    public class GetRequestReasonMetricasResponse : ResponseBase
    {
        /// <summary>
        /// Lista de motivos para a demanda
        /// </summary>
        [DataMember]
        public List<GetRequestReasonMetricasDTO> Reasons
        { get; set; }


    }

    [DataContract]
    public class GetRequestReasonMetricasDTO : DTOBase
    {
        /// <summary>
        /// Id do registro do motivo
        /// </summary>
        [DataMember]
        public Guid ReasonId
        { get; set; }

        /// <summary>
        /// Nome do motivo
        /// </summary>
        [DataMember]
        public string ReasonName
        { get; set; }
    }
}
