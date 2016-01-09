using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetDiscountRateRestriction
{
    [DataContract]
    public class GetDiscountRateRestrictionRequest : RequestBase
    {
        [DataMember]
        public decimal DefaultRate
        { get; set; }

        [DataMember]
        public string AgentGroupCode
        { get; set; }

        [DataMember]
        public string BranchActivityCode
        { get; set; }

        [DataMember]
        public string ProductCode
        { get; set; }
    }

    [DataContract]
    public class GetDiscountRateRestrictionResponse : ResponseBase
    {
        [DataMember]
        public decimal DiscountRateRestrictionPercentage
        { get; set; }

        [DataMember]
        public decimal MinDiscountRateRestrictionPercentage
        { get; set; }

        [DataMember]
        public decimal MaxDiscountRateRestrictionPercentage
        { get; set; }
    }
}
