using Cielo.Sirius.Business.Products;
using Cielo.Sirius.Contracts.DesabilitarServico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Business.UnitTest
{
    [TestClass]
    public class DesabilitarServicoUnitTest
    {
        [TestMethod]
        public void Successo()
        {
            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 1,
                CodigoServico = "1",
                IlhaDeAtendimento = "Ilha de Atendimento S",
                TituloDaOcorrencia = "Titulo da Ocorrência S",
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
            };

            var business = new DesabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.Success);
        }

        [TestMethod]
        public void BusinessError()
        {
            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 2,
                CodigoServico = "2",
                IlhaDeAtendimento = "Ilha de Atendimento BE",
                TituloDaOcorrencia = "Titulo da Ocorrência BE",
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
            };

            var business = new DesabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.BusinessError);
        }

        [TestMethod]
        public void TechnicalError()
        {
            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 3,
                CodigoServico = "3",
                IlhaDeAtendimento = "Ilha de Atendimento TE",
                TituloDaOcorrencia = "Titulo da Ocorrência TE",
                UserId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405"),
                CorrelationId = new Guid("be12ef3a-000f-e511-80c0-00155d0ef405")
            };

            var business = new DesabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == Foundation.ExecutionStatus.TechnicalError);
        }

        [TestMethod]
        public void CodigoClienteNaoExistente()
        {
            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = -1,
                CodigoServico = "1"
            };

            var business = new DesabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }

        [TestMethod]
        public void CodigoServicoNaoExistente()
        {
            var request = new DesabilitarServicoRequest()
            {
                CodigoCliente = 1,
                CodigoServico = "-1"
            };

            var business = new DesabilitarServicoBL();

            var response = business.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Status == Foundation.ExecutionStatus.Success);
            Assert.AreEqual("9999", response.ErrorCode);
            Assert.AreEqual("RECORD NOT FOUND", response.ErrorMessage);
        }
    }
}
