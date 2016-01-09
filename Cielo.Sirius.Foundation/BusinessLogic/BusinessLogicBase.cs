using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    public abstract class BusinessLogicBase<RequestType, ResponseType>
        where ResponseType : ResponseBase
        where RequestType : RequestBase
    {
        public abstract ResponseType Execute(RequestType requestData);
    }
}
