using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.SmartApps.Communication.Tests
{
    [TestClass]
    public class DAOFactoryTest
    {
        [TestMethod]
        public void BasicTest()
        {
            var daoImplementation = DAOFactory.GetDAO<BasicExampleDAO, ExampleRequest, ExampleResponse>();

            Assert.IsNotNull(daoImplementation);
            Assert.IsInstanceOfType(daoImplementation, typeof(BasicExampleDAO));
        }

        [TestMethod]
        public void BasicMockedTest()
        {
            var daoImplementation = DAOFactory.GetDAO<BasicExampleMockedDAO, ExampleRequest, ExampleResponse>();

            Assert.IsNotNull(daoImplementation);
            Assert.IsInstanceOfType(daoImplementation, typeof(DAOMockParameterized<ExampleRequest, ExampleResponse>));
        }
    }
}
