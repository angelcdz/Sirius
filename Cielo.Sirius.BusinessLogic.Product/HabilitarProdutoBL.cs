using System;
using System.Collections.Generic;

using Cielo.Sirius.Contracts.HabilitarProduto;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class HabilitarProdutoBL : BusinessLogicBase<HabilitarProdutoRequest, HabilitarProdutoResponse>
    {
        public override HabilitarProdutoResponse Execute(HabilitarProdutoRequest requestData)
        {
            var dao = DAOFactory.GetDAO<HabilitarProdutoDAO, HabilitarProdutoRequest, HabilitarProdutoResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
