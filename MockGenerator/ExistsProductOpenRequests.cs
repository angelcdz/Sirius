using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ExistsProductOpenDemand;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class ExistsProductOpenRequests : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ExistsProductOpenDemandRequest, ExistsProductOpenDemandResponse>>();

            var request = new ExistsProductOpenDemandRequest();
            request.CodigoCliente = 1;
            request.CodigoProdutos.Add("0001");
            request.CodigoProdutos.Add("0002");
            request.CodigoProdutos.Add("0003");
            request.CodigoProdutos.Add("0004");
            request.CodigoProdutos.Add("0005");
            request.CodigoProdutos.Add("0006");
            request.CodigoProdutos.Add("0007");
            request.CodigoProdutos.Add("0008");
            request.CodigoProdutos.Add("0009");
            request.CodigoProdutos.Add("0010");
            request.CodigoProdutos.Add("0011");
            request.CodigoProdutos.Add("0012");
            request.CodigoProdutos.Add("0013");
            request.CodigoProdutos.Add("0014");
            request.CodigoProdutos.Add("0015");

            var response = new ExistsProductOpenDemandResponse();
            response.Status = ExecutionStatus.Success;
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0001", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0002", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0003", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0004", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0005", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0006", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0007", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0008", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0009", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0010", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0011", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0012", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0013", IndicadorPossuiDemandasAbertas = false });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0014", IndicadorPossuiDemandasAbertas = true });
            response.ExistsProductOpenRequests.Add(new ExistsProductOpenDemandDTO() { CodigoProduto = "0015", IndicadorPossuiDemandasAbertas = true });

            var mockSet = new MockSet<ExistsProductOpenDemandRequest, ExistsProductOpenDemandResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockExistsProductOpenDemand.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ExistsProductOpenDemandResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "005";
            response.ErrorMessage = "CRM generic error";

            this.WriteObject(@"..\..\Generated\MockExistsProductOpenDemandError.xml", response);
        }
    }
}
