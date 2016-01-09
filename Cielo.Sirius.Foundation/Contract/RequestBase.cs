using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    [DataContract]
    public abstract class RequestBase
    {
        [DataMember]
        public Guid UserId
        { get; set; }

        [DataMember]
        public Guid CorrelationId
        { get; set; }

        public RequestBase()
        {
            this.UserId = Guid.Empty;
            this.CorrelationId = Guid.Empty;
        }
    }
}
