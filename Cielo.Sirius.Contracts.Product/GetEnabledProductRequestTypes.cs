using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.GetEnabledProductRequestTypes
{
    [DataContract]
    public class GetEnabledProductRequestTypesRequest : RequestBase
    {
        [DataMember]
        public string ProductGroup
        { get; set; }

        [DataMember]
        public bool? EnabledTypedSaleIndicator
        { get; set; }

        [DataMember]
        public double? FlexibleMaturityRate
        { get; set; }

        [DataMember]
        public long ECNumber
        { get; set; }
    }

    [DataContract]
    public class GetEnabledProductRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetEnabledProductRequestTypesDTO> ProductRequestTypes
        { get; set; }

        // MCC
        [DataMember]
        public string BranchOfActivityCode
        { get; set; }

        // MEI
        [DataMember]
        public bool MEIIndicator
        { get; set; }
    }

    [DataContract]
    public class GetEnabledProductRequestTypesDTO : DTOBase
    {
        [DataMember]
        public Guid Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public int IntegrationRequestCode
        { get; set; }
    }
}
