using Cielo.Sirius.Foundation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Foundation
{
    public sealed class DomainTablesDecoder
    {

        static Logger logger = Logger.LoggerFor<DomainTablesDecoder>();

        private DomainTablesDecoder()
        {
        }

        public static List<DomainItem> GetDomainValues(string domainTableName)
        {
            try
            {
                var domainCodes = from code in DomainDecodingTablesConfiguration.Settings.DomainTables[domainTableName].DomainCodes
                                  select new DomainItem()
                                  {
                                      Name = code.Name,
                                      Value = code.Value
                                  };

                return domainCodes.ToList();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "An error occurred during execution: {0}",  ex.Message);
                throw;
            }
        }

        public static string Decode(string domainTableName, string codeName, string decodeName)
        {
            try
            {
                if(DomainDecodingTablesConfiguration.Settings != null)
                {
                    var domainCodeTable = DomainDecodingTablesConfiguration.Settings.DomainTables[domainTableName];

                    if (domainCodeTable != null)
                    {
                        var decoded = from decode in domainCodeTable.DomainCodes[codeName].DomainDecodes
                                      where decode.Name == decodeName
                                      select decode.Value;

                        if (decoded != null)
                        {
                            return decoded.FirstOrDefault();
                        }
                        else
                        {
                            //Error: decode name does not exists!
                            logger.LogError("An error occurred during execution of DomainTablesDecoder. Decode name does not exists! ");
                        }
                    }
                    else
                    {
                        //Error: domain does not exists!
                        logger.LogError("An error occurred during execution of DomainTablesDecoder. Domain does not exists!");
                    }
                }
                else
                {
                    //Return error: not configured!
                    logger.LogError("An error occurred during execution of DomainTablesDecoder. Not configured!");
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during execution: {1}", ex.Message);
                throw;
            }
        }
    }

    public sealed class DomainItem
    {
        public string Name
        { get; set; }

        public string Value
        { get; set; }
    }
}
