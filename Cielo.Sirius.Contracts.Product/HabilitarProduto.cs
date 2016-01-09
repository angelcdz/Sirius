using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.HabilitarProduto
{
    [DataContract]
    public class HabilitarProdutoRequest : RequestBase
    {
        [DataMember]
        public string Protocolo
        { get; set; }

        [DataMember]
        public long? CodigoCliente 
        { get; set; }

        [DataMember]
        public string CodigoProduto 
        { get; set; }

        [DataMember]
        public string QuantidadeParcelas 
        { get; set; }

        [DataMember]
        public decimal? PercentualTaxa 
        { get; set; }

        [DataMember]
        public List<HabilitarProdutoFaixaTaxaSegmentadoDTO> FaixasTaxaSegmentado 
        { get; set; }

        [DataMember]
        public string NomeSolicitante 
        { get; set; }

        [DataMember]
        public string Origem 
        { get; set; }

        [DataMember]
        public string TelefoneSolicitante 
        { get; set; }

        [DataMember]
        public string CodigoEmpresa 
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }
    }

    [DataContract]
    public class HabilitarProdutoResponse : ResponseBase
    {
        [DataMember]
        public string StatusRetorno 
        { get; set; }

        [DataMember]
        public string SistemaLegado 
        { get; set; }

        [DataMember]
        public HabilitarProdutoSolicitacaoCentralAtendimentoDTO SolicitacaoCentralAtendimento 
        { get; set; }
    }

    [DataContract]
    public class HabilitarProdutoFaixaTaxaSegmentadoDTO : DTOBase
    {
        [DataMember]
        public double? PercentualTaxaFaixa
        { get; set; }

        [DataMember]
        public string NumeroInicialParcelaFaixa 
        { get; set; }

        [DataMember]
        public string NumeroFinalParcelaFaixa 
        { get; set; }

        [DataMember]
        public string CodigoFaixa 
        { get; set; }
    }

    [DataContract]
    public class HabilitarProdutoSolicitacaoCentralAtendimentoDTO : DTOBase
    {
        [DataMember]
        public string CodigoSolicitacao
        { get; set; }

        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao
        { get; set; }
    }
}