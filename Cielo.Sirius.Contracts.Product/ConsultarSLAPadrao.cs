using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarSLAPadrao
{
    [DataContract]
    public class ConsultarSLAPadraoRequest : RequestBase
    {
        /// <summary>
        /// Código do Cliente (Customer EC Number)
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

        /// <summary>
        /// Código da Demanda (Request Type Code)
        /// </summary>
        [DataMember]
        public int TipoDemanda
        { get; set; }
    }

    [DataContract]
    public class ConsultarSLAPadraoResponse : ResponseBase
    {
        [DataMember]
        public DateTime? DataSLA
        { get; set; }
    }
}
