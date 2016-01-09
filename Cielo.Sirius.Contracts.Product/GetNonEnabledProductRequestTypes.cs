using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetNonEnabledProductRequestTypes
{
    [DataContract]
    public class GetNonEnabledProductRequestTypesRequest : RequestBase
    {
        //Grupo do tipo de solicitação
        [DataMember]
        public string ProductGroup 
        { get; set; }

    }

    [DataContract]
    public class GetNonEnabledProductRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetNonEnabledProductRequestTypesDTO> ProductRequestTypes 
        { get; set; }
    }

    [DataContract]
    public class GetNonEnabledProductRequestTypesDTO : DTOBase
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
