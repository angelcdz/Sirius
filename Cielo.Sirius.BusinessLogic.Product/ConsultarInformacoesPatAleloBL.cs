using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;


namespace Cielo.Sirius.Business.Products
{
    public class ConsultarInformacoesPatAleloBL : BusinessLogicBase<ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>
    {
        public override ConsultarInformacoesPatAleloResponse Execute(ConsultarInformacoesPatAleloRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ConsultarInformacoesPatAleloDAO, ConsultarInformacoesPatAleloRequest, ConsultarInformacoesPatAleloResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
