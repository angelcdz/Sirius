using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.ComponentModel;

using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.Foundation.USD.Messenger;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class RateChangeViewModel : ViewModelBase
    {

        #region Fields

        private RequestRatesPurviewModel _requestSegmentedFeeModelInstance;

        #endregion

        #region properties

        private string CodigoProduto
        {
            get;
            set;
        }
        private ObservableCollection<Rate> _rates;
        public ObservableCollection<Rate> Rates
        {
            get { return _rates; }
            set
            {
                if (_rates == value)
                    return;
                _rates = value;
                OnPropertyChanged();
            }
        }

        private bool _hasRatesErros;
        public bool HasRatesErros
        {
            get { return _hasRatesErros; }
            set
            {
                if (_hasRatesErros == value)
                    return;
                _hasRatesErros = value;
                OnPropertyChanged();
            }
        }

        private string _solutionEstimatedDate;
        public string SolutionEstimatedDate
        {
            get { return _solutionEstimatedDate; }
            set
            {
                if (_solutionEstimatedDate == value)
                    return;
                _solutionEstimatedDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        //private ICommand _getRatesCommand;
        //private ICommand GetRatesCommand
        //{
        //    get            
        //    {
        //        if (_getRatesCommand == null)
        //        {
        //            _getRatesCommand = new AsyncRelayCommand(
        //                param => GetRates(),
        //                param => true,
        //                param => CheckRequestSegmentedFeeResponse()

        //                );
        //        }
        //        return _getRatesCommand;
        //    }
        //}

        private ICommand _checkRatesErros;
        public ICommand CheckRatesErros
        {
            get
            {
                if (_checkRatesErros == null)
                {
                    _checkRatesErros = new RelayCommand(
                        param => CheckRatesErrosMethod(param),
                        param => true
                    );
                }
                return _checkRatesErros;
            }
        }

        private ICommand _SelectMatrixValue;
        public ICommand SelectMatrixValue
        {
            get
            {
                if (_SelectMatrixValue == null)
                {
                    _SelectMatrixValue = new RelayCommand(
                        param =>
                        {
                            ((Rate)param).NewCustomValue = string.Empty;
                            CheckRatesErrosMethod(param);
                        },
                        param => param is Rate
                    );
                }
                return _SelectMatrixValue;
            }
        }


        #endregion

        #region Initialize
        //public override void PreInitialize(Dictionary<string, object> navegationParams_)
        //{
        //    // TODO : Remove setContext
        //    UpdateCrmContextValue(Constants.CONTEXTOCRM_CLIENTID, "10011001");
        //    GetRatesCommand.Execute(null);
        //    base.PreInitialize(navegationParams_);
        //}

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            LoadSolutionEstimatedDate(navegationParams_);
            base.PreInitialize(navegationParams_);
        }
        #endregion

        #region Methods

        private void LoadSolutionEstimatedDate(Dictionary<string, object> navegationParams_)
        {
            CodigoProduto = string.Empty;
            if (navegationParams_.ContainsKey("product") &&
                navegationParams_["product"] != null)
            {
                CodigoProduto = navegationParams_.ContainsKey("product").ToString();
            }

            int requestTypeId = 0;
            if (navegationParams_.ContainsKey("requestTypeId") &&
                navegationParams_["requestTypeId"] != null &&
                (int.TryParse(navegationParams_["requestTypeId"].ToString(), out requestTypeId)))
            {

                CalculateDefaultSLA(requestTypeId);
            }

        }

        private void CalculateDefaultSLA(int requestTypeId_)
        {
            SolutionEstimatedDate = "SLA indisponível.";

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Cielo.Sirius.Contracts.Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Erro na consulta da data prevista para solução: Código do cliente inválido.";
                return;
            }

            var defaultSlaModel = new DefaultRequestSLAModel();
            var getDefaultSLARequest = new ConsultarPrazoPadraoRequest();

            getDefaultSLARequest.TipoDemanda = requestTypeId_;
            getDefaultSLARequest.SubTipoDemanda = CodigoProduto;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
        }

        //private void GetRates()
        //{
        //    _requestSegmentedFeeModelInstance = new RequestProductRatesModel();

        //    long clientIdNumber = new long();
        //    if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
        //    {
        //        ErrorMessage = "Código do cliente inválido";
        //        HasError = true;
        //        return;
        //    }


        //    //TODO: Recuperar informações do contexto
        //    var requestFees = new RecuperarTaxasProdutoRequest();
        //    requestFees.CodigoCliente = clientIdNumber.ToString();
        //    requestFees.CodigoProduto = null;
        //    requestFees.UserId = System.Guid.Empty;

        //    _requestSegmentedFeeModelInstance.Request = requestFees;

        //    HasError = !_requestSegmentedFeeModelInstance.Execute();

        //}

        //private void CheckRequestSegmentedFeeResponse()
        //{
        //    if (!HasError)
        //    {
        //        var response = _requestSegmentedFeeModelInstance.Response;
        //        ShowSegmentedFees(response.Faixas);
        //        //TODO: chamar ShowSegmentedFees()
        //    }

        //    ErrorMessage = _requestSegmentedFeeModelInstance.ErrorMessage;
        //}

        //private void ShowSegmentedFees(List<Faixa> ratesList)
        //{
        //    var asdf = new Rate();

        //    //TODO: Remover
        //    ratesList.Add(new Faixa()
        //        {
        //            NumeroInicialParcelaFaixa = 1,
        //            NumeroFinalParcelaFaixa = 3,
        //            PercentualTaxaPadrao = 2,
        //            PercentualTaxaFaixa = 3,
        //            PercentualTaxaMatriz = 7
        //        });

        //    foreach (var faixa in ratesList)
        //    {
        //        bool temMatriz = false; 

        //        if (faixa.PercentualTaxaMatriz > 0)
        //        {
        //            temMatriz = true;
        //        }

        //        Rates.Add(new Rate() 
        //        {
        //            MinPortion = faixa.NumeroInicialParcelaFaixa,
        //            MaxPortion = faixa.NumeroFinalParcelaFaixa,
        //            DefaultValue = faixa.PercentualTaxaPadrao,
        //            ContractedValue = faixa.PercentualTaxaFaixa,
        //            MatrixValue = faixa.PercentualTaxaMatriz, 
        //            LineChecked = true,
        //            UseMatrixValue = temMatriz,
        //            //TODO: Recuperar alçada do operador
        //            MinValue = 1, 
        //            MaxValue = 3,  
        //        });
        //    }

        //    foreach (var item in Rates)
        //    {
        //        item.NewCustomValue = string.Format("{0:N2}", item.ContractedValue);
        //        item.Portion = string.Format("{0}x a {1}x", item.MinPortion, item.MaxPortion);
        //    }
        //}

        private void CheckRatesErrosMethod(object param_)
        {
            HasRatesErros = Rates.Any((rate) =>
            {
                return !string.IsNullOrEmpty(rate.Error);
            });
        }


        //TODO: Implementar ação real do Botão para atualizar taxas
        private void SendDemandMethod(object param_)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Classe de Taxa

        public class Rate : INotifyPropertyChanged, IDataErrorInfo 
        {
            public decimal DefaultValue { get; set; }
            public decimal ContractedValue { get; set; }
            public decimal MatrixValue { get; set; }
            public double MinValue { get; set; }
            public double MaxValue { get; set; }
            public int MinPortion { get; set; }
            public int MaxPortion { get; set; }
            public bool UseMatrixValue { get; set; }
            public string Portion { get; set; }

            private string _newCustomValue;
            public string NewCustomValue
            {
                get { return _newCustomValue; }
                set
                {
                    if (_newCustomValue == value)
                        return;
                    _newCustomValue = value;
                    OnPropertyChanged();
                }
            }

            private bool _lineChecked;
            public bool LineChecked
            {
                get { return _lineChecked; }
                set
                {
                    if (_lineChecked == value)
                        return;
                    _lineChecked = value;
                    OnPropertyChanged();
                }
            }

            #region IDataErrorInfo

            private List<string> _errorsList = new List<string>();

            public string Error
            {
                get
                {
                    return _errorsList.Count > 0 ? "Campos inválidos" : string.Empty;
                }
            }

            public string this[string columnName]
            {
                get
                {
                    var errorMessage = string.Empty;
                    switch (columnName)
                    {
                        case "NewCustomValue":
                            double customValue = 0;
                            if (string.IsNullOrEmpty(NewCustomValue))
                            {
                                errorMessage = UseMatrixValue ? "Valor não inserido" : string.Empty;
                            }
                            else if (double.TryParse(NewCustomValue, out customValue))
                            {
                                if (customValue > MaxValue)
                                {
                                    errorMessage = "Valor superior ao máximo";
                                }
                                else if (customValue < MinValue)
                                {
                                    errorMessage = "Valor inferior ao mínimo";
                                }
                            }
                            else
                            {
                                errorMessage = "Valor não numérico";
                            }
                            break;
                    }

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        if (_errorsList.Contains(columnName))
                            _errorsList.Remove(columnName);
                    }
                    else
                    {
                        if (!_errorsList.Contains(columnName))
                            _errorsList.Add(columnName);
                    }

                    return errorMessage;
                }
            }

            #endregion

            #region OnPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName_ = null)
            {
                VerifyPropertyName(propertyName_);

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName_));
                }
            }

            [Conditional("DEBUG")]
            [DebuggerStepThrough]
            public virtual void VerifyPropertyName(string propertyName_)
            {
                if (TypeDescriptor.GetProperties(this)[propertyName_] == null)
                {
                    string msg = "Invalid property name: " + propertyName_;
                    if (this.ThrowOnInvalidPropertyName)
                    {
                        throw new Exception(msg);
                    }

                    Debug.Fail(msg);
                }
            }

            protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

            #endregion
        }

        #endregion
    }
}
