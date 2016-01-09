using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public sealed class DataAccessConfiguration : ConfigurationSection
    {
        public static DataAccessConfiguration Settings
        {
            get
            {
                return ConfigurationManager.GetSection(MainConfigurationHandler.DATA_ACCESS_CONFIG_SECTION) as DataAccessConfiguration;
            }
        }
        
        private const string PROPERTY_DEFAULT_PARAMETERS = "defaultParameters";

        [ConfigurationProperty(PROPERTY_DEFAULT_PARAMETERS, IsRequired = false, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add")]
        public KeyValueConfigurationCollection DefaultParameters
        {
            get
            {
                return (KeyValueConfigurationCollection)this[PROPERTY_DEFAULT_PARAMETERS];
            }
        }

        private const string PROPERTY_COMPONENTS = "dataAccessComponents";

        [ConfigurationProperty(PROPERTY_COMPONENTS, IsRequired = false)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "dataAccessObject")]
        public GenericConfigurationElementCollection<DataAccessConfigurationElement> DataAccessComponents
        {
            get
            {
                return (GenericConfigurationElementCollection<DataAccessConfigurationElement>)this[PROPERTY_COMPONENTS];
            }
        }
    }

    public class DataAccessConfigurationElement : BaseConfigurationElement
    {
        private const string PROPERTY_PARAMETERS = "parameters";

        [ConfigurationProperty(PROPERTY_PARAMETERS, IsRequired = false, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add")]
        public KeyValueConfigurationCollection Parameters
        {
            get
            {
                return (KeyValueConfigurationCollection)this[PROPERTY_PARAMETERS];
            }
        }
    }
}
