using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarProdutosPrazoFlexivel;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarProdutosPrazoFlexivelMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>>();

            var request = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 1
            };

            var response = new ConsultarProdutosPrazoFlexivelResponse();
            response.Status = ExecutionStatus.Success;

            response.CodigoGrupoPrazoFlexivel = 5678;
            response.Produtos = new List<ConsultarProdutosPrazoFlexivelProdutoDTO>();
            response.Produtos.Add(new ConsultarProdutosPrazoFlexivelProdutoDTO()
            {
                CodigoProduto = 998,
                NomeProduto = "Produto Sucesso",
                CodigoBandeira = 899,
                NomeBandeira = "Visa",
                PercentualTaxaGarantia = 2.5,
                QuantidadeDiasPrazo = 15
            });

            response.Produtos.Add(new ConsultarProdutosPrazoFlexivelProdutoDTO()
            {
                CodigoProduto = 999,
                NomeProduto = "Produto Sucesso 2",
                CodigoBandeira = 456,
                NomeBandeira = "Visa",
                PercentualTaxaGarantia = 2.5,
                QuantidadeDiasPrazo = 14
            });

            var mockSet = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarProdutosPrazoFlexivel.xml", mockSets);
        }

        [TestMethod]
        public void UniTest()
        {
            var mockSets = new List<MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>>();

            #region Retornando Grupo com lista de um elemento

            var request1 = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 1,
            };

            var response1 = new ConsultarProdutosPrazoFlexivelResponse();
            response1.CodigoGrupoPrazoFlexivel = 2;
            response1.Produtos = new List<ConsultarProdutosPrazoFlexivelProdutoDTO>();
            response1.Produtos.Add(new ConsultarProdutosPrazoFlexivelProdutoDTO()
            {
                CodigoProduto = 111,
                NomeProduto = "Retorno de Grupo com 1 elemento",
                CodigoBandeira = 899,
                NomeBandeira = "Visa",
                PercentualTaxaGarantia = 2.5,
                QuantidadeDiasPrazo = 15
            });

            response1.Status = ExecutionStatus.Success;

            var mockSet1 = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet1.request = request1;
            mockSet1.response = response1;

            mockSets.Add(mockSet1);

            #endregion

            #region Retornando Grupo com linde de vinte elementos

            var request2 = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 2,
            };

            var response2 = new ConsultarProdutosPrazoFlexivelResponse();
            response2.CodigoGrupoPrazoFlexivel = 3;
            response2.Produtos = new List<ConsultarProdutosPrazoFlexivelProdutoDTO>();

            for (int i = 0; i < 20; i++)
            {
                response2.Produtos.Add(new ConsultarProdutosPrazoFlexivelProdutoDTO()
                {
                    CodigoProduto = 222,
                    NomeProduto = "Produto Retorno de grupo com 20 elementos",
                    CodigoBandeira = 899,
                    NomeBandeira = "Visa",
                    PercentualTaxaGarantia = 2.5,
                    QuantidadeDiasPrazo = 15
                });
            }
            response2.Status = ExecutionStatus.Success;

            var mockSet2 = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet2.request = request2;
            mockSet2.response = response2;

            mockSets.Add(mockSet2);

            #endregion

            #region Retornando Grupo com lista vazia 
            var request3 = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 3,
            };

            var response3 = new ConsultarProdutosPrazoFlexivelResponse();
            response3.CodigoGrupoPrazoFlexivel = 22;
            response3.Produtos = new List<ConsultarProdutosPrazoFlexivelProdutoDTO>();

            response3.Status = ExecutionStatus.Success;

            var mockSet3 = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            #endregion

            #region Retornando Erro de negócio

            var request4 = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 4
            };

            var response4 = new ConsultarProdutosPrazoFlexivelResponse();

            response4.Status = ExecutionStatus.BusinessError;

            var mockSet4 = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet4.request = request4;
            mockSet4.response = response4;

            mockSets.Add(mockSet4);

            #endregion

            #region Retornando Erro técnico

            var request5 = new ConsultarProdutosPrazoFlexivelRequest()
            {
                CodigoCliente = 5
            };

            var response5 = new ConsultarProdutosPrazoFlexivelResponse();

            response5.Status = ExecutionStatus.TechnicalError;

            var mockSet5 = new MockSet<ConsultarProdutosPrazoFlexivelRequest, ConsultarProdutosPrazoFlexivelResponse>();
            mockSet5.request = request5;
            mockSet5.response = response5;

            mockSets.Add(mockSet5);

            #endregion

            this.WriteObject(@"..\..\Generated\MockConsultarProdutosPrazoFlexivel.xml", mockSets);

        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarProdutosPrazoFlexivelResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(H)";

            this.WriteObject(@"..\..\Generated\ConsultarProdutosPrazoFlexivelMock.xml", response);
        }
    }
}
