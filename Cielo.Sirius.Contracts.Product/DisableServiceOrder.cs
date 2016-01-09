using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.DisableServiceOrder
{
    [DataContract]
    public class DisableServiceOrderRequest : RequestBase
    {
        /// <summary>
        /// Título da ocorrência: Protocolo + Contador de Ocorrências 
        /// </summary>
        [DataMember]
        public string CaseName
        { get; set; }

        /// <summary>
        ///Número do Estabelecimento Comercial
        /// </summary>
        [DataMember]
        public string CommercialEstablishmentNumber
        { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public string AccountID
        { get; set; }

        /// <summary>
        /// Ilha de Atendimento
        /// </summary>
        [DataMember]
        public string AgentGroupCode
        { get; set; }

        /// <summary>
        /// Canal de Atendimento
        /// </summary>
        [DataMember]
        public string ServiceChannelCode
        { get; set; }

        /// <summary>
        /// CaseType
        /// </summary>
        [DataMember]
        public string CaseType
        { get; set; }

        /// <summary>
        /// Tipo de Solicitação
        /// </summary>
        [DataMember]
        public string ArticleSubjectCode
        { get; set; }

        /// <summary>
        /// Razão de Status
        /// </summary>
        [DataMember]
        public int StatusReasonCode
        { get; set; }

        /// <summary>
        /// Tipo de Processo de Atendimento
        /// </summary>
        [DataMember]
        public string ProcessTypeCode
        { get; set; }

        /// <summary>
        ///  ID da Ocorrência de Atendimento
        /// </summary>
        [DataMember]
        public string ParentCaseId
        { get; set; }
    }

    public class DisableServiceOrderResponse : ResponseBase
    {

    }
}
