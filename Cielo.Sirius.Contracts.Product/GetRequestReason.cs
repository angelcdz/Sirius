using System;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cielo.Sirius.Contracts.GetRequestReason
{
    [DataContract]
    public class GetRequestReasonRequest : RequestBase
    {
        /// <summary>
        /// Id da solicitação
        /// </summary>
        [DataMember]
        public Guid DemandId
        { get; set; }

    }

    [DataContract]
    public class GetRequestReasonResponse : ResponseBase
    {
        /// <summary>
        /// Lista de motivos para a demanda
        /// </summary>
        [DataMember]
        public List<GetRequestReasonDTO> Reasons
        { get; set; }


    }

    [DataContract]
    public class GetRequestReasonDTO : DTOBase
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
