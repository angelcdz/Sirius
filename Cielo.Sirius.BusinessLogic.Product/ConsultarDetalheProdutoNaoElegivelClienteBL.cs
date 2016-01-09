using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarDetalheProdutoNaoElegivelCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarDetalheProdutoNaoElegivelClienteBL : BusinessLogicBase<ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>
    {
        public override ConsultarDetalheProdutoNaoElegivelClienteResponse Execute(ConsultarDetalheProdutoNaoElegivelClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoNaoElegivelClienteDAO, ConsultarDetalheProdutoNaoElegivelClienteRequest, ConsultarDetalheProdutoNaoElegivelClienteResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
