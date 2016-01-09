using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarElegibilidadeCriacaoDemanda;
using Cielo.Sirius.DAO.Products.NegociacaoService;
using Cielo.Sirius.DAO.Products.WR.Negociacao.Extensions;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarElegibilidadeCriacaoDemandaDAO : DAOOSBBase<ConsultarElegibilidadeCriacaoDemandaRequest, ConsultarElegibilidadeCriacaoDemandaResponse>
    {
        protected override ConsultarElegibilidadeCriacaoDemandaResponse GetData(ConsultarElegibilidadeCriacaoDemandaRequest requestData)
        {
            var response = new ConsultarElegibilidadeCriacaoDemandaResponse();

            var client = new TemporarioServicePortTypeClient();

            var requestOSB = new consultarElegibilidadeNegociacaoComercialRequest()
            {
                codigoCliente = requestData.CodigoCliente,
                codigoTipoDemanda = requestData.TipoDemanda,
                cieloSoapHeader = this.GetSoapHeader()
            };

            listaDemandaType[] lista = null;
            var responseOSB = client.consultarElegibilidadeNegociacaoComercial(
                                requestOSB.cieloSoapHeader
                                , requestOSB.codigoCliente
                                , requestOSB.codigoTipoDemanda
                                , requestOSB.codigoSubTipoDemanda
                                , out lista);

            response.IndicadorElegibilidade = responseOSB.indicadorElegibilidade;
            response.Status = ExecutionStatus.Success;

            return response;
        }
    }
}
