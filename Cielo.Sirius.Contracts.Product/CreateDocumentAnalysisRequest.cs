using Cielo.Sirius.Foundation;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.CreateDocumentAnalysisRequest
{
    [DataContract]
    public class CreateDocumentAnalysisRequestRequest : RequestBase
    {
        /// <summary>
        /// Case creation information.
        /// </summary>
        [DataMember]
        public CaseDTO Case
        { get; set; }

        /// <summary>
        /// Request case information.
        /// </summary>
        [DataMember]
        public TypedSaleRequestDTO TypedSaleRequest
        { get; set; }
    }

    [DataContract]
    public class CreateDocumentAnalysisRequestResponse : ResponseBase 
    { }

    [DataContract]
    public class CaseDTO : DTOBase
    {
        /// <summary>
        /// Case title (Protocol + case counter).
        /// </summary>
        [DataMember]
        public string CaseTitle
        { get; set; }

        /// <summary>
        /// Status reason (returned by OSB).
        /// </summary>
        [DataMember]
        public string StatusReason
        { get; set; }

        /// <summary>
        /// Reference to Commercial Establishment Number (EC Number).
        /// [TODO] lookup: GUID ou EntityReference?
        /// </summary>
        [DataMember]
        public string ECNumber
        { get; set; }

        /// <summary>
        /// Client name described in commercial establishment.
        /// </summary>
        [DataMember]
        public string ClientName
        { get; set; }

        /// <summary>
        /// Reference to Agent Group Code.
        /// [TODO] lookup: GUID ou EntityReference?
        /// </summary>
        [DataMember]
        public string AgentGroupCode
        { get; set; }

        /// <summary>
        /// Service Channel.
        /// </summary>
        [DataMember]
        public string ServiceChannel
        { get; set; }

        /// <summary>
        /// Reference to Request Type.
        /// [TODO] lookup: GUID ou EntityReference?
        /// </summary>
        [DataMember]
        public string RequestParametrizationCode
        { get; set; }

        /// <summary>
        /// Reference to Article Subject.
        /// [TODO] lookup: GUID ou EntityReference?
        /// </summary>
        [DataMember]
        public string ArticleSubjectCode
        { get; set; }
    }

    [DataContract]
    public class TypedSaleRequestDTO: DTOBase
    {

	    /// <summary>
        /// Reference to Document Analisys Case.
        /// [TODO] lookup: GUID ou EntityReference?
	    /// </summary>
        [DataMember]
        public string ReferenceCaseCode
	    { get; set; }
	
	    /// <summary>
        /// Reference to Request Reason.
        /// [TODO] lookup: GUID ou EntityReference?
	    /// </summary>
        [DataMember]
	    public string RequestReasonCode
	    { get; set; }

        /// <summary>
        /// Status reason (returned by OSB).
        /// </summary>
        [DataMember]
        public string StatusReason
        { get; set; }
    }

}
