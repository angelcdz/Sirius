using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.DisableService
{
    [DataContract]
    public class EnableServiceOrderRequest : RequestBase
    {
        public string TituloDaOcorrencia
        { get; set; }

        public string EstabelecimentoComercial
        { get; set; }

        public string Cliente
        { get; set; }

        public string IlhaDeAtendimento
        { get; set; }

        public string CanalDeAtendimento
        { get; set; }

        public string CaseType
        { get; set; }

        public string ArvoreDeAssunto
        { get; set; }

        public string RazaoStatus
        { get; set; }

        /// <summary>
        /// Represents the selected reason for each demand type
        /// </summary>
        [DataMember]
        public Guid ReasonId
        { get; set; }
    }

    public class EnableServiceOrderResponse : ResponseBase
    {

    }
}
