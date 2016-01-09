using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente
{
    [DataContract]
    public class ConsultarServicoNaoElegivelClienteRequest : RequestBase
    {
        /// <summary>
        /// Codigo do Cliente
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }

    }

    [DataContract]
    public class ConsultarServicoNaoElegivelClienteResponse : ResponseBase
    {
        /// <summary>
        /// Chave da Paginacao
        /// </summary>
        [DataMember]
        public String ChavePaginacao
        { get; set; }

        /// <summary>
        /// Numero Total de Registros
        /// </summary>
        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }

        /// <summary>
        /// Proximo Registro da Paginacao
        /// </summary>
        [DataMember]
        public String ProximoRegistro
        { get; set; }

        /// <summary>
        /// Lista de Servicos Nao Elegiveis Consultados
        /// </summary>
        [DataMember]
        public List<ConsultarServicoNaoElegivelClienteServicoDTO> Servicos
        { get; set; }

        

    }

    [DataContract]
    public class ConsultarServicoNaoElegivelClienteServicoDTO : DTOBase
    {
        /// <summary>
        /// Nome do Servico
        /// </summary>
        [DataMember]
        public String NomeServico
        { get; set; }

        /// <summary>
        /// Codigo do Servico
        /// </summary>
        [DataMember]
        public String CodigoServico
        { get; set; }

        /// <summary>
        /// Descricao do Servico
        /// </summary>
        [DataMember]
        public String DescricaoServico
        { get; set; }

        /// <summary>
        /// Indica se há demandas em aberto para o serviço no CRM
        /// </summary>
        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }

        /// <summary>
        /// Vantagem
        /// </summary>
        [DataMember]
        public String Vantagem
        { get; set; }
    }

}
