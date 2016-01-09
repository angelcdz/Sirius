using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente
{
    [DataContract]
    public class ConsultarProdutoHabilitadoClienteRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutoHabilitadoClienteResponse : ResponseBase
    {
        [DataMember]
        public List<ConsultarProdutoHabilitadoClienteProdutoDTO> Produtos
        { get; set; }

        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }

        [DataMember]
        public DateTime DataUltimaTransacao
        { get; set; }

    }

    [DataContract]
    public class ConsultarProdutoHabilitadoClienteProdutoDTO : DTOBase
    {
        [DataMember]
        public string CodigoProduto
        { get; set; }

        //Label: Produto
        [DataMember]
        public string NomeProduto
        { get; set; }

        [DataMember]
        public string CodigoBandeira
        { get; set; }

        //Label: Bandeira
        [DataMember]
        public string NomeBandeira
        { get; set; }

        //Label: Taxa Padrão
        //Se TipoGrupoProduto = 4, exibir texto fixo "--", caso contrário exibir o valor desta propriedade (PercentualTaxaPadrao)
        [DataMember]
        public double? PercentualTaxaPadrao
        { get; set; }

        //Label: Taxa Contratada
        //Se TipoGrupoProduto = 4, exibir texto fixo "--", caso contrário exibir o valor desta propriedade (PercentualTaxa)
        [DataMember]
        public decimal? PercentualTaxa
        { get; set; }

        //Label: Prazo de Pagamento
        [DataMember]
        public string QuantidadeDiasPrazo
        { get; set; }

        //Label: Taxa Prazo Flexível
        [DataMember]
        public double? PercentualTaxaGarantia
        { get; set; }

        //Label: Parcelas
        //Se TipoGrupoProduto = 4, exibir texto fixo "SEGMENTADO", caso contrário exibir o valor desta propriedade (QuantidadeParcelasLoja)
        [DataMember]
        public string QuantidadeParcelasLoja
        { get; set; }

        //Label: Tipo de Cobrança
        [DataMember]
        public string NomeTipoLiquidacao
        { get; set; }


        //Tarifa
        [DataMember]
        public double? ValorTarifa
        { get; set; }

        /// <summary>
        /// Indicates if there's any open demands for the product in CRM
        /// </summary>
        /// <remarks>
        /// Refer's to step "3.1 - Consulta se Existem Demandas em Aberto para cada Produto" in "Consultar Produtos" process
        /// </remarks>
        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }

        [DataMember]
        public decimal? PercentualDesconto
        { get; set; }

        [DataMember]
        public bool? IndicadorVendaDigitada
        { get; set; }

        [DataMember]
        public bool? IndicadorVendaDigitadaHabilitada
        { get; set; }

        [DataMember]
        public string OrdemApresentacao
        { get; set; }

        [DataMember]
        public bool IndicadorVendaUltimoMes
        { get; set; }

        [DataMember]
        public string TipoGrupoProduto
        { get; set; }
    }
}
