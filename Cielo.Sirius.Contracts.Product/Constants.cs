using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Contracts
{
    public sealed class Constants
    {
        /// <summary>
        /// Private contructor to avoid object construction
        /// </summary>
        private Constants()
        {
        }

        //INDICADOR PARA AGRUPAR PRODUTO POR CREDITO, PARCELADO, PARCELADO SEGMENTADO
        //'1' - CREDITO
        //'2' - PRE DATADO
        //'3' - PARCELADO
        //'4' - PARCELADO SEGMENTADO
        public const string TIPOGRUPOPRODUTO_CREDITO = "1";
        public const string TIPOGRUPOPRODUTO_PREDATADO = "2";
        public const string TIPOGRUPOPRODUTO_PARCELADO = "3";
        public const string TIPOGRUPOPRODUTO_SEGMENTADO = "4";

        // Contexto CRM
        public const string CONTEXTOCRM_CLIENTID = "ECNumber";
        public const string CONTEXTOCRM_ILHADEATENDIMENTO = "SourceAgentGroup";
        public const string CONTEXTOCRM_PROTOCOLO = "Protocol";
        public const string CONTEXTOCRM_NOMECONTATO = "NOMECONTATO";
        public const string CONTEXTOCRM_TITULOCORRENCIA = "TITULOOCORRENCIA";
        public const string CONTEXTOCRM_TELEFONE = "TELEFONE";
        public const string CONTEXTOCRM_CELULAR = "CELULAR";
        public const string CONTEXTOCRM_ACCOUNT = "ACCOUNT";
        public const string CONTEXTOCRM_PARENTCASEID = "PARENTCASEID";
        public const string CONTEXTOCRM_CONTACTID = "CONTACTID";

        public const string GRUPO_PRODUTO_ELEGIVEL_HABILITADO = "791880020"; //"GrupoProdutoElegivelHabilitado";
        public const string GRUPO_PRODUTO_ELEGIVEL_NAOHABILITADO = "791880040"; //"GrupoProdutoElegivelNaoHabilitado";
        public const string GRUPO_PRODUTO_NAOELEGIVEL = "GrupoProdutoNaoElegivel";

        public const string GRUPO_SERVICO_ELEGIVEL_HABILITADO = "791880050"; //"GrupoServicoElegivelHabilitado";
        public const string GRUPO_SERVICO_ELEGIVEL_NAOHABILITADO = "791880060"; //"GrupoServicoElegivelNaoHabilitado";
        public const string GRUPO_SERVICO_NAOELEGIVEL = "GrupoServicoNaoElegivel";

        public const int TIPO_SOLICITACAO_PRODUTO_ALTERACAODETAXA = 0001;
        public const int TIPO_SOLICITACAO_PRODUTO_SOLICITACAODENEGOCIACAODETAXA = 0002;
        public const int TIPO_SOLICITACAO_PRODUTO_HABILITARPRODUTO = 0003;
        public const int TIPO_SOLICITACAO_PRODUTO_DESABILITARPRODUTO = 0004;
        public const int TIPO_SOLICITACAO_PRODUTO_HABILITARPRAZOFLEXIVEL = 0005;
        public const int TIPO_SOLICITACAO_PRODUTO_DESABILITARPRAZOFLEXIVEL = 0006;
        public const int TIPO_SOLICITACAO_PRODUTO_ALTERARPRAZOFLEXIVEL = 0007;

        //Tipo Produto PAT Alelo
        public const string TIPO_PRODUTO_PAT_ALELO_ALIMENTACAO = "66";
        public const string TIPO_PRODUTO_PAT_ALELO_REFEICAO = "65";
        public const string CODIGO_BANDEIRA_PAT_ALELO = "7";

        //Tipo de cobranca multivan
        public const string TIPO_COBRANCA_MULTIVAN = "MULTIVAN";

        //Tipo de demanda de produto (código de integração da requisição)
        public const int TIPO_DEMANDA_PRD_HABILITAR_VENDA_DIGITADA = 1005;
        public const int TIPO_DEMANDA_PRD_DESABILITAR_VENDA_DIGITADA = 1006;
        public const int TIPO_DEMANDA_PRD_SOLICITAR_NEGOCIACAO_DE_TAXA = 1004;
        public const int TIPO_DEMANDA_PRD_HABILITAR_PRAZO_FLEXIVEL = 1009;
        public const int TIPO_DEMANDA_PRD_DESABILITAR_PRAZO_FLEXIVEL = 1010;
        public const int TIPO_DEMANDA_PRD_ALTERAR_PRAZO_FLEXIVEL = 1011;
        public const int TIPO_DEMANDA_PRD_ANALISE_DOCUMENTACAO = 1008;
        public const int TIPO_DEMANDA_PRD_DESABILITARPRODUTO = 1007;
        public const int TIPO_DEMANDA_PRD_ALTERAR_PRODUTO = 1001;
        
        //Tipo de demanda de serviço (código de integração da requisição)
        public const int TIPO_DEMANDA_SVC_HABILITAR_SERVICO = 2001;
        public const int TIPO_DEMANDA_SVC_DESABILITAR_SERVICO = 2002;

        //Período de carência Data de Filiação - Habilitar Prazo Flexível
        public const int CARENCIA_DATA_FILIACAO = 3;

        public const string RETURN_CODE_SEC_SUCCESS = "0";
    }
}
