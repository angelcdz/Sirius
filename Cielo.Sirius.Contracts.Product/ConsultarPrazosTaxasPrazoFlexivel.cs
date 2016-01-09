using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel
{
    [DataContract]
    public class ConsultarPrazosTaxasPrazoFlexivelRequest : RequestBase
    {
        [DataMember]
        /// <summary>
        /// Represents the EC Number
        /// </summary>
        public long CodigoCliente
        { get; set; }

        /// <summary>
        /// Product Group Code
        /// </summary>
        [DataMember]
        public int CodigoGrupoPrazoFlexivel
        { get; set; }

    }

    [DataContract]
    public class ConsultarPrazosTaxasPrazoFlexivelResponse : ResponseBase
    {

        [DataMember]
        public List<ConsultarPrazosTaxasPrazoFlexivelDTO> GruposProdutoPrazoFlexivel
        { get; set; }
    }

    [DataContract]
    public class ConsultarPrazosTaxasPrazoFlexivelDTO : DTOBase
    {
        [DataMember]
        /// <summary>
        /// Product Group Code
        /// </summary>
        public int CodigoGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        /// <summary>
        /// Description of the Product Group
        /// </summary>
        public string DescricaoGrupoPrazoFlexivel
        { get; set; }

        /// <summary>
        /// Indicates if the product group has the flexible deadline
        /// </summary>
        [DataMember]
        public string IndicadorHabilitado
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO> DadosTarifasGrupoProdutoPrazoFlexivel
        { get; set; }
    }

    [DataContract]
    public class ConsultarPrazosTaxasPrazoFlexivelTarifasDTO : DTOBase
    {
        /// <summary>
        /// Tax value 
        /// </summary>
        [DataMember]
        public double? PercentualTaxaGrupoPrazoFlexivel
        { get; set; }

        /// <summary>
        /// Quantity of days until the deadline
        /// </summary>
        [DataMember]
        public int? QuantidadeDiasGrupoPrazoFlexivel
        { get; set; }
    }
}
