using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetEligibleProductRequestTypes
{
    [DataContract]
    public class GetEligibleProductRequestTypesRequest: RequestBase
    {
        //Grupo do tipo de solicitação
        [DataMember]
        public string ProductGroup 
        { get; set; }

    }

    [DataContract]
    public class GetEligibleProductRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetEligibleProductRequestTypesDTO> ProductRequestTypes 
        { get; set; }
    }

    [DataContract]
    public class GetEligibleProductRequestTypesDTO : DTOBase
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
