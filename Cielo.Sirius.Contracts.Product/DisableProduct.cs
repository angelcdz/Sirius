using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.DisableProduct
{
    [DataContract]
    public class DisableProductRequest : RequestBase
    {
        /// <summary>
        /// Ilha de Atendimento
        /// </summary>
        [DataMember]
        public string AgentGroupCode { get; set; }

        /// <summary>
        /// Código do Produto
        /// </summary>
        [DataMember]
        public int ProductCode { get; set; }

        /// <summary>
        /// Razão de Status
        /// </summary>
        [DataMember]
        public int StatusReasonCode { get; set; }

        /// <summary>
        ///  ID da Ocorrência de Atendimento (pai)
        /// </summary>
        [DataMember]
        public string ParentCaseId { get; set; }

        /// <summary>
        /// Motivo da demanda selecionada
        /// </summary>
        [DataMember]
        public Guid ReasonId { get; set; }

        /// <summary>
        /// References the demand that the case and request will be open for
        /// </summary>
        [DataMember]
        public Guid DemandId { get; set; }

        /// <summary>
        /// SLA real da demanda
        /// </summary>
        [DataMember]
        public DateTime? ExpectedResolutionDate { get; set; }

        /// <summary>
        /// Operador que realizou o atendimento
        /// </summary>
        [DataMember]
        public string RequestingUser { get; set; }

        /// <summary>
        /// Contato que realizou o atendimento caso não seja atendimento por Canal Expresso
        /// </summary>
        [DataMember]
        public Guid? CustomerContactCode { get; set; }

        /// <summary>
        /// Nome do Assessor caso atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string AdvisorName { get; set; }
        
        /// <summary>
        /// Código do Assessor caso atendimento via Canal Expresso
        /// </summary>
        [DataMember]
        public string AdvisorCode { get; set; }

        /// <summary>
        /// ID da solicitação do legado
        /// </summary>
        [DataMember]
        public string RequestId { get; set; }

        /// <summary>
        /// Sistema responsável retornado pelo serviço
        /// </summary>
        [DataMember]
        public int SourceSystemCode { get; set; }

        /// <summary>
        /// Preenchido com a data atual caso o status retornado seja concluído
        /// </summary> 
        [DataMember]
        public DateTime? ResolvedDate { get; set; }

        /// <summary>
        /// Caso o status retornado seja concluído deve ser preenchido com Status Resolvido
        /// </summary>
        [DataMember]
        public int StateCode { get; set; }
    }

    [DataContract]
    public class DisableProductResponse : ResponseBase
    {

    }
}
