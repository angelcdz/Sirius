using System;
using System.Collections.Generic;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.Contracts.ExistsServiceOpenDemand;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarServicoNaoElegivelClienteBL : BusinessLogicBase<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>
    {
        public override ConsultarServicoNaoElegivelClienteResponse Execute(ConsultarServicoNaoElegivelClienteRequest requestData)
        {
            var daoConsultarServicoNaoElegivel = DAOFactory.GetDAO<ConsultarServicoNaoElegivelClienteDAO, ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>();
            var daoExistsService = DAOFactory.GetDAO<ExistsServiceOpenDemandDAO, ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>();

            if (daoConsultarServicoNaoElegivel == null)
            {
                var response = new ConsultarServicoNaoElegivelClienteResponse();
                response.ErrorCode = ErrorCodes.BL_OSB_CALL_DAOFACTORY;
                response.ErrorMessage = "Objeto daoConsultarServicoNaoElegivel nulo";
                response.Status = ExecutionStatus.BusinessError; 

                return response;
            }
            
            var responseConsultarServicoNaoElegivel = daoConsultarServicoNaoElegivel.Execute(requestData);

            // Erro ao consultar servicos nao elegiveis
            if (responseConsultarServicoNaoElegivel.Status != ExecutionStatus.Success)
            {
                responseConsultarServicoNaoElegivel.ErrorMessage = "Erro ao consultar informações de Serviços.\nInformar ao cliente para tentar novamente mais tarde.";
                return responseConsultarServicoNaoElegivel;
            }

            ExistsServiceOpenDemandRequest request = new ExistsServiceOpenDemandRequest();

            request.CodigoServicos = new List<string>();
            request.UserId = requestData.UserId;
            request.CodigoCliente = requestData.CodigoCliente;

            var servicosConsultarServicoNaoElegivel = responseConsultarServicoNaoElegivel.Servicos;
            foreach (var servicoConsultarServicoNaoElegivel in servicosConsultarServicoNaoElegivel)
            {
                request.CodigoServicos.Add(servicoConsultarServicoNaoElegivel.CodigoServico.ToString());
            }


            if (daoExistsService == null)
            {
                var response = new ConsultarServicoNaoElegivelClienteResponse();
                response.ErrorCode = ErrorCodes.BL_OSB_CALL_DAOFACTORY;
                response.ErrorMessage = "Objeto daoConsultarServicoNaoElegivel nulo";
                response.Status = ExecutionStatus.BusinessError;

                return response;
            }
            

            var responseExistsService = daoExistsService.Execute(request);

            var ServicesWithOpenDemands = responseExistsService.ExistsServiceOpenRequests;
            foreach (var ServiceWithOpenDemands in ServicesWithOpenDemands)
            {
                if (ServiceWithOpenDemands.IndicadorPossuiDemandasAbertas.Equals(true))
                {
                    var servico = servicosConsultarServicoNaoElegivel.Find(x => x.CodigoServico == ServiceWithOpenDemands.CodigoServico);
                    if (servico != null)
                    {
                        servico.IndicadorPossuiDemandasAbertas = true;
                    }
                }
            }

            return responseConsultarServicoNaoElegivel;
        }
    }
}
