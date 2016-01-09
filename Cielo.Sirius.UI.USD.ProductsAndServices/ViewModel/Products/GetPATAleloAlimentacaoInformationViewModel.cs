using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.ConsultarInformacoesPatAlelo;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    public class GetPATAleloAlimentacaoInformationViewModel : ViewModelBase
    {
        #region Atributos

        private ConsultInformationPatAleloModel _informationPatAleloModel;
        private string _checkoutsLoja;
        private bool _supermercado;
        private bool _armazem;
        private bool _laticinio;
        private bool _segundaSexta;
        private string _areaAtendimento;
        private bool _sabado;
        private bool _domingo;
        private bool _hipermercado;
        private bool _acougue;
        private bool _outros;
        private bool _comercial;
        private bool _noturno;
        private bool _horas24;
        private bool _hortimercado;
        private bool _peixaria;
        private string _apresentaCartao;
        private string _delivery;
        private string _internet;
        private bool _mercearia;
        private bool _padaria;
        private bool _apresentarPATAlimentacao;

        private Logger _logger = Logger.LoggerFor<GetPATAleloAlimentacaoInformationViewModel>();

        #endregion

        #region Propriedades

        public string CheckoutsLoja
        {
            get { return _checkoutsLoja; }
            set
            {
                if (_checkoutsLoja == value)
                    return;
                _checkoutsLoja = value;
                OnPropertyChanged();
            }
        }

        public bool Supermercado
        {
            get { return _supermercado; }
            set
            {
                if (_supermercado == value)
                    return;
                _supermercado = value;
                OnPropertyChanged();
            }
        }

        public bool Armazem
        {
            get { return _armazem; }
            set
            {
                if (_armazem == value)
                    return;
                _armazem = value;
                OnPropertyChanged();
            }
        }

        public bool Laticinio
        {
            get { return _laticinio; }
            set
            {
                if (_laticinio == value)
                    return;
                _laticinio = value;
                OnPropertyChanged();
            }
        }

        public bool SegundaSexta
        {
            get { return _segundaSexta; }
            set
            {
                if (_segundaSexta == value)
                    return;
                _segundaSexta = value;
                OnPropertyChanged();
            }
        }

        public string AreaAtendimento
        {
            get { return _areaAtendimento; }
            set
            {
                if (_areaAtendimento == value)
                    return;
                _areaAtendimento = value;
                OnPropertyChanged();
            }
        }

        public bool Sabado
        {
            get { return _sabado; }
            set
            {
                if (_sabado == value)
                    return;
                _sabado = value;
                OnPropertyChanged();
            }
        }

        public bool Domingo
        {
            get { return _domingo; }
            set
            {
                if (_domingo == value)
                    return;
                _domingo = value;
                OnPropertyChanged();
            }
        }

        public bool Hipermercado
        {
            get { return _hipermercado; }
            set
            {
                if (_hipermercado == value)
                    return;
                _hipermercado = value;
                OnPropertyChanged();
            }
        }

        public bool Acougue
        {
            get { return _acougue; }
            set
            {
                if (_acougue == value)
                    return;
                _acougue = value;
                OnPropertyChanged();
            }
        }

        public bool Outros
        {
            get { return _outros; }
            set
            {
                if (_outros == value)
                    return;
                _outros = value;
                OnPropertyChanged();
            }
        }

        public bool Comercial
        {
            get { return _comercial; }
            set
            {
                if (_comercial == value)
                    return;
                _comercial = value;
                OnPropertyChanged();
            }
        }

        public bool Noturno
        {
            get { return _noturno; }
            set
            {
                if (_noturno == value)
                    return;
                _noturno = value;
                OnPropertyChanged();
            }
        }

        public bool Horas24
        {
            get { return _horas24; }
            set
            {
                if (_horas24 == value)
                    return;
                _horas24 = value;
                OnPropertyChanged();
            }
        }

        public bool Hortimercado
        {
            get { return _hortimercado; }
            set
            {
                if (_hortimercado == value)
                    return;
                _hortimercado = value;
                OnPropertyChanged();
            }
        }

        public bool Peixaria
        {
            get { return _peixaria; }
            set
            {
                if (_peixaria == value)
                    return;
                _peixaria = value;
                OnPropertyChanged();
            }
        }

        public string ApresentaCartao
        {
            get { return _apresentaCartao; }
            set
            {
                if (_apresentaCartao == value)
                    return;
                _apresentaCartao = value;
                OnPropertyChanged();
            }
        }

        public string Delivery
        {
            get { return _delivery; }
            set
            {
                if (_delivery == value)
                    return;
                _delivery = value;
                OnPropertyChanged();
            }
        }

        public string Internet
        {
            get { return _internet; }
            set
            {
                if (_internet == value)
                    return;
                _internet = value;
                OnPropertyChanged();
            }
        }

        public bool Mercearia
        {
            get { return _mercearia; }
            set
            {
                if (_mercearia == value)
                    return;
                _mercearia = value;
                OnPropertyChanged();
            }
        }

        public bool Padaria
        {
            get { return _padaria; }
            set
            {
                if (_padaria == value)
                    return;
                _padaria = value;
                OnPropertyChanged();
            }
        }

        public bool ApresentarPATAlimentacao
        {
            get { return _apresentarPATAlimentacao; }
            set
            {
                if (_apresentarPATAlimentacao == value)
                    return;
                _apresentarPATAlimentacao = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Métodos

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            CheckProductType(navegationParams_);
            if (ApresentarPATAlimentacao)
            {
                LoadPATAleloAlimentacaoInformation(navegationParams_);
                CheckEnabledPATAleloAlimentacaoInformation();
            }
            base.PreInitialize(navegationParams_);
        }

        private void CheckProductType(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null)
            {
                string flagCode = null;
                if (navegationParams_["flagCode"] != null)
                {
                    flagCode = navegationParams_["flagCode"].ToString();
                }
                string product = null;
                if (navegationParams_["product"] != null)
                {
                    product = navegationParams_["product"].ToString();
                }
                if (product == Constants.TIPO_PRODUTO_PAT_ALELO_ALIMENTACAO && flagCode == Constants.CODIGO_BANDEIRA_PAT_ALELO)
                {
                    ApresentarPATAlimentacao = true;
                }
            }
        }

        private void LoadPATAleloAlimentacaoInformation(Dictionary<string, object> navegationParams_)
        {
            _informationPatAleloModel = new ConsultInformationPatAleloModel();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                ViewState = ViewStates.LoadingError;
                _logger.LogError(ErrorMessage);
                return;
            }

            ConsultarInformacoesPatAleloRequest informationPatAleloRequest = new ConsultarInformacoesPatAleloRequest();
            informationPatAleloRequest.CodigoCliente = clientIdNumber;
            _informationPatAleloModel.Request = informationPatAleloRequest;
            _informationPatAleloModel.Execute();
        }

        private void CheckEnabledPATAleloAlimentacaoInformation()
        {
            var response = _informationPatAleloModel.Response;

            if (response.Status == ExecutionStatus.Success || response.Status == ExecutionStatus.Warning)
            {
                ViewState = ViewStates.Default;

                CheckoutsLoja = response.DadosAlimentacao.CheckOutsLoja ?? "---";
                Supermercado = response.DadosAlimentacao.Supermercado;
                Armazem = response.DadosAlimentacao.Armazem;
                Laticinio = response.DadosAlimentacao.LaticinioFrios;
                SegundaSexta = response.DadosAlimentacao.SegundaSexta;
                Sabado = response.DadosAlimentacao.Sabado;
                Domingo = response.DadosAlimentacao.Domingo;
                Hipermercado = response.DadosAlimentacao.Hipermercado;
                Acougue = response.DadosAlimentacao.Acougue;
                Outros = response.DadosAlimentacao.Outros;
                Noturno = response.DadosAlimentacao.Noturno;
                Horas24 = response.DadosAlimentacao.Aberto24Horas;
                AreaAtendimento = response.DadosAlimentacao.ValorAreaAtendimentoPublico ?? "---";
                Hortimercado = response.DadosAlimentacao.Hortimercado;
                Peixaria = response.DadosAlimentacao.Peixaria;
                ApresentaCartao = response.DadosAlimentacao.IndicadorApresentacaoCartao ?? "---";
                Delivery = response.DadosAlimentacao.IndicadorServicoDelivery ?? "---";
                Internet = response.DadosAlimentacao.IndicadorVendaInternet ?? "---";
                Mercearia = response.DadosAlimentacao.Mercearia;
                Padaria = response.DadosAlimentacao.Padaria;
            }
            else if (response != null)
            {
                ErrorMessage = response.Status == ExecutionStatus.BusinessError ?
                    "Não existem informações PAT Alelo para o EC em Atendimento." :
                    "Não foi possível recuperar as informações PAT Alelo.";
                ErrorId = response.CorrelationId.ToString();
                _logger.LogError(response.ErrorMessage ?? ErrorMessage);
                ViewState = ViewStates.CustomError;
            }
            else 
            {
                ErrorMessage = "Não foi possível recuperar as informações PAT Alelo.";
                ErrorId = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                _logger.LogError("Null response for the model 'ConsultInformationPatAleloModel'.");
                ViewState = ViewStates.CustomError;
            }
        }

        #endregion
    }
}
