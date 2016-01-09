using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;

namespace Cielo.Sirius.Contracts.CreateCaseProductSegmentedInstallments
{
    [DataContract]
    public class CreateCaseProductSegmentedInstallmentsRequest : RequestBase
    {
        [DataMember]
        public EntityReference ArticleCode { get; set; }

        [DataMember]
        public OptionSetValue ServiceChannelCode { get; set; }

        [DataMember]
        public EntityReference AccountID { get; set; }

        [DataMember]
        public bool ConferenceCallIndicator { get; set; }

        [DataMember]
        public EntityReference CustomerContactCode { get; set; }

        [DataMember]
        public EntityReference AgentGroupCode { get; set; }

        [DataMember]
        public Guid CaseID { get; set; }

        [DataMember]
        public EntityReference ParentCaseID { get; set; }

        [DataMember]
        public EntityReference ReferenceCaseCode { get; set; }

        [DataMember]
        public OptionSetValue StatusReasonCode { get; set; }

        [DataMember]
        public OptionSetValue StateCode { get; set; }

        [DataMember]
        public EntityReference PhoneCallOriginatorCode { get; set; }

        [DataMember]
        public EntityReference ArticleSubjectCode { get; set; }

        [DataMember]
        public bool CallTransferIndicator { get; set; }

        [DataMember]
        public EntityReference RequestingUserCode { get; set; }

        [DataMember]
        public DateTime CaseResolvedDate { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public string RequestDescription { get; set; }

        [DataMember]
        public bool RecurrenceIndicator { get; set; }

        [DataMember]
        public string CaseName { get; set; }

        [DataMember]
        public EntityReference CommercialEstablishmentNumber { get; set; }

        [DataMember]
        public string ECDayZeroNumber { get; set; }

        [DataMember]
        public string ServiceCallNumber { get; set; }

        [DataMember]
        public decimal CaseSLANumber { get; set; }

        [DataMember]
        public OptionSetValue ProcessTypeCode { get; set; }

        [DataMember]
        public int OperationTime { get; set; }

        [DataMember]
        public EntityReference ReasonRequestCode { get; set; }
    }

    [DataContract]
    public class CreateCaseProductSegmentedInstallmentsResponse : ResponseBase
    {
        [DataMember]
        public int ReturnCode
        { get; set; }

        [DataMember]
        public string ReturnMessage
        { get; set; }
    }
}
