using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarDetalheProdutoElegivelCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarDetalheProdutoElegivelClienteBL : BusinessLogicBase<ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>
    {
        public override ConsultarDetalheProdutoElegivelClienteResponse Execute(ConsultarDetalheProdutoElegivelClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoElegivelClienteDAO, ConsultarDetalheProdutoElegivelClienteRequest, ConsultarDetalheProdutoElegivelClienteResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
