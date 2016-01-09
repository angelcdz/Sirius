using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.CommercialNegotiation
{
    [DataContract]
    public class CommercialNegotiationRequest : RequestBase
    {
        #region Case Atribs
        [DataMember]
        public string Protocol { get; set; }
        [DataMember]
        public long ECNumber { get; set; }
        [DataMember]
        public Guid Customer { get; set; }
        [DataMember]
        public Guid AgentGroup { get; set; }
        [DataMember]
        public string ContactChannel { get; set; }
        //UserId
        [DataMember]
        public Guid Contact { get; set; }
        [DataMember]
        public string AdvisorName { get; set; }
        [DataMember]
        public string AdvisorCode { get; set; }
        #endregion

        #region Request Atribs
        [DataMember]
        public Guid DealItem { get; set; }
        [DataMember]
        public Guid Competitor { get; set; }
        [DataMember]
        public string CompetitorValue { get; set; }
        [DataMember]
        public string Description { get; set; }
        #endregion

        #region Both Atribs
        [DataMember]
        public Guid RequestReason { get; set; }
        [DataMember]
        public Guid RequestParameterization { get; set; }
        [DataMember]
        public DateTime? ServiceExpectedDate { get; set; }
        [DataMember]
        public long OSBDemandId { get; set; }
        #endregion
    }

    [DataContract]
    public class CommercialNegotiationResponse : ResponseBase { }
}
