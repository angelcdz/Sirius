using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    [DataContract]
    public abstract class ResponseBase
    {
        [DataMember]
        public string ErrorCode
        { get; set; }

        [DataMember]
        public string ErrorMessage
        { get; set; }

        [DataMember]
        public ExecutionStatus Status
        { get; set; }

        [DataMember]
        public Guid CorrelationId
        { get; set; }

        public ResponseBase()
        {
            this.Status = ExecutionStatus.NotExecuted;
            this.CorrelationId = Guid.Empty;
        }
    }

    [DataContract]
    public enum ExecutionStatus : int
    {
        [EnumMember]
        NotExecuted = 0,
        [EnumMember]
        Success = 1,
        [EnumMember]
        Warning = 2,
        [EnumMember]
        TechnicalError = 3,
        [EnumMember]
        BusinessError = 4,
    }
}
