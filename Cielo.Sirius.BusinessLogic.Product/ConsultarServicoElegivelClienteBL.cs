using System;
using System.Collections.Generic;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Contracts.ExistsServiceOpenDemand;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarServicoElegivelClienteBL : BusinessLogicBase<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>
    {
        public override ConsultarServicoElegivelClienteResponse Execute(ConsultarServicoElegivelClienteRequest requestData)
        {

            var daoConsultarServicoElegivel = DAOFactory.GetDAO<ConsultarServicoElegivelClienteDAO, ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>();
            var daoExistsService = DAOFactory.GetDAO<ExistsServiceOpenDemandDAO, ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>();

            var responseConsultarServicoElegivel = daoConsultarServicoElegivel.Execute(requestData);

            // Erro ao consultar servicos elegiveis
            if (responseConsultarServicoElegivel.Status != ExecutionStatus.Success)
            {
                responseConsultarServicoElegivel.ErrorMessage = "Erro ao consultar informações de Serviços.\nInformar ao cliente para tentar novamente mais tarde.";
                return responseConsultarServicoElegivel;
            }

            ExistsServiceOpenDemandRequest request = new ExistsServiceOpenDemandRequest();

            var servicosConsultarServicoElegivel = responseConsultarServicoElegivel.Servicos;

            request.CodigoServicos = new List<string>();
            request.UserId = requestData.UserId;
            request.CodigoCliente = requestData.CodigoCliente;

            foreach (var servicoConsultarServicoElegivel in servicosConsultarServicoElegivel)
            {
                request.CodigoServicos.Add(servicoConsultarServicoElegivel.CodigoServico.ToString());
            }

            var responseExistsService = daoExistsService.Execute(request);

            var ServicesWithOpenDemands = responseExistsService.ExistsServiceOpenRequests;

            foreach (var ServiceWithOpenDemands in ServicesWithOpenDemands)
            {
                if (ServiceWithOpenDemands.IndicadorPossuiDemandasAbertas.Equals(true))
                {
                    var servico = servicosConsultarServicoElegivel.Find(x => x.CodigoServico == ServiceWithOpenDemands.CodigoServico);
                    if (servico != null)
                    {
                        servico.IndicadorPossuiDemandasAbertas = true;
                    }
                }
            }

            return responseConsultarServicoElegivel;
        }
    }
}
