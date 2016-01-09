using Cielo.Sirius.Business.Products;
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
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Contracts.GetEnabledServiceRequestTypes;
using Cielo.Sirius.Contracts.GetNonEligibleProductRequestTypes;
using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Contracts.GetServiceRequestsHistory;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.Contracts.HabilitarServico;
using Cielo.Sirius.Contracts.HabilitarPrazoFlexivel;
using Cielo.Sirius.Contracts.Products;
using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.Contracts.SolicitarNegociacaoTaxa;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cielo.Sirius.Contracts.GetRequestReason;
using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Contracts.AlterarProdutoAVista;
using Cielo.Sirius.Contracts.CalcularAlcadaFaixasParceladoSegmentado;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParcelado;
using Cielo.Sirius.Contracts.ConsultarDadosNegociacao;
using Cielo.Sirius.Contracts.NegociacaoComercial;

namespace Cielo.Sirius.Integration.OutboundService
{
    public class ProdutosService : ServiceBase, IProdutosService
    {
        public ConsultarInformacoesPatAleloResponse ConsultarInformacoesPatAleloCliente(ConsultarInformacoesPatAleloRequest requestData)
        {
            var business = new ConsultarInformacoesPatAleloBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarProdutoHabilitadoClienteResponse ConsultarProdutoHabilitadoCliente(ConsultarProdutoHabilitadoClienteRequest requestData)
        {
            var business = new ConsultarProdutoHabilitadoClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarDetalheProdutoHabilitadoClienteResponse ConsultarDetalheProdutoHabilitadoCliente(ConsultarDetalheProdutoHabilitadoClienteRequest requestData)
        {
            var business = new ConsultarDetalheProdutoHabilitadoClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarProdutoElegivelClienteResponse ConsultarProdutoElegivelCliente(ConsultarProdutoElegivelClienteRequest requestData)
        {
            var business = new ConsultarProdutoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarDetalheProdutoElegivelClienteResponse ConsultarDetalheProdutoElegivelCliente(ConsultarDetalheProdutoElegivelClienteRequest requestData)
        {
            var business = new ConsultarDetalheProdutoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarProdutoNaoElegivelClienteResponse ConsultarProdutoNaoElegivelCliente(ConsultarProdutoNaoElegivelClienteRequest requestData)
        {
            var business = new ConsultarProdutoNaoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarDetalheProdutoNaoElegivelClienteResponse ConsultarDetalheProdutoNaoElegivelCliente(ConsultarDetalheProdutoNaoElegivelClienteRequest requestData)
        {
            var business = new ConsultarDetalheProdutoNaoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetProductRequestsHistoryResponse GetProductRequestsHistory(GetProductRequestsHistoryRequest requestData)
        {
            var business = new GetProductRequestsHistoryBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetEnabledProductRequestTypesResponse GetProductRequestTypesEnabled(GetEnabledProductRequestTypesRequest requestData)
        {
            var business = new GetProductRequestTypesEnabledBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetEnabledServiceRequestTypesResponse GetServiceRequestTypesEnabled(GetEnabledServiceRequestTypesRequest requestData)
        {
            var business = new GetServiceRequestTypesEnabledBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetNonEnabledServiceRequestTypesResponse GetServiceRequestTypesNonEnabled(GetNonEnabledServiceRequestTypesRequest requestData)
        {
            var business = new GetServiceRequestTypesNonEnabledBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetNonEligibleServiceRequestTypesResponse GetServiceRequestTypesNonElegible(GetNonEligibleServiceRequestTypesRequest requestData)
        {
            var business = new GetServiceRequestTypesNonElegibleBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetNonEnabledProductRequestTypesResponse GetProductRequestTypesNonEnabled(GetNonEnabledProductRequestTypesRequest requestData)
        {
            var business = new GetProductRequestTypesNonEnabledBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetNonEligibleProductRequestTypesResponse GetProductRequestTypesNonEligible(GetNonEligibleProductRequestTypesRequest requestData)
        {
            var business = new GetProductRequestTypesNonEligibleBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarPrazoPadraoResponse ConsultarPrazoPadrao(ConsultarPrazoPadraoRequest requestData)
        {
            var business = new ConsultarPrazoPadraoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetDiscountRateRestrictionResponse GetDiscountRateRestriction(GetDiscountRateRestrictionRequest requestData)
        {
            var business = new GetDiscountRateRestrictionBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public AlterarParcelaFaixaProdutoResponse AlterarTaxa(AlterarParcelaFaixaProdutoRequest requestData)
        {
            var business = new AlterarParcelaFaixaProdutoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public SolicitarNegociacaoTaxaResponse SolicitarNegociacaoTaxaProdutoComercial(SolicitarNegociacaoTaxaRequest requestData)
        {
            var business = new SolicitarNegociacaoTaxaBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public HabilitarPrazoFlexivelResponse ManterPrazoFlexivel(HabilitarPrazoFlexivelRequest requestData)
        {
            var business = new ManterPrazoFlexivelBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarProdutosPrazoFlexivelResponse ConsultarProdutosPrazoFlexivel(ConsultarProdutosPrazoFlexivelRequest requestData)
        {
            var business = new ConsultarProdutosPrazoFlexivelBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public HabilitarDesabilitarVendaDigitadaResponse HabilitarDesabilitarVendaDigitada(HabilitarDesabilitarVendaDigitadaRequest requestData)
        {
            var business = new HabilitarDesabilitarVendaDigitadaBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public SolicitarExclusaoProdutoResponse SolicitarExclusaoProduto(SolicitarExclusaoProdutoRequest requestData)
        {
            var business = new SolicitarExclusaoProdutoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarDetalheProdutoMultivanContratadoClienteResponse ConsultarDetalheProdutoMultivanContratadoCliente(ConsultarDetalheProdutoMultivanContratadoClienteRequest requestData)
        {
            var business = new ConsultarDetalheProdutoMultivanContratadoClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public SolicitaAnaliseAlvaraResponse SolicitaAnaliseAlvara(SolicitaAnaliseAlvaraRequest requestData)
        {
            var business = new SolicitaAnaliseAlvaraBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public HabilitarProdutoResponse HabilitarProduto(HabilitarProdutoRequest requestData)
        {
            var business = new HabilitarProdutoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarServicoElegivelClienteResponse ConsultarServicoElegivelCliente(ConsultarServicoElegivelClienteRequest requestData)
        {
            var business = new ConsultarServicoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarServicoNaoElegivelClienteResponse ConsultarServicoNaoElegivelCliente(ConsultarServicoNaoElegivelClienteRequest requestData)
        {
            var business = new ConsultarServicoNaoElegivelClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarServicoHabilitadoClienteResponse ConsultarServicoHabilitadoCliente(ConsultarServicoHabilitadoClienteRequest requestData)
        {
            var business = new ConsultarServicoHabilitadoClienteBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ValidarPermissaoVendaDigitadaResponse ValidarPermissaoVendaDigitiada(ValidarPermissaoVendaDigitadaRequest requestData)
        {
            var business = new ValidarPermissaoVendaDigitadaBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public HabilitarServicoResponse HabilitarServico(HabilitarServicoRequest requestData)
        {
            var business = new HabilitarServicoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public DesabilitarServicoResponse DesabilitarServico(DesabilitarServicoRequest requestData)
        {
            var business = new DesabilitarServicoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public DesabilitarProdutoResponse DesabilitarProduto(DesabilitarProdutoRequest requestData)
        {
            var business = new DesabilitarProdutoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public ConsultarPrazosTaxasPrazoFlexivelResponse ConsultarPrazosTaxasPrazoFlexivel(ConsultarPrazosTaxasPrazoFlexivelRequest requestData)
        {
            var business = new ConsultarPrazosTaxasPrazoFlexivelBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public GetServiceRequestsHistoryResponse GetServiceRequestsHistory(GetServiceRequestsHistoryRequest requestData)
        {
            var business = new GetServiceRequestsHistoryBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public Contracts.GetRequestReason.GetRequestReasonResponse GetRequestReason(GetRequestReasonRequest requestData)
        {
            var business = new GetRequestReasonBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public AlterarProdutoCreditoParceladoSegmentadoResponse AlterarProdutoCreditoParceladoSegmentado(AlterarProdutoCreditoParceladoSegmentadoRequest requestData)
        {
            var business = new AlterarProdutoCreditoParceladoSegmentadoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }


        public CalcularAlcadaFaixasParceladoSegmentadoResponse CalcularAlcadaFaixasParceladoSegmentado(CalcularAlcadaFaixasParceladoSegmentadoRequest requestData)
        {
            var business = new CalcularAlcadaFaixasParceladoSegmentadoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public AlterarProdutoAVistaResponse AlterarProdutoAVista(AlterarProdutoAVistaRequest requestData)
        {
            var business = new ChangeProductOneLumpBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }

        public AlterarProdutoCreditoParceladoResponse AlterarProdutoCreditoParcelado(AlterarProdutoCreditoParceladoRequest requestData)
        {
            var business = new AlterarProdutoCreditoParceladoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }


        public ConsultarDadosNegociacaoResponse ConsultarDadosNegociacao(ConsultarDadosNegociacaoRequest requestData)
        {
            var business = new ConsultarDadosNegociacaoBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }


        public NegociacaoComercialResponse NegociacaoComercial(NegociacaoComercialRequest requestData)
        {
            var business = new NegociacaoComercialBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }


        public Contracts.GetCommercialDealRequestTypes.GetCommercialDealRequestTypesResponse GetCommercialDealRequestTypes(Contracts.GetCommercialDealRequestTypes.GetCommercialDealRequestTypesRequest requestData)
        {
            var business = new GetCommercialDealRequestTypesBL();
            var response = this.ExecuteBusiness(business, requestData);
            return response;
        }
    }
}
