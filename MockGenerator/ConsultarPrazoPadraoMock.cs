using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarPrazoPadraoMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>>();

            #region SLA Habilitar Serviço

            var request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "8",
                TipoDemanda = 2001
            };

            var response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            var mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "9",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "10",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "11",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "13",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "16",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "SLA indisponível"
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "16",
                TipoDemanda = 2001
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "SLA indisponível"
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "30",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "31",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "32",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "33",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "34",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "35",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "400",
                TipoDemanda = 2001
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            #endregion

            #region SLA Desabilitar Serviço

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "12",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "15",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "18",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "19",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "20",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO com Data

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "21",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO Concluído

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "22",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // Sem data OK

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "23",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "24",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "25",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "26",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO com Data

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "27",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO com Data

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "28",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO com Data

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "29",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // TO DO Concluído

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "36",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                // Sem data OK

            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "37",
                TipoDemanda = 2002
            };

            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            #endregion

            #region SLA Desabilitar Produto
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1007
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };  

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "65",
                TipoDemanda = 1007
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "3",
                TipoDemanda = 1007
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "5",
                TipoDemanda = 1007
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "6",
                TipoDemanda = 1007
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011023,
                SubTipoDemanda = "1007",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "SLA indisponível"
            };


            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);
         

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011023,
                SubTipoDemanda = "1008",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };


            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011023,
                SubTipoDemanda = "1009",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };


            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011023,
                SubTipoDemanda = "1010",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };


            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011023,
                SubTipoDemanda = "1011",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };


            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            #endregion

            #region SLA Solicitar Negociação de Taxa

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1004
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "65",
                TipoDemanda = 1004
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "3",
                TipoDemanda = 1004
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "5",
                TipoDemanda = 1004
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "6",
                TipoDemanda = 1004
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            #endregion

            #region SLA Desabilitar Venda Digitada

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "65",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                ErrorCode = "SLA indisponível"
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "3",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                // Erro de SLA Indisponivel
                Status = ExecutionStatus.BusinessError,
                ErrorMessage = "SLA Indisponível"
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "5",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "6",
                TipoDemanda = 1006
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(2),
                ErrorMessage = string.Empty,
            };

            mockSet = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            #endregion

            //Alterar produto
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1001
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(3),
                ErrorMessage = string.Empty,
            };

            var mockSetDemandaAlterarProduto = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSetDemandaAlterarProduto.request = request;
            mockSetDemandaAlterarProduto.response = response;

            mockSets.Add(mockSetDemandaAlterarProduto);

            //Habilitar Venda Digitada
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "3",
                TipoDemanda = 1005
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.BusinessError,
                DataSLA = DateTime.Now.AddDays(4),
                ErrorMessage = string.Empty,
            };

            var mockSetDemandaHabilitarVendaDigitada = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSetDemandaHabilitarVendaDigitada.request = request;
            mockSetDemandaHabilitarVendaDigitada.response = response;

            mockSets.Add(mockSetDemandaHabilitarVendaDigitada);

            //Habilitar prazo flexível
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1009
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(7),
                ErrorMessage = string.Empty,
            };

            var mockSetDemandaHabilitarPrazoFlexivel = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSetDemandaHabilitarPrazoFlexivel.request = request;
            mockSetDemandaHabilitarPrazoFlexivel.response = response;

            mockSets.Add(mockSetDemandaHabilitarPrazoFlexivel);

            //Desabilitar prazo flexível
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1010
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(8),
                ErrorMessage = string.Empty,
            };

            var mockSetDemandaDesabilitarPrazoFlexivel = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSetDemandaDesabilitarPrazoFlexivel.request = request;
            mockSetDemandaDesabilitarPrazoFlexivel.response = response;

            mockSets.Add(mockSetDemandaDesabilitarPrazoFlexivel);

            //Alterar prazo flexível
            request = new ConsultarPrazoPadraoRequest()
            {
                CodigoCliente = 10011001,
                SubTipoDemanda = "66",
                TipoDemanda = 1011
            };


            response = new ConsultarPrazoPadraoResponse()
            {
                Status = ExecutionStatus.Success,
                DataSLA = DateTime.Now.AddDays(9),
                ErrorMessage = string.Empty,
            };

            var mockSetDemandaAlterarPrazoFlexivel = new MockSet<ConsultarPrazoPadraoRequest, ConsultarPrazoPadraoResponse>();
            mockSetDemandaAlterarPrazoFlexivel.request = request;
            mockSetDemandaAlterarPrazoFlexivel.response = response;

            mockSets.Add(mockSetDemandaAlterarPrazoFlexivel);


            this.WriteObject(@"..\..\Generated\MockConsultarPrazoPadrao.xml", mockSets);
        }

        
        [TestMethod]
        public void TechnicalError()
        {
            var response = new ConsultarPrazoPadraoResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(H)";

            this.WriteObject(@"..\..\Generated\MockConsultarPrazoPadraoError.xml", response);
        }
    }
}
