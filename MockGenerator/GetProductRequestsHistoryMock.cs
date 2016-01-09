using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class GetProductRequestsHistoryMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>>();

            var request = new GetProductRequestsHistoryRequest();
            request.CodigoCliente = 10011001;
            request.CodigoProduto = "6";

            var response = new GetProductRequestsHistoryResponse();
            response.Status = ExecutionStatus.Success;
            response.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "09876542739404",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-15),
                ClosedOn = DateTime.Now.AddDays(-10)
            });

            var mockSet = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet.request = request;
            mockSet.response = response;


            var request2 = new GetProductRequestsHistoryRequest();
            request2.CodigoCliente = 10011001;
            request2.CodigoProduto = "65";

            var response2 = new GetProductRequestsHistoryResponse();
            response2.Status = ExecutionStatus.Success;
            response2.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response2.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "08876542739403",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-12),
                ClosedOn = DateTime.Now.AddDays(-8)
            });

            var mockSet2 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet2.request = request2;
            mockSet2.response = response2;


            var request3 = new GetProductRequestsHistoryRequest();
            request2.CodigoCliente = 10011001;
            request2.CodigoProduto = "66";

            var response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            var mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet);
            mockSets.Add(mockSet2);
            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "5";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "6";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "66";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "65";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "1004";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.BusinessError;

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011020;
            request3.CodigoProduto = "1005";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011022;
            request3.CodigoProduto = "5";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011022;
            request3.CodigoProduto = "6";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011022;
            request3.CodigoProduto = "66";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011022;
            request3.CodigoProduto = "65";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011023;
            request3.CodigoProduto = "1007";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011023;
            request3.CodigoProduto = "1008";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011023;
            request3.CodigoProduto = "1009";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011023;
            request3.CodigoProduto = "1010";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);


            request3 = new GetProductRequestsHistoryRequest();
            request3.CodigoCliente = 10011023;
            request3.CodigoProduto = "1011";

            response3 = new GetProductRequestsHistoryResponse();
            response3.Status = ExecutionStatus.Success;
            response3.ProductRequests = new List<GetProductRequestsHistoryDTO>();
            response3.ProductRequests.Add(new GetProductRequestsHistoryDTO()
            {
                ServiceCallNumber = "07876542739402",
                ProductRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-10),
                ClosedOn = DateTime.Now.AddDays(-5)
            });

            mockSet3 = new MockSet<GetProductRequestsHistoryRequest, GetProductRequestsHistoryResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            this.WriteObject(@"..\..\Generated\MockGetProductRequestsHistory.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new GetProductRequestsHistoryResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "005";
            response.ErrorMessage = "CRM generic error";

            this.WriteObject(@"..\..\Generated\MockGetProductRequestsHistoryError.xml", response);
        }
    }
}
