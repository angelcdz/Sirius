using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.Shells;
using Cielo.Sirius.UI.USD.ProductsAndServices.TestControls;
using Cielo.Sirius.UI.USD.ProductsAndServices.View;
using Microsoft.Crm.UnifiedServiceDesk.CommonUtility;
using Microsoft.Crm.UnifiedServiceDesk.Dynamics;
using Microsoft.Uii.AifServices;
using Microsoft.Uii.Desktop.SessionManager;
using System;
using System.Globalization;
using System.Collections.Generic;
using Cielo.Sirius.UI.USD.ProductsAndServices.View.Services;
using Cielo.Sirius.UI.USD.ProductsAndServices.View.Products;
using Cielo.Sirius.UI.USD.ProductsAndServices.View.CommercialDeal;

namespace Cielo.Sirius.UI.USD.ProductsAndServices
{
    /// <summary>
    /// Interaction logic for USDControl.xaml
    /// This is a base control for building Unified Service Desk Aware add-ins
    /// See USD API documentation for full API Information available via this control.
    /// </summary>
    public partial class ProductsAndServicesMainControl : MainHostedControlBase
    {
        #region Vars
        /// <summary>
        /// Log writer for USD 
        /// </summary>
        private TraceLogger LogWriter = null;

        #endregion

