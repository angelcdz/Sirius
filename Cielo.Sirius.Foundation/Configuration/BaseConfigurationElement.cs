using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public class BaseConfigurationElement : ConfigurationElement
    {
        private const string PROPERTY_NAME = "name";

        [ConfigurationProperty(PROPERTY_NAME, IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this[PROPERTY_NAME];
            }
            set
            {
                this[PROPERTY_NAME] = value;
            }
        }
    }
}
