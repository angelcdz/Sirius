using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Contracts.ExistsServiceOpenDemand;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;

namespace Cielo.Sirius.Business.Products
{
    public class ConsultarServicoHabilitadoClienteBL : BusinessLogicBase<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>
    {
        public override ConsultarServicoHabilitadoClienteResponse Execute(ConsultarServicoHabilitadoClienteRequest requestData)
        {
            var daoConsultarServicoHabilitado = DAOFactory.GetDAO<ConsultarServicoHabilitadoClienteDAO, ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>();
            var daoExistsService = DAOFactory.GetDAO<ExistsServiceOpenDemandDAO, ExistsServiceOpenDemandRequest, ExistsServiceOpenDemandResponse>();

            var responseConsultarServicoHabilitado = daoConsultarServicoHabilitado.Execute(requestData);

            // Erro ao consultar servicos elegiveis
            if (responseConsultarServicoHabilitado.Status != ExecutionStatus.Success)
            {
                responseConsultarServicoHabilitado.ErrorMessage = "Erro ao consultar informações de Serviços.\nInformar ao cliente para tentar novamente mais tarde.";
                return responseConsultarServicoHabilitado;
            }
                        
            ExistsServiceOpenDemandRequest request = new ExistsServiceOpenDemandRequest();
            request.CodigoServicos = new List<string>();
            request.UserId = requestData.UserId;
            request.CodigoCliente = requestData.CodigoCliente;

            request.CodigoServicos = new List<string>();

            var servicosConsultarServicoHabilitado = responseConsultarServicoHabilitado.Servicos;

            foreach (var servicoConsultarServicoHabilitado in servicosConsultarServicoHabilitado)
            {
                request.CodigoServicos.Add(servicoConsultarServicoHabilitado.CodigoServico.ToString());
            }
            var responseExistsService = daoExistsService.Execute(request);

            var ServicesWithOpenDemands = responseExistsService.ExistsServiceOpenRequests;
            foreach (var ServiceWithOpenDemands in ServicesWithOpenDemands)
            {
                if (ServiceWithOpenDemands.IndicadorPossuiDemandasAbertas.Equals(true))
                {
                    var servico = servicosConsultarServicoHabilitado.Find(x => x.CodigoServico == ServiceWithOpenDemands.CodigoServico);
                    if (servico != null)
                    {
                        servico.IndicadorPossuiDemandasAbertas = true;
                    }
                }
            }

            return responseConsultarServicoHabilitado;
        }
    }
}
