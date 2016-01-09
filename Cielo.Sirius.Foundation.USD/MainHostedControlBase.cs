using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.UnifiedServiceDesk.CommonUtility;
using Microsoft.Crm.UnifiedServiceDesk.Dynamics;
using System.Windows;
using Cielo.Sirius.Foundation.USD.Navegation;
using System.Windows.Controls;
using Microsoft.Uii.Csr;

namespace Cielo.Sirius.Foundation.USD
{
    public class MainHostedControlBase : DynamicsBaseHostedControl, ICrmCommunicator
    {
        private INavegator _navegator;
        public INavegator Navegator
        {
            get
            {
                if (_navegator == null)
                {
                    _navegator = NavegatorFactory.GetNavegator(this.GetType().ToString());
                    _navegator.CrmCommunicator = this;
                    _navegator.Messenger = new Messenger.Messenger();
                }
                return _navegator;
            }
            private set
            {
                _navegator = value;
            }
        }

        /// <summary>
        /// UII Constructor 
        /// </summary>
        /// <param name="appID">ID of the application</param>
        /// <param name="appName">Name of the application</param>
        /// <param name="initString">Initializing XML for the application</param>
        public MainHostedControlBase(Guid appID, string appName, string initString)
            : base(appID, appName, initString)
        { }

        public string GetCrmContextValue(string crmContextKey_)
        {
            string temp = Context.GetContext();
            Context updatedContext = new Context(temp);

            return updatedContext[crmContextKey_];
        }

        public void UpdateCrmContextValue(string crmContextKey_, string value_)
        {
            string temp = Context.GetContext();
            Context updatedContext = new Context(temp);

            updatedContext[crmContextKey_] = value_;

            // Notify Unified Service Desk of this new context information.
            FireChangeContext(new ContextEventArgs(updatedContext));
        }

        public void FireCrmRequestAction(string target_, string action_, object data_ = null)
        {
            FireRequestAction(new RequestActionEventArgs(target_, action_, data_));
        }
    }
}
