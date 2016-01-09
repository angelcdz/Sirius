using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarProdutosPrazoFlexivelBL : BusinessLogicBase<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>
    {
        public override ConsultarProdutosPrazoFlexivelResponse Execute(ConsultarProdutosPrazoFlexivelRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarProdutosPrazoFlexivelDAO, ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
