using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    [DataContract]
    public class MockSet<RequestType, ResponseType>
        where RequestType : RequestBase
        where ResponseType : ResponseBase
    {
        [DataMember]
        public RequestType request;

        [DataMember]
        public ResponseType response;
    }
}
