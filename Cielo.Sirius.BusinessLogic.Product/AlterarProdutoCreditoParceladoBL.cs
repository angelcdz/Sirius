using Cielo.Sirius.Contracts.AlterarProdutoCreditoParcelado;
using Cielo.Sirius.Contracts.ChangeProductInstallmentCredit;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Business.Products
{
    public class AlterarProdutoCreditoParceladoBL : BusinessLogicBase<AlterarProdutoCreditoParceladoRequest, AlterarProdutoCreditoParceladoResponse>
    {
        public override AlterarProdutoCreditoParceladoResponse Execute(AlterarProdutoCreditoParceladoRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<AlterarProdutoCreditoParceladoDAO, AlterarProdutoCreditoParceladoRequest, AlterarProdutoCreditoParceladoResponse>();
            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB.Status != ExecutionStatus.Success)
                return responseOSB;

            var requestCRM = new ChangeProductInstallmentCreditRequest()
            { 
                //dados request CRM
            };

            var daoCRM = DAOFactory.GetDAO<ChangeProductInstallmentCreditDAO, ChangeProductInstallmentCreditRequest, ChangeProductInstallmentCreditResponse>();
            var responseCRM = daoCRM.Execute(requestCRM);

            // passar dados do response do CRM para o response do OSB

            return responseOSB;
        }
    }
}
