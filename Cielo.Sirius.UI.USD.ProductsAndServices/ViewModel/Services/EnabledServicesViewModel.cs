using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class EnabledServicesViewModel : ViewModelBase
    {
        #region Constants

        private const string LOADING_DEFAULT_ERROR_MSG = "Erro ao consultar informações de Serviços. Informar ao cliente para tentar novamente mais tarde";

        #endregion

        #region Fields

        private ObservableCollection<Service> _selectedServices;
        private ObservableCollection<Service> _filteredServices;

        private Logger _logger = Logger.LoggerFor<EnabledServicesViewModel>();

        #endregion

        #region Properties

        private ObservableCollection<Service> _displayedServices;
        public ObservableCollection<Service> DisplayedServices
        {
            get { return _displayedServices; }
            set
            {
                if (_displayedServices == value)
                    return;
                _displayedServices = value;
                OnPropertyChanged();
            }
        }

        private int _indexDisplayedServices;
        public int IndexDisplayedServices
        {
            get { return _indexDisplayedServices; }
            private set
            {
                if (_indexDisplayedServices == value)
                    return;
                _indexDisplayedServices = value;
                OnPropertyChanged();
            }
        }

        private int _maxIndexDisplayedServices;
        public int MaxIndexDisplayedServices
        {
            get { return _maxIndexDisplayedServices; }
            private set
            {
                if (_maxIndexDisplayedServices == value)
                    return;
                _maxIndexDisplayedServices = value;
                OnPropertyChanged();
            }
        }

        private string _servicesSearchText;
        public string ServicesSearchText
        {
            get { return _servicesSearchText; }
            set
            {
                if (_servicesSearchText == value)
                    return;
                _servicesSearchText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand _previewServicesPage;
        public ICommand PreviewServicesPage
        {
            get
            {
                if (_previewServicesPage == null)
                {
                    _previewServicesPage = new RelayCommand(
                        param =>
                        {
                            IndexDisplayedServices--;
                            PaginateServices();
                        },
                        param => IndexDisplayedServices > 1
                    );
                }
                return _previewServicesPage;
            }
        }

        private ICommand _nextServicesPage;
        public ICommand NextServicesPage
        {
            get
            {
                if (_nextServicesPage == null)
                {
                    _nextServicesPage = new RelayCommand(
                        param =>
                        {
                            IndexDisplayedServices++;
                            PaginateServices();
                        },
                        param => IndexDisplayedServices < MaxIndexDisplayedServices
                    );
                }
                return _nextServicesPage;
            }
        }

        private ICommand _lastServicesPage;
        public ICommand LastServicesPage
        {
            get
            {
                if (_lastServicesPage == null)
                {
                    _lastServicesPage = new RelayCommand(
                        param =>
                        {
                            IndexDisplayedServices = MaxIndexDisplayedServices;
                            PaginateServices();
                        },
                        param => IndexDisplayedServices != MaxIndexDisplayedServices
                    );
                }
                return _lastServicesPage;
            }
        }

        private ICommand _firstServicesPage;
        public ICommand FirstServicesPage
        {
            get
            {
                if (_firstServicesPage == null)
                {
                    _firstServicesPage = new RelayCommand(
                        param =>
                        {
                            IndexDisplayedServices = 1;
                            PaginateServices();
                        },
                        param => IndexDisplayedServices > 1
                    );
                }
                return _firstServicesPage;
            }
        }

        private ICommand _filterServices;
        public ICommand FilterServices
        {
            get
            {
                if (_filterServices == null)
                {
                    _filterServices = new RelayCommand(
                        param => FilterServicesMethod(param),
                        param => true
                    );
                }
                return _filterServices;
            }
        }

        private ICommand _serviceSelectedCommand;
        public ICommand ServiceSelectedCommand
        {
            get
            {
                if (_serviceSelectedCommand == null)
                {
                    _serviceSelectedCommand = new RelayCommand(
                        param =>
                        {
                            var selectedService = param as Service;
                            var paramsDic = new Dictionary<string, object>();
                            paramsDic.Add("service", selectedService.ServiceDTO);
                            paramsDic.Add("serviceId", selectedService.ServiceDTO.CodigoServico);
                            paramsDic.Add("indicadorVendaUltimoMes", selectedService.IndicadorVendaUltimoMes);
                            paramsDic.Add("vantagens", selectedService.Vantanges);
                            Navegate("EnabledServiceDetails", "ProductsAndServicesMainRegion", "", paramsDic);
                        },
                        param => true
                    );
                }
                return _serviceSelectedCommand;
            }
        }

        #endregion

        #region Initialize

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            LoadServicesCommandMethod();
            base.PreInitialize(navegationParams_);
        }

        #endregion

        #region Private Methods

        private void LoadServicesCommandMethod()
        {
            _selectedServices = new ObservableCollection<Service>();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

            var servicesModel = new EnabledServicesModel();
            servicesModel.Request = new ConsultarServicoHabilitadoClienteRequest();
            servicesModel.Request.CodigoCliente = clientIdNumber;

            servicesModel.Execute();
            var response = servicesModel.Response;

            if (response != null && response.Status.Equals(ExecutionStatus.Success))
            {
                ViewState = ViewStates.Default;

                var servicesOrdered = servicesModel.Response.Servicos.OrderBy(serv => serv.NomeServico);

                foreach (var service in servicesOrdered)
                {
                    _selectedServices.Add(new Service()
                    {
                        Name = service.NomeServico,
                        HasRequest = service.IndicadorPossuiDemandasAbertas,
                        IndicadorVendaUltimoMes = servicesModel.Response.IndicadorVendaUltimoMes,
                        Vantanges = service.Vantagem,
                        ServiceDTO = service
                    });
                }

                _filteredServices = _selectedServices;
                CalculateServicesIndex();
                PaginateServices();
            }
            else if (response != null && response.Status.Equals(ExecutionStatus.BusinessError))
            {
                ViewState = ViewStates.LoadingError;
                ErrorId = response.CorrelationId.ToString();
                ErrorMessage = response.ErrorMessage;
            }
            else
            {
                ViewState = ViewStates.CustomError;
                ErrorMessage = LOADING_DEFAULT_ERROR_MSG;
            }
        }

        private void FilterServicesMethod(object param_)
        {
            var newDisplayedServices = new ObservableCollection<Service>();

            if (string.IsNullOrEmpty(ServicesSearchText))
            {
                newDisplayedServices = _selectedServices ?? new ObservableCollection<Service>();
            }
            else
            {
                foreach (var service in _selectedServices)
                {
                    if (ServicesSearchText == service.Name)
                    {
                        newDisplayedServices.Add(service);
                    }
                }
            }

            _filteredServices = newDisplayedServices;
            DisplayedServices = new ObservableCollection<Service>(_filteredServices.Take<Service>(12));
            CalculateServicesIndex();
        }

        private void CalculateServicesIndex()
        {
            MaxIndexDisplayedServices = _filteredServices.Count % 12 == 0 ?
                (_filteredServices.Count / 12) : (_filteredServices.Count / 12) + 1;

            IndexDisplayedServices = (MaxIndexDisplayedServices > 0) ? 1 : 0;
        }

        private void PaginateServices()
        {
            var services = _filteredServices.Skip<Service>((IndexDisplayedServices - 1) * 12).Take<Service>(12);
            DisplayedServices = new ObservableCollection<Service>(services);
        }

        #endregion

        #region Additional Classes

        public class Service
        {
            public string Name { get; set; }
            public bool HasRequest { get; set; }
            public bool IndicadorVendaUltimoMes { get; set; }
            public string Vantanges { get; set; }
            public ConsultarServicoHabilitadoClienteServicoDTO ServiceDTO { get; set; }
        }

        #endregion
    }
}
