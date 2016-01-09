using Cielo.Sirius.Contracts.DesabilitarProduto;
using Cielo.Sirius.Contracts.DisableProduct;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.Products
{
    public class DesabilitarProdutoBL : BusinessLogicBase<DesabilitarProdutoRequest, DesabilitarProdutoResponse>
    {
        public override DesabilitarProdutoResponse Execute(DesabilitarProdutoRequest requestData) 
        {
            var daoOSB = DAOFactory.GetDAO<DesabilitarProdutoDAO, DesabilitarProdutoRequest, DesabilitarProdutoResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            //Verifies if some business error occured. If it does so, returns the response object with business error status
            if (responseOSB != null && responseOSB.Status == ExecutionStatus.BusinessError)
            {
                return responseOSB;
            }

            var requestCRM = new DisableProductRequest
            {
                UserId = requestData.UserId,
                AgentGroupCode = requestData.IlhaDeAtendimento,
                ReasonId = requestData.RequestReasonId,
                DemandId = requestData.DemandId,
                ProductCode = requestData.CodigoProduto,
                ParentCaseId = requestData.ParentCaseId,

                //StatusReasonCode will be 1 in the case of the OSB's DAO runs correctly, which means "Integrated" on CRM's Option Set
                //If it doesn't, the attributed value will be 2, which means "Not Integrated"
                StatusReasonCode = responseOSB.Status == ExecutionStatus.Success ? 1 : 2,
            };

            var daoCRM = DAOFactory.GetDAO<DisableProductDAO, DisableProductRequest, DisableProductResponse>();

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
