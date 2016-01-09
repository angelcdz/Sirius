using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto
{
    [DataContract]
    public class AlterarParcelaFaixaProdutoRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public List<AlterarParcelaFaixaProdutoDTO> DadosFaixaTaxaSegmentado
        { get; set; }

        [DataMember]
        public decimal? PercentualTaxa
        { get; set; }

        [DataMember]
        public string Protocolo
        { get; set; }

        [DataMember]
        public string QuantidadeParcelas
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }

        [DataMember]
        public string Origem
        { get; set; }
    }

    [DataContract]
    public class AlterarParcelaFaixaProdutoDTO : DTOBase
    {
        [DataMember]
        public string CodigoFaixa
        { get; set; }

        [DataMember]
        public string NumeroFinalParcelaFaixa
        { get; set; }

        [DataMember]
        public string NumeroInicialParcelaFaixa
        { get; set; }

        [DataMember]
        public double? PercentualTaxaFaixa
        { get; set; }
    }

    [DataContract]
    public class AlterarParcelaFaixaProdutoResponse : ResponseBase
    {
        [DataMember]
        public string StatusRetorno
        { get; set; }

        [DataMember]
        public string SistemaLegado
        { get; set; }

        [DataMember]
        public string CodigoSolicitacao
        { get; set; }

        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao
        { get; set; }
    }
}