using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.Products
{
    [DataContract]
    public class GetNonEnabledServiceRequestTypesRequest : RequestBase
    {
        /// <summary>
        /// Grupo do tipo de solicitação
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
    public class GetNonEnabledServiceRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetNonEnabledServiceRequestTypesDTO> ServiceRequestTypes
        { get; set; }
    }

    [DataContract]
    public class GetNonEnabledServiceRequestTypesDTO : DTOBase
    {
        /// <summary>
        /// Guid (CRM)
        /// </summary>
        [DataMember]
        public Guid Id
        { get; set; }

        /// <summary>
        /// Nome (de exibição)
        /// </summary>
        [DataMember]
        public string Name
        { get; set; }

        /// <summary>
        /// Codigo da integração
        /// </summary>
        [DataMember]
        public int IntegrationRequestCode
        { get; set; }
    }
}
