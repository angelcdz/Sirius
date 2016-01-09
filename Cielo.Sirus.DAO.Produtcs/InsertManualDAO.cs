using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.HabilitarDesabilitarVendaDigitada;
using Cielo.Sirius.DAO.Products.XRMSDK;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cielo.Sirius.DAO.Products
{
    public class InsertManualDAO : DAOCRMBase<HabilitarDesabilitarVendaDigitadaRequest, HabilitarDesabilitarVendaDigitadaResponse>
    {
        protected override HabilitarDesabilitarVendaDigitadaResponse GetData(HabilitarDesabilitarVendaDigitadaRequest requestData)
        {
            using (var context = new CRMServiceContext(service))
            {
                context.cielo_commercialestablishmentSet.First().cielo_segmentcode = "1111";
                context.SaveChanges();
                return new HabilitarDesabilitarVendaDigitadaResponse() { Status = ExecutionStatus.Success};
            }
        }
    }
}

