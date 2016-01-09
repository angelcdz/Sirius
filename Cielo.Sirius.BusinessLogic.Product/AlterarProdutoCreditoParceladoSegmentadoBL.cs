using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.AlterarProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Contracts.ChangeProductSegmentedParcelledCredit;

namespace Cielo.Sirius.Business.Products
{
    public class AlterarProdutoCreditoParceladoSegmentadoBL : BusinessLogicBase<AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>
    {
        public override AlterarProdutoCreditoParceladoSegmentadoResponse Execute(AlterarProdutoCreditoParceladoSegmentadoRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO <AlterarProdutoCreditoParceladoSegmentadoDAO, AlterarProdutoCreditoParceladoSegmentadoRequest, AlterarProdutoCreditoParceladoSegmentadoResponse>();
            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB.Status != ExecutionStatus.Success)
                return responseOSB;

            var requestCRM = new ChangeProductSegmentedParcelledCreditRequest()
            {
                //<De-para aqui!>
            };

            var daoCRM = DAOFactory.GetDAO<ChangeProductSegmentedParcelledCreditDAO, ChangeProductSegmentedParcelledCreditRequest, ChangeProductSegmentedParcelledCreditResponse>();
            var responseCRM = daoCRM.Execute(requestCRM);

            return responseOSB;
        }
    }
}
