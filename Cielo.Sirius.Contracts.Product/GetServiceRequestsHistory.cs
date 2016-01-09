using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.GetServiceRequestsHistory
{
        [DataContract]
        public class GetServiceRequestsHistoryRequest : RequestBase
        {
            [DataMember]
            public long CodigoCliente
            { get; set; }

            [DataMember]
            public string CodigoServico
            { get; set; }
        }

        [DataContract]
        public class GetServiceRequestsHistoryResponse : ResponseBase
        {
            [DataMember]
            public List<GetServiceRequestsHistoryDTO> ServiceRequests
            { get; set; }
        }

        [DataContract]
        public class GetServiceRequestsHistoryDTO : DTOBase
        {
            /// <summary>
            /// Column: Protocolo
            /// </summary>
            [DataMember]
            public string CaseTitle
            { get; set; }

            /// <summary>
            /// Column: Descrição
            /// </summary>
            [DataMember]
            public string ServiceRequestName
            { get; set; }

            /// <summary>
            /// Column: Abertura
            /// </summary>
            [DataMember]
            public DateTime CreatedOn
            { get; set; }

            /// <summary>
            /// Column: Solução
            /// </summary>
            [DataMember]
            public DateTime ClosedOn
            { get; set; }
        
    }
}
