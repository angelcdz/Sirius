using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace Cielo.Sirius.Foundation
{
    public class DAOMockSimple<RequestType, ResponseType> : DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase, new()
        where RequestType : RequestBase
    {
        private string sourceDataPath;
        private Logger logger = Logger.LoggerFor<DAOMockSimple<RequestType, ResponseType>>();

        public DAOMockSimple(string xmlMockedDataFullPath)
        {
            this.sourceDataPath = xmlMockedDataFullPath;
        }

        protected override ResponseType GetData(RequestType requestData)
        {
            XmlDictionaryReader reader = null;
            FileStream stream = null;

            try
            {
                if (string.IsNullOrEmpty(this.sourceDataPath) && !File.Exists(this.sourceDataPath))
                {
                    logger.LogWarning("The mock file '{0}' was not found.", this.sourceDataPath);

                    var response = new ResponseType();
                    response.ErrorCode = ErrorCodes.DAO__MOCK_FILE_NOT_FOUND;
                    response.ErrorMessage = string.Format("The mock file '{0}' was not found.", this.sourceDataPath);
                    response.Status = ExecutionStatus.TechnicalError;
                    return response;
                }

                stream = new FileStream(sourceDataPath, FileMode.Open, FileAccess.Read);
                reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(ResponseType));

                ResponseType deserialized = (ResponseType)ser.ReadObject(reader, true);
                return deserialized;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during DAO-MockSimple execution: {0}", ex.Message);

                var response = new ResponseType();
                response.ErrorCode = ErrorCodes.DAO_MOCK_GENERIC_ERROR;
                response.ErrorMessage = ex.Message;
                response.Status = ExecutionStatus.TechnicalError;
                return response;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
