using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Avanade.SmartApps.CoreServices.Test
{
    [TestClass]
    public class UnitTest1
    {
        Logger logger = Logger.LoggerFor<UnitTest1>();

        public UnitTest1()
        {
            Trace.CorrelationManager.StartLogicalOperation();
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
        }

        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 1; i <= 10; i++)
            {
                logger.LogError("teste nulo {0}", i);
            }
            System.Threading.Thread.Sleep(20000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var log1 = Logger.LoggerFor<UnitTest1>();
            var log2 = Logger.LoggerFor<UnitTest1>();
            try
            {
                log1.LogInformation("Information");
                throw new Exception("erro forcado");
            }
            catch (Exception ex)
            {
                log2.LogError(ex, "An error occurred during execution: {1}", ex.Message);
                throw;
            }
        }
    }
}
