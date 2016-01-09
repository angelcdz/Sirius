using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.USD
{
    public class Cache
    {
        public static RequestType SmartRequest<RequestType, ResponseType>(string key, ResponseType requestObject, Func<ResponseType, RequestType> methodToCallWhenObjectIsNotOnCache)
        {
            RequestType response;

            // Check if the object is already on cache
            if (Exists(key))
            {
                // If yes, retrieve it from cache
                response = Retrieve<RequestType>(key);
            }
            else
            {
                // If not, perform a request
                response = methodToCallWhenObjectIsNotOnCache(requestObject);

                // And then add the response to cache
                Add(key, response);
            }

            return response;
        }

        private static void Add(string key, object obj)
        {
            // TODO: Write the object into somewhere
            //throw new NotImplementedException();
        }

        private static T Retrieve<T>(string key)
        {
            // TODO: Retrieve the object from somewhere
            throw new NotImplementedException();
        }

        private static void ReleaseObject(string key)
        {
            // TODO: Remove the object from cache
            throw new NotImplementedException();
        }

        private static bool Exists(string key)
        {
            // TODO: Check if the object exists on cache
            return false;
        }
    }
}
