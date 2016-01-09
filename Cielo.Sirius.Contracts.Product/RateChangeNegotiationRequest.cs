using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.RateChangeNegotiationRequest
{
    [DataContract]
    public class RateChangeNegotiationRequestRequest : RequestBase
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
        public long? CommercialEstablishmentNumber
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
        /// Tipo de Processo de Atendimento
        /// </summary>
        [DataMember]
        public string ProcessTypeCode
        { get; set; }

        /// <summary>
        /// Árvore de assunto - Tipo de Solicitação
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
        ///  ID da Ocorrência de Atendimento
        /// </summary>
        [DataMember]
        public string ParentCaseId
        { get; set; }

        /// <summary>
        /// Motivo da demanda selecionada
        /// </summary>
        [DataMember]
        public Guid ReasonId
        { get; set; }

        /// <summary>
        /// References the demand that the case and request will be open for
        /// </summary>
        [DataMember]
        public Guid DemandId
        { get; set; }

        /// <summary>
        /// SLA real da demanda
        /// </summary>
        [DataMember]
        public DateTime? ExpectedConclusionDate { get; set; }

        /// <summary>
        /// Protocolo do atendimento
        /// </summary>
        [DataMember]
        public string Protocol { get; set; }

        /// <summary>
        /// Operador que realizou o atendimento
        /// </summary>
        [DataMember]
        public string RequesterUser { get; set; }

        /// <summary>
        /// Contato que realizou o atendimento caso não seja atendimento por Canal Expresso
        /// </summary>
        [DataMember]
        public string RequesterContact { get; set; }

        /// <summary>
        /// Nome do Assessor caso atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string AssessorName { get; set; }

        /// <summary>
        /// Código do Assessor caso atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string AssessorCode { get; set; }

        /// <summary>
        /// Sistema responsável retornado pelo serviço
        /// </summary>
        [DataMember]
        public string ResponsibleSystem { get; set; }

        /// <summary>
        /// Preenchido com a data atual caso o status retornado seja concluído
        /// </summary> 
        [DataMember]
        public DateTime ConclusionDate { get; set; }

        /// <summary>
        /// Caso o status retornado seja concluído deve ser preenchido com Status Resolvido
        /// </summary>
        [DataMember]
        public string StateCode { get; set; }

        /// <summary>
        /// Código do produto selecionado
        /// </summary>
        [DataMember]
        public string ProductCode { get; set; }

        /// <summary>
        /// Taxa informada pelo Operador na abertura da solicitação
        /// </summary>
        [DataMember]
        public decimal RateChangeRequest { get; set; }



    }

    [DataContract]
    public class RateChangeNegotiationRequestResponse : ResponseBase
    {
       
    }
}
