using System;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public class View
    {
        public Type ControlType { get; set; }
        public string Region { get; set; }

        public View(Type controlType_,string region_)
        {
            ControlType = controlType_;
            Region = region_;
        }
    }
}
