using Cielo.Sirius.Contracts.ConsultarPrazosTaxasPrazoFlexivel;
using Cielo.Sirius.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Contracts;
using Cielo.Sirius.DAO.Products.WR.Cliente;
using Cielo.Sirius.DAO.Products.WR.Cliente.Extensions;


namespace Cielo.Sirius.DAO.Products
{
    public class ConsultarPrazosTaxasPrazoFlexivelDAO : DAOOSBBase<ConsultarPrazosTaxasPrazoFlexivelRequest, ConsultarPrazosTaxasPrazoFlexivelResponse>
    {
        protected override ConsultarPrazosTaxasPrazoFlexivelResponse GetData(ConsultarPrazosTaxasPrazoFlexivelRequest requestData)
        {
            // Cria objeto Response
            var response = new ConsultarPrazosTaxasPrazoFlexivelResponse()
                {
                    GruposProdutoPrazoFlexivel = new List<ConsultarPrazosTaxasPrazoFlexivelDTO>()
                };

            //[Rule]: Chamada ao serviço do barramento
            //ClienteServicePortTypeClient client = new ClienteServicePortTypeClient("ClienteServiceSOAP");
            WR.Cliente.ClienteService client = new WR.Cliente.ClienteService();

            //[Rule]: Recuperação dos dados de credenciais no CredentialManager
            client.cieloSoapHeader = this.GetSoapHeader();

            string codigoRetorno = string.Empty;
            string descricaoRetornoMensagem = string.Empty;
            string proximoRegistro = string.Empty;
            string chavePaginacao = string.Empty;

            try
            {
                do
                {
                    DadosGrupoProdutoPrazoFlexivelType[] dadosGrupoProdutoResponse = client.consultarPrazosTaxasPrazoFlexivel(codigoCliente: requestData.CodigoCliente,
                        codigoGrupoPrazoFlexivel: requestData.CodigoGrupoPrazoFlexivel.ToString(), // WSDL atual espera uma string, porém será alterado para int.
                        proximoRegistro: ref proximoRegistro,
                        chavePaginacao: ref chavePaginacao,
                        codigoRetorno: out codigoRetorno,
                        descricaoRetornoMensagem: out descricaoRetornoMensagem);

                    //[Rule]: Business Error: Returns immediately
                    if (codigoRetorno != Constants.RETURN_CODE_SEC_SUCCESS)
                    {
                        response.ErrorCode = codigoRetorno;
                        response.ErrorMessage = descricaoRetornoMensagem;
                        response.Status = ExecutionStatus.BusinessError;
                        return response;
                    }
                    else
                    {
                        response.Status = ExecutionStatus.Success;
                    }

                    foreach (DadosGrupoProdutoPrazoFlexivelType dadoGrupoProdutoResponse in dadosGrupoProdutoResponse)
                    {
                        if (dadoGrupoProdutoResponse != null)
                        {
                            var GruposProdutoPrazoFlexivelDTO = new ConsultarPrazosTaxasPrazoFlexivelDTO();

                            int codigoGrupoPrazoFlexivel = 0;
                            if (int.TryParse(dadoGrupoProdutoResponse.codigoGrupoPrazoFlexivel, out codigoGrupoPrazoFlexivel))
                                GruposProdutoPrazoFlexivelDTO.CodigoGrupoPrazoFlexivel = codigoGrupoPrazoFlexivel;
                            GruposProdutoPrazoFlexivelDTO.DescricaoGrupoPrazoFlexivel = dadoGrupoProdutoResponse.descricaoGrupoPrazoFelxivel;
                            GruposProdutoPrazoFlexivelDTO.IndicadorHabilitado = dadoGrupoProdutoResponse.IndicadorHabilitado;

                            foreach (TarifaGrupoProdutoPrazoFlexivel dadosTarifasGrupoProdutoPrazoFlexivel in dadoGrupoProdutoResponse.dadosTarifasGrupoProdutoPrazoFlexivel)
                            {
                                if (dadoGrupoProdutoResponse.dadosTarifasGrupoProdutoPrazoFlexivel != null)
                                {
                                    var PrazosTaxasPrazoFlexivelDTO = new ConsultarPrazosTaxasPrazoFlexivelTarifasDTO();

                                    PrazosTaxasPrazoFlexivelDTO.PercentualTaxaGrupoPrazoFlexivel = dadosTarifasGrupoProdutoPrazoFlexivel.percentualTaxaGrupoPrazoFlexivel;

                                    int quantidadeDiasGrupoPrazoFlexivel = 0;
                                    if (int.TryParse(dadosTarifasGrupoProdutoPrazoFlexivel.quantidadeDiasGrupoPrazoFlexivel, out quantidadeDiasGrupoPrazoFlexivel))
                                        PrazosTaxasPrazoFlexivelDTO.QuantidadeDiasGrupoPrazoFlexivel = quantidadeDiasGrupoPrazoFlexivel;

                                    GruposProdutoPrazoFlexivelDTO.DadosTarifasGrupoProdutoPrazoFlexivel.Add(PrazosTaxasPrazoFlexivelDTO);
                                }
                            }

                            response.GruposProdutoPrazoFlexivel.Add(GruposProdutoPrazoFlexivelDTO);
                        }
                    }
                } while (!string.IsNullOrEmpty(proximoRegistro) && !string.IsNullOrEmpty(chavePaginacao));
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return response;

        }
    }
}
