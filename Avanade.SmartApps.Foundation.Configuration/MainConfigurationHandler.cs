using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public class MainConfigurationHandler : ConfigurationSection
    {
        public static MainConfigurationHandler Settings
        {
            get
            {
                return ConfigurationManager.GetSection("cielo.sirius.configuration") as MainConfigurationHandler;
            }
        }

        [ConfigurationProperty("dataAccessComponents", IsRequired = false)]
        [ConfigurationCollection(typeof(DataAccesConfigurationElement), AddItemName = "dataAccess")]
        public GenericConfigurationElementCollection<DataAccesConfigurationElement> DataAccessComponents
        {
            get
            {
                return (GenericConfigurationElementCollection<DataAccesConfigurationElement>)this["dataAccessComponents"];
            }
        }
    }

    public class BaseConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }

    public class DataAccesConfigurationElement : BaseConfigurationElement
    {
        [ConfigurationProperty("mocked", IsRequired = false, DefaultValue = false)]
        public bool Mocked
        {
            get
            {
                return (bool)this["mocked"];
            }
            set
            {
                this["mocked"] = value;
            }
        }

        [ConfigurationProperty("parameterizedMock", IsRequired = false, DefaultValue = false)]
        public bool ParameterizedMock
        {
            get
            {
                return (bool)this["parameterizedMock"];
            }
            set
            {
                this["parameterizedMock"] = value;
            }
        }

        [ConfigurationProperty("mockSourceData", IsRequired = false, DefaultValue = "")]
        public string MockSourceData
        {
            get
            {
                return (string)this["mockSourceData"];
            }
            set
            {
                this["mockSourceData"] = value;
            }
        }


        [ConfigurationProperty("parameters", IsRequired = false, IsDefaultCollection=false)]
        [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add")]
        public KeyValueConfigurationCollection Parameters
        {
            get
            {
                return (KeyValueConfigurationCollection)this["parameters"];
            }
        }
    }

    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T> where T : BaseConfigurationElement, new()
    {
        List<T> _elements = new List<T>();

        protected override ConfigurationElement CreateNewElement()
        {
            T newElement = new T();
            _elements.Add(newElement);
            return newElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BaseConfigurationElement)element).Name;
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public T this[int idx]
        {
            get
            {
                return (T)BaseGet(idx);
            }
        }

        public new T this[string name]
        {
            get
            {
                return (T)BaseGet(name);
            }
        }
    }

    //<cielo.sirius.configuration>
    //  <dataAccessComponents>
    //    <dataAccess name="">
    //      <parameters>
    //        <add key="url" value="" />
    //        <add key="realm" value="" />
    //        <add key="credentialkey" value="" />
    //        <add key="mockfilepath" value="" />
    //      </parameters>
    //    </dataAccess>
    //  </dataAccessComponents>
    //</cielo.sirius.configuration>
}
