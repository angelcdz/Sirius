using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.DisableTypedSale
{
    [DataContract]
    public class DisableTypedSaleRequest : RequestBase
    {
        [DataMember]
        public string CaseName
        { get; set; }

        [DataMember]
        public string CommercialEstablishmentNumber
        { get; set; }

        [DataMember]
        public string AccountID
        { get; set; }

        [DataMember]
        public string AgentGroupCode
        { get; set; }

        [DataMember]
        public string ServiceChannelCode
        { get; set; }

        [DataMember]
        public string ProcessTypeCode
        { get; set; }

        [DataMember]
        public string ArticleSubjectCode
        { get; set; }

        [DataMember]
        public string StatusReasonCode
        { get; set; }

        [DataMember]
        public string ParentCaseId
        { get; set; }
    }

    public class DisableTypedSaleResponse : ResponseBase
    {

    }
}
