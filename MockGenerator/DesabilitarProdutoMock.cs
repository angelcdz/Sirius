using Cielo.Sirius.Contracts.DesabilitarProduto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class DesabilitarProdutoMock : MockBase
    {
        [TestMethod]
        public void DesabilitarProduto()
        {
            var mockSets = new List<MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>>();

            var request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 3,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova Demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            var response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet1 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet2 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 66,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet3 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 5,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet4 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;
            mockSets.Add(mockSet4);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 65,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet5 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;
            mockSets.Add(mockSet5);

            this.WriteObject(@"..\..\Generated\MockDesabilitarProdutoSuccess.xml", mockSets);
        }

        [TestMethod]
        public void DesabilitarProduto2() 
        {

            var response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };


            this.WriteObject(@"..\..\Generated\MockDesabilitarProdutoSuccess2.xml", response);

        }



        [TestMethod]
        public void DesabilitarProdutoTechnicalError()
        {
            var mockSets = new List<MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>>();

            var request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 3,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            var response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet1 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet2 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 66,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet3 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 5,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet4 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;
            mockSets.Add(mockSet4);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 65,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet5 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;
            mockSets.Add(mockSet5);

            this.WriteObject(@"..\..\Generated\MockDesabilitarProdutoTechnicalError.xml", mockSets);
        }

        [TestMethod]
        public void DesabilitarProdutoBusinessError()
        {
            var mockSets = new List<MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>>();

            var request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 3,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            var response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet1 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet2 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 66,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet3 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 5,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet4 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet4.request = request;
            mockSet4.response = response;
            mockSets.Add(mockSet4);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 65,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet5 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet5.request = request;
            mockSet5.response = response;
            mockSets.Add(mockSet5);

            this.WriteObject(@"..\..\Generated\MockDesabilitarProdutoError.xml", mockSets);
        }

        [TestMethod]
        public void UnitTest()
        {
            var mockSets = new List<MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>>();

            var request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 3,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            var response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.Success
            };

            var mockSet1 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet1.request = request;
            mockSet1.response = response;
            mockSets.Add(mockSet1);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 6,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.TechnicalError
            };

            var mockSet2 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet2.request = request;
            mockSet2.response = response;
            mockSets.Add(mockSet2);

            request = new DesabilitarProdutoRequest()
            {
                Protocolo = "0000222",
                CodigoCliente = 10011001,
                CodigoProduto = 66,
                NomeSolicitante = "Cielo",
                Origem = "Dynamics CRM",
                TelefoneSolicitante = "985435678",
                CodigoEmpresa = "123456",
                MotivoSolicitacao = "Nova demanda",
                IlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090",
                ParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597",
                RequestReasonId = new Guid("9ce30986-573f-e511-80cb-000d3ac00701"),
                DemandId = new Guid("f8be8be4-163a-e511-80f3-000d3ac01607")
            };

            response = new DesabilitarProdutoResponse()
            {
                Status = ExecutionStatus.BusinessError
            };

            var mockSet3 = new MockSet<DesabilitarProdutoRequest, DesabilitarProdutoResponse>();
            mockSet3.request = request;
            mockSet3.response = response;
            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockDesabilitarProdutoUnitTest.xml", mockSets);
        }
    }
}
