using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarElegibilidadeCriacaoDemanda
{
    [DataContract]
    public class ConsultarElegibilidadeCriacaoDemandaRequest : RequestBase
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
        public long TipoDemanda
        { get; set; }
    }

    [DataContract]
    public class ConsultarElegibilidadeCriacaoDemandaResponse : ResponseBase
    {
        [DataMember]
        public bool IndicadorElegibilidade { get; set; }
    }
}
