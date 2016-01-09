using Cielo.Sirius.Foundation;
using System;
using System.Runtime.Serialization;

namespace Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada
{
    [DataContract]
    public class ValidarPermissaoVendaDigitadaRequest : RequestBase
    {
        [DataMember]
        /// <summary>
        /// Representa o Codigo do Cliente / Estabelecimento Comercial
        /// </summary>
        public long CodigoCliente
        { get; set; }

        [DataMember]
        /// <summary>
        /// Representa o Ramo de atividade / MCC
        /// </summary>
        public string CodigoRamoAtividade
        { get; set; }

        [DataMember]
        /// <summary>
        /// Indica ação (H – Habilitado / D – Desabilitado)
        /// </summary>
        public string IndicaOperacao
        { get; set; }

        /// <summary>
        /// Representa o motivo selecionado para cada tipo de demanda
        /// </summary>
        [DataMember]
        public Guid IdMotivo
        { get; set; }
    }

    [DataContract]
    public class ValidarPermissaoVendaDigitadaResponse : ResponseBase
    {
        [DataMember]
        /// <summary>
        /// •	Tipo de Mensagem (E - Erro / A - Alerta)
        /// </summary>
        public string TipoDeMensagem 
        { get; set; }
    }
}
