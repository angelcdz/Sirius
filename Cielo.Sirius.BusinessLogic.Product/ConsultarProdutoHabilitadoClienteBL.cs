using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ExistsProductOpenDemand;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarProdutoHabilitadoClienteBL : BusinessLogicBase<ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>
    {
        public override ConsultarProdutoHabilitadoClienteResponse Execute(ConsultarProdutoHabilitadoClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarProdutoHabilitadoClienteDAO, ConsultarProdutoHabilitadoClienteRequest, ConsultarProdutoHabilitadoClienteResponse>();

            ConsultarProdutoHabilitadoClienteResponse response = dao.Execute(requestData);

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
                        produto.PercentualTaxa = 0;
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
            ConsultarProdutoHabilitadoClienteRequest productsRequest,
            ConsultarProdutoHabilitadoClienteResponse productsResponse)
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
