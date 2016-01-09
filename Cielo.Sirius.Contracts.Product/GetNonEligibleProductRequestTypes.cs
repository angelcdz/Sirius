using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes
{
    [DataContract]
    public class GetNonEligibleProductRequestTypesRequest: RequestBase
    {
        //Grupo do tipo de solicitação
        [DataMember]
        public string ProductGroup 
        { get; set; }

    }

    [DataContract]
    public class GetNonEligibleProductRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetNonEligibleProductRequestTypesDTO> ProductRequestTypes 
        { get; set; }
    }

    [DataContract]
    public class GetNonEligibleProductRequestTypesDTO : DTOBase
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
