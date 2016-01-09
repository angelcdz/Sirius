using System;
using System.Collections.Generic;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public class IScreen
    {
        string Name { get; set; }
        Type Shell { get; set; }
        List<View> Views { get; set; }
    }
}
