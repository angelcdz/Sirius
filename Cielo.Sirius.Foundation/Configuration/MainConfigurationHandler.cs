using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.Configuration
{
    public sealed class MainConfigurationHandler
    {
        public const string MAIN_CONFIG_SECTION_GROUP = "cielo.sirius.configuration";
        public const string DATA_ACCESS_CONFIG_SECTION = MAIN_CONFIG_SECTION_GROUP + "/dataAccess";
        public const string DECODING_TABLES_CONFIG_SECTION = MAIN_CONFIG_SECTION_GROUP + "/domainDecodingTables";

    }




    /*
    <cielo.sirius.configuration>

      <applicationCatalog>
      </applicationCatalog>

      <dataAccessComponents>
        <dataAccess name = "" >
          <parameters>
            <add key="url" value="" />
            <add key="realm" value="" />
            <add key="credentialkey" value="" />
            <add key="mockfilepath" value="" />
          </parameters>
        </dataAccess>
      </dataAccessComponents>

    <domainTables>
        <domainTable name="Sexo">
            <code name="M" value="Masculino">
                <decode name = "SEC" value="Masculino" />
                <decode name = "BOB" value="Masc" />
            </code> 
        </domainTable>
    </domainTables>

    </cielo.sirius.configuration>
    */

}
