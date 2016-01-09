using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.GetEnabledServiceRequestTypes
{
    [DataContract]
    public class GetEnabledServiceRequestTypesRequest : RequestBase
    {
        /// <summary>
        /// Request Type Group
        /// </summary>
        [DataMember]
        public string ServiceGroup
        { get; set; }

        /// <summary>
        /// Service Name
        /// </summary>
        [DataMember]
        public string ServiceName
        { get; set; }
    }
    
    [DataContract]
    public class GetEnabledServiceRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetEnabledServiceRequestTypesDTO> ServiceRequestTypes
        { get; set; }
    }

    [DataContract]
    public class GetEnabledServiceRequestTypesDTO : DTOBase
    {
        /// <summary>
        /// Guid (CRM)
        /// </summary>
        [DataMember]
        public Guid Id
        { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name
        { get; set; }

        /// <summary>
        /// Integration Code
        /// </summary>
        [DataMember]
        public int IntegrationRequestCode
        { get; set; }
    }
}
