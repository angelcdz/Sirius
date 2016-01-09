using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarPrazoPadrao
{
    [DataContract]
    public class ConsultarPrazoPadraoRequest : RequestBase
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

        /// <summary>
        /// Código do Produto (Product Identifier)
        /// </summary>
        [DataMember]
        public string SubTipoDemanda
        { get; set; }
    }

    [DataContract]
    public class ConsultarPrazoPadraoResponse : ResponseBase
    {
        [DataMember]
        public DateTime DataSLA
        { get; set; }
    }
}
