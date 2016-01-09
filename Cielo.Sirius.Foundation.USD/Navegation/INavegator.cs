using System.Collections.Generic;
using System.Windows;
using Cielo.Sirius.Foundation.USD.Messenger;
using System;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public interface INavegator
    {
        ICrmCommunicator CrmCommunicator { get; set; }
        IMessenger Messenger { get; set; }

        void RegisterShell(string shellKey_, Type shellType_);
        void RegisterScreen(string key_, string shellKey_, IEnumerable<View> views_);
        void AddNavegationRegion(FrameworkElement region_);
        void RemoveNavegationRegion(FrameworkElement region_);

        void Navegate(string viewKey, string navegationRegionName, string title, Dictionary<string, object> navegationParams=null, object context = null);
    }
}
