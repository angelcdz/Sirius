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
    public class GetNonEligibleServiceRequestTypesRequest : RequestBase
    {
        /// <summary>
        /// Grupo do tipo de solicitação
        /// </summary>
        [DataMember]
        public string ServiceGroup
        { get; set; }

    }

    [DataContract]
    public class GetNonEligibleServiceRequestTypesResponse : ResponseBase
    {
        [DataMember]
        public List<GetNonEligibleServiceRequestTypesDTO> ServiceRequestTypes
        { get; set; }
    }

    [DataContract]
    public class GetNonEligibleServiceRequestTypesDTO : DTOBase
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
