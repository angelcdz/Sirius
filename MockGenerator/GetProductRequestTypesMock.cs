using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.GetEnabledProductRequestTypes;
using Cielo.Sirius.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MockGenerator
{
    [TestClass]
    public class GetProductRequestTypesMock : MockBase
    {
        [TestMethod]
        public void BasicData()
        {
            var mockSets = new List<MockSet<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>>();

            var request = new GetEnabledProductRequestTypesRequest();
            request.ProductGroup = Constants.GRUPO_PRODUTO_ELEGIVEL_HABILITADO;

            var response = new GetEnabledProductRequestTypesResponse();
            response.Status = ExecutionStatus.Success;
            response.ProductRequestTypes = new List<GetEnabledProductRequestTypesDTO>();
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_ALTERACAODETAXA, Name = "Alteração de Taxa" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_SOLICITACAODENEGOCIACAODETAXA, Name = "Solicitação de Negociação de Taxa" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_HABILITARPRODUTO, Name = "Habilitar Produto" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_DESABILITARPRODUTO, Name = "Desabilitar Produto" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_HABILITARPRAZOFLEXIVEL, Name = "Habilitar Prazo Flexível" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_DESABILITARPRAZOFLEXIVEL, Name = "Desabilitar Prazo Flexível" });
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_ALTERARPRAZOFLEXIVEL, Name = "Alterar Prazo Flexível" });

            var mockSet = new MockSet<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new GetEnabledProductRequestTypesRequest();
            request.ProductGroup = Constants.GRUPO_PRODUTO_ELEGIVEL_NAOHABILITADO;

            response = new GetEnabledProductRequestTypesResponse();
            response.Status = ExecutionStatus.Success;
            response.ProductRequestTypes = new List<GetEnabledProductRequestTypesDTO>();
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_HABILITARPRODUTO, Name = "Habilitar Produto" });

            mockSet = new MockSet<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            request = new GetEnabledProductRequestTypesRequest();
            request.ProductGroup = Constants.GRUPO_PRODUTO_NAOELEGIVEL;

            response = new GetEnabledProductRequestTypesResponse();
            response.Status = ExecutionStatus.Success;
            response.ProductRequestTypes = new List<GetEnabledProductRequestTypesDTO>();
            response.ProductRequestTypes.Add(new GetEnabledProductRequestTypesDTO() { IntegrationRequestCode = Constants.TIPO_SOLICITACAO_PRODUTO_HABILITARPRODUTO, Name = "Habilitar Produto" });

            mockSet = new MockSet<GetEnabledProductRequestTypesRequest, GetEnabledProductRequestTypesResponse>();
            mockSet.request = request;
            mockSet.response = response;

            mockSets.Add(mockSet);

            this.WriteObject(@"..\..\Generated\MockGetProductRequestTypes.xml", mockSets);
        }

        [TestMethod]
        public void ErrorData()
        {
            var response = new GetEnabledProductRequestTypesResponse();
            response.Status = ExecutionStatus.TechnicalError;
            response.ErrorCode = "005";
            response.ErrorMessage = "CRM generic error";

            this.WriteObject(@"..\..\Generated\MockGetProductRequestTypesError.xml", response);
        }
    }
}
