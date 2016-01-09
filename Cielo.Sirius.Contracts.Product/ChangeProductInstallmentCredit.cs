using Cielo.Sirius.Foundation;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.ChangeProductInstallmentCredit
{
    [DataContract]
    public class ChangeProductInstallmentCreditRequest : RequestBase
    {
    }

    [DataContract]
    public class ChangeProductInstallmentCreditResponse : ResponseBase
    {
    }

    [DataContract]
    public class ChangeProductInstallmentCreditRangeDTO : DTOBase
    {
        //Código da faixa
        [DataMember]
        public string RangeCode
        { get; set; }

        //Valor inicial da faixa de parcelas
        [DataMember]
        public string RangeInitialParcelNumber
        { get; set; }

        //Valor final da faixa de parcelas
        [DataMember]
        public string RangeLastParcelNumber
        { get; set; }

        //Taxa padrão
        [DataMember]
        public decimal DefaultRatePercentage
        { get; set; }

        //Taxa matriz
        public double? ParentRate
        { get; set; }

        //
        [DataMember]
        public decimal DiscountRateRestrictionPercentage
        { get; set; }

        //
        [DataMember]
        public decimal MinDiscountRateRestrictionPercentage
        { get; set; }

        //
        [DataMember]
        public decimal MaxDiscountRateRestrictionPercentage
        { get; set; }
    }
}