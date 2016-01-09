using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ChangeProductOneLump
{
    //TODO Translate
    [DataContract]
    public class ChangeProductOneLumpRequest : RequestBase
    {
        #region CRM Request Parameters

        [DataMember]
        public long AccountId
        { get; set; }

        [DataMember]
        public string ProductCode

        { get; set; }

        [DataMember]
        public decimal? RatePercentage
        { get; set; }

        [DataMember]
        public string Protocol
        { get; set; }

        [DataMember]
        public int StatusReasonCode
        { get; set; }

        [DataMember]
        public Guid CommercialEstablishmentId

        { get; set; }
        
        [DataMember]
        public Guid AgentGroupId
        { get; set; }

        [DataMember]
        public int ServiceChannelCode
        { get; set; }

        [DataMember]
        public String CaseType
        { get; set; }

        [DataMember]
        public Guid ArticleSubjectId
        { get; set; }

        [DataMember]
        public Guid RequestParametrizationId
        { get; set; }

        [DataMember]
        public Guid RequestorId
        { get; set; }

        [DataMember]
        public Guid CustomerContactId

        { get; set; }

        [DataMember]
        public string AdvisorName

        { get; set; }

        [DataMember]
        public string AdvisorCode 

        { get; set; }

        [DataMember]
        public string LegacySystem
        { get; set; }

        [DataMember]
        public DateTime? CaseResolvedDate

        { get; set; }

        [DataMember]
        public int StateCode
        { get; set; }

        [DataMember]
        public string ProdutctName
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }


        [DataMember]
        public string CodeRequestLegacySystem
        { get; set; }

        [DataMember]
        public DateTime? ExpectedDateSolution

        { get; set; }

        #endregion

    }

    [DataContract]
    public class ChangeProductOneLumpResponse : ResponseBase
    {
        //Não há response para o CRM.
    }
}