using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;


namespace Cielo.Sirius.Contracts.DesabilitarProduto
{
    [DataContract]
    public class DesabilitarProdutoRequest : RequestBase
    {
        /// <summary>
        /// Protocolo do atendimento - em contexto 
        /// </summary>
        [DataMember]
        public string Protocolo { get; set; }

        /// <summary>
        /// Número do EC - em contexto
        /// </summary>
        [DataMember]
        public long CodigoCliente { get; set; }

        /// <summary>
        /// Código do produto selecionado
        /// </summary>
        [DataMember]
        public int CodigoProduto { get; set; }

        /// <summary>
        /// Nome do contato que solicita a demanda - em contexto
        /// </summary>
        [DataMember]
        public string NomeSolicitante { get; set; }

        /// <summary>
        /// "CRM"
        /// </summary>
        [DataMember]
        public string Origem { get; set; }

        /// <summary>
        /// Telefonedo contato - em contexto
        /// </summary>
        [DataMember]
        public string TelefoneSolicitante { get; set; }

        /// <summary>
        /// Código da empresa
        /// </summary>
        [DataMember]
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// Motivo da solicitação da demanda
        /// </summary>
        [DataMember]
        public string MotivoSolicitacao { get; set; }

        /// <summary>
        /// Ilha de atendimento - em contexto
        /// </summary>
        [DataMember]
        public string IlhaDeAtendimento { get; set; }

        /// <summary>
        /// ID da ocorrência de atendimento (pai)
        /// </summary>
        [DataMember]
        public string ParentCaseId { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid RequestReasonId { get; set; }

        /// <summary>
        /// References the demand that the case and request will be open for
        /// </summary>
        [DataMember]
        public Guid DemandId { get; set; }

        /// <summary>
        /// Contato que realizou o atendimento caso não seja atendimento por Canal Expresso
        /// </summary>
        [DataMember]
        public string NomeContato { get; set; }

        /// <summary>
        /// Armazenado no contexto caso seja atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string NomeAssessor { get; set; }

        /// <summary>
        /// armazenado no contexto caso seja atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string CodigoAssessor { get; set; }
    }

    [DataContract]
    public class DesabilitarProdutoResponse : ResponseBase
    {

        [DataMember]
        public string StatusRetorno
        { get; set; }

        [DataMember]
        public string SistemaLegado
        { get; set; }
        
        [DataMember]
        public DesabilitarProdutoSolicitacaoCentralAtendimentoDTO SolicitacaoCentralAtendimento
        { get; set; }

    }

    [DataContract]
    public class DesabilitarProdutoSolicitacaoCentralAtendimentoDTO: DTOBase
    {
        [DataMember]
        public string CodigoSolicitacao
        { get; set; }

        /// <summary>
        /// SLA padrão da demanda
        /// </summary>
        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao
        { get; set; }

    }
}
