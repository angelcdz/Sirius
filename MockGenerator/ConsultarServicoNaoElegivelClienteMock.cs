using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarServicoNaoElegivelClienteMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>>();

            mockSets.Add(GetMocksetforCustomer(10011001, null));
            mockSets.Add(GetMocksetforCustomer(10011002, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011003, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011004, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011005, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011006, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011007, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011008, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011009, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011010, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011011, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011012, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011013, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011014, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011015, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011016, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011017, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011018, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011019, new string[] { "300", "301" }));
            mockSets.Add(GetMocksetforCustomer(10011020, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011021, new string[] { "342", "343" }));
            mockSets.Add(GetMocksetforCustomer(10011022, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011023, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011024, new string[] { "14" }));
            mockSets.Add(GetMocksetforCustomer(10011025, new string[] { "14" }));


            this.WriteObject(@"..\..\Generated\ConsultarServicoNaoElegivelClienteMock.xml", mockSets);
        }

        #region Mock data for Customers

        public MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse> GetMocksetforCustomer(long codigoCliente, string[] codigosServicos)
        {
            var request = new ConsultarServicoNaoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarServicoNaoElegivelClienteResponse();
            response.Status = ExecutionStatus.Success;

            response.Servicos = new List<ConsultarServicoNaoElegivelClienteServicoDTO>();

            if (codigosServicos != null)
            {
                var servicos = from servico in GetFullServiceList()
                               where codigosServicos.Contains(servico.CodigoServico)
                               select servico;

                response.Servicos.AddRange(servicos);
            }
            else
            {
                response.Servicos.AddRange(GetFullServiceList());
            }

            response.NumeroTotalRegistros = response.Servicos.Count;

            var mockSet = new MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Loading
        public MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse> GetMocksetforCustomerErrorLoading(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoNaoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";

            response.Servicos = new List<ConsultarServicoNaoElegivelClienteServicoDTO>();

            if (codigosServicos_ != null)
            {
                var servicos = from servico in GetFullServiceList()
                               where codigosServicos_.Contains(servico.CodigoServico)
                               select servico;

                response.Servicos.AddRange(servicos);
            }
            else
            {
                response.Servicos.AddRange(GetFullServiceList());
            }

            response.NumeroTotalRegistros = response.Servicos.Count;

            var mockSet = new MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Action
        public MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse> GetMocksetforCustomerErrorAction(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoNaoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";

            response.Servicos = new List<ConsultarServicoNaoElegivelClienteServicoDTO>();

            if (codigosServicos_ != null)
            {
                var servicos = from servico in GetFullServiceList()
                               where codigosServicos_.Contains(servico.CodigoServico)
                               select servico;

                response.Servicos.AddRange(servicos);
            }
            else
            {
                response.Servicos.AddRange(GetFullServiceList());
            }

            response.NumeroTotalRegistros = response.Servicos.Count;

            var mockSet = new MockSet<ConsultarServicoNaoElegivelClienteRequest, ConsultarServicoNaoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion

        #region Product List Generation

        private List<ConsultarServicoNaoElegivelClienteServicoDTO> GetFullServiceList()
        {
            var servicos = new List<ConsultarServicoNaoElegivelClienteServicoDTO>();

            servicos.Add(new ConsultarServicoNaoElegivelClienteServicoDTO()
            {
                CodigoServico = "14",
                DescricaoServico = "Serviço Teste 3",
                NomeServico = "Serviço Teste 3",
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoNaoElegivelClienteServicoDTO()
            {
                CodigoServico = "17",
                DescricaoServico = "Serviço Teste 6",
                NomeServico = "Serviço Teste 6",
                IndicadorPossuiDemandasAbertas = false
            });

            return servicos;
        }

        #endregion

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarServicoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoNaoElegivelClienteMockError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusiness()
        {
            var response = new ConsultarServicoNaoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoNaoElegivelClienteMockErrorBusiness.xml", response);
        }
    }
}
