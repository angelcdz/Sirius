using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;

namespace Avanade.SmartApps.Communication.Tests
{
    [TestClass]
    public class DAOConfigurationTest
    {
        [TestMethod]
        public void BasicConfigurationTest()
        {
            var daoImplementation = DAOFactory.GetDAO<BasicExampleDAO, ExampleRequest, ExampleResponse>();

            Assert.IsNotNull(daoImplementation);
            Assert.AreEqual("/value/test", daoImplementation.Parameters["realm"]);
        }

        [TestMethod]
        public void BasicMockedConfigurationTest()
        {
            var daoImplementation = DAOFactory.GetDAO<BasicExampleMockedDAO, ExampleRequest, ExampleResponse>();

            Assert.IsNotNull(daoImplementation);
            Assert.AreEqual("/value/test", daoImplementation.Parameters["realm"]);
        }

        [TestMethod]
        public void BasicOverrideParamsConfigurationTest()
        {
            var daoImplementation = DAOFactory.GetDAO<BasicExampleOverrideParametersDAO, ExampleRequest, ExampleResponse>();

            Assert.IsNotNull(daoImplementation);
            Assert.AreEqual("/myDAORealm/test", daoImplementation.Parameters["realm"]);
        }        
    }


}
