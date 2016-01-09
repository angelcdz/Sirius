using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada
{
    [DataContract]
    public class HabilitarDesabilitarVendaDigitadaRequest : RequestBase
    {
        /// <summary>
        /// Codigo do cliente
        /// </summary>
        [DataMember]
        public long? CodigoCliente { get; set; }

        /// <summary>
        /// Indica a operacao a ser executada, sendo "H" para habilitação ou "D" para desabilitação
        /// </summary>
        [DataMember]
        public string IndicaOperacao { get; set; }

        /// <summary>
        /// Número do protocolo
        /// </summary>
        [DataMember]
        public string Protocolo { get; set; }

        /// <summary>
        /// Origem da requisição
        /// </summary>
        [DataMember]
        public string Origem { get; set; }

        /// <summary>
        /// Lista com os dados de venda digitada
        /// </summary>
        [DataMember]
        public List<HabilitarDesabilitarVendaDigitadaDTO> DadosVendaDigitada { get; set; }

        /// <summary>
        /// Protocolo + contador de ocorrência
        /// </summary>
        [DataMember]
        public string TituloDaOcorrencia
        { get; set; }
        
        /// <summary>
        /// Número do Account
        /// </summary>
        [DataMember]
        public string Cliente
        { get; set; }

        /// <summary>
        /// Ilha de atendimento
        /// </summary>
        [DataMember]
        public string IlhaDeAtendimento
        { get; set; }

        /// <summary>
        /// Canal de atendimento
        /// </summary>
        [DataMember]
        public string CanalDeAtendimento
        { get; set; }

        /// <summary>
        /// Tipo de processo de atendimento
        /// </summary>
        [DataMember]
        public string CaseType
        { get; set; }

        /// <summary>
        /// Tipo de solicitação
        /// </summary>
        [DataMember]
        public string ArvoreDeAssunto
        { get; set; }

        /// <summary>
        /// ID da ocorrência de atendimento
        /// </summary>
        [DataMember]
        public string ParentCaseId
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }

        /// <summary>
        /// References the demand that the case and request will be open for
        /// </summary>
        [DataMember]
        public Guid IdDemanda
        { get; set; }
    }

    [DataContract]
    public class HabilitarDesabilitarVendaDigitadaResponse : ResponseBase 
    {
        /// <summary>
        /// Data de SLA retornada pelo serviço
        /// </summary>
        [DataMember]
        public DateTime? DataPrevistaConclusaoSolicitacao { get; set; }

        /// <summary>
        /// Status retornado pelo OSB
        /// </summary>
        [DataMember]
        public string StatusRetorno
        { get; set; }

        /// <summary>
        /// Sigla Sistema responsável
        /// </summary>
        [DataMember]
        public string SistemaLegado { get; set; }

        /// <summary>
        /// Código Solicitação Sistema Legado
        /// </summary> 
        [DataMember]
        public string CodigoSolicitacao { get; set; }
    }

    [DataContract]
    public class HabilitarDesabilitarVendaDigitadaDTO : DTOBase
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        [DataMember]
        public string CodigoProduto { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        [DataMember]
        public string NomeProduto { get; set; }

        /// <summary>
        /// Indica se é para adicionar ou remover um produto para a venda digitada, "S" ou "N"
        /// </summary>
        [DataMember]
        public string IndicaAcao { get; set; }
    }
}
