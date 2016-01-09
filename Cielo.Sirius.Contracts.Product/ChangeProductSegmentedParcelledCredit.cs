using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ChangeProductSegmentedParcelledCredit
{
    //TODO Translate
    [DataContract]
    public class ChangeProductSegmentedParcelledCreditRequest : RequestBase
    {
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

        [DataMember]
        public ChangeProductSegmentedParcelledCreditRangeDTO Rates
        { get; set; }
    }

    [DataContract]
    public class ChangeProductSegmentedParcelledCreditResponse : ResponseBase
    { }

    [DataContract]
    public class ChangeProductSegmentedParcelledCreditRangeDTO : DTOBase
    {
        //Taxas: código da faixa
        [DataMember]
        public string RangeCode
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor inicial da Faixa
        [DataMember]
        public string RangeInitialParcelNumber
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor final da Faixa
        [DataMember]
        public string RangeLastParcelNumber
        { get; set; }

        //Taxas: Taxa Padrão
        [DataMember]
        public decimal DefaultRatePercentage
        { get; set; }

        //Taxas: Taxa Matriz
        public double? ParentRate
        { get; set; }

        [DataMember]
        public decimal DiscountRateRestrictionPercentage
        { get; set; }

        [DataMember]
        public decimal MinDiscountRateRestrictionPercentage
        { get; set; }

        [DataMember]
        public decimal MaxDiscountRateRestrictionPercentage
        { get; set; }
    }
}
