using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarSLAPadrao;
using Cielo.Sirius.DAO.Products.EquipamentoService;
using Cielo.Sirius.DAO.Products.Extensions.EquipamentoService;
using Cielo.Sirius.DAO.Products.WR.Equipamento;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;

namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarSLAPadraoDAO : DAOOSBBase<ConsultarSLAPadraoRequest, ConsultarSLAPadraoResponse>
    {
        protected override ConsultarSLAPadraoResponse GetData(ConsultarSLAPadraoRequest requestData)
        {
            string codigoRetorno;
            string mensagemRetorno;

            var responseOSB = new EquipamentoServicePortTypeClient()
                                .consultarPrazoPadrao(this.GetSoapHeader(), 
                                    new consultarPrazoPadraoRequest()
                                    {
                                        codigoCliente = requestData.CodigoCliente,
                                        tipoDemanda = requestData.TipoDemanda
                                    }, 
                                    out codigoRetorno, 
                                    out mensagemRetorno);

            return codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS ?
                    new ConsultarSLAPadraoResponse() { Status = ExecutionStatus.BusinessError, ErrorCode = codigoRetorno, ErrorMessage = mensagemRetorno } :
                    new ConsultarSLAPadraoResponse() { Status = ExecutionStatus.Success, DataSLA = responseOSB.dataSLA };
        }
    }
}