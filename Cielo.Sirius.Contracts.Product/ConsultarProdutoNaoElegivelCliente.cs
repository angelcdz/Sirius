using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente
{
    [DataContract]
    public class ConsultarProdutoNaoElegivelClienteRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutoNaoElegivelClienteResponse : ResponseBase
    {
        [DataMember]
        public List<ConsultarProdutoNaoElegivelClienteProdutoDTO> Produtos
        { get; set; }

        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutoNaoElegivelClienteProdutoDTO : DTOBase
    {
        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public string TipoGrupoProduto
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

        //Label: Prazo de Pagamento
        [DataMember]
        public string QuantidadeDiasPrazo
        { get; set; }

        //Label: Parcelas
        //Se TipoGrupoProduto = 4, exibir texto fixo "SEGMENTADO", caso contrário exibir o valor desta propriedade (QuantidadeParcelasLoja)
        [DataMember]
        public string QuantidadeParcelasLoja
        { get; set; }

        //Label: Taxa Prazo Flexível
        [DataMember]
        public double? PercentualTaxaGarantia
        { get; set; }

        //Label: Taxa Padrão
        //Se TipoGrupoProduto = 4, exibir texto fixo "--", caso contrário exibir o valor desta propriedade (PercentualTaxaPadrao)
        [DataMember]
        public double? PercentualTaxaPadrao
        { get; set; }

        //Label: Tipo de Cobrança
        [DataMember]
        public string NomeTipoLiquidacao
        { get; set; }

        [DataMember]
        public bool? IndicadorVendaDigitada
        { get; set; }

        [DataMember]
        public string OrdemApresentacao
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
    }
}
