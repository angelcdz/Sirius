using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using Cielo.Sirius.Foundation.Configuration;

namespace Cielo.Sirius.Foundation
{
    public sealed class DAOMockParameterized<RequestType, ResponseType> : DAOBase<RequestType, ResponseType>
        where RequestType : RequestBase
        where ResponseType : ResponseBase, new()
    {
        private string sourceDataPath;

        private Logger logger = Logger.LoggerFor<DAOMockParameterized<RequestType, ResponseType>>();

        public DAOMockParameterized(string xmlMockedDataFullPath)
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

                stream = new FileStream(this.sourceDataPath, FileMode.Open, FileAccess.Read);
                reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(List<MockSet<RequestType, ResponseType>>));

                var deserializedMocksets = (List<MockSet<RequestType, ResponseType>>)ser.ReadObject(reader, true);

                var found = from mock in deserializedMocksets
                            where BasicSerialization(mock.request) == BasicSerialization(requestData)
                            select mock;

                if (found != null && found.Count() > 0)
                {
                    return found.First().response;
                }
                else
                {
                    var response = new ResponseType();
                    response.ErrorCode = ErrorCodes.DAO_PARAMETERIZED_MOCK_RECORD_NOT_FOUND;
                    response.ErrorMessage = "RECORD NOT FOUND";
                    response.Status = ExecutionStatus.TechnicalError;
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during DAO-ParameterizedMock execution: {0}", ex.Message);

                var response = new ResponseType();
                response.ErrorCode = ErrorCodes.DAO_PARAMETERIZED_MOCK_GENERIC_ERROR;
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

        private string BasicSerialization(RequestBase request)
        {
            var userIdTemp = request.UserId;
            var correlationId = request.CorrelationId;

            //Forcing request-variable values for comparison
            request.UserId = Guid.Empty;
            request.CorrelationId = Guid.Empty;

            StringBuilder strbuilder = new StringBuilder();

            XmlWriter writer = XmlWriter.Create(strbuilder);
            DataContractSerializer serializer = new DataContractSerializer(request.GetType());
            serializer.WriteObject(writer, request);
            writer.Flush();

            request.UserId = userIdTemp;
            request.CorrelationId = correlationId;

            return strbuilder.ToString();
        }
    }
}
