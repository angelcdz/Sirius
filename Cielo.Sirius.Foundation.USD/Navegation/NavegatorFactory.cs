using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public class NavegatorFactory
    {
        public static INavegator GetNavegator(string hostedControlKey_)
        {
            // TODO : Get from configuration if necessary
            return new Navegator();
        }
    }
}
