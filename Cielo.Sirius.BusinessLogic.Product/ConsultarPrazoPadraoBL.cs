using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarPrazoPadraoBL : BusinessLogicBase<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>
    {
        public override ConsultarPrazoPadraoResponse Execute(ConsultarPrazoPadraoRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarPrazoPadraoDAO, ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
