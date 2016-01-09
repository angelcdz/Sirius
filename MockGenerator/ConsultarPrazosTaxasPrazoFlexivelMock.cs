using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarPrazosTaxasPrazoFlexivelMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>>();

            var request = new ConsultarPrazosTaxasPrazoFlexivelRequest() 
            { 
                CodigoCliente = 1
            };

            var response = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            response.Status = ExecutionStatus.Success;

            response.GruposProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelDTO>();
            response.GruposProdutoPrazoFlexivel.Add(new ConsultarPrazosTaxasPrazoFlexivelDTO()
            {
                CodigoGrupoPrazoFlexivel = 1,
                DescricaoGrupoPrazoFlexivel = "Flexivel",
                IndicadorHabilitado = "N",
                DadosTarifasGrupoProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO>()
            });
            response.GruposProdutoPrazoFlexivel.Add(new ConsultarPrazosTaxasPrazoFlexivelDTO()
            {
                CodigoGrupoPrazoFlexivel = 2,
                DescricaoGrupoPrazoFlexivel = "Não Flexivel",
                IndicadorHabilitado = "N",
                DadosTarifasGrupoProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO>()
            });

            foreach (var item in response.GruposProdutoPrazoFlexivel)
            {
                item.DadosTarifasGrupoProdutoPrazoFlexivel.Add(
                    new ConsultarPrazosTaxasPrazoFlexivelTarifasDTO()
                {
                    PercentualTaxaGrupoPrazoFlexivel = 9999.00,
                    QuantidadeDiasGrupoPrazoFlexivel = 100                    
                });
            }

            var mockSet = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarPrazosTaxasPrazoFlexivel.xml", mockSets);
        }

        [TestMethod]
        public void UniTest()
        {
            var mockSets = new List<MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>>();

            #region Retornando Lista Vazia

            var request1 = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 1,
                CodigoGrupoPrazoFlexivel = 1
            };

            var response1 = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            response1.GruposProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelDTO>();
            response1.GruposProdutoPrazoFlexivel.Add(
                new ConsultarPrazosTaxasPrazoFlexivelDTO()
                {
                    CodigoGrupoPrazoFlexivel = 1,
                    DadosTarifasGrupoProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO>(),
                    DescricaoGrupoPrazoFlexivel = "Grupo com retorno vazio",
                    IndicadorHabilitado = "H"
                }
            );
            response1.Status = ExecutionStatus.Success;

            var mockSet1 = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet1.request = request1;
            mockSet1.response = response1;

            mockSets.Add(mockSet1);

            #endregion

            #region Retornando Lista com um elemento

            var request2 = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 2,
                CodigoGrupoPrazoFlexivel = 2
            };

            var response2 = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            response2.GruposProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelDTO>();
            response2.GruposProdutoPrazoFlexivel.Add(
                new ConsultarPrazosTaxasPrazoFlexivelDTO()
                {
                    CodigoGrupoPrazoFlexivel = 2,
                    DadosTarifasGrupoProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO>(),
                    DescricaoGrupoPrazoFlexivel = "Grupo com retorno de um elemento",
                    IndicadorHabilitado = "H"
                }
            );
            response2.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel.Add(
                new ConsultarPrazosTaxasPrazoFlexivelTarifasDTO()
                {
                    PercentualTaxaGrupoPrazoFlexivel = 3d,
                    QuantidadeDiasGrupoPrazoFlexivel = 4
                }
            );
            
            response2.Status = ExecutionStatus.Success;

            var mockSet2 = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet2.request = request2;
            mockSet2.response = response2;

            mockSets.Add(mockSet2);

            #endregion

            #region Retornando Lista com vinte elementos

            var request3 = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 3,
                CodigoGrupoPrazoFlexivel = 3
            };

            var response3 = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            response3.GruposProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelDTO>();
            response3.GruposProdutoPrazoFlexivel.Add(
                new ConsultarPrazosTaxasPrazoFlexivelDTO()
                {
                    CodigoGrupoPrazoFlexivel = 3,
                    DadosTarifasGrupoProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelTarifasDTO>(),
                    DescricaoGrupoPrazoFlexivel = "Grupo com retorno de vinte elementos",
                    IndicadorHabilitado = "H"
                }
            );
            for (int i = 0; i < 20; i++)
            {
                response3.GruposProdutoPrazoFlexivel[0].DadosTarifasGrupoProdutoPrazoFlexivel.Add(
                    new ConsultarPrazosTaxasPrazoFlexivelTarifasDTO()
                    {
                        PercentualTaxaGrupoPrazoFlexivel = ((double)i)/4,
                        QuantidadeDiasGrupoPrazoFlexivel = i+10
                    }
                );
            }
            response3.Status = ExecutionStatus.Success;

            var mockSet3 = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet3.request = request3;
            mockSet3.response = response3;

            mockSets.Add(mockSet3);

            #endregion

            #region Retornando Erro de negócio

            var request4 = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 4,
                CodigoGrupoPrazoFlexivel = 4
            };

            var response4 = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            
            response4.Status = ExecutionStatus.BusinessError;

            var mockSet4 = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet4.request = request4;
            mockSet4.response = response4;

            mockSets.Add(mockSet4);

            #endregion

            #region Retornando Erro técnico

            var request5 = new ConsultarPrazosTaxasPrazoFlexivelRequest()
            {
                CodigoCliente = 5,
                CodigoGrupoPrazoFlexivel = 5
            };

            var response5 = new ConsultarPrazosTaxasPrazoFlexivelResponse();

            response5.Status = ExecutionStatus.TechnicalError;

            var mockSet5 = new MockSet<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>();
            mockSet5.request = request5;
            mockSet5.response = response5;

            mockSets.Add(mockSet5);

            #endregion

            this.WriteObject(@"..\..\Generated\MockUnitTestConsultarPrazosTaxasPrazoFlexivel.xml", mockSets);

        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarPrazosTaxasPrazoFlexivelResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(H)";

            this.WriteObject(@"..\..\Generated\ConsultarPrazosTaxasPrazoFlexivelMock.xml", response);
        }
    }
}
