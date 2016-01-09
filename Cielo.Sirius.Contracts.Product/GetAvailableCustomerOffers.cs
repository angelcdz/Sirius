using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.GetAvailableCustomerOffers
{
    [DataContract]
    public class GetAvailableCustomerOffersRequest : RequestBase
    {
        /// <summary>
        /// Commercial Establishment.
        /// </summary>
        [DataMember]
        public long CommercialEstablishmentNumber
        { get; set; }

        /// <summary>
        /// Ilha de Atendimento
        /// </summary>
        [DataMember]
        public string AgentGroupCode
        { get; set; }
    }

    [DataContract]
    public class GetAvailableCustomerOffersResponse : ResponseBase
    {
        /// <summary>
        /// Indicates if exists any customer offer
        /// </summary>
        public bool DoOffersExist { get; set; }
    }
}
