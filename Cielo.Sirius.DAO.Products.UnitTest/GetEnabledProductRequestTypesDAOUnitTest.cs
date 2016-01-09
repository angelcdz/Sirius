using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.DAO.Products.UnitTest
{
        [TestClass]
        public class GetEnabledProductRequestTypesDAOUnitTest
        {
            [TestMethod]
            public void Sucesso()
            {
                var requestData = new GetEnabledProductRequestTypesRequest()
                {
                    ProductGroup = "Produtos Habilitados"
                };
                var dao = DAOFactory.GetDAO<GetEnabledProductRequestTypesDAO, GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>();
                var response = dao.Execute(requestData);

                Assert.IsNotNull(response);
    
            }
        }
}
