using System;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cielo.Sirius.Contracts.GetNegotiationData
{
    [DataContract]
    public class GetNegotiationDataRequest : RequestBase 
    {
        /// <summary>
        /// Código do Cliente (Customer EC Number)
        /// </summary>
        [DataMember]
        public Guid ECNumber
        { get; set; }

        /// <summary>
        /// Ilha de Atendimento
        /// </summary>
        [DataMember]
        public string AgentGroupCode
        { get; set; }

        /// <summary>
        /// Id da demanda
        /// </summary>
        [DataMember]
        public Guid DemandId
        { get; set; }
    }

    [DataContract]
    public class GetNegotiationDataResponse : ResponseBase
    {
        [DataMember]
        public bool DoOffersExist { get; set; }

        [DataMember]
        public List<GetNegotiationDataReasonsDTO> Reasons { get; set; }

        [DataMember]
        public List<GetNegotiationDataDealItemsDTO> DealItems { get; set; }

        [DataMember]
        public List<GetNegotiationDataCompetitorsDTO> Competitors { get; set; }
    }

    [DataContract]
    public class GetNegotiationDataReasonsDTO
    {
        [DataMember]
        public string ReasonName { get; set; }

        [DataMember]
        public Guid ReasonId { get; set; }
    }

    [DataContract]
    public class GetNegotiationDataDealItemsDTO
    {
        [DataMember]
        public string DealItemName { get; set; }

        [DataMember]
        public Guid DealItemId { get; set; }
    }

    [DataContract]
    public class GetNegotiationDataCompetitorsDTO
    {
        [DataMember]
        public string CompetitorName { get; set; }

        [DataMember]
        public Guid CompetitorId { get; set; }
    }
}
