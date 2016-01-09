using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa
{
    [DataContract]
    public class SolicitarNegociacaoTaxaRequest : RequestBase
    {
        /// <summary>
        /// Titulo da Ocorrencia
        /// </summary>
        [DataMember]
        public string TituloDaOcorrencia
        { get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public string Cliente
        { get; set; }

        /// <summary>
        /// Ilha de atendimento
        /// </summary>
        [DataMember]
        public string IlhaDeAtendimento
        { get; set; }

        /// <summary>
        /// Canal de atendimento
        /// </summary>
        [DataMember]
        public string CanalDeAtendimento
        { get; set; }

        /// <summary>
        /// Tipo de solicitacao
        /// </summary>
        [DataMember]
        public string CaseType
        { get; set; }

        /// <summary>
        /// Arvore de assunto
        /// </summary>
        [DataMember]
        public string ArvoreDeAssunto
        { get; set; }

        /// <summary>
        /// ParentCaseID
        /// </summary>
        [DataMember]
        public string ParentCaseId
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Protocolo 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public long CodigoCliente 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoProduto 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NomeContato 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal PercentualTaxaPropostaConcorrente 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CelularContato 
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TelefoneContato
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

        /// <summary>
        /// Operador que realizou o atendimento
        /// </summary>
        [DataMember]
        public string UsuarioSolicitante
        { get; set; }

        /// <summary>
        /// Armazenado no contexto caso seja atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string NomeAssessor
        { get; set; }

        /// <summary>
        /// armazenado no contexto caso seja atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string CodigoAssessor 
        { get; set; }
   



    }

    [DataContract]
    public class SolicitarNegociacaoTaxaResponse : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string StatusRetorno
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SistemaLegado
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoSolicitacao
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao 
        { get; set; }
    }
}
