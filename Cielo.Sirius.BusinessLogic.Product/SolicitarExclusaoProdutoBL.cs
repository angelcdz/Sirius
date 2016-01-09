using System;
using System.Collections.Generic;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.SolicitarExclusaoProduto;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class SolicitarExclusaoProdutoBL : BusinessLogicBase<SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>
    {
        public override SolicitarExclusaoProdutoResponse Execute(SolicitarExclusaoProdutoRequest requestData)
        {
            var dao = DAOFactory.GetDAO<SolicitarExclusaoProdutoDAO, SolicitarExclusaoProdutoRequest, SolicitarExclusaoProdutoResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
