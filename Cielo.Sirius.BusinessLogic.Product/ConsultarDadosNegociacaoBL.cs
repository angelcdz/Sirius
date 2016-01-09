using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Contracts.ConsultarElegibilidadeCriacaoDemanda;
using Cielo.Sirius.Contracts.ConsultarSLAPadrao;
using Cielo.Sirius.Contracts.ConsultarDadosNegociacao;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.GetNegotiationData;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarDadosNegociacaoBL : BusinessLogicBase<ConsultarDadosNegociacaoRequest, ConsultarDadosNegociacaoResponse>
    {
        public override ConsultarDadosNegociacaoResponse Execute(ConsultarDadosNegociacaoRequest requestData)
        {
            var response = new ConsultarDadosNegociacaoResponse() 
            { 
                Status = ExecutionStatus.Success,
                DadosCRM = new GetNegotiationDataResponse()
                {
                    Competitors = new List<GetNegotiationDataCompetitorsDTO>(),
                    DealItems = new List<GetNegotiationDataDealItemsDTO>(),
                    Reasons = new List<GetNegotiationDataReasonsDTO>()
                }
            };

            var requestElegibilidade = new ConsultarElegibilidadeCriacaoDemandaRequest()
            {
                CodigoCliente = requestData.CodigoCliente,
                TipoDemanda = requestData.TipoDemanda
            };
            var daoElegibilidade = DAOFactory.GetDAO<ConsultarElegibilidadeCriacaoDemandaDAO, ConsultarElegibilidadeCriacaoDemandaRequest, ConsultarElegibilidadeCriacaoDemandaResponse>();
            var responseElegibilidade = daoElegibilidade.Execute(requestElegibilidade);

            if (responseElegibilidade.Status != ExecutionStatus.Success)
            {
                response.Status = responseElegibilidade.Status;
                return response;
            }

            if (!responseElegibilidade.IndicadorElegibilidade)
            {
                response.IndicadorElegibilidade = false;
                return response;
            }
            
            response.IndicadorElegibilidade = responseElegibilidade.IndicadorElegibilidade;

            var requestSLA = new ConsultarSLAPadraoRequest()
            {
                CodigoCliente = requestData.CodigoCliente,
                TipoDemanda = requestData.TipoDemanda
            };
            var daoSLA = DAOFactory.GetDAO<ConsultarSLAPadraoDAO, ConsultarSLAPadraoRequest, ConsultarSLAPadraoResponse>();
            var responseSLA = daoSLA.Execute(requestSLA);

            response.DataSLA = responseSLA.DataSLA;

            var requestCRM = new GetNegotiationDataRequest()
            {
                AgentGroupCode = requestData.IlhaAtendimento,
                DemandId = requestData.DemandId,
                ECNumber = requestData.ECNumber,
                UserId = requestData.UserId
            };
            var daoCRM = DAOFactory.GetDAO<GetNegotiationDataDAO, GetNegotiationDataRequest, GetNegotiationDataResponse>();
            var responseCRM = daoCRM.Execute(requestCRM);

            if (responseCRM.Status != ExecutionStatus.Success)
            {
                response.Status = responseCRM.Status;
                return response;
            }

            response.DadosCRM.Competitors = responseCRM.Competitors;
            response.DadosCRM.DealItems = responseCRM.DealItems;
            response.DadosCRM.DoOffersExist = responseCRM.DoOffersExist;
            response.DadosCRM.Reasons = responseCRM.Reasons;

            return response;
        }
    }
}
