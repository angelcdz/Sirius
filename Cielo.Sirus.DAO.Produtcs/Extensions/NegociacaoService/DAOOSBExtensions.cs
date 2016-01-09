using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products.NegociacaoService;

namespace Cielo.Sirius.DAO.Products.Extensions.NegociacaoService
{
    using Cielo.Sirius.DAO.Products.NegociacaoService;

    public static class DAOOSBExtensions
    {
        public static CieloSoapHeaderType GetSoapHeader<RequestType, ResponseType>(this DAOOSBBase<RequestType, ResponseType> dao)
            where ResponseType : ResponseBase, new()
            where RequestType : RequestBase
        {
            CieloSoapHeaderType cieloSoapHeader = new CieloSoapHeaderType();

            UsuarioType objUserCred = new UsuarioType();

            OSBCredentials credentialData = dao.RetrieveOSBCredentials();

            objUserCred.id = credentialData.Username;
            objUserCred.senha = credentialData.Password;

            cieloSoapHeader.Item = objUserCred;
            cieloSoapHeader.realm = credentialData.Realm;

            return cieloSoapHeader;
        }

    }
}

namespace Cielo.Sirius.DAO.Products.WR.Negociacao.Extensions
{
    public static class DAOOSBExtensions
    {
        public static CieloSoapHeaderType GetSoapHeader<RequestType, ResponseType>(this DAOOSBBase<RequestType, ResponseType> dao)
            where ResponseType : ResponseBase, new()
            where RequestType : RequestBase
        {
            var cieloSoapHeader = new CieloSoapHeaderType();

            UsuarioType objUserCred = new UsuarioType();

            OSBCredentials credentialData = dao.RetrieveOSBCredentials();

            objUserCred.id = credentialData.Username;
            objUserCred.senha = credentialData.Password;

            cieloSoapHeader.Item = objUserCred;
            cieloSoapHeader.realm = credentialData.Realm;

            return cieloSoapHeader;
        }

    }
}