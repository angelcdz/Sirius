using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarInformacaoesPatAleloBaseCliente
{

    [DataContract]
    public class ConsultarInformacoesPatAleloBaseClienteResponse : ResponseBase
    {
        /// <summary>
        /// Item Name = 24 horas
        /// </summary>
        [DataMember]
        public bool Aberto24Horas
        { get; set; }

        /// <summary>
        /// Item Name = Domingo
        /// </summary>
        [DataMember]
        public bool Domingo
        { get; set; }

        /// <summary>
        /// Item Name = Horário comercial
        /// </summary>
        [DataMember]
        public bool HorarioComercial
        { get; set; }

        /// <summary>
        /// Item Name = Noturno
        /// </summary>
        [DataMember]
        public bool Noturno
        { get; set; }

        /// <summary>
        /// Item Name = Outros
        /// </summary>
        [DataMember]
        public bool Outros
        { get; set; }

        /// <summary>
        /// Item Name = Padaria
        /// </summary>
        [DataMember]
        public bool Padaria
        { get; set; }

        /// <summary>
        /// Item Name = Sábado
        /// </summary>
        [DataMember]
        public bool Sabado
        { get; set; }

        /// <summary>
        /// Item Name = Segunda a Sexta
        /// </summary>
        [DataMember]
        public bool SegundaSexta
        { get; set; }

    }

}
