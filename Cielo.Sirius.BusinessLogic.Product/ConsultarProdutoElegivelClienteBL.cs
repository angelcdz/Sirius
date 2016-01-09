using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Contracts.ExistsProductOpenDemand;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarProdutoElegivelClienteBL : BusinessLogicBase<ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>
    {
        public override ConsultarProdutoElegivelClienteResponse Execute(ConsultarProdutoElegivelClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarProdutoElegivelClienteDAO, ConsultarProdutoElegivelClienteRequest, ConsultarProdutoElegivelClienteResponse>();

            ConsultarProdutoElegivelClienteResponse response = dao.Execute(requestData);

            //[Rule]: If Status is false, means an infrastructure or business error, return immediately with no processing
            if (response.Status == ExecutionStatus.Success)
            {
                //[Rule]: get open demands (CRM)
                var responseCRM = GetIfExistsProductOpenRequests(requestData, response);

                foreach (var produto in response.Produtos)
                {
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
            ConsultarProdutoElegivelClienteRequest productsRequest,
            ConsultarProdutoElegivelClienteResponse productsResponse)
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
