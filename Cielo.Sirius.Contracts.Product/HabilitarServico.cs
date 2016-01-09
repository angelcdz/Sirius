using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.HabilitarServico
{

    [DataContract]
    public class HabilitarServicoRequest : RequestBase
    {
        /// <summary>
        /// Código do Cliente (Número de EC)
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

        /// <summary>
        /// Código do Serviço
        /// </summary>
        [DataMember]
        public String CodigoServico
        { get; set; }

        /// <summary>
        /// Protocolo + Contador de Ocorrências 
        /// </summary>
        [DataMember]
        public String TituloOcorrencia
        { get; set; }

        /// <summary>
        /// Número do cliente (account)
        /// </summary>
        [DataMember]
        public string Cliente
        { get; set; }

        /// <summary>
        /// Ilha de Atendimento armazenada no contexto da Customer Session atual
        /// </summary>
        [DataMember]
        public String IlhaDeAtendimento
        { get; set; }

        /// <summary>
        /// Canal de Atendimento 
        /// </summary>
        [DataMember]
        public String CanalDeAtendimento
        { get; set; }

        /// <summary>
        /// Tipo de Processo de Atendimento
        /// </summary>
        [DataMember]
        public String CaseType
        { get; set; }

        /// <summary>
        /// Tipo de Solicitação
        /// </summary>
        [DataMember]
        public String ArvoreAssunto
        { get; set; }

        /// <summary>
        /// ID da Ocorrência de Atendimento
        /// </summary>
        [DataMember]
        public string ParentCaseId
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }

        /// <summary>
        /// References the demand that the case and request will be open for
        /// </summary>
        [DataMember]
        public Guid IdDemanda
        { get; set; }

        ///// <summary>
        /////  Protocol information from the Customer Session.[Número do Protocolo]
        ///// </summary>
        [DataMember]
        public string Protocolo
        { get; set; }

        ///// <summary>
        /////   identifies the requesting system, in this case Dynamics CRM (CRM)
        ///// </summary>
        [DataMember]
        public string Origem
        { get; set; }


    }

    [DataContract]
    public class HabilitarServicoResponse : ResponseBase
    {

        //    /// <summary>
        //    /// References to return code, where "0" means "success" and not "0" means "error". Refer descricaoRetornoMensagem for details. 
        //    /// </summary>
        //    [DataMember]
        //    public int CodigoRetorno { get; set; }

        //    /// <summary>
        //    /// References the message returned 
        //    /// </summary>
        //    [DataMember]
        //    public string DescricaoRetornoMensagem { get; set; }

        //    /// <summary>
        //    /// Request Status Code 
        //    /// </summary>
        //    [DataMember]
        //    public string StatusRetorno { get; set; }

        //    /// <summary>
        //    /// References to the abbreviation of responsible system (owner)
        //    /// </summary>
        //    [DataMember]
        //    public string SistemaLegado { get; set; }

        //    /// <summary>
        //    /// Customer requests that were made through the call center
        //    /// </summary>
        //    [DataMember]
        //    public SolicitacaoCentralAtendimento SolicitacaoCentralAtendimento { get; set; }

        //}

        //[DataContract]
        //public class SolicitacaoCentralAtendimento : DTOBase
        //{

        //    /// <summary>
        //    /// Code that uniquely identifies one solicitation. 
        //    /// </summary>
        //    [DataMember]
        //    public int CodigoSolicitacao
        //    { get; set; }

        /// <summary>
        /// Scheduled date for the solicitation be completed.
        /// </summary>
        [DataMember]
        public DateTime DataSLA
        { get; set; }

        /// <summary>
        /// Status retornado pelo OSB
        /// </summary>
        [DataMember]
        public string StatusRetorno
        { get; set; }

        /// <summary>
        /// Sigla Sistema responsável
        /// </summary>
        [DataMember]
        public string SistemaLegado { get; set; }

        /// <summary>
        /// Código Solicitação Sistema Legado
        /// </summary> 
        [DataMember]
        public string CodigoSolicitacao { get; set; }
    }


}
