using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Cielo.Sirius.Foundation.USD.Extensions;
using System.Windows.Threading;

namespace Cielo.Sirius.Foundation.USD.Navegation
{
    public class Navegator : INavegator
    {
        private List<FrameworkElement> _regionsRepository;
        private Dictionary<string, Screen> _screenCatalog;
        private Dictionary<string, Type> _shellCatalog;

        public ICrmCommunicator CrmCommunicator { get; set; }
        public Messenger.IMessenger Messenger { get; set; }

        public Navegator()
        {
            _regionsRepository = new List<FrameworkElement>();
            _screenCatalog = new Dictionary<string, Screen>();
            _shellCatalog = new Dictionary<string, Type>();
        }

        public void RegisterShell(string shellKey_, Type shellType_)
        {
            if (string.IsNullOrWhiteSpace(shellKey_))
                throw new ArgumentNullException("The 'Shell Key' is null or empty");

            if (_shellCatalog.ContainsKey(shellKey_))
                throw new ArgumentException("The key '" + shellKey_ + "' is already registered in the shells catalog");

            _shellCatalog.Add(shellKey_, shellType_);
        }

        public void RegisterScreen(string key_, string shellKey_, IEnumerable<View> views_)
        {
            if (string.IsNullOrWhiteSpace(key_))
                throw new ArgumentNullException("The 'Screen Key' is null or empty");

            if (_screenCatalog.ContainsKey(key_))
                throw new ArgumentException("The key '" + key_ + "' is already registered in the views catalog");

            if (string.IsNullOrWhiteSpace(shellKey_))
                throw new ArgumentNullException("The 'Shell Key' is null or empty");

            if (!_shellCatalog.ContainsKey(shellKey_))
                throw new ArgumentException("The key '" + shellKey_ + "' is not registered in the shells catalog");

            var screen = new Screen();
            screen.Views = new List<View>(views_);
            screen.Shell = _shellCatalog[shellKey_];
            screen.Name = key_;
            _screenCatalog.Add(key_, screen);
        }

        public void AddNavegationRegion(FrameworkElement region_)
        {
            RemoveNavegationRegion(region_);
            _regionsRepository.Add(region_);
        }

        public void RemoveNavegationRegion(FrameworkElement region_)
        {
            var container = GetContainerRegion((string)region_.GetValue(NavigationRegion.RegionNameProperty), (string)region_.GetValue(NavigationRegion.NavegationContextProperty));
            if (container != null)
            {
                _regionsRepository.Remove(container);
            }
        }

        public void Navegate(string screenKey, string navegationRegionName, string title, Dictionary<string, object> navegationParams = null, object context = null)
        {
            var container = GetContainerRegion(navegationRegionName, context);
            if (container != null)
            {
                Navegate(screenKey, container, title, navegationParams);
            }
        }

        private void Navegate(string screenKey, FrameworkElement container, string title, Dictionary<string, object> navegationParams)
        {
            if (!_screenCatalog.ContainsKey(screenKey))
            {
                throw new KeyNotFoundException("The view key: '" + screenKey + "' does not exists");
            }

            Screen screen = _screenCatalog[screenKey];
            screen.InitializeViews();

            Navegate(screen.ShellControl, container, title);
            screen.ShellControl.UpdateLayout();

            foreach (var viewModel in screen.ViewModels)
            {
                viewModel.Navegator = this;
                viewModel.CrmCommunicator = this.CrmCommunicator;
                viewModel.Messenger = this.Messenger;
                viewModel.LoadCommand = new Commands.AsyncRelayCommand(
                    param => viewModel.PreInitialize(navegationParams), 
                    param => true,
                    param =>
                    {
                        if (viewModel.ViewState == ViewStates.Busy)
                        {
                            viewModel.ViewState = ViewStates.Default;
                        }
                    });
                viewModel.ViewState = ViewStates.Busy;
                viewModel.LoadCommand.Execute(null);
            }

            Application.Current.Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action(() => { }));

            foreach (var viewModel in screen.ViewModels)
            {
                viewModel.PosInitialize(navegationParams);
            }

            // TODO : Send a navegation event, e.g. update the breadcrumb           
        }

        private void Navegate(FrameworkElement view, FrameworkElement container, string title)
        {
            if (container is ContentControl)
            {
                Navegate(view, (ContentControl)container);
            }
            else if (container is Panel)
            {
                Navegate(view, (Panel)container);
            }
            else
            {
                throw new InvalidOperationException("The container is not a vaild region.");
            }
        }

        private void Navegate(FrameworkElement view, ContentControl container)
        {
            container.Content = null;
            container.Content = view;
        }

        private void Navegate(FrameworkElement view, Panel container)
        {
            container.Children.Clear();
            container.Children.Add(view);
        }

        private FrameworkElement GetContainerRegion(string navegationRegionName, object context)
        {
            var container = _regionsRepository.FirstOrDefault<FrameworkElement>(element =>
            {
                return element.GetValue(NavigationRegion.RegionNameProperty).Equals(navegationRegionName)
                    && element.GetValue(NavigationRegion.NavegationContextProperty) == context;
            });
            return container;
        }
    }

    public class Screen : IScreen
    {
        public string Name { get; set; }
        public Type Shell { get; set; }
        public List<View> Views { get; set; }
        public List<ViewModelBase> ViewModels { get; private set; }
        internal FrameworkElement ShellControl { get; set; }

        public Screen()
        {
            Views = new List<View>();
            ViewModels = new List<ViewModelBase>();
        }

        internal void InitializeViews()
        {
            ViewModels = new List<ViewModelBase>();
            ShellControl = Activator.CreateInstance(this.Shell) as UserControl;
            if (this.ShellControl == null)
            {
                throw new NullReferenceException("The Shell of the screen registred with the key: '" + Name + "' is null");
            }

            foreach (var view in this.Views)
            {
                if (!(typeof(UserControl).IsAssignableFrom(view.ControlType)))
                {
                    throw new InvalidCastException("The screen registred with the key: '" + Name + "' has a view that is not a UserControl");
                }

                var region = this.ShellControl.Name == view.Region ? this.ShellControl : this.ShellControl.FindName(view.Region);
                if (region == null)
                {
                    throw new NullReferenceException("The Region: '" + view.Region + "' of the screen registred with the key: '" + Name + "' is null");
                }

                var viewControl = (UserControl)Activator.CreateInstance(view.ControlType);
                if (viewControl.DataContext is ViewModelBase)
                {
                    ViewModels.Add((ViewModelBase)viewControl.DataContext);
                }

                if (region is Panel)
                {
                    ((Panel)region).Children.Add(viewControl);
                }
                else if (region is ContentControl)
                {
                    ((ContentControl)region).Content = viewControl;
                }
            }
        }
    }

}
