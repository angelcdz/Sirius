using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;
using Cielo.Sirius.DAO.Products;
using Cielo.Sirius.Contracts.CalcularAlcadaFaixasParceladoSegmentado;
using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Contracts.GetCommercialEstablishmentInformation;

namespace Cielo.Sirius.Business.Products
{
    public class CalcularAlcadaFaixasParceladoSegmentadoBL : BusinessLogicBase<CalcularAlcadaFaixasParceladoSegmentadoRequest, CalcularAlcadaFaixasParceladoSegmentadoResponse>
    {
        public override CalcularAlcadaFaixasParceladoSegmentadoResponse Execute(CalcularAlcadaFaixasParceladoSegmentadoRequest requestData)
        {
            var daoAlcada = DAOFactory.GetDAO<GetDiscountRateRestrictionDAO, GetDiscountRateRestrictionRequest, GetDiscountRateRestrictionResponse>();
            var responseCRM = new CalcularAlcadaFaixasParceladoSegmentadoResponse();

            foreach (var item in requestData.Taxas)
            {
                var resp = daoAlcada.Execute(new GetDiscountRateRestrictionRequest()
                            {
                                AgentGroupCode = requestData.IlhaAtendimento,
                                ProductCode = requestData.CodigoProduto,
                                BranchActivityCode = requestData.MCC,
                                UserId = requestData.UserId,
                                DefaultRate = item.PercentualTaxaPadrao
                            });

                responseCRM.Taxas.Add(new CalcularAlcadaFaixasParceladoSegmentadoTaxaDTO()
                {
                    CodigoFaixa = item.CodigoFaixa,
                    NumeroFinalParcelaFaixa = item.NumeroFinalParcelaFaixa,
                    NumeroInicialParcelaFaixa = item.NumeroInicialParcelaFaixa,
                    PercentualDescontoAlcada = resp.DiscountRateRestrictionPercentage,
                    PercentualMaximoDescontoAlcada = resp.MaxDiscountRateRestrictionPercentage,
                    PercentualMinimoDescontoAlcada = resp.MinDiscountRateRestrictionPercentage,
                    PercentualTaxaPadrao = item.PercentualTaxaPadrao,
                    TaxaMatriz = item.TaxaMatriz
                });
            }

            responseCRM.Status = ExecutionStatus.Success;

            return responseCRM;
        }
    }
}
