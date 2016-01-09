using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using System.Linq;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarServicoHabilitadoClienteMock : MockBase
    {

        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>>();

            mockSets.Add(GetMocksetforCustomer(10011001, null));
            mockSets.Add(GetMocksetforCustomer(10011002, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011003, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011004, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011005, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011006, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011007, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011008, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011009, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011010, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011011, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011012, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011013, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011014, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011015, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011016, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011017, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011018, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomerErrorLoading(10011019, new string[] { "300", "301" }));
            mockSets.Add(GetMocksetforCustomer(10011020, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomerErrorAction(10011021, new string[] { "342", "343" }));
            mockSets.Add(GetMocksetforCustomer(10011022, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011023, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011024, new string[] { "5", "6" }));
            mockSets.Add(GetMocksetforCustomer(10011025, new string[] { "5", "6" }));

            this.WriteObject(@"..\..\Generated\ConsultarServicoHabilitadoClienteMock.xml", mockSets);
        }

        #region Mock data for Customers

        public MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse> GetMocksetforCustomer(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoHabilitadoClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoHabilitadoClienteResponse();

            response.Status = ExecutionStatus.Success;
            response.DataUltimaTransacao = new DateTime(2015, 7, 30);
            response.IndicadorVendaUltimoMes = true;

            response.Servicos = new List<ConsultarServicoHabilitadoClienteServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Loading
        public MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse> GetMocksetforCustomerErrorLoading(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoHabilitadoClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";
            
            response.Servicos = new List<ConsultarServicoHabilitadoClienteServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        //Mockset Error Action
        public MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse> GetMocksetforCustomerErrorAction(long codigoCliente_, string[] codigosServicos_)
        {
            var request = new ConsultarServicoHabilitadoClienteRequest()
            {
                CodigoCliente = codigoCliente_
            };

            var response = new ConsultarServicoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "Loading";
            response.ErrorMessage = "Ocorreu um erro e não foi possível realizar a operação \n- ob5le375-4f32-4ddo-ab8c-l96b8b2c72cd \n- 10/08/2015 11:23:40";
            
            response.Servicos = new List<ConsultarServicoHabilitadoClienteServicoDTO>();

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

            var mockSet = new MockSet<ConsultarServicoHabilitadoClienteRequest, ConsultarServicoHabilitadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            return mockSet;
        }

        #endregion


        #region Product List Generation

        private List<ConsultarServicoHabilitadoClienteServicoDTO> GetFullServiceList()
        {
            var servicos = new List<ConsultarServicoHabilitadoClienteServicoDTO>();

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "1",
                DescricaoServico = "MEI",
                NomeServico = "MEI",
                DataHabilitacaoServico = new DateTime(2015, 7, 30),
                IndicadorPossuiDemandasAbertas = true,               
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "2",
                DescricaoServico = "Ale",
                NomeServico = "Ale",
                DataHabilitacaoServico = new DateTime(2015, 7, 25),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "3",
                DescricaoServico = "Dotz",
                NomeServico = "Dotz",
                DataHabilitacaoServico = new DateTime(2015, 7, 18),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "4",
                DescricaoServico = "Linkci",
                NomeServico = "Linkci",
                DataHabilitacaoServico = new DateTime(2015, 7, 4),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "5",
                DescricaoServico = "Promofind",
                NomeServico = "Promofind",
                DataHabilitacaoServico = new DateTime(2015, 06, 20),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "6",
                DescricaoServico = "Premia CTF BR",
                NomeServico = "Premia CTF BR",
                DataHabilitacaoServico = new DateTime(2015, 05, 21),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "7",
                DescricaoServico = "Cielo Promo",
                NomeServico = "Cielo Promo",
                DataHabilitacaoServico = new DateTime(2015, 4, 6),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "12",
                DescricaoServico = "Serviço Teste 1",
                NomeServico = "Serviço Teste 1",
                DataHabilitacaoServico = new DateTime(2015, 1, 1),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "15",
                DescricaoServico = "Serviço Teste 4",
                NomeServico = "Serviço Teste 4",
                DataHabilitacaoServico = new DateTime(2014, 08, 13),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "18",
                DescricaoServico = "Serviço Teste 7",
                NomeServico = "Serviço Teste 7",
                DataHabilitacaoServico = new DateTime(2014, 08, 14),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "19",
                DescricaoServico = "Serviço Teste 8",
                NomeServico = "Serviço Teste 8",
                DataHabilitacaoServico = new DateTime(2014, 08, 15),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "20",
                DescricaoServico = "Serviço Teste 9",
                NomeServico = "Serviço Teste 9",
                DataHabilitacaoServico = new DateTime(2014, 08, 16),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "300",
                DescricaoServico = "MEI",
                NomeServico = "MEI",
                DataHabilitacaoServico = new DateTime(2015, 6, 1),
                IndicadorPossuiDemandasAbertas = true
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "301",
                DescricaoServico = "Ale",
                NomeServico = "Ale",
                DataHabilitacaoServico = new DateTime(2015, 6, 2),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "302",
                DescricaoServico = "Dotz",
                NomeServico = "Dotz",
                DataHabilitacaoServico = new DateTime(2015, 6, 3),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "303",
                DescricaoServico = "Linkci",
                NomeServico = "Linkci",
                DataHabilitacaoServico = new DateTime(2015, 6, 4),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "304",
                DescricaoServico = "Promofind",
                NomeServico = "Promofind",
                DataHabilitacaoServico = new DateTime(2015, 6, 5),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "305",
                DescricaoServico = "Premia CTF BR",
                NomeServico = "Premia CTF BR",
                DataHabilitacaoServico = new DateTime(2015, 6, 6),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "306",
                DescricaoServico = "Cielo Promo",
                NomeServico = "Cielo Promo",
                DataHabilitacaoServico = new DateTime(2015, 6, 7),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "307",
                DescricaoServico = "Recarga Cartão",
                NomeServico = "Recarga Cartão",
                DataHabilitacaoServico = new DateTime(2015, 6, 8),
                IndicadorPossuiDemandasAbertas = false
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "308",
                DescricaoServico = "Plano de TV SKY",
                NomeServico = "Plano de TV SKY",
                DataHabilitacaoServico = new DateTime(2015, 6, 9),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "309",
                DescricaoServico = "Pagamento com Celular",
                NomeServico = "Pagamento com Celular",
                DataHabilitacaoServico = new DateTime(2015, 6, 10),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "310",
                DescricaoServico = "Pagamento Parcial",
                NomeServico = "Pagamento Parcial",
                DataHabilitacaoServico = new DateTime(2015, 08, 15),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "311",
                DescricaoServico = "Recarga Cartão",
                NomeServico = "Recarga Cartão",
                DataHabilitacaoServico = new DateTime(2015, 6, 12),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "342",
                DescricaoServico = "Serviço Generico 9",
                NomeServico = "Serviço Generico 9",
                DataHabilitacaoServico = new DateTime(2014, 7, 13),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "343",
                DescricaoServico = "Serviço Generico 10",
                NomeServico = "Serviço Generico 10",
                DataHabilitacaoServico = new DateTime(2015, 7, 14),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "344",
                DescricaoServico = "Serviço Generico 11",
                NomeServico = "Serviço Generico 11",
                DataHabilitacaoServico = new DateTime(2015, 7, 15),
                IndicadorPossuiDemandasAbertas = false,
            });

            servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
            {
                CodigoServico = "345",
                DescricaoServico = "Serviço Generico 12",
                NomeServico = "Serviço Generico 12",
                DataHabilitacaoServico = new DateTime(2015, 7, 16),
                IndicadorPossuiDemandasAbertas = false,
            });

            for (int i = 351; i < 500; i++)
            {
                servicos.Add(new ConsultarServicoHabilitadoClienteServicoDTO()
                {
                    CodigoServico = i.ToString(),
                    DescricaoServico = "Serviço Generico " + i.ToString(),
                    NomeServico = "Serviço Generico " + i.ToString(),
                    DataHabilitacaoServico = new DateTime(2015, 7, 17),
                    IndicadorPossuiDemandasAbertas = false,
                });
            }

            return servicos;
        }

        #endregion

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarServicoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoHabilitadoClienteMockError.xml", response);
        }

        [TestMethod]
        public void ErrorDataBusiness()
        {
            var response = new ConsultarServicoHabilitadoClienteResponse();
            response.Status = Cielo.Sirius.Foundation.ExecutionStatus.BusinessError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\ConsultarServicoHabilitadoClienteMockErrorBusiness.xml", response);
        }
    }
}
