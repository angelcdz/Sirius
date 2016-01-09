using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    public sealed class ErrorCodes
    {
        /*
         * Error format: 
         * 10XXXX: Foundation
         * 20XXXX: CRM
         * 30XXXX: Service - outbound
         * 40XXXX: USD
         * 50XXXX: Service - inbound
         */

        public const string GENERIC_TECHNICAL_ERROR = "100001";
        public const string GENERIC_BUSINESS_ERROR = "100002";

        public const string DAO_MOCK_GENERIC_ERROR = "100004";
        public const string DAO_PARAMETERIZED_MOCK_GENERIC_ERROR = "100005";
        public const string DAO_PARAMETERIZED_MOCK_RECORD_NOT_FOUND = "100006";
        public const string DAO__MOCK_FILE_NOT_FOUND = "100007";

        public const string DAO_OSB_GENERIC_ERROR = "300001";
        public const string DAO_OSB_CALL_SOAP_ERROR = "300002";
        public const string DAO_OSB_CALL_TIMEOUT_ERROR = "300005";
        public const string DAO_OSB_CALL_NAME_RESOLUTION_FAILURE_ERROR = "300006";

        public const string DAO_CRM_GENERIC_ERROR = "300003";
        public const string DAO_CRM_USER_NOT_INFORMED = "300004";

        public const string BL_OSB_CALL_DAOFACTORY = "500001";
    }
}
