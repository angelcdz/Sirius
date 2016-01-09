using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Cielo.Sirius.DynamicsCRM.Plugins.XRMSDKPlugins;
using System.Linq;
using System.Collections;

namespace Cielo.Sirius.DynamicsCRM.Plugins.DiscountRateRestriction
{
    public class DiscountRateRestrictionPlugin : PluginBase
    {
        Team team;
        cielo_branchofactivity branchOfActivity;

        /// <summary>
        /// 
        /// Initializes a new instance of the DiscountRateRestrictionPlugin class.
        /// </summary>
        public DiscountRateRestrictionPlugin()
            : base(typeof(DiscountRateRestrictionPlugin))
        {
            System.Diagnostics.Debugger.Launch();

            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(40, "", "cielo_GetDiscountRateRestriction", new Action<LocalPluginContext>(ExecuteCielo_discountraterestriction)));
            // Note : you can register for more events here if this plugin is not specific to an individual entity and message combination.
            // You may also need to update your RegisterFile.crmregister plug-in registration file to reflect any change.
        }

        /// <summary>
        /// Executes the plug-in.
        /// </summary>
        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics CRM caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected void ExecuteCielo_discountraterestriction(LocalPluginContext localContext)
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

                var mccParameter = (string)localContext.PluginExecutionContext.InputParameters["BranchActivity"];
                var agentGroupParameter = (string)localContext.PluginExecutionContext.InputParameters["AgentGroup"];
                var defaultRateParameter = (decimal)localContext.PluginExecutionContext.InputParameters["DefaultRate"];
                var productCodeParameter = (string)localContext.PluginExecutionContext.InputParameters["ProductCode"];

                using (var context = new XrmServiceContext(localContext.OrganizationService))
                {
                    branchOfActivity = context.cielo_branchofactivitySet.Where(x => x.cielo_code == Int32.Parse(mccParameter)).First();
                    team = context.TeamSet.Where(x => x.Id == Guid.Parse(agentGroupParameter)).First();

                    var discountRateRestriction = context.cielo_discountraterestrictionSet.Where(x => x.cielo_agentgroupcodeId == new EntityReference(Team.EntityLogicalName, team.Id)
                                                                                                    && x.cielo_branchactivitycodeId == new EntityReference(cielo_branchofactivity.EntityLogicalName, team.Id)
                                                                                                    && x.cielo_productcode == productCodeParameter).First();
                    if (discountRateRestriction != null)
                    {
                        SetOutputParameters(discountRateRestriction, localContext);
                        return;
                    }

                    discountRateRestriction = context.cielo_discountraterestrictionSet.Where(x => x.cielo_agentgroupcodeId == new EntityReference(Team.EntityLogicalName, team.Id)
                                                                                                && x.cielo_branchactivitycodeId == new EntityReference(cielo_branchofactivity.EntityLogicalName, team.Id)).First();
                    if (discountRateRestriction != null)
                    {
                        SetOutputParameters(discountRateRestriction, localContext);
                        return;
                    }

                    discountRateRestriction = context.cielo_discountraterestrictionSet.Where(x => x.cielo_agentgroupcodeId == new EntityReference(Team.EntityLogicalName, team.Id)).First();

                    if (discountRateRestriction != null)
                        SetOutputParameters(discountRateRestriction, localContext);
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

        private void SetOutputParameters(cielo_discountraterestriction cielo_discountraterestriction, LocalPluginContext localContext)
        {
            var defaultRateParameter = (decimal)localContext.PluginExecutionContext.InputParameters["DefaultRate"];

            // Minimum Tax = Default Tax - ((Default Tax * Discount Rate Restriction Percentage) / 100
            localContext.PluginExecutionContext.OutputParameters["MinimumRateRestrictionPercentage"] = defaultRateParameter - ((defaultRateParameter - cielo_discountraterestriction.cielo_discountraterestrictionpercentage) / 100);
            localContext.PluginExecutionContext.OutputParameters["MaximumRateRestrictionPercentage"] = cielo_discountraterestriction.cielo_discountraterestrictionpercentage;
            localContext.PluginExecutionContext.OutputParameters["DiscounRateRestrictionPercentage"] = cielo_discountraterestriction.cielo_discountraterestrictionpercentage;
        }
    }
}
