using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarDetalheProdutoMultivanContratadoClienteBL : BusinessLogicBase<ConsultarDetalheProdutoMultivanContratadoClienteRequest, ConsultarDetalheProdutoMultivanContratadoClienteResponse>
    {
        public override ConsultarDetalheProdutoMultivanContratadoClienteResponse Execute(ConsultarDetalheProdutoMultivanContratadoClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoMultivanContratadoClienteDAO, 
                                        ConsultarDetalheProdutoMultivanContratadoClienteRequest, 
                                        ConsultarDetalheProdutoMultivanContratadoClienteResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
