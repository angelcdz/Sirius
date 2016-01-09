using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.Products
{
    public class ValidarPermissaoVendaDigitadaBL : BusinessLogicBase<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>
    {
        public override ValidarPermissaoVendaDigitadaResponse Execute(ValidarPermissaoVendaDigitadaRequest requestData)
        {
            var dao = DAOFactory.GetDAO<ValidarPermissaoVendaDigitadaDAO, ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();

            var response = dao.Execute(requestData);

            return response;
        }
    }
}
