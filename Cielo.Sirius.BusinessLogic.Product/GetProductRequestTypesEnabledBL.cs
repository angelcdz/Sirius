using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetCommercialEstablishmentInformation;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.Business.Products
{
    public class GetProductRequestTypesEnabledBL : BusinessLogicBase<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>
    {
        public override GetEnabledProductRequestTypesResponse Execute(GetEnabledProductRequestTypesRequest requestData)
        {
            // GetCommercialEstablishmentInformation part
            GetCommercialEstablishmentInformationRequest requestCommEstabInfo = new GetCommercialEstablishmentInformationRequest();
            requestCommEstabInfo.UserId = requestData.UserId;
            requestCommEstabInfo.CommercialEstablishmentNumber = requestData.ECNumber; // Fill request from view (context)

            var daoCommEstabInfo = DAOFactory.GetDAO<GetCommercialEstablishmentInformationDAO, GetCommercialEstablishmentInformationRequest, GetCommercialEstablishmentInformationResponse>();
            var responseCommEstabInfo = daoCommEstabInfo.Execute(requestCommEstabInfo);

            if (responseCommEstabInfo.Status != Foundation.ExecutionStatus.Success)
            {
                var responseRet = new GetEnabledProductRequestTypesResponse();
                responseRet.Status = responseCommEstabInfo.Status;
                responseRet.ErrorMessage = responseCommEstabInfo.ErrorMessage;
                responseRet.ErrorCode = responseCommEstabInfo.ErrorCode;
                return responseRet;
            }

            // Main part
            var dao = DAOFactory.GetDAO<GetEnabledProductRequestTypesDAO, GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>();
            var responseData = dao.Execute(requestData);

            if (responseData.Status != Foundation.ExecutionStatus.Success)
            {
                return responseData;
            }

            return VerifyProductRequestTypesEnabledRules(requestData, responseData, responseCommEstabInfo);
        }

        private GetEnabledProductRequestTypesResponse VerifyProductRequestTypesEnabledRules(GetEnabledProductRequestTypesRequest request,
                                                                                            GetEnabledProductRequestTypesResponse response,
                                                                                            GetCommercialEstablishmentInformationResponse responseCE)
        {
            double flexibleMaturityRate = request.FlexibleMaturityRate == null ? 0 : (double)request.FlexibleMaturityRate;
            bool enabledTypedSaleIndicator = request.EnabledTypedSaleIndicator == null ? false : (bool)request.EnabledTypedSaleIndicator;
            string branchOfActivityCode = responseCE.BranchOfActivityCode == null ? string.Empty : responseCE.BranchOfActivityCode.ToString();
            bool meiIndicator = responseCE.MEIIndicator == null ? false : (bool)responseCE.MEIIndicator;
            DateTime membershipDate = responseCE.MembershipDate;
            
            // TODO:List filled with branch of activity codes that can't enable type sale
            List<string> branchCodeIfEnable = new List<string>(new string[] { "7995", "6051", "5271", "5993", "5541" });
            // TODO:List filled with branch of activity codes that can't disable type sale
            List<string> branchCodeIfDisable = new List<string>(new string[] { "5960", "5961", "5962", "5964", "5965", "5966", "5967", "5968", "5969" });

            // TODO:Removing hardcoded documentation analisys option
            RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_ANALISE_DOCUMENTACAO);
            
            if (enabledTypedSaleIndicator)
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_HABILITAR_VENDA_DIGITADA);
            }
            else
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_DESABILITAR_VENDA_DIGITADA);
            }

            if (branchCodeIfEnable.Contains(branchOfActivityCode))
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_HABILITAR_VENDA_DIGITADA);
            }

            if (branchCodeIfDisable.Contains(branchOfActivityCode))
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_DESABILITAR_VENDA_DIGITADA);
            }
            
            if (meiIndicator)
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_SOLICITAR_NEGOCIACAO_DE_TAXA);
            }

            if (flexibleMaturityRate > 0)
            {

                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_HABILITAR_PRAZO_FLEXIVEL);
            }
            else
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_DESABILITAR_PRAZO_FLEXIVEL);
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_ALTERAR_PRAZO_FLEXIVEL);
            }

            if (membershipDate.CompareTo(DateTime.Today.AddMonths(Constants.CARENCIA_DATA_FILIACAO)) >= 0)
            {
                RemoveFromListResponse(ref response, Constants.TIPO_DEMANDA_PRD_HABILITAR_PRAZO_FLEXIVEL);
            }

            response.MEIIndicator = meiIndicator;
            response.BranchOfActivityCode = branchOfActivityCode;
            
            return response;
        }

        private GetEnabledProductRequestTypesResponse RemoveFromListResponse(ref GetEnabledProductRequestTypesResponse response, int integrationRequestCode)
        {
            response.ProductRequestTypes.RemoveAll(s => s.IntegrationRequestCode == integrationRequestCode);
            return response;
        }
    }
}
