using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado
{
    [DataContract]
    public class AlterarProdutoCreditoParceladoSegmentadoRequest : RequestBase
    {
        #region Common Request Parameters

        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public string Protocolo
        { get; set; }

        [DataMember]
        public string QuantidadeParcelas
        { get; set; }

        [DataMember]
        public List<AlterarProdutoCreditoParceladoSegmentadoFaixaDTO> Faixas
        { get; set; }

        #endregion

        #region OSB Request Parameters

        [DataMember]
        public string Origem
        { get; set; }

        #endregion

        #region CRM Request Parameters

        [DataMember]
        public Guid EstabelecimentoComercial
        { get; set; }

        [DataMember]
        public Guid Cliente
        { get; set; }

        [DataMember]
        public Guid IlhaAtendimento
        { get; set; }

        [DataMember]
        public int CanalAtendimento
        { get; set; }

        [DataMember]
        public String CaseType
        { get; set; }

        [DataMember]
        public Guid ArvoreAssunto
        { get; set; }

        [DataMember]
        public int TipoSolicitacao
        { get; set; }

        [DataMember]
        public Guid UsuarioSolicitante
        { get; set; }

        [DataMember]
        public Guid Contato
        { get; set; }

        #region canal Expresso

        [DataMember]
        public string NomeAssessor
        { get; set; }

        [DataMember]
        public string CodigoAssessor
        { get; set; }

        #endregion

        [DataMember]
        public string SistemaResponsavel
        { get; set; }

        [DataMember]
        public string NomeProduto
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }

        #endregion

    }

    [DataContract]
    public class AlterarProdutoCreditoParceladoSegmentadoResponse : ResponseBase
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

    [DataContract]
    public class AlterarProdutoCreditoParceladoSegmentadoFaixaDTO : DTOBase
    {
        //Taxas: código da faixa
        [DataMember]
        public string CodigoFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor inicial da Faixa
        [DataMember]
        public string NumeroInicialParcelaFaixa
        { get; set; }

        //Taxas, Faixa de Parcelas: Valor final da Faixa
        [DataMember]
        public string NumeroFinalParcelaFaixa
        { get; set; }

        //Taxas: Taxa Padrão
        [DataMember]
        public decimal PercentualTaxaPadrao
        { get; set; }

        //Taxas: Percentual Taxa Faixa
        [DataMember]
        public double PercentualTaxaFaixa
        { get; set; }

        //Taxas: Taxa Matriz
        public double? TaxaMatriz
        { get; set; }

        [DataMember]
        public decimal PercentualDescontoAlcada
        { get; set; }

        [DataMember]
        public decimal PercentualMinimoDescontoAlcada
        { get; set; }

        [DataMember]
        public decimal PercentualMaximoDescontoAlcada
        { get; set; }
    }
}
