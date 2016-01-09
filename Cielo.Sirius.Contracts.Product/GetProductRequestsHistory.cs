using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.GetProductRequestsHistory
{
    [DataContract]
    public class GetProductRequestsHistoryRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }
    }

    [DataContract]
    public class GetProductRequestsHistoryResponse : ResponseBase
    {
        [DataMember]
        public List<GetProductRequestsHistoryDTO> ProductRequests
        { get; set; }
    }

    [DataContract]
    public class GetProductRequestsHistoryDTO : DTOBase
    {
        /// <summary>
        /// Column: Protocolo
        /// </summary>
        [DataMember]
        public string ServiceCallNumber
        { get; set; }

        /// <summary>
        /// Column: Descrição
        /// </summary>
        [DataMember]
        public string ProductRequestName
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
