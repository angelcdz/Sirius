using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.NegociacaoComercial;
using Cielo.Sirius.Contracts.CommercialNegotiation;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class NegociacaoComercialBL : BusinessLogicBase<NegociacaoComercialRequest, NegociacaoComercialResponse>
    {
        public override NegociacaoComercialResponse Execute(NegociacaoComercialRequest requestData)
        {
            var daoOSB = DAOFactory.GetDAO<NegociacaoComercialDAO, NegociacaoComercialRequest, NegociacaoComercialResponse>();

            var responseOSB = daoOSB.Execute(requestData);

            if (responseOSB.Status == ExecutionStatus.BusinessError)
                return responseOSB;

            var requestCRM = new CommercialNegotiationRequest()
            {
                AdvisorCode = requestData.CodigoAssessor,
                AdvisorName = requestData.NomeAssessor,
                AgentGroup = requestData.IlhaAtendimento,
                Competitor = requestData.Concorrente,
                CompetitorValue = requestData.ValorConcorrente,
                Contact = requestData.Contato,
                ContactChannel = requestData.CanalAtendimento,
                Customer = requestData.Cliente,
                DealItem = requestData.ItemNegociacao,
                Description = requestData.Descricao,
                ECNumber = requestData.NumeroEC,
                OSBDemandId = responseOSB.IdDemandaOSB,
                Protocol = requestData.Protocolo,
                RequestParameterization = requestData.Demanda,
                RequestReason = requestData.Motivo,
                ServiceExpectedDate = requestData.DataPrevistaSolicitacao,
                UserId = requestData.UserId
            };

            var daoCRM = DAOFactory.GetDAO<CommercialNegotiationDAO, CommercialNegotiationRequest, CommercialNegotiationResponse>();

            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM == null || responseCRM.Status != ExecutionStatus.Success)
                responseOSB.Status = ExecutionStatus.TechnicalError;
            else
                responseOSB.Status = ExecutionStatus.Success;

            return responseOSB;
        }
    }
}
