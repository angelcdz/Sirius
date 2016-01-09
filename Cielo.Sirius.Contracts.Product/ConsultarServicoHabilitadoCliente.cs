using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente
{
    [DataContract]
    public class ConsultarServicoHabilitadoClienteRequest : RequestBase
    {
        /// <summary>
        /// O Código do Cliente armazenado na Customer Session.
        /// </summary>
        [DataMember]
        public long CodigoCliente
        { get; set; }
    }

    [DataContract]
    public class ConsultarServicoHabilitadoClienteResponse : ResponseBase
    {
        /// <summary>
        /// Campo 'Data Última Transação' dos Detalhes do Serviço.
        /// </summary>
        [DataMember]
        public DateTime DataUltimaTransacao
        { get; set; }

        /// <summary>
        /// Utilizado apenas para validações em regras de negócio.
        /// </summary>
        [DataMember]
        public bool IndicadorVendaUltimoMes
        { get; set; }

        /// <summary>
        /// A quantidade total de registros da consulta. Informação exibida em frente ao label do RadioButton do filtro Elegíveis - Habilitados.
        /// </summary>
        [DataMember]
        public long NumeroTotalRegistros
        { get; set; }

        /// <summary>
        /// Conjunto de serviços habilitados obtidos como resposta.
        /// </summary>
        [DataMember]
        public List<ConsultarServicoHabilitadoClienteServicoDTO> Servicos
        { get; set; }
    }

    [DataContract]
    public class ConsultarServicoHabilitadoClienteServicoDTO : DTOBase
    {
        /// <summary>
        /// O código do serviço que deverá ser armazenado para uso interno.
        /// </summary>
        [DataMember]
        public string CodigoServico
        { get; set; }

        /// <summary>
        /// Campo 'Data Habilitação' dos Detalhes do Serviço.
        /// </summary>
        [DataMember]
        public DateTime? DataHabilitacaoServico
        { get; set; }

        /// <summary>
        /// Campo 'Descrição' dos Detalhes do Serviço.
        /// </summary>
        [DataMember]
        public string DescricaoServico
        { get; set; }

        /// <summary>
        /// O nome do serviço que será exibido na lista da Consulta de Serviços.
        /// </summary>
        [DataMember]
        public string NomeServico
        { get; set; }

        [DataMember]
        public bool IndicadorPossuiDemandasAbertas
        { get; set; }

        /// <summary>
        /// Campo 'Vantagem' dos Detalhes do Serviço.
        /// </summary>
        [DataMember]
        public string Vantagem
        { get; set; }
    }
}
