using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo
{
    #region Request
    [DataContract]
    public class ConsultarInformacoesPatAleloRequest : RequestBase
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
    public class ConsultarInformacoesPatAleloResponse : ResponseBase
    {
        

            
        [DataMember]
        public PatAleloAlimentacaoDTO DadosAlimentacao
        {get; set;}

        [DataMember]
        public PatAleloRefeicaoDTO DadosRefeicao
        { get; set; }


    }
    #endregion

    #region DTO Alimentacao
    /// <summary>
    /// As informações devem ser posicionadas na tela na seguinte ordem: Checkouts loja, supermercado, armazem, laticinio-frios, segunda a sexta, area de atendimento, sabado, domingo, hipermercado, 
    /// açougue, outros, comercial, noturno, 24 horas, hortimercado, peixaria, apresenta cartão, delivery, internet, mercearia, padaria
    /// </summary>
    [DataContract]
    public class PatAleloAlimentacaoDTO : DTOBase
    {
        /// <summary>
        /// Item name = Checkouts loja - Posicionamento na tela: Primeiro campo do componemte Informações Pat Alelo -  Alimentação
        /// </summary>
        [DataMember]
        public string CheckOutsLoja
        { get; set; }

        /// <summary>
        /// Item nane = Açougue - Posicionamento na tela: Depois de Hipermercado, antes de Outros
        /// </summary>
        [DataMember]
        public bool Acougue
        { get; set; }

        /// <summary>
        /// Item Name = Armazem - Posicionamento na tela: Depois de Supermercado, antes de Laticionio-Frios
        /// </summary>
        [DataMember]
        public bool Armazem
        { get; set; }

        /// <summary>
        /// Item Name = Supermercado - Posicionamento na tela: Depois de Domingo, Antes de Açougue
        /// </summary>
        [DataMember]
        public bool Hipermercado
        { get; set; }

        /// <summary>
        /// Item name = Hortimercado - Posicionamento na tela: Depois de 24 Horas, antes de Peixaria
        /// </summary>
        [DataMember]
        public bool Hortimercado
        { get; set; }

        /// <summary>
        /// Item Name = Laticínio-Frios - Posicionamento na tela: Depois de Armazem, antes de Segunda a Sexta
        /// </summary>
        [DataMember]
        public bool LaticinioFrios
        { get; set; }

        /// <summary>
        /// Item name = Mercearia - Posicionamento na tela:  Depois de internet, antes de Padaria
        /// </summary>
        [DataMember]
        public bool Mercearia
        { get; set; }

        /// <summary>
        /// Item name = Peixaria - Posicionamento na tela: Depois de hortimercado, antes de Apresenta Cartão
        /// </summary>
        [DataMember]
        public bool Peixaria
        { get; set; }

        /// <summary>
        /// Item name = Supermercado - Posicionamento na tela: Depois de Checkouts loja, antes de Armazem
        /// </summary>
        [DataMember]
        public bool Supermercado
        { get; set; }

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

         /// <summary>
        /// Não aparece essa informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public long? CodigoCliente
        { get; set; }

        /// <summary>
        /// Não aparece essa informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public string CodigoProduto
        { get; set; }

       
        /// <summary>
        /// Item Name = Afiliação
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DataAfiliacao
        { get; set; }

        /// <summary>
        /// Item Name = Apresenta Cartão
        /// Posicionamento na tela: Depois de Peixaria, antes de Delivery
        /// </summary>
        [DataMember]
        public string IndicadorApresentacaoCartao
        { get; set; }

        /// <summary>
        /// Item name = Delivery
        /// Posicionamento na tela: Depois de Apresenta Cartão, antes de internet
        /// </summary>
        [DataMember]
        public string IndicadorServicoDelivery
        { get; set; }

        /// <summary>
        /// Internet
        /// Posicionamento na tela: Depois de Delivery, antes de mercearia
        /// </summary>
        [DataMember]
        public string IndicadorVendaInternet
        { get; set; }

        /// <summary>
        /// Area de atendimento - Posicionamento na tela: Depois de segunda a sexta, antes de Sabado
        /// </summary>
        [DataMember]
        public string ValorAreaAtendimentoPublico
        { get; set; }
    }

    #endregion

    #region DTO Refeicao
    /// <summary>
    /// As informações devem ser posicionadas na tela na seguinte ordem: Maximo de refeições, Numero de mesa, Numero de assentos, Area de atendimento, Lanchonete, Afiliação,
    /// Segunda a sexta, sabado, domingo, restaurante, padaria, comercial, Noturno, 24 horas, fast food, outros, apresenta cartão, delivery, internet, bar
    /// </summary>
    [DataContract]
    public class PatAleloRefeicaoDTO : DTOBase
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

         /// <summary>
        /// Não aparece essa informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public long? CodigoCliente
        { get; set; }

        /// <summary>
        /// Não aparece essa informação no IAD
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// </summary>
        [DataMember]
        public string CodigoProduto
        { get; set; }


        /// <summary>
        /// Item Name = Afiliação
        /// Posicionamento na tela: Não é mostrado no WireFrame
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DataAfiliacao
        { get; set; }

        /// <summary>
        /// Item Name = Apresenta Cartão
        /// Posicionamento na tela: Depois de Peixaria, antes de Delivery
        /// </summary>
        [DataMember]
        public string IndicadorApresentacaoCartao
        { get; set; }

        /// <summary>
        /// Item name = Delivery
        /// Posicionamento na tela: Depois de Apresenta Cartão, antes de internet
        /// </summary>
        [DataMember]
        public string IndicadorServicoDelivery
        { get; set; }

        /// <summary>
        /// Internet
        /// Posicionamento na tela: Depois de Delivery, antes de mercearia
        /// </summary>
        [DataMember]
        public string IndicadorVendaInternet
        { get; set; }

        /// <summary>
        /// Não aparece essa informação no IAD - Posicionamento na tela: Não é mostrado no wireFrame
        /// </summary>
        [DataMember]
        public string QuantidadeDeAssento
        { get; set; }

        /// <summary>
        /// Não aparece essa informação no IAD - Posicionamento na tela: Não é mostrado no wireFrame
        /// </summary>
        [DataMember]
        public string QuantidadeDeMaximaRefeicao
        { get; set; }

        /// <summary>
        /// Não aparece essa informação no IAD -  Posicionamento na tela: Não é mostrado no wireFrame
        /// </summary>
        [DataMember]
        public string QuantidadeDeMesa
        { get; set; }

        /// <summary>
        /// Area de atendimento - Posicionamento na tela: Depois de segunda a sexta, antes de Sabado
        /// </summary>
        [DataMember]
        public string ValorAreaAtendimentoPublico
        { get; set; }
    }

    #endregion

}

