using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ValidarPermissaoVendaDigitada;
using Cielo.Sirius.Foundation;
using System.Collections.Generic;

namespace MockGenerator
{
    [TestClass]
    public class ValidarPermissaoVendaDigitadaMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>>();

            var request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5960",
                IndicaOperacao = "S"
            };
            
            var response = new ValidarPermissaoVendaDigitadaResponse() {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            var mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5961",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5962",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5964",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5965",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5966",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5967",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5968",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);



            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5969",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "00",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            

            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "7995",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "01",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);




            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "6051",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "01",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5271",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "01",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5993",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "01",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);




            request = new ValidarPermissaoVendaDigitadaRequest()
            {
                CodigoCliente = 10011001,
                CodigoRamoAtividade = "5541",
                IndicaOperacao = "S"
            };

            response = new ValidarPermissaoVendaDigitadaResponse()
            {
                Status = ExecutionStatus.Success,
                TipoDeMensagem = "A",
                ErrorCode = "01",
            };

            mockSet = new MockSet<ValidarPermissaoVendaDigitadaRequest, ValidarPermissaoVendaDigitadaResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockValidarPermissaoVendaDigitada.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ValidarPermissaoVendaDigitadaResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "Falha ao carregar as informações.\n Informe o cliente para tentar mais tarde novamente";

            this.WriteObject(@"..\..\Generated\HabilitarDesabilitarVendaDigitadaMockError.xml", response);
        }
    }
}
