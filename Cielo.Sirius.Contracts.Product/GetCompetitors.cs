using System;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cielo.Sirius.Contracts.GetCompetitors
{
    [DataContract]
    public class GetCompetitorsRequest : RequestBase { }

    [DataContract]
    public class GetCompetitorsResponse : ResponseBase
    {
        /// <summary>
        /// Lista de concorrentes
        /// </summary>
        [DataMember]
        public List<GetCompetitorsDTO> Competitors
        { get; set; }


    }

    [DataContract]
    public class GetCompetitorsDTO : DTOBase
    {
        /// <summary>
        /// Id do registro do concorrente
        /// </summary>
        [DataMember]
        public Guid CompetitorId { get; set; }

        /// <summary>
        /// Nome do concorrente
        /// </summary>
        [DataMember]
        public string CompetitorName { get; set; }
    }
}
