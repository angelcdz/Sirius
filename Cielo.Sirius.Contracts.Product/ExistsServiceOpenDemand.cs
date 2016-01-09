using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ExistsServiceOpenDemand
{
    [DataContract]
    public class ExistsServiceOpenDemandRequest : RequestBase
    {
        public ExistsServiceOpenDemandRequest()
        {
            this.CodigoServicos = new List<string>();
        }

        /// <summary>
        /// Código do cliente
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

        /// <summary>
        /// Lista com os codigos dos servicos a serem verificados
        /// </summary>
        [DataMember]
        public List<string> CodigoServicos
        { get; set; }
    }

    [DataContract]
    public class ExistsServiceOpenDemandResponse : ResponseBase
    {
        public ExistsServiceOpenDemandResponse()
        {
            this.ExistsServiceOpenRequests = new List<ExistsServiceOpenDemandDTO>();
        }

        /// <summary>
        /// Lista com os codigos dos servicos verificados
        /// </summary>
        [DataMember]
        public List<ExistsServiceOpenDemandDTO> ExistsServiceOpenRequests
        { get; private set; }
    }

    [DataContract]
    public class ExistsServiceOpenDemandDTO : DTOBase
    {
        /// <summary>
        /// Codigo do servico
        /// </summary>
        [DataMember]
        public string CodigoServico
        { get; set; }

        /// <summary>
        /// Indicador se existe ou nao demandas abertas para o servico
        /// </summary>
        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }
    }
}
