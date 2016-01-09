using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.Foundation;

namespace MockGenerator
{
    [TestClass]
    public class ConsultarDetalheProdutoMultivanContratadoClienteMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                            ConsultarDetalheProdutoMultivanContratadoClienteResponse>>();

            var request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "6"
            };

            var response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>();

            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Concorrente",
                NumeroCadastroEmpresa = "12344321",
                InicioVigencia = new DateTime(2015, 1, 1),
                FimVigencia = new DateTime(2015, 1, 10)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa Concorrente Número Um",
                NumeroCadastroEmpresa = "11111111111111111111111",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "",
                NumeroCadastroEmpresa = "",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa 2",
                NumeroCadastroEmpresa = "1919181819",
                InicioVigencia = new DateTime(2015, 2, 10)
            });


            var mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "66"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>();

            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Concorrente",
                NumeroCadastroEmpresa = "12344321",
                InicioVigencia = new DateTime(2015, 1, 1),
                FimVigencia = new DateTime(2015, 1, 10)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa Concorrente Número Um",
                NumeroCadastroEmpresa = "11111111111111111111111",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "",
                NumeroCadastroEmpresa = "",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa 2",
                NumeroCadastroEmpresa = "1919181819",
                InicioVigencia = new DateTime(2015, 2, 10)
            });


            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011001,
                CodigoProduto = "65"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>();

            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Concorrente",
                NumeroCadastroEmpresa = "12344321",
                InicioVigencia = new DateTime(2015, 1, 1),
                FimVigencia = new DateTime(2015, 1, 10)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa Concorrente Número Um",
                NumeroCadastroEmpresa = "11111111111111111111111",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "",
                NumeroCadastroEmpresa = "",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa 2",
                NumeroCadastroEmpresa = "1919181819",
                InicioVigencia = new DateTime(2015, 2, 10)
            });


            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.BusinessError;

            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1003"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>();

            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Concorrente",
                NumeroCadastroEmpresa = "12344321",
                InicioVigencia = new DateTime(2015, 1, 1),
                FimVigencia = new DateTime(2015, 1, 10)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa Concorrente Número Um",
                NumeroCadastroEmpresa = "11111111111111111111111",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "",
                NumeroCadastroEmpresa = "",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa 2",
                NumeroCadastroEmpresa = "1919181819",
                InicioVigencia = new DateTime(2015, 2, 10)
            });


            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011020,
                CodigoProduto = "1005"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.Success;
            response.DetalhesMultivan = new List<ConsultarDetalheProdutoMultivanContratadoClienteDTO>();

            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Concorrente",
                NumeroCadastroEmpresa = "12344321",
                InicioVigencia = new DateTime(2015, 1, 1),
                FimVigencia = new DateTime(2015, 1, 10)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa Concorrente Número Um",
                NumeroCadastroEmpresa = "11111111111111111111111",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "",
                NumeroCadastroEmpresa = "",
                InicioVigencia = new DateTime(2015, 2, 10),
                FimVigencia = new DateTime(2016, 1, 9)
            });
            response.DetalhesMultivan.Add(new ConsultarDetalheProdutoMultivanContratadoClienteDTO()
            {
                NomeEmpresa = "Empresa 2",
                NumeroCadastroEmpresa = "1919181819",
                InicioVigencia = new DateTime(2015, 2, 10)
            });


            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);


            request = new ConsultarDetalheProdutoMultivanContratadoClienteRequest()
            {
                CodigoCliente = 10011022,
                CodigoProduto = "6"
            };

            response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.TechnicalError;

            mockSet = new MockSet<ConsultarDetalheProdutoMultivanContratadoClienteRequest,
                                      ConsultarDetalheProdutoMultivanContratadoClienteResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoMultivanContratadoCliente.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new ConsultarDetalheProdutoMultivanContratadoClienteResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "007";
            response.ErrorMessage = "INVALID ACCOUNT(N-H)";

            this.WriteObject(@"..\..\Generated\MockConsultarDetalheProdutoMultivanContratadoClienteMockError.xml", response);
        }
    }
}
