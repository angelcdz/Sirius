using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetCommercialEstablishmentInformation
{
    [DataContract]
    public class GetCommercialEstablishmentInformationRequest : RequestBase
    {
        /// <summary>
        /// Commercial Establishment.
        /// </summary>
        [DataMember]
        public long CommercialEstablishmentNumber
        { get; set; }
    }

    [DataContract]
    public class GetCommercialEstablishmentInformationResponse : ResponseBase
    {
        /// <summary>
        /// Branch of Activity code.
        /// </summary>
        [DataMember]
        public string BranchOfActivityCode
        { get; set; }

        /// <summary>
        /// MEI Indicator flag.
        /// </summary>
        [DataMember]
        public bool? MEIIndicator
        { get; set; }

        /// <summary>
        /// Membership date.
        /// </summary>
        [DataMember]
        public DateTime MembershipDate
        { get; set; }
    }
}
