using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.DAO
{
    [DataContract]
    public class CRMKeys
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public string Organization { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
