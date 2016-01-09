using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.SolicitaAnaliseAlvara
{
    [DataContract]
    public class SolicitaAnaliseAlvaraRequest : RequestBase
    {
        [DataMember]
        /// <summary>
        /// Representa o Número do Protocolo da Solicitação
        /// </summary>
        public string Protocolo 
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Número do EC do cliente
        /// </summary>
        public long CodigoCliente 
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Número de Telefone de Contato
        /// </summary>
        public string NumeroTelefoneContato
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Nome do Contato
        /// </summary>
        public string NomeContato
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Email Principal do Contato
        /// </summary>
        public string NomeEmailContato 
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Status do Estabelecimento Comercial
        /// </summary>
        public string CodigoSituacaoCliente 
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Nome do Proprietário
        /// </summary>
        public string NomeProprietario 
        { get; set; }

      
    }

    [DataContract]
    public class SolicitaAnaliseAlvaraResponse : ResponseBase 
    {
        [DataMember]
        /// <summary>
        ///Status do Retorno, informação utilizada para o componente “Retorno da Abertura das Demandas”
        /// </summary>
        public string StatusRetorno
        { get; set; }

        [DataMember]
        /// <summary>
        ///Descricao Sistema legado
        /// </summary>
        public string SistemaLegado
        { get; set; }

        [DataMember]
        /// <summary>
        ///Contém o Código de Solicitação e Data Prevista para a Conclusão
        /// </summary>
        public SolicitaAnaliseAlvaraDTO SolicitacaoCentralAtendimento
        { get; set; }

        /// <summary>
        ///Código Retorno Serviço
        /// </summary>
        [DataMember]
        public string CodigoRetorno
        { get; set; }

         /// <summary>
        ///Descrição Retorno Mensagem
        /// </summary>
        [DataMember]
        public string DescricaoRetornoMensagem
        { get; set; }
        

    }

    [DataContract]
    public class SolicitaAnaliseAlvaraDTO : DTOBase
    {
        /// <summary>
        /// Código da Solicitação
        /// </summary>
        [DataMember]
        public string CodigoSolicitacao { get; set; }

        /// <summary>
        /// Data Prevista de Conclusão da Solicitação
        /// </summary>
        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao { get; set; }
    
    
    }

}
