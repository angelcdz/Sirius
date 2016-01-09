using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.Configuration;
using System.IO;
using System.Configuration;

namespace Cielo.Sirius.Foundation
{
    public sealed class DAOFactory
    {
        static Logger logger = Logger.LoggerFor<DAOFactory>();

        public static DAOBase<RequestType, ResponseType> GetDAO<DAOType, RequestType, ResponseType>()
            where DAOType : DAOBase<RequestType, ResponseType>, new()
            where RequestType : RequestBase
            where ResponseType : ResponseBase, new()
        {
            try
            {
                DAOBase<RequestType, ResponseType> daoImplementation = null;

                var parameters = GetParameters(typeof(DAOType).Name);

                bool isMocked = false;

                if (parameters.ContainsKey("useMockData"))
                {
                    if (!bool.TryParse(parameters["useMockData"], out isMocked))
                    {
                        logger.LogInformation("Invalid configuration for '{0}': verify 'useMockData' parameter.", typeof(DAOType).Name);
                    }
                }

                if (isMocked)
                {
                    logger.LogInformation("Configuration for DAO '{0}' was set to use mocked data.", typeof(DAOType).Name);
                    daoImplementation = GetMockedDAO<RequestType, ResponseType>(parameters, typeof(DAOType).Name);
                }

                if (daoImplementation == null)
                {
                    logger.LogInformation("Returning real DAO implementation: '{0}'.", typeof(DAOType).Name);
                    daoImplementation = new DAOType();

                    foreach(string key in parameters.Keys)
                    {
                        daoImplementation.Parameters[key] = parameters[key];
                    }
                }

                return daoImplementation;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured on DAO '{0}' setup: {1}.", typeof(DAOType).Name, ex.Message);
                throw;
            }
        }

        private static Dictionary<string, string> GetParameters(string DAOClassName)
        {
            KeyValueConfigurationCollection defaultParameters = DataAccessConfiguration.Settings.DefaultParameters;
            KeyValueConfigurationCollection daoParameters = null;

            if (DataAccessConfiguration.Settings.DataAccessComponents[DAOClassName] != null)
            {
                daoParameters = DataAccessConfiguration.Settings.DataAccessComponents[DAOClassName].Parameters;
            }
            else
            {
                logger.LogInformation("Configuration for DAO '{0}' was not found. Real DAO implementation will be returned.", DAOClassName);
            }

            Dictionary<string, string> mergedParameters = new Dictionary<string, string>();

            foreach (string key in defaultParameters.AllKeys)
            {
                mergedParameters[key] = defaultParameters[key].Value;
            }

            if (daoParameters != null)
            {
                foreach (string key in daoParameters.AllKeys)
                {
                    mergedParameters[key] = daoParameters[key].Value;
                }
            }

            return mergedParameters;
        }

        private static DAOBase<RequestType, ResponseType> GetMockedDAO<RequestType, ResponseType>(Dictionary<string, string> parameters, string DAOClassName)
            where RequestType : RequestBase
            where ResponseType : ResponseBase, new()
        {
            try
            {
                DAOBase<RequestType, ResponseType> mockedDAOImplementation = null;

                string xmlFullPath = null;
                string mockType = null;

                if (parameters.ContainsKey("mockSourceData"))
                {
                    xmlFullPath = parameters["mockSourceData"];
                }
                else
                {
                    logger.LogError("The parameter 'mockSourceData' was not informed for '{0}' DAO", DAOClassName);
                    return null;
                }

                if (parameters.ContainsKey("mockType"))
                {
                    mockType = parameters["mockType"];
                }

                if (!string.IsNullOrEmpty(mockType) && mockType == "parameterized")
                {
                    logger.LogInformation("Configuration for DAO '{0}' was set to use the parameterized mock DAO.", DAOClassName);
                    mockedDAOImplementation = new DAOMockParameterized<RequestType, ResponseType>(xmlFullPath);
                }
                else
                {
                    logger.LogInformation("Configuration for DAO '{0}' was set to use the simple mock DAO.", DAOClassName);
                    mockedDAOImplementation = new DAOMockSimple<RequestType, ResponseType>(xmlFullPath);
                }

                foreach (string key in parameters.Keys)
                {
                    mockedDAOImplementation.Parameters[key] = parameters[key];
                }

                return mockedDAOImplementation;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured on DAO '{0}' configuration retrieval or mock setup: '{1}'", DAOClassName, ex.Message);
                return null;
            }
        }
    }
}
