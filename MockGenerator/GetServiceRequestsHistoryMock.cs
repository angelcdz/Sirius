using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.GetProductRequestsHistory;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.GetServiceRequestsHistory;

namespace MockGenerator
{
    [TestClass]
    public class GetServiceRequestsHistoryMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>>();

            //Habilitados
            mockSets.Add(GetMocksetforCustomer(10011001, "12"));
            mockSets.Add(GetMocksetforCustomer(10011001, "18"));
            mockSets.Add(GetMocksetforCustomer(10011002, "5"));
            mockSets.Add(GetMocksetforCustomer(10011002, "6"));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011003, "5"));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011003, "6"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011004, "5"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011004, "6"));

            //Elegível
            mockSets.Add(GetMocksetforCustomer(10011001, "1"));
            mockSets.Add(GetMocksetforCustomer(10011001, "2"));
            mockSets.Add(GetMocksetforCustomer(10011001, "3"));
            mockSets.Add(GetMocksetforCustomer(10011001, "4"));
            mockSets.Add(GetMocksetforCustomer(10011001, "5"));
            mockSets.Add(GetMocksetforCustomer(10011001, "6"));
            mockSets.Add(GetMocksetforCustomer(10011001, "7"));
            mockSets.Add(GetMocksetforCustomer(10011001, "8"));
            mockSets.Add(GetMocksetforCustomer(10011001, "9"));
            mockSets.Add(GetMocksetforCustomer(10011001, "13"));
            mockSets.Add(GetMocksetforCustomer(10011001, "16"));
            mockSets.Add(GetMocksetforCustomer(10011005, "10"));
            mockSets.Add(GetMocksetforCustomer(10011005, "11"));
            mockSets.Add(GetMocksetforCustomer(10011006, "11"));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011006, "10"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011007, "10"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011007, "11"));

            //Não Elegível
            mockSets.Add(GetMocksetforCustomer(10011008, "14"));
            mockSets.Add(GetMocksetforCustomer(10011008, "17"));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011009, "14"));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011009, "17"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011010, "14"));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011010, "17"));
            
            this.WriteObject(@"..\..\Generated\MockGetServiceRequestsHistory.xml", mockSets);
            }

        #region Mock data for Customers

        public MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse> GetMocksetforCustomer(long codigoCliente_, string codigosServico_)
        {
            var request = new GetServiceRequestsHistoryRequest()
            {
                CodigoCliente = codigoCliente_,
                CodigoServico = codigosServico_
            };

            var response = new GetServiceRequestsHistoryResponse();
            response.ServiceRequests = GetServiceRequestHistoryList();
            response.Status = ExecutionStatus.Success;

            var mockSet = new MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //MockSet TechnicalError
        public MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse> GetMocksetforCustomerErrorLoading(long codigoCliente_, string codigosServico_)
        {
            var request = new GetServiceRequestsHistoryRequest()
            {
                CodigoCliente = codigoCliente_,
                CodigoServico = codigosServico_
            };

            var response = new GetServiceRequestsHistoryResponse();
            response.ServiceRequests = GetServiceRequestHistoryList();
            response.Status = ExecutionStatus.TechnicalError;
            
            var mockSet = new MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //MockSet BusinessError
        public MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse> GetMocksetforCustomerErrorAction(long codigoCliente_, string codigosServico_)
        {
            var request = new GetServiceRequestsHistoryRequest()
            {
                CodigoCliente = codigoCliente_,
                CodigoServico = codigosServico_
            };

            var response = new GetServiceRequestsHistoryResponse();
            response.ServiceRequests = GetServiceRequestHistoryList();
            response.Status = ExecutionStatus.BusinessError;
            response.ErrorCode = "Business Error";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";

            var mockSet = new MockSet<GetServiceRequestsHistoryRequest, GetServiceRequestsHistoryResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion

        #region Service Request History Generation

        private List<GetServiceRequestsHistoryDTO> GetServiceRequestHistoryList()
        {
            var demanda = new List<GetServiceRequestsHistoryDTO>();

            demanda.Add(new GetServiceRequestsHistoryDTO()
            {
                CaseTitle = "09876542739404",
                ServiceRequestName = "Alteração de Taxa",
                CreatedOn = DateTime.Now.AddDays(-15),
                ClosedOn = DateTime.Now.AddDays(-10)
            });

            return demanda;
        }
        #endregion

        [TestMethod]
        public void ErrorData()
        {
            var response = new GetServiceRequestsHistoryResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "005";
            response.ErrorMessage = "CRM generic error";

            this.WriteObject(@"..\..\Generated\MockGetServiceRequestsHistoryError.xml", response);
        }
    }
}
