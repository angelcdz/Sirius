using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarPrazosTaxasPrazoFlexivelBL : BusinessLogicBase<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>
    {
        public override ConsultarPrazosTaxasPrazoFlexivelResponse Execute(ConsultarPrazosTaxasPrazoFlexivelRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarPrazosTaxasPrazoFlexivelDAO, ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
