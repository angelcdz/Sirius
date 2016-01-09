using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;

namespace Cielo.Sirius.Contracts.ProductRequestSegmentedInstallments
{
    [DataContract]
    public class ProductRequestSegmentedInstallmentsRequest : RequestBase
    {
        [DataMember]
        public Guid ProductRequestCode { get; set; }

        [DataMember]
        public string CodeChainType { get; set; }

        [DataMember]
        public OptionSetValue CodeTypeCollection { get; set; }

        [DataMember]
        public EntityReference ArticleSubjectCode { get; set; }

        [DataMember]
        public EntityReference BrandCode { get; set; }

        [DataMember]
        public string CodeCompany { get; set; }

        [DataMember]
        public string ProductGroupCode { get; set; }

        [DataMember]
        public EntityReference BranchActivityCode { get; set; }

        [DataMember]
        public EntityReference CaseId { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public OptionSetValue StatusReasonCode { get; set; }

        [DataMember]
        public string ProductRequestLegacyCode { get; set; }

        [DataMember]
        public OptionSetValue RequestStatusCode { get; set; }

        [DataMember]
        public DateTime EffectiveEndDate { get; set; }

        [DataMember]
        public DateTime DateProductEnable { get; set; }

        [DataMember]
        public DateTime EffectiveDateHome { get; set; }

        [DataMember]
        public DateTime ScheduledDataSolution { get; set; }

        [DataMember]
        public string DescriptionMessageReturnLegacy { get; set; }

        [DataMember]
        public bool IndicatorTransactionLastMonth { get; set; }

        [DataMember]
        public string NameCompany { get; set; }

        [DataMember]
        public string ProductGroupName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductRequestName { get; set; }

        [DataMember]
        public string NumberClientCompany { get; set; }

        [DataMember]
        public decimal PercentageDiscount { get; set; }

        [DataMember]
        public decimal PercentageRateItem { get; set; }

        [DataMember]
        public decimal ContractedRatePercentage { get; set; }

        [DataMember]
        public decimal MatrixRatePercentage { get; set; }

        [DataMember]
        public decimal MaximumRatePercentage { get; set; }

        [DataMember]
        public decimal PercentageRateMEI { get; set; }

        [DataMember]
        public decimal LeastRatePercentage { get; set; }

        [DataMember]
        public decimal FlexibleTermRatePercentage { get; set; }

        [DataMember]
        public decimal PercentageRateTable { get; set; }

        [DataMember]
        public int NumberDaysFlexibleTermReceipt { get; set; }

        [DataMember]
        public int NumberDaysProductPayment { get; set; }

        [DataMember]
        public int QuantityMaximaPlot { get; set; }

        [DataMember]
        public int ParcelQuantity { get; set; }

        [DataMember]
        public decimal CurrentRevenueAccumulatedValue { get; set; }

        [DataMember]
        public decimal CompetingValueProposal { get; set; }

        [DataMember]
        public bool TypedSaleIndicator { get; set; }

        /// <summary>
        /// Represents the selected reason for each demand type
        /// </summary>
        [DataMember]
        public Guid ReasonId
        { get; set; }
    }

    [DataContract]
    public class ProductRequestSegmentedInstallmentsResponse : ResponseBase
    {
        [DataMember]
        public int ReturnCode
        { get; set; }

        [DataMember]
        public string ReturnMessage
        { get; set; }
    }
}
