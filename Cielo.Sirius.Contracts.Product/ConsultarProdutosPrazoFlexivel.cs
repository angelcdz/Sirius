using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel
{
    [DataContract]
    public class ConsultarProdutosPrazoFlexivelRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutosPrazoFlexivelResponse : ResponseBase
    {
        [DataMember]
        public int CodigoGrupoPrazoFlexivel
        { get; set; }

        [DataMember]
        public List<ConsultarProdutosPrazoFlexivelProdutoDTO> Produtos
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutosPrazoFlexivelProdutoDTO : DTOBase
    {
        [DataMember]
        public int CodigoProduto
        { get; set; }

        [DataMember]
        public string NomeProduto
        { get; set; }

        [DataMember]
        public int CodigoBandeira
        { get; set; }

        [DataMember]
        public string NomeBandeira
        { get; set; }

        [DataMember]
        public int? QuantidadeDiasPrazo
        { get; set; }

        [DataMember]
        public double? PercentualTaxaGarantia
        { get; set; }
    }
}
