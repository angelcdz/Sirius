using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public sealed class ApplicationCatalogConfiguration : ConfigurationSection
    {
        private const string PROPERTY_APPLICATIONS = "applications";

        [ConfigurationProperty(PROPERTY_APPLICATIONS, IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "application")]
        public GenericConfigurationElementCollection<Template> Applications
        {
            get
            {
                return (GenericConfigurationElementCollection<Template>)this[PROPERTY_APPLICATIONS];
            }
        }
    }

    public sealed class Application : BaseConfigurationElement
    {
        private const string PROPERTY_TEMPLATES = "templates";

        [ConfigurationProperty(PROPERTY_TEMPLATES, IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "template")]
        public GenericConfigurationElementCollection<Template> DomainDecodes
        {
            get
            {
                return (GenericConfigurationElementCollection<Template>)this[PROPERTY_TEMPLATES];
            }
        }

        private const string PROPERTY_SHELLS = "shells";

        [ConfigurationProperty(PROPERTY_SHELLS, IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "shell")]
        public GenericConfigurationElementCollection<Shell> Shells
        {
            get
            {
                return (GenericConfigurationElementCollection<Shell>)this[PROPERTY_SHELLS];
            }
        }
    }

    public sealed class Template : BaseConfigurationElement
    {
        private const string PROPERTY_CLASSNAME = "className";

        [ConfigurationProperty(PROPERTY_CLASSNAME, IsRequired = true)]
        public string ClassName
        {
            get
            {
                return this[PROPERTY_CLASSNAME] as string;
            }
            set
            {
                this[PROPERTY_CLASSNAME] = value;
            }
        }
    }

    public sealed class Shell : BaseConfigurationElement
    {
        private const string PROPERTY_TEMPLATENAME = "templateName";

        [ConfigurationProperty(PROPERTY_TEMPLATENAME, IsRequired = true)]
        public string TemplateName
        {
            get
            {
                return this[PROPERTY_TEMPLATENAME] as string;
            }
            set
            {
                this[PROPERTY_TEMPLATENAME] = value;
            }
        }

        private const string PROPERTY_VIEWS = "views";

        [ConfigurationProperty(PROPERTY_VIEWS, IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(DataAccessConfigurationElement), AddItemName = "view")]
        public GenericConfigurationElementCollection<View> Shells
        {
            get
            {
                return (GenericConfigurationElementCollection<View>)this[PROPERTY_VIEWS];
            }
        }
    }

    public sealed class View : BaseConfigurationElement
    {
        private const string PROPERTY_REGIONNAME = "regionName";

        [ConfigurationProperty(PROPERTY_REGIONNAME, IsRequired = true)]
        public string RegionName
        {
            get
            {
                return this[PROPERTY_REGIONNAME] as string;
            }
            set
            {
                this[PROPERTY_REGIONNAME] = value;
            }
        }

        private const string PROPERTY_CLASSNAME = "className";

        [ConfigurationProperty(PROPERTY_CLASSNAME, IsRequired = true)]
        public string ClassName
        {
            get
            {
                return this[PROPERTY_CLASSNAME] as string;
            }
            set
            {
                this[PROPERTY_CLASSNAME] = value;
            }
        }

        private const string PROPERTY_RENDER_AT_STARTUP = "renderAtStartup";

        [ConfigurationProperty(PROPERTY_RENDER_AT_STARTUP, IsRequired = true)]
        public bool RenderAtStartup
        {
            get
            {
                return (bool)this[PROPERTY_RENDER_AT_STARTUP];
            }
            set
            {
                this[PROPERTY_RENDER_AT_STARTUP] = value;
            }
        }
    }

    /*

    <applicationCatalog>
      <application name="Cielo.Sirius.USD.ProductsandServices">
        <templates>
          <template name="" className="" />
        </templates>
        <shells>
          <shell name="" templateName="">
            <views>
              <view name="" regionName="" className="" renderAtStartup="true" />
            </views>
          </shell>
        </shells>
      </application>
    </applicationCatalog>

    */
}
