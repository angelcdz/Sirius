using Microsoft.Uii.Csr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.USD
{
    public interface ICrmCommunicator
    {
        string GetCrmContextValue(string crmContextKey_);
        void UpdateCrmContextValue(string crmContextKey_, string value_);
        void FireCrmRequestAction(string target_, string action_, object data_);
    }
}
