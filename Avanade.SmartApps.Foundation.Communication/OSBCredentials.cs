using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cielo.Sirius.Foundation
{
    [DataContract]
    public class OSBCredentials
    {
        [DataMember]
        public string Username
        { get; set; }

        [DataMember]
        public string Password
        { get; set; }

        [DataMember]
        public string ReturnCode
        { get; set; }

        [DataMember]
        public string Realm
        { get; set; }
    }
}