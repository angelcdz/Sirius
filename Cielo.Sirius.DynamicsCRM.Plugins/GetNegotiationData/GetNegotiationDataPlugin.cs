using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using System.Collections;
using Cielo.Sirius.DynamicsCRM.Plugins.XRMSDKPlugins;

namespace Cielo.Sirius.DynamicsCRM.Plugins.DiscountRateRestriction
{
    public class GetNegotiationDataPlugin : PluginBase
    {
        public GetNegotiationDataPlugin()
            : base(typeof(GetNegotiationDataPlugin))
        {
            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(40, "cielo_CmNeGetNegotiationDataAction", "", new Action<LocalPluginContext>(ExecuteCielo_CmNeGetNegotiationDataAction)));
        }

        protected void ExecuteCielo_CmNeGetNegotiationDataAction(LocalPluginContext localContext)
        {
            try
            {
                if (localContext == null) throw new ArgumentNullException("localContext");

                if (localContext.PluginExecutionContext.Depth > 1) return;

                var commercialEstablishment = (EntityReference)localContext.PluginExecutionContext.InputParameters["CommercialEstablishment"];
                var agentGroup = (EntityReference)localContext.PluginExecutionContext.InputParameters["AgentGroup"];
                var requestParameterization = (EntityReference)localContext.PluginExecutionContext.InputParameters["RequestParameterization"];
                var collection = new EntityCollection();

                localContext.PluginExecutionContext.OutputParameters["DoOffersExist"] = 
                localContext
                    .OrganizationService
                    .RetrieveMultiple(
                    new FetchExpression(String.Format(@"
                    <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                        <entity name='cielo_customeroffer'>
                        <attribute name='cielo_customerofferid' />
                        <attribute name='cielo_customeroffername' />
                        <order attribute='cielo_customeroffername' descending='false' />
                        <filter type='and'>
                            <condition attribute='statecode' operator='eq' value='0' />
                            <condition attribute='cielo_responseid' operator='null' />
                            <condition attribute='cielo_commercialestablishmentid' operator='eq' value='{0}' />
                            <condition attribute='cielo_agentgroupid' operator='eq' value='{1}' />
                        </filter>
                        </entity>
                    </fetch>", commercialEstablishment.Id, agentGroup.Id)))
                    .Entities
                    .Count > 0 ? true : false;

                localContext
                    .OrganizationService
                    .RetrieveMultiple(
                    new FetchExpression(String.Format(@"
                    <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                        <entity name='cielo_requestreason'>
                        <attribute name='cielo_name' />
                        <attribute name='cielo_requestreasonid' />
                        <order attribute='cielo_name' descending='false' />
                        <filter type='and'>
                            <condition attribute='statecode' operator='eq' value='0' />
                        </filter>
                        <link-entity name='subject' from='subjectid' to='cielo_articlesubjectcodeid' alias='aa'>
                            <link-entity name='cielo_requestparameter' from='cielo_subjectid' to='subjectid' alias='ab'>
                            <filter type='and'>
                                <condition attribute='cielo_requestparameterid' operator='eq' value='{0}' />
                            </filter>
                            </link-entity>
                        </link-entity>
                        </entity>
                    </fetch>", requestParameterization.Id)))
                    .Entities
                    .ToList()
                    .ForEach(item =>
                    {
                        var entity = new Entity(cielo_requestreason.EntityLogicalName);
                        entity.Attributes.Add("cielo_name", (string)item["cielo_name"]);
                        entity.Attributes.Add("cielo_requestreasonid", (Guid)item["cielo_requestreasonid"]);
                        collection.Entities.Add(entity);
                    });
                localContext.PluginExecutionContext.OutputParameters["Reasons"] = collection;


                collection = new EntityCollection(); 
                localContext
                    .OrganizationService
                    .RetrieveMultiple(
                    new FetchExpression(@"
                    <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                        <entity name='cielo_dealitem'>
                        <attribute name='cielo_dealitem' />
                        <attribute name='cielo_dealitemid' />
                        <order attribute='cielo_dealitem' descending='false' />
                        <filter type='and'>
                            <condition attribute='statecode' operator='eq' value='0' />
                        </filter>
                        </entity>
                    </fetch>"))
                    .Entities
                    .ToList()
                    .ForEach(item =>
                    {
                        var entity = new Entity(cielo_dealitem.EntityLogicalName);
                        entity.Attributes.Add("cielo_dealitem", (string)item["cielo_dealitem"]);
                        entity.Attributes.Add("cielo_dealitemid", (Guid)item["cielo_dealitemid"]);
                        collection.Entities.Add(entity);
                    });
                localContext.PluginExecutionContext.OutputParameters["DealItems"] = collection;


                collection = new EntityCollection(); 
                localContext
                    .OrganizationService
                    .RetrieveMultiple(
                    new FetchExpression(@"
                    <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                        <entity name='competitor'>
                        <attribute name='name' />
                        <attribute name='competitorid' />
                        <order attribute='name' descending='false' />
                        </entity>
                    </fetch>"))
                    .Entities
                    .ToList()
                    .ForEach(item =>
                    {
                        var entity = new Entity(Competitor.EntityLogicalName);
                        entity.Attributes.Add("name", (string)item["name"]);
                        entity.Attributes.Add("competitorid", (Guid)item["competitorid"]);
                        collection.Entities.Add(entity);
                    });
                localContext.PluginExecutionContext.OutputParameters["Competitors"] = collection;

                
                /////////////////////////////////////////////////////
                //Entidades tiveram que ser adicionadas            //
                //utilizando o método acima pois estava            //
                //enfrentando problemas de desserialização         //
                //no retorno da Action na DAO GetNegotiationDataDAO//
                //                                                 //
                //Autor: Angel Ojea                                //
                /////////////////////////////////////////////////////
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
