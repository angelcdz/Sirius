using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.HabilitarPrazoFlexivel;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class ManterPrazoFlexivelBL : BusinessLogicBase<HabilitarPrazoFlexivelRequest, HabilitarPrazoFlexivelResponse>
    {

        public override HabilitarPrazoFlexivelResponse Execute(HabilitarPrazoFlexivelRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ManterPrazoFlexivelDAO, HabilitarPrazoFlexivelRequest, HabilitarPrazoFlexivelResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
