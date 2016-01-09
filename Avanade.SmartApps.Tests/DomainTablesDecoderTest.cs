using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
//using Avanade.SmartApps.CoreServices;

namespace Avanade.SmartApps.Tests
{
    [TestClass]
    public class DomainTablesDecoderTest
    {
        [TestMethod]
        public void GetDomainValues()
        {
            var domainEntries = DomainTablesDecoder.GetDomainValues("Sexo");
            Assert.IsNotNull(domainEntries);
            Assert.IsTrue(domainEntries.Count > 0);
        }

        [TestMethod]
        public void Decode()
        {
            var decoded = DomainTablesDecoder.Decode("Sexo", "M", "SEC");
            Assert.AreEqual("Masculino", decoded);
        }
    }
}
