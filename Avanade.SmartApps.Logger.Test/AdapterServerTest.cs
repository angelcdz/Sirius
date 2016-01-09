using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using System.Diagnostics;

namespace Avanade.SmartApps.CoreServices.Test
{
    [TestClass]
    public class AdapterServerTest
    {
        Logger logger = Logger.LoggerFor<AdapterServerTest>();

        public AdapterServerTest()
        {
            Trace.CorrelationManager.StartLogicalOperation();
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                logger.LogInformation(null);
                TestMethod2();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in TestMethod1");
                System.Threading.Thread.Sleep(200000);
                throw;
            }
        }
        [TestMethod]
        private void TestMethod2()
        {
            try
            {
                logger.LogInformation("Start TestMethod2");

                throw new Exception("Forcando erro no TestMethod2");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in TestMethod2");
                throw;
            }
        }
    }
}
