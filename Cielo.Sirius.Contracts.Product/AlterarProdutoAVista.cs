using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.AlterarProdutoAVista
{

    [DataContract]
    public class AlterarProdutoAVistaRequest : RequestBase
    {
        #region Common Request Parameters
        
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }

        [DataMember]
        public decimal? PercentualTaxa
        { get; set; }

        [DataMember]
        public string Protocolo
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
    public class AlterarProdutoAVistaResponse : ResponseBase
    {

        [DataMember]
        public string SistemaLegado
        { get; set; }

        [DataMember]
        public AlterarProdutoAVistaSolicitacaoDTO Solicitacao
        { get; set; }

    }

    [DataContract]
    public class AlterarProdutoAVistaSolicitacaoDTO : DTOBase
    {
        [DataMember]
        public string CodigoSolicitacao
        { get; set; }

        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao
        { get; set; }
    }

}