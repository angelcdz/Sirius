using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarInformacoesPatAleloRefeicao
{
    #region Request
    [DataContract]
    public class ConsultarInformacoesPatAleloRefeicaoClienteRequest : RequestBase
    {
        /// <summary>
        /// Mesmo que EC Number
        /// </summary>
        [DataMember]
        public long? CodigoCliente
        { get; set; }
    }
    #endregion

    #region Response
    [DataContract]
    public class ConsultarInformacoesPatAleloRefeicaoClienteResponse : ResponseBase
    {
        /// <summary>
        /// Lista
        /// </summary>
        [DataMember]
        public List<ConsultarInformacoesPatAleloRefeicaoClienteDTO> DadosTipoEstabelecimentoVVR
        { get; set; }

   
        [DataMember]
        public DadosPatAlelo dadospataleloVR
        { get; set; }


        [DataMember]
        public PatAlelo pataleloVR
        { get; set; }

    }
    #endregion

    #region DTO
    /// <summary>
   /// As informações devem ser posicionadas na tela na seguinte ordem: Maximo de refeições, Numero de mesa, Numero de assentos, Area de atendimento, Lanchonete, Afiliação,
   /// Segunda a sexta, sabado, domingo, restaurante, padaria, comercial, Noturno, 24 horas, fast food, outros, apresenta cartão, delivery, internet, bar
   /// </summary>
    [DataContract]
    public class ConsultarInformacoesPatAleloRefeicaoClienteDTO : DTOBase
    {
        /// <summary>
        /// Item Name =  Bar
        /// </summary>
        [DataMember]
        public bool Bar
        { get; set; }

        /// <summary>
        /// Item Name = FastFood
        /// </summary>
        [DataMember]
        public bool FastFood
        { get; set; }

        /// <summary>
        /// Item Name = Lanchonete
        /// </summary>
        [DataMember]
        public bool Lanchonete
        { get; set; }

        /// <summary>
        /// Item Name = Restaurante
        /// </summary>
        [DataMember]
        public bool Restaurante
        { get; set; }
    }

    #endregion

    #region Classe PatAlelo

    [DataContract]
    public class PatAlelo
    {
        /// <summary>
        /// Não aparece informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public long? CodigoCliente
        { get; set; }

        /// <summary>
        /// Não Aparece Informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public string CodigoProduto
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DadosLojaFisica dadosLojaFisica
        { get; set; }

        /// <summary>
        /// Item Name = Afiliação
        /// </summary>
        [DataMember]
        public DateTime? DataAfiliacao
        { get; set; }

        /// <summary>
        /// Item Name = Apresenta Cartão
        /// </summary>
        [DataMember]
        public string IndicadorApresentacaoCartao
        { get; set; }

        /// <summary>
        /// Item Name = Delivery
        /// </summary>
        [DataMember]
        public string IndicadorServicoDelivery
        { get; set; }

        /// <summary>
        /// Item Name = Internet
        /// </summary>
        [DataMember]
        public string IndicadorVendaInternet
        { get; set; }
    }

    #endregion

    #region Classe DadosPatAlelo

    [DataContract]
    public class DadosPatAlelo
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
    #endregion

    #region Classe DadosLojaFisica
    [DataContract]
    public class DadosLojaFisica
    {
        /// <summary>
        /// Item Name = Numero de assentos
        /// </summary>
        [DataMember]
        public string QuantidadeDeAssento
        { get; set; }

        /// <summary>
        /// Item Name = Máximo de refeições
        /// </summary>
        [DataMember]
        public string QuantidadeDeMaximaRefeicao
        { get; set; }

        /// <summary>
        /// Item Name = Numero de mesas
        /// </summary>
        [DataMember]
        public string QuantidadeDeMesa
        { get; set; }

        /// <summary>
        /// Item Name = Area de atendimento
        /// </summary>
        [DataMember]
        public string ValorAreaAtendimentoPublico
        { get; set; }
    }
#endregion
}
