using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetAvailableCustomerOffers
{
    [DataContract]
    public class GetDealItemsRequest : RequestBase { }

    [DataContract]
    public class GetDealItemsResponse : ResponseBase
    {
        /// <summary>
        /// List of Deal Items
        /// </summary>
       [DataMember]
        public List<GetDealItemsDTO> DealItems { get; set; }
    }

    public class GetDealItemsDTO : DTOBase
	{
        [DataMember]
        public string DealName { get; set; }

        [DataMember]
        public string DealId { get; set; }
	}
}
