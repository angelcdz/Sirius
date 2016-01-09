using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.SmartApps.Communication.Tests
{
    internal class BasicExampleDAO : DAOBase<ExampleRequest, ExampleResponse>
    {
        protected override ExampleResponse GetData(ExampleRequest requestData)
        {
            return new ExampleResponse()
            {
                Status = ExecutionStatus.Success
            };
        }
    }

    internal class BasicExampleMockedDAO : DAOBase<ExampleRequest, ExampleResponse>
    {
        protected override ExampleResponse GetData(ExampleRequest requestData)
        {
            return new ExampleResponse()
            {
                Status = ExecutionStatus.Success
            };
        }
    }

    internal class BasicExampleOverrideParametersDAO : DAOBase<ExampleRequest, ExampleResponse>
    {
        protected override ExampleResponse GetData(ExampleRequest requestData)
        {
            return new ExampleResponse()
            {
                Status = ExecutionStatus.Success
            };
        }
    }

    internal class ExampleRequest : RequestBase
    {
    }

    internal class ExampleResponse : ResponseBase
    {
    }
}
