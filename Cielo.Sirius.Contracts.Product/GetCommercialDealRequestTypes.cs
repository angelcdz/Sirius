using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.GetCommercialDealRequestTypes
{
    [DataContract]
    public class GetCommercialDealRequestTypesRequest : RequestBase
    {
        //Grupo do tipo de solicitação
        [DataMember]
        public string GroupCode { get; set; }
    }

    [DataContract]
    public class GetCommercialDealRequestTypesResponse :  ResponseBase
    {
        [DataMember]
        public List<GetCommercialDealRequestTypesDTO> CommercialDealRequestTypes { get; set; }
    }

    [DataContract]
    public class GetCommercialDealRequestTypesDTO : DTOBase
    {
        //Id do tipo de demanda
        [DataMember]
        public Guid Id { get;set; }

        //Descrição do tipo de demanda
        [DataMember]
        public string Name {get;set;}

        //Código da integração do tipo de demanda com o legado
        [DataMember]
        public int IntegrationRequestCode { get;set; }
    }
}
