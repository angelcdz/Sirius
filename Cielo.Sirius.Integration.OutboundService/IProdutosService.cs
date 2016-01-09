using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Contracts.AlterarTaxasProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;
using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;
using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Contracts.GetNonEnabledProductRequestTypes;
using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.Contracts.HabilitarPrazoFlexivel;
using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Contracts.GetRequestReason;
using System.ServiceModel;
using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;
using Cielo.Sirius.Contracts.GetEnabledServiceRequestTypes;
using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Contracts.AlterarProdutoAVista;
using Cielo.Sirius.Contracts.CalcularAlcadaFaixasParceladoSegmentado;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParcelado;
using Cielo.Sirius.Contracts.ConsultarDadosNegociacao;
using Cielo.Sirius.Contracts.NegociacaoComercial;
using Cielo.Sirius.Contracts.GetCommercialDealRequestTypes;

namespace Cielo.Sirius.Integration.OutboundService
{
    [ServiceContract]
    public interface IProdutosService
    {

        [OperationContract]
        ConsultarInformacoesPatAleloResponse ConsultarInformacoesPatAleloCliente(ConsultarInformacoesPatAleloRequest requestData);

        [OperationContract]
        ConsultarProdutoHabilitadoClienteResponse ConsultarProdutoHabilitadoCliente(ConsultarProdutoHabilitadoClienteRequest requestData);

        [OperationContract]
        ConsultarDetalheProdutoHabilitadoClienteResponse ConsultarDetalheProdutoHabilitadoCliente(ConsultarDetalheProdutoHabilitadoClienteRequest requestData);

        [OperationContract]
        ConsultarProdutoElegivelClienteResponse ConsultarProdutoElegivelCliente(ConsultarProdutoElegivelClienteRequest requestData);

        [OperationContract]
        ConsultarDetalheProdutoElegivelClienteResponse ConsultarDetalheProdutoElegivelCliente(ConsultarDetalheProdutoElegivelClienteRequest requestData);

        [OperationContract]
        ConsultarProdutoNaoElegivelClienteResponse ConsultarProdutoNaoElegivelCliente(ConsultarProdutoNaoElegivelClienteRequest requestData);

        [OperationContract]
        ConsultarDetalheProdutoNaoElegivelClienteResponse ConsultarDetalheProdutoNaoElegivelCliente(ConsultarDetalheProdutoNaoElegivelClienteRequest requestData);

        [OperationContract]
        GetProductRequestsHistoryResponse GetProductRequestsHistory(GetProductRequestsHistoryRequest requestData);

        [OperationContract]
        GetServiceRequestsHistoryResponse GetServiceRequestsHistory(GetServiceRequestsHistoryRequest requestData);

        [OperationContract]
        GetEnabledProductRequestTypesResponse GetProductRequestTypesEnabled(GetEnabledProductRequestTypesRequest requestData);

        [OperationContract]
        GetEnabledServiceRequestTypesResponse GetServiceRequestTypesEnabled(GetEnabledServiceRequestTypesRequest requestData);

        [OperationContract]
        GetNonEnabledServiceRequestTypesResponse GetServiceRequestTypesNonEnabled(GetNonEnabledServiceRequestTypesRequest requestData);

        [OperationContract]
        GetNonEligibleServiceRequestTypesResponse GetServiceRequestTypesNonElegible(GetNonEligibleServiceRequestTypesRequest requestData);

        [OperationContract]
        GetNonEligibleProductRequestTypesResponse GetProductRequestTypesNonEligible(GetNonEligibleProductRequestTypesRequest requestData);

        [OperationContract]
        GetNonEnabledProductRequestTypesResponse GetProductRequestTypesNonEnabled(GetNonEnabledProductRequestTypesRequest requestData);

        [OperationContract]
        ConsultarPrazoPadraoResponse ConsultarPrazoPadrao(ConsultarPrazoPadraoRequest requestData);

        [OperationContract]
        AlterarParcelaFaixaProdutoResponse AlterarTaxa(AlterarParcelaFaixaProdutoRequest requestData);

