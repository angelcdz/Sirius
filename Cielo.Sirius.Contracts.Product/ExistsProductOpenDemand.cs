using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ExistsProductOpenDemand
{
    [DataContract]
    public class ExistsProductOpenDemandRequest : RequestBase
    {
        public ExistsProductOpenDemandRequest()
        {
            this.CodigoProdutos = new List<string>();
        }

        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public List<string> CodigoProdutos
        { get; private set; }
    }

    [DataContract]
    public class ExistsProductOpenDemandResponse : ResponseBase
    {
        public ExistsProductOpenDemandResponse()
        {
            this.ExistsProductOpenRequests = new List<ExistsProductOpenDemandDTO>();
        }

        [DataMember]
        public List<ExistsProductOpenDemandDTO> ExistsProductOpenRequests
        { get; private set; }
    }

    [DataContract]
    public class ExistsProductOpenDemandDTO : DTOBase
    {
        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }
    }
}
