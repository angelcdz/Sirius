using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    public class MockBase
    {
        protected void WriteObject<ObjectType>(string filename, ObjectType response)
        {
            FileStream writer = null;

            try
            {
                writer = new FileStream(filename, FileMode.Create);
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObjectType));
                serializer.WriteObject(writer, response);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        protected ObjectType ReadObject<ObjectType>(string filename)
        {
            FileStream fileStream = null;
            XmlDictionaryReader reader = null;

            try
            {
                fileStream = new FileStream(filename, FileMode.Open);
                reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObjectType));
                ObjectType deserializedResponse = (ObjectType)serializer.ReadObject(reader, true);
                return deserializedResponse;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}
