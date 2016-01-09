using Cielo.Sirius.Contracts.ConsultarServicoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarServicoNaoElegivelCliente;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class NonElegibleServiceDetailsViewModel : ViewModelBase
    {
        private ConsultarServicoNaoElegivelClienteServicoDTO _service;
        public ConsultarServicoNaoElegivelClienteServicoDTO Service
        {
            get { return _service; }
            set
            {
                if (_service == value)
                    return;

                _service = value;
                OnPropertyChanged();
            }
        }

        private string _indicadorVendaUltimoMes;
        public string IndicadorVendaUltimoMes
        {
            get { return _indicadorVendaUltimoMes; }
            set
            {
                if (_indicadorVendaUltimoMes == value)
                    return;

                _indicadorVendaUltimoMes = value;
                OnPropertyChanged();
            }
        }

        private string _vantanges;
        public string Vantanges
        {
            get { return _vantanges; }
            set
            {
                if (_vantanges == value)
                    return;

                _vantanges = value;
                OnPropertyChanged();
            }
        }

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null
                && navegationParams_.ContainsKey("service")
                && navegationParams_.ContainsKey("indicadorVendaUltimoMes")
                && navegationParams_.ContainsKey("vantagens"))
            {
                Vantanges = navegationParams_["vantagens"] as string;
                IndicadorVendaUltimoMes = navegationParams_["indicadorVendaUltimoMes"].Equals(true) ? "Sim" : "Não";
                Service = navegationParams_["service"] as ConsultarServicoNaoElegivelClienteServicoDTO;
            }

            base.PreInitialize(navegationParams_);
        }
    }
}
