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
    class GetPATAleloRefeicaoInformationViewModel : ViewModelBase
    {
        #region Atributos

        private ConsultInformationPatAleloModel _informationPatAleloModel;
        private string _maximoRefeicoes;
        private string _numeroMesas;
        private string _numeroAssentos;
        private string _areaAtendimento;
        private bool _lanchonete;
        private DateTime? _afiliacao;
        private bool _segundaSexta;
        private bool _sabado;
        private bool _domingo;
        private bool _restaurante;
        private bool _padaria;
        private bool _comercial;
        private bool _noturno;
        private bool _horas24;
        private bool _fastFood;
        private bool _outros;
        private string _apresentaCartao;
        private string _delivery;
        private string _internet;
        private bool _bar;
        private bool _apresentarPATRefeicao;

        private Logger _logger = Logger.LoggerFor<GetPATAleloRefeicaoInformationViewModel>();

        #endregion

        #region Propriedades

        public string MaximoRefeicoes
        {
            get { return _maximoRefeicoes; }
            set
            {
                if (_maximoRefeicoes == value)
                    return;
                _maximoRefeicoes = value;
                OnPropertyChanged();
            }
        }

        public string NumeroMesas
        {
            get { return _numeroMesas; }
            set
            {
                if (_numeroMesas == value)
                    return;
                _numeroMesas = value;
                OnPropertyChanged();
            }
        }

        public string NumeroAssentos
        {
            get { return _numeroAssentos; }
            set
            {
                if (_numeroAssentos == value)
                    return;
                _numeroAssentos = value;
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

        public bool Lanchonete
        {
            get { return _lanchonete; }
            set
            {
                if (_lanchonete == value)
                    return;
                _lanchonete = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Afiliacao
        {
            get { return _afiliacao; }
            set
            {
                if (_afiliacao == value)
                    return;
                _afiliacao = value;
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

        public bool Restaurante
        {
            get { return _restaurante; }
            set
            {
                if (_restaurante == value)
                    return;
                _restaurante = value;
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

        public bool FastFood
        {
            get { return _fastFood; }
            set
            {
                if (_fastFood == value)
                    return;
                _fastFood = value;
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

        public bool Bar
        {
            get { return _bar; }
            set
            {
                if (_bar == value)
                    return;
                _bar = value;
                OnPropertyChanged();
            }
        }

        public bool ApresentarPATRefeicao
        {
            get { return _apresentarPATRefeicao; }
            set
            {
                if (_apresentarPATRefeicao == value)
                    return;
                _apresentarPATRefeicao = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Métodos

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            CheckProductType(navegationParams_);
            if (ApresentarPATRefeicao)
            {
                LoadPATAleloRefeicaoInformation();
                CheckEnabledPATAleloRefeicaoInformation();
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
                if (product == Constants.TIPO_PRODUTO_PAT_ALELO_REFEICAO && flagCode == Constants.CODIGO_BANDEIRA_PAT_ALELO)
                {
                    ApresentarPATRefeicao = true;
                }
            }
        }

        private void LoadPATAleloRefeicaoInformation()
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
            ExecutionStatus executionState = ExecutionStatus.Success;
            _informationPatAleloModel.Execute();
        }

        private void CheckEnabledPATAleloRefeicaoInformation()
        {
            var response = _informationPatAleloModel.Response;

            if (response.Status == ExecutionStatus.Success || response.Status == ExecutionStatus.Warning)
            {
                ViewState = ViewStates.Default;

                MaximoRefeicoes = response.DadosRefeicao.QuantidadeDeMaximaRefeicao ?? "---";
                NumeroMesas = response.DadosRefeicao.QuantidadeDeMesa ?? "---";
                NumeroAssentos = response.DadosRefeicao.QuantidadeDeAssento ?? "---";
                AreaAtendimento = response.DadosRefeicao.ValorAreaAtendimentoPublico ?? "---";
                Lanchonete = response.DadosRefeicao.Lanchonete;
                Afiliacao = response.DadosRefeicao.DataAfiliacao;
                SegundaSexta = response.DadosRefeicao.SegundaSexta;
                Sabado = response.DadosRefeicao.Sabado;
                Domingo = response.DadosRefeicao.Domingo;
                Restaurante = response.DadosRefeicao.Restaurante;
                Padaria = response.DadosRefeicao.Padaria;
                Comercial = response.DadosRefeicao.HorarioComercial;
                Noturno = response.DadosRefeicao.Noturno;
                Horas24 = response.DadosRefeicao.Aberto24Horas;
                FastFood = response.DadosRefeicao.FastFood;
                Outros = response.DadosRefeicao.Outros;
                ApresentaCartao = response.DadosRefeicao.IndicadorApresentacaoCartao ?? "---";
                Delivery = response.DadosRefeicao.IndicadorServicoDelivery ?? "---";
                Internet = response.DadosRefeicao.IndicadorVendaInternet ?? "---";
                Bar = response.DadosRefeicao.Bar;

            }
            else if(response != null)
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
