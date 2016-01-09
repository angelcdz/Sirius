using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cielo.Sirius.Contracts.ConsultarServicoElegivelCliente;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarServicoElegivelClienteMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>>();

            mockSets.Add(GetMocksetforCustomer(10011001, null));
            mockSets.Add(GetMocksetforCustomer(10011002, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011003, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011004, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011005, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011006, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011007, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011008, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011009, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011010, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011011, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011012, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011013, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011014, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011015, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011016, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011017, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011018, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011019, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011020, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011021, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011022, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011023, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011024, new string[] { "10", "11" }));
            mockSets.Add(GetMocksetforCustomer(10011025, new string[] { "10", "11" }));

            this.WriteObject(@"..\..\Generated\ConsultarServicoElegivelClienteMock.xml", mockSets);
        }

        #region Mock data for Customers

        public MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse> GetMocksetforCustomer(long codigoCliente, string[] codigosServicos)
        {
            var request = new ConsultarServicoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente
            };

            var response = new ConsultarServicoElegivelClienteResponse();

            response.Status = ExecutionStatus.Success;

            response.Servicos = new List<ConsultarServicoClienteElegivelServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Loading
        public MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse> GetMocksetforCustomerErrorLoading(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";

            response.Servicos = new List<ConsultarServicoClienteElegivelServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Action
        public MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse> GetMocksetforCustomerErrorAction(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoElegivelClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";

            response.Servicos = new List<ConsultarServicoClienteElegivelServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoElegivelClienteRequest, ConsultarServicoElegivelClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion

        #region Product List Generation

        private List<ConsultarServicoClienteElegivelServicoDTO> GetFullServiceList()
        {
            var servicos = new List<ConsultarServicoClienteElegivelServicoDTO>();

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "8",
                DescricaoServico = "Recarga Cartão",
                NomeServico = "Recarga Cartão",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "9",
                DescricaoServico = "Plano de TV SKY",
                NomeServico = "Plano de TV SKY",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "10",
                DescricaoServico = "Pagamento com Celular",
                NomeServico = "Pagamento com Celular",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "11",
                DescricaoServico = "Pagamento Parcial",
                NomeServico = "Pagamento Parcial",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "13",
                DescricaoServico = "Serviço Teste 2",
                NomeServico = "Serviço Teste 2",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "16",
                DescricaoServico = "Serviço Teste 5",
                NomeServico = "Serviço Teste 5",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "35",
                DescricaoServico = "Serviço Teste 12",
                NomeServico = "Serviço Teste 12",
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "2",
                DescricaoServico = "ALE",
                NomeServico = "ALE",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "3",
                DescricaoServico = "DOTZ",
                NomeServico = "DOTZ",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "5",
                DescricaoServico = "PROMOFIND",
                NomeServico = "PROMOFIND",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "6",
                DescricaoServico = "PREMIA CTF BR",
                NomeServico = "PREMIA CTF BR",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "7",
                DescricaoServico = "CIELO PROMO",
                NomeServico = "CIELO PROMO",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "1",
                DescricaoServico = "MEI",
                NomeServico = "MEI",
                IndicadorPossuiDemandasAbertas = true,
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "300",
                DescricaoServico = "ME",
                NomeServico = "ME",
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "301",
                DescricaoServico = "TESTE1",
                NomeServico = "TESTE1",
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoClienteElegivelServicoDTO()
            {
                CodigoServico = "400",
                DescricaoServico = "Serviço Teste 400",
                NomeServico = "Serviço Teste 400",
                IndicadorPossuiDemandasAbertas = false
            });

            return servicos;
        }

        #endregion

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarServicoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoElegivelClienteMockError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusiness()
        {
            var response = new ConsultarServicoElegivelClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoElegivelClienteMockErrorBusiness.xml", response);
        }
    }
}
