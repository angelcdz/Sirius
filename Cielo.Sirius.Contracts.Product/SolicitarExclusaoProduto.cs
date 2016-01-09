using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.SolicitarExclusaoProduto
{
    [DataContract]
    public class SolicitarExclusaoProdutoRequest : RequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Protocolo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public long? CodigoCliente { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoProduto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NomeSolicitante { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Origem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TelefoneSolicitante { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string MotivoSolicitacao { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }
    }

    [DataContract]
    public class SolicitarExclusaoProdutoResponse : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SistemaLegado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string StatusRetorno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SolicitarExclusaoProdutoDTO SolicitacaoCentralAtendimento { get; set; }
    }

    [DataContract]
    public class SolicitarExclusaoProdutoDTO : DTOBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoSolicitacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao { get; set; }
    }
}
