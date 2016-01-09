using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.SolicitaAnaliseAlvara;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;


namespace Cielo.Sirius.Business.Products
{
    public class SolicitaAnaliseAlvaraBL : BusinessLogicBase<SolicitaAnaliseAlvaraRequest,SolicitaAnaliseAlvaraResponse> 
    {
        public override SolicitaAnaliseAlvaraResponse Execute(SolicitaAnaliseAlvaraRequest requestData)
        {
            var dao = DAOFactory.GetDAO<SolicitaAnaliseAlvaraDAO, SolicitaAnaliseAlvaraRequest, SolicitaAnaliseAlvaraResponse>();

            var response = dao.Execute(requestData);

            return response;
        }


    }
}
