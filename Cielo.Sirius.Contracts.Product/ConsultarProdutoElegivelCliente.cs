using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente
{
    [DataContract]
    public class ConsultarProdutoElegivelClienteRequest : RequestBase
    {
        [DataMember]
        public long CodigoCliente
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutoElegivelClienteResponse : ResponseBase
    {
        [DataMember]
        public List<ConsultarProdutoElegivelClienteProdutoDTO> Produtos
        { get; set; }

        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }
    }

    [DataContract]
    public class ConsultarProdutoElegivelClienteProdutoDTO : DTOBase
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

        /// <summary>
        /// Retorna o Tipo do Grupo de Produto
        /// </summary>
        [DataMember]
        public string TipoGrupoProduto
        { get; set; }
    }
}