        /// <summary>
        /// UII Constructor 
        /// </summary>
        /// <param name="appID">ID of the application</param>
        /// <param name="appName">Name of the application</param>
        /// <param name="initString">Initializing XML for the application</param>
        public ProductsAndServicesMainControl(Guid appID, string appName, string initString)
            : base(appID, appName, initString)
        {
            InitializeComponent();

            // Shells
            Navegator.RegisterShell("TwoResultsDisplayShell", typeof(TwoResultsDisplayShell));
            Navegator.RegisterShell("DetailsShell", typeof(DetailsShell));
            Navegator.RegisterShell("SingleControlShell", typeof(SingleControlShell));

            // Context mock
            var contextControlViews = new List<Foundation.USD.Navegation.View>();
            contextControlViews.Add(new Foundation.USD.Navegation.View(typeof(ContextControl), "FirstResultDisplayRegion"));
            Navegator.RegisterScreen("ContextControl", "TwoResultsDisplayShell", contextControlViews);

            // Products and Services
            var productsAndServicesViews = new List<Foundation.USD.Navegation.View>();
            productsAndServicesViews.Add(new Foundation.USD.Navegation.View(typeof(ProductsView), "FirstResultDisplayRegion"));
            productsAndServicesViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledProducts), "FirstResultsListRegion"));
            productsAndServicesViews.Add(new Foundation.USD.Navegation.View(typeof(ServicesView), "SecondResultDisplayRegion"));
            productsAndServicesViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledServices), "SecoundResultsListRegion"));
            Navegator.RegisterScreen("ProductsAndServices", "TwoResultsDisplayShell", productsAndServicesViews);

            // Enabled Products
            var enabledProductsViews = new List<Foundation.USD.Navegation.View>();
            enabledProductsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledProducts), "ContentRegion"));
            Navegator.RegisterScreen("EnabledProducts", "SingleControlShell", enabledProductsViews);

            // Non Enabled Products
            var nonEnabledProductsViews = new List<Foundation.USD.Navegation.View>();
            nonEnabledProductsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledProducts), "ContentRegion"));
            Navegator.RegisterScreen("NonEnabledProducts", "SingleControlShell", nonEnabledProductsViews);

            // Non Elegible Products
            var nonElegibleProductsViews = new List<Foundation.USD.Navegation.View>();
            nonElegibleProductsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleProducts), "ContentRegion"));
            Navegator.RegisterScreen("NonElegibleProducts", "SingleControlShell", nonElegibleProductsViews);

            // Enabled Services
            var enabledServicesViews = new List<Foundation.USD.Navegation.View>();
            enabledServicesViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledServices), "ContentRegion"));
            Navegator.RegisterScreen("EnabledServices", "SingleControlShell", enabledServicesViews);

            // Non Enabled Services
            var nonEnabledServicesViews = new List<Foundation.USD.Navegation.View>();
            nonEnabledServicesViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledServices), "ContentRegion"));
            Navegator.RegisterScreen("NonEnabledServices", "SingleControlShell", nonEnabledServicesViews);

            // Non Enabled Services
            var nonElegibleServicesViews = new List<Foundation.USD.Navegation.View>();
            nonElegibleServicesViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleServices), "ContentRegion"));
            Navegator.RegisterScreen("NonElegibleServices", "SingleControlShell", nonElegibleServicesViews);

            // Enabled Products Details
            var enabledProductDetailsViews = new List<Foundation.USD.Navegation.View>();
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledProductDetails), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetMultivanProductDetail), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledProductTaxesDetails), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloAlimentacaoInformation), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloRefeicaoInformation), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(RequestsHistory), "DetailsRegion"));
            enabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledProductRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("EnabledProductDetails", "DetailsShell", enabledProductDetailsViews);

            // Non Enabled Products Details
            var nonEnabledProductDetailsViews = new List<Foundation.USD.Navegation.View>();
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledProductDetails), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetMultivanProductDetail), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledProductTaxesDetails), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloAlimentacaoInformation), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloRefeicaoInformation), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(RequestsHistory), "DetailsRegion"));
            nonEnabledProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledProductRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("NonEnabledProductDetails", "DetailsShell", nonEnabledProductDetailsViews);

            // Non Elegible Products Details
            var nonElegibleProductDetailsViews = new List<Foundation.USD.Navegation.View>();
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleProductDetails), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetMultivanProductDetail), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleProductTaxesDetails), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloAlimentacaoInformation), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(GetPATAleloRefeicaoInformation), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(RequestsHistory), "DetailsRegion"));
            nonElegibleProductDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleProductRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("NonElegibleProductDetails", "DetailsShell", nonElegibleProductDetailsViews);

            // Enabled Services Details
            var enabledServiceDetailsViews = new List<Foundation.USD.Navegation.View>();
            enabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            enabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledServiceDetails), "DetailsRegion"));
            enabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(ServiceRequestsHistory), "DetailsRegion"));
            enabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledServiceRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("EnabledServiceDetails", "DetailsShell", enabledServiceDetailsViews);

            // Non Enabled Services Details
            var nonEnabledServiceDetailsViews = new List<Foundation.USD.Navegation.View>();
            nonEnabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            nonEnabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledServiceDetails), "DetailsRegion"));
            nonEnabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(ServiceRequestsHistory), "DetailsRegion"));
            nonEnabledServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonEnabledServiceRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("NonEnabledServiceDetails", "DetailsShell", nonEnabledServiceDetailsViews);

            // Non Elegible Services Details
            var nonElegibleServiceDetailsViews = new List<Foundation.USD.Navegation.View>();
            nonElegibleServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(BackControl), "DetailsRegion"));
            nonElegibleServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleServiceDetails), "DetailsRegion"));
            nonElegibleServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(ServiceRequestsHistory), "DetailsRegion"));
            nonElegibleServiceDetailsViews.Add(new Foundation.USD.Navegation.View(typeof(NonElegibleServiceRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("NonElegibleServiceDetails", "DetailsShell", nonElegibleServiceDetailsViews);

            // Disable Typed Sale
            var disabledTypedSaleViews = new List<Foundation.USD.Navegation.View>();
            disabledTypedSaleViews.Add(new Foundation.USD.Navegation.View(typeof(DisabledTypedSale), "ContentRegion"));
            Navegator.RegisterScreen("DisabledTypedSale", "SingleControlShell", disabledTypedSaleViews);

            // Enable Typed Sale
            var enabledTypedSaleViews = new List<Foundation.USD.Navegation.View>();
            enabledTypedSaleViews.Add(new Foundation.USD.Navegation.View(typeof(EnabledTypedSale), "ContentRegion"));
            Navegator.RegisterScreen("EnabledTypedSale", "SingleControlShell", enabledTypedSaleViews);

            // Rate Negotiation Request
            var rateNegotiationRequestViews = new List<Foundation.USD.Navegation.View>();
            rateNegotiationRequestViews.Add(new Foundation.USD.Navegation.View(typeof(RateNegotiationRequest), "ContentRegion"));
            Navegator.RegisterScreen("RateNegotiationRequest", "SingleControlShell", rateNegotiationRequestViews);

            // Disable Service
            var disableServiceViews = new List<Foundation.USD.Navegation.View>();
            disableServiceViews.Add(new Foundation.USD.Navegation.View(typeof(DisableService), "ContentRegion"));
            Navegator.RegisterScreen("DisableService", "SingleControlShell", disableServiceViews);

            // Enable Service
            var enableServiceViews = new List<Foundation.USD.Navegation.View>();
            enableServiceViews.Add(new Foundation.USD.Navegation.View(typeof(EnableService), "ContentRegion"));
            Navegator.RegisterScreen("EnableService", "SingleControlShell", enableServiceViews);

            // Disable Product
            var disableProductViews = new List<Foundation.USD.Navegation.View>();
            disableProductViews.Add(new Foundation.USD.Navegation.View(typeof(DisableProduct), "ContentRegion"));
            Navegator.RegisterScreen("DisableProduct", "SingleControlShell", disableProductViews);

            // Service Request Success
            var productRequestSuccessViews = new List<Foundation.USD.Navegation.View>();
            productRequestSuccessViews.Add(new Foundation.USD.Navegation.View(typeof(ProductRequestSuccess), "ContentRegion"));
            Navegator.RegisterScreen("ProductRequestSuccess", "SingleControlShell", productRequestSuccessViews);

            // Product Request Error
            var productRequestErrorViews = new List<Foundation.USD.Navegation.View>();
            productRequestErrorViews.Add(new Foundation.USD.Navegation.View(typeof(ProductRequestError), "ContentRegion"));
            Navegator.RegisterScreen("ProductRequestError", "SingleControlShell", productRequestErrorViews);

            // Service Request Success
            var serviceRequestSuccessViews = new List<Foundation.USD.Navegation.View>();
            serviceRequestSuccessViews.Add(new Foundation.USD.Navegation.View(typeof(ServiceRequestSuccess), "ContentRegion"));
            Navegator.RegisterScreen("ServiceRequestSuccess", "SingleControlShell", serviceRequestSuccessViews);

            // Service Request Error
            var serviceRequestErrorViews = new List<Foundation.USD.Navegation.View>();
            serviceRequestErrorViews.Add(new Foundation.USD.Navegation.View(typeof(ServiceRequestError), "ContentRegion"));
            Navegator.RegisterScreen("ServiceRequestError", "SingleControlShell", serviceRequestErrorViews);

            var commercialDealView = new List<Foundation.USD.Navegation.View>();            
            commercialDealView.Add(new Foundation.USD.Navegation.View(typeof(Cielo.Sirius.UI.USD.ProductsAndServices.View.CommercialDeal.EquipmentDetail), "DetailsRegion"));
            commercialDealView.Add(new Foundation.USD.Navegation.View(typeof(CommercialDealRequestsSelector), "RequestsSelectorRegion"));
            Navegator.RegisterScreen("EquipmentDetails", "DetailsShell", commercialDealView);

            // This will create a log writer with the default provider for Unified Service desk
            LogWriter = new TraceLogger();
        }

        /// <summary>
        /// Raised when the Desktop Ready event is fired. 
        /// </summary>
        protected override void DesktopReady()
        {
            Navegator.Navegate("ContextControl", "ProductsAndServicesMainRegion", "", null); 
            base.DesktopReady();
        }

        /// <summary>
        /// Raised when an action is sent to this control
        /// </summary>
        /// <param name="args">args for the action</param>
        protected override void DoAction(Microsoft.Uii.Csr.RequestActionEventArgs args)
        {
            // Log process.
            LogWriter.Log(string.Format(CultureInfo.CurrentCulture, "{0} -- DoAction called for action: {1}", this.ApplicationName, args.Action), System.Diagnostics.TraceEventType.Information);

            base.DoAction(args);
        }

        /// <summary>
        /// Raised when a context change occurs in USD
        /// </summary>
        /// <param name="context"></param>
        public override void NotifyContextChange(Microsoft.Uii.Csr.Context context)
        {
            base.NotifyContextChange(context);
        }
    }
}
