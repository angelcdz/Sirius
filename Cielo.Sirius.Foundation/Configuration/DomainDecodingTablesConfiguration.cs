using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public class DomainDecodingTablesConfiguration : ConfigurationSection
    {
        public static DomainDecodingTablesConfiguration Settings
        {
            get
            {
                return ConfigurationManager.GetSection(MainConfigurationHandler.DECODING_TABLES_CONFIG_SECTION) as DomainDecodingTablesConfiguration;
            }
        }

        private const string PROPERTY_TABLES = "domainTables";

        [ConfigurationProperty(PROPERTY_TABLES, IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "domainTable")]
        public GenericConfigurationElementCollection<DomainTable> DomainTables
        {
            get
            {
                return (GenericConfigurationElementCollection<DomainTable>)this[PROPERTY_TABLES];
            }
        }
    }

    public class DomainTable : BaseConfigurationElement
    {
        private const string PROPERTY_CODES = "domainCodes";

        [ConfigurationProperty(PROPERTY_CODES, IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "domainCode")]
        public GenericConfigurationElementCollection<DomainCode> DomainCodes
        {
            get
            {
                return (GenericConfigurationElementCollection<DomainCode>)this[PROPERTY_CODES];
            }
        }
    }

    public class DomainCode : BaseConfigurationElement
    {
        private const string PROPERTY_VALUE = "value";
        private const string PROPERTY_DECODES = "domainDecodes";

        [ConfigurationProperty(PROPERTY_VALUE, IsRequired = false, DefaultValue = "")]
        public string Value
        {
            get
            {
                return this[PROPERTY_VALUE] as string;
            }
            set
            {
                this[PROPERTY_VALUE] = value;
            }
        }

        [ConfigurationProperty(PROPERTY_DECODES, IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "decode")]
        public GenericConfigurationElementCollection<DomainDecode> DomainDecodes
        {
            get
            {
                return (GenericConfigurationElementCollection<DomainDecode>)this[PROPERTY_DECODES];
            }
        }
    }

    public class DomainDecode : BaseConfigurationElement
    {
        private const string PROPERTY_VALUE = "value";

        [ConfigurationProperty(PROPERTY_VALUE, IsRequired = false, DefaultValue = "")]
        public string Value
        {
            get
            {
                return this[PROPERTY_VALUE] as string;
            }
            set
            {
                this[PROPERTY_VALUE] = value;
            }
        }
    }
}
