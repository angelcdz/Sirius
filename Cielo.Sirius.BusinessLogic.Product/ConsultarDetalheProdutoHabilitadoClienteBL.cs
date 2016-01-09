using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarDetalheProdutoHabilitadoClienteBL : BusinessLogicBase<ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>
    {
        public override ConsultarDetalheProdutoHabilitadoClienteResponse Execute(ConsultarDetalheProdutoHabilitadoClienteRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarDetalheProdutoHabilitadoClienteDAO, ConsultarDetalheProdutoHabilitadoClienteRequest, ConsultarDetalheProdutoHabilitadoClienteResponse>();

            var response = dao.Execute(requestData);

            return response;
        }

    }
}
