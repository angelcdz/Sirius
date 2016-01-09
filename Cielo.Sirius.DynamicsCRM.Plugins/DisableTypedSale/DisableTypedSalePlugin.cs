using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Cielo.Sirius.DynamicsCRM.Plugins.XRMSDKPlugins;
using Microsoft.Xrm.Sdk.Messages;

namespace Cielo.Sirius.DynamicsCRM.Plugins.DisableTypedSale
{
    public class DisableTypedSalePlugin: PluginBase
    {
        Guid InitiatingUserId = Guid.Empty;
        string localizedErrorMessage = string.Empty;

        public DisableTypedSalePlugin()
            : base(typeof(DisableTypedSalePlugin))
        {
            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(40, "cielo_PrSvDisableTypedSaleAc", "", new Action<LocalPluginContext>(ExecuteCielo_PrSvDisableTypedSaleAc)));
        }

        protected void ExecuteCielo_PrSvDisableTypedSaleAc(LocalPluginContext localContext)
        {
            try
            {
                if (localContext == null)
                {
                    throw new ArgumentNullException("localContext");
                }

                // Verificando se o plugin não foi chamado por outro plugin
                if (localContext.PluginExecutionContext.Depth > 1)
                    return;

                //Instancia as entidades enviadas à Action
                var entityTargetReference = GetEntityParameter<EntityReference>("Target");
                var parameterizationReference = GetEntityParameter<EntityReference>("RequestParameterization");
                var requestCase = GetEntityParameter<Entity>("RequestCase").ToEntity<Incident>();
                var productRequest = GetEntityParameter<Entity>("ProductRequest").ToEntity<cielo_productrequest>();
                var affectedProducts = GetEntityParameter<EntityCollection>("AffectedProducts");

                var entityTarget = GetEntityById(entityTargetReference.LogicalName, 
                                                entityTargetReference.Id,
                                                new ColumnSet("customerid", 
                                                            "cielo_servicecallnumber", 
                                                            "cielo_commercialestablishmentid", 
                                                            "cielo_teamid",
                                                            "cielo_contactid"))
                                                .ToEntity<Incident>();
                var parameterization = GetEntityById(parameterizationReference.LogicalName,
                                                parameterizationReference.Id,
                                                new ColumnSet("cielo_subjectid","cielo_name"))
                                                .ToEntity<cielo_requestparameter>();

                //Seta os valores da case a ser criada
                requestCase.ParentCaseId = new EntityReference(Incident.EntityLogicalName, entityTarget.Id);
                requestCase.cielo_requestparamterid = new EntityReference(cielo_requestparameter.EntityLogicalName, parameterization.Id);
                requestCase.cielo_servicechannelcode = new OptionSetValue(791880020);
                requestCase.cielo_processtypecode = new OptionSetValue(791880020);
                requestCase.CaseOriginCode = new OptionSetValue(1);
                requestCase.CaseTypeCode = new OptionSetValue(3);
                requestCase.StatusCode = requestCase.StatusCode != null? requestCase.StatusCode : new OptionSetValue(1);
                requestCase.cielo_servicecallnumber = entityTarget.cielo_servicecallnumber;
                requestCase.CustomerId = entityTarget.CustomerId;
                requestCase.cielo_commercialestablishmentid = entityTarget.cielo_commercialestablishmentid;
                requestCase.cielo_contactid = entityTarget.cielo_contactid;
                requestCase.cielo_teamid = entityTarget.cielo_teamid;
                requestCase.SubjectId = parameterization.cielo_subjectid;
                requestCase.Id = localContext.OrganizationService.Create(requestCase);
                
                //Seta os valores da solicitacao a ser criada
                productRequest.cielo_caseId = new EntityReference(Incident.EntityLogicalName, requestCase.Id);
                productRequest.cielo_name = parameterization.cielo_name;
                productRequest.OwnerId = requestCase.OwnerId;
                productRequest.cielo_requestreasoncode = requestCase.cielo_requestreasoncode;
                productRequest.cielo_requestparameterizationcode = new EntityReference(cielo_requestparameter.EntityLogicalName, parameterization.Id);
                productRequest.cielo_typedsaleindicator = false;
                productRequest.Id = localContext.OrganizationService.Create(productRequest);

                //Recupera do CRM o case que foi e criado e que teve o seu titulo atualizado via plugin
                requestCase = localContext.OrganizationService.Retrieve(Incident.EntityLogicalName, requestCase.Id, new ColumnSet("title")).ToEntity<Incident>();

                //Seta os valores e cria as entidade Produto da solicitacao
                foreach (var item in affectedProducts.Entities)
                {
                    var requestProduct = item.ToEntity<cielo_requestproduct>();
                        //
                    //requestProduct.cielo_productname = item.ToEntity<cielo_requestproduct>().cielo_productname;
                    //requestProduct.cielo_productcode = item.ToEntity<cielo_requestproduct>().cielo_productcode;
                    requestProduct.cielo_productrequestcode = new EntityReference(cielo_productrequest.EntityLogicalName, productRequest.Id);
                    requestProduct.cielo_name = string.Concat(requestCase.Title, " - ", requestProduct.cielo_productcode);
                    localContext.OrganizationService.Create(requestProduct);
                }
            }
            catch (InvalidPluginExecutionException ex)
            {
                throw ex;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                //string friendlyMessage = ExceptionManagement.LogException(ex, Entities.Exception.Priority.Medium, localContext.OrganizationService);
                //throw new InvalidPluginExecutionException(friendlyMessage);
            }
            catch (Exception ex)
            {
                //string friendlyMessage = ExceptionManagement.LogException(ex, Entities.Exception.Priority.Medium, localContext.OrganizationService);
                //throw new InvalidPluginExecutionException(friendlyMessage);
            }
        }

        
    }
}
