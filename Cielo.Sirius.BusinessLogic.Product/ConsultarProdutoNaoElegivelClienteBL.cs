using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarProdutoNaoElegivelCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Contracts.ExistsProductOpenDemand;
using Cielo.Sirius.Contracts;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarProdutoNaoElegivelClienteBL : BusinessLogicBase<ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>
    {
        public override ConsultarProdutoNaoElegivelClienteResponse Execute(ConsultarProdutoNaoElegivelClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarProdutoNaoElegivelClienteDAO, ConsultarProdutoNaoElegivelClienteRequest, ConsultarProdutoNaoElegivelClienteResponse>();

            ConsultarProdutoNaoElegivelClienteResponse response = dao.Execute(requestData);

            //[Rule]: If Status is false, means an infrastructure or business error, return immediately with no processing
            if (response.Status == ExecutionStatus.Success)
            {
                //[Rule]: get open demands (CRM)
                var responseCRM = GetIfExistsProductOpenRequests(requestData, response);

                foreach (var produto in response.Produtos)
                {
                    //[Rule]: Parcelas SEGMENTADO e Percentual Taxa
                    if (produto.TipoGrupoProduto == Constants.TIPOGRUPOPRODUTO_SEGMENTADO)
                    {
                        produto.QuantidadeParcelasLoja = "SEGMENTADO";
                        produto.PercentualTaxaPadrao = 0;
                    }

                    //[Rule]: get open demands (CRM)
                    if (responseCRM.Status == ExecutionStatus.Success)
                    {
                        var indicators = from indicator in responseCRM.ExistsProductOpenRequests
                                         where indicator.CodigoProduto == produto.CodigoProduto
                                         select indicator;

                        if (indicators != null && indicators.Count() > 0)
                        {
                            produto.IndicadorPossuiDemandasAbertas = indicators.First().IndicadorPossuiDemandasAbertas;
                        }
                    }
                }
            }

            return response;
        }

        private ExistsProductOpenDemandResponse GetIfExistsProductOpenRequests(
            ConsultarProdutoNaoElegivelClienteRequest  productsRequest,
            ConsultarProdutoNaoElegivelClienteResponse productsResponse)
        {
            var daoCRM = DAOFactory.GetDAO<ExistsProductOpenDemandDAO, ExistsProductOpenDemandRequest, ExistsProductOpenDemandResponse>();

            var productsIds = from product in productsResponse.Produtos
                              select product.CodigoProduto;

            var requestCRM = new ExistsProductOpenDemandRequest();
            requestCRM.CodigoCliente = productsRequest.CodigoCliente;
            requestCRM.CodigoProdutos.AddRange(productsIds.ToList());
            requestCRM.UserId = productsRequest.UserId;

            return daoCRM.Execute(requestCRM);
        }
    }
}
