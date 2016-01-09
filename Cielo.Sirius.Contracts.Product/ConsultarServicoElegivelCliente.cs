using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente
{

    [DataContract]
    public class ConsultarServicoElegivelClienteRequest : RequestBase
    {
        /// <summary>
        /// Obter informações do cliente, mesmo que Código do estabelecimento comercial
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

    }

    [DataContract]
    public class ConsultarServicoElegivelClienteResponse : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<ConsultarServicoClienteElegivelServicoDTO> Servicos
        { get; set; }

        /// <summary>
        /// Se posicionará ao lado de cada opção no filtro de pesquisa de serviço
        /// </summary>
        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }

    }

    [DataContract]
    public class ConsultarServicoClienteElegivelServicoDTO : DTOBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoServico
        { get; set; }

        /// <summary>
        /// Grid "Resultados da Pesquisa de Serviços"
        /// </summary>

        [DataMember]
        public string NomeServico
        { get; set; }

        /// <summary>
        /// Ao lado do label "Descrição" na tela "Detalhes do Serviço"
        /// </summary>
        [DataMember]
        public string DescricaoServico
        { get; set; }

        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }

        /// <summary>
        /// Ao lado do label "Vantagens" na tela "Detalhes do Serviço"
        /// </summary>
        [DataMember]
        public string Vantagem
        { get; set; }
    }
}