        [OperationContract]
        SolicitarNegociacaoTaxaResponse SolicitarNegociacaoTaxaProdutoComercial(SolicitarNegociacaoTaxaRequest requestData);

        [OperationContract]
        GetDiscountRateRestrictionResponse GetDiscountRateRestriction(GetDiscountRateRestrictionRequest requestData);

        [OperationContract]
        HabilitarPrazoFlexivelResponse ManterPrazoFlexivel(HabilitarPrazoFlexivelRequest requestData);

        [OperationContract]
        HabilitarDesabilitarVendaDigitadaResponse HabilitarDesabilitarVendaDigitada(HabilitarDesabilitarVendaDigitadaRequest requestData);

        [OperationContract]
        SolicitarExclusaoProdutoResponse SolicitarExclusaoProduto(SolicitarExclusaoProdutoRequest requestData);

        [OperationContract]
        ConsultarServicoHabilitadoClienteResponse ConsultarServicoHabilitadoCliente(ConsultarServicoHabilitadoClienteRequest requestData);

        [OperationContract]
        ConsultarDetalheProdutoMultivanContratadoClienteResponse ConsultarDetalheProdutoMultivanContratadoCliente(ConsultarDetalheProdutoMultivanContratadoClienteRequest requestData);

        [OperationContract]
        SolicitaAnaliseAlvaraResponse SolicitaAnaliseAlvara(SolicitaAnaliseAlvaraRequest requestData);

        [OperationContract]
        HabilitarProdutoResponse HabilitarProduto(HabilitarProdutoRequest requestData);

        [OperationContract]
        ConsultarServicoElegivelClienteResponse ConsultarServicoElegivelCliente(ConsultarServicoElegivelClienteRequest requestData);

        [OperationContract]
        ConsultarServicoNaoElegivelClienteResponse ConsultarServicoNaoElegivelCliente(ConsultarServicoNaoElegivelClienteRequest requestData);

        [OperationContract]
        ValidarPermissaoVendaDigitadaResponse ValidarPermissaoVendaDigitiada(ValidarPermissaoVendaDigitadaRequest requestData);

        [OperationContract]
        HabilitarServicoResponse HabilitarServico(HabilitarServicoRequest requestData);

        [OperationContract]
        DesabilitarServicoResponse DesabilitarServico(DesabilitarServicoRequest requestData);

        [OperationContract]
        DesabilitarProdutoResponse DesabilitarProduto(DesabilitarProdutoRequest requestData);

        [OperationContract]
        ConsultarPrazosTaxasPrazoFlexivelResponse ConsultarPrazosTaxasPrazoFlexivel(ConsultarPrazosTaxasPrazoFlexivelRequest requestData);

        [OperationContract]
        ConsultarProdutosPrazoFlexivelResponse ConsultarProdutosPrazoFlexivel(ConsultarProdutosPrazoFlexivelRequest requestData);

        [OperationContract]
        GetRequestReasonResponse GetRequestReason(GetRequestReasonRequest requestData);

        [OperationContract]
        AlterarProdutoCreditoParceladoSegmentadoResponse AlterarProdutoCreditoParceladoSegmentado(AlterarProdutoCreditoParceladoSegmentadoRequest requestData);

        [OperationContract]
        AlterarProdutoAVistaResponse AlterarProdutoAVista(AlterarProdutoAVistaRequest requestData);

        [OperationContract]
        CalcularAlcadaFaixasParceladoSegmentadoResponse CalcularAlcadaFaixasParceladoSegmentado(CalcularAlcadaFaixasParceladoSegmentadoRequest requestData);

        [OperationContract]
        AlterarProdutoCreditoParceladoResponse AlterarProdutoCreditoParcelado(AlterarProdutoCreditoParceladoRequest requestData);

        [OperationContract]
        ConsultarDadosNegociacaoResponse ConsultarDadosNegociacao(ConsultarDadosNegociacaoRequest requestData);

        [OperationContract]
        NegociacaoComercialResponse NegociacaoComercial(NegociacaoComercialRequest requestData);

        [OperationContract]
        GetCommercialDealRequestTypesResponse GetCommercialDealRequestTypes(GetCommercialDealRequestTypesRequest requestData);
    }
}
