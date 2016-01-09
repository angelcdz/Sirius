using Cielo.Sirius.Contracts;
using Cielo.Sirius.Contracts.AlterarParcelaFaixaProduto;
using Cielo.Sirius.Contracts.AlterarTaxasProdutoCreditoParceladoSegmentado;
using Cielo.Sirius.Contracts.ConsultarDetalheProdutoHabilitadoCliente;
using Cielo.Sirius.Contracts.ConsultarPrazoPadrao;
using Cielo.Sirius.Contracts.GetDiscountRateRestriction;
using Cielo.Sirius.Foundation;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel
{
    class ChangeProductOneLumpViewModel : ViewModelBase
    {
        private string _codigoProduto;
        private bool _meiIndicator;
        private string _branchOfActivityCode;
        private RequestRatesPurviewModel _productsRatesModel;
        private ConsultarDetalheProdutoHabilitadoClienteProdutoDTO _productDetails;

        #region Properties

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

        private ObservableCollection<string> _reasonList;
        public ObservableCollection<string> ReasonList
        {
            get { return _reasonList; }
            set
            {
                if (_reasonList == value)
                    return;
                _reasonList = value;
                OnPropertyChanged();
            }
        }

        private string _reasonSelected;
        public string ReasonSelected
        {
            get { return _reasonSelected; }
            set
            {
                if (_reasonSelected == value)
                    return;
                _reasonSelected = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

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

        public ICommand _sendChangeRateRequestCommand;
        public ICommand SendChangeRateRequestCommand
        {
            get
            {
                if (_sendChangeRateRequestCommand == null)
                {
                    _sendChangeRateRequestCommand = new RelayCommand(
                        param => SendChangeRateRequest(param),
                        param => true
                        );
                }
                return _sendChangeRateRequestCommand;
            }
        }

        #endregion

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            _codigoProduto = navegationParams_["product"] as string;
            _meiIndicator = navegationParams_["meiIndicator"] == null ? false : (bool)navegationParams_["meiIndicator"];
            _branchOfActivityCode = navegationParams_["branchOfActivityCode"] as string;
            Messenger.Register<ConsultarDetalheProdutoHabilitadoClienteProdutoDTO>(this, 
                (enabledProducDetailsDTO_) => _productDetails = enabledProducDetailsDTO_);
            LoadSolutionEstimatedDate(navegationParams_);
            LoadProductRatesMethod();
            base.PreInitialize(navegationParams_);
        }
 
        private void LoadReasons(Dictionary<string, object> navegationParams_)
        {
        }

        private void LoadSolutionEstimatedDate(Dictionary<string, object> navegationParams_)
        {
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
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Erro na consulta da data prevista para solução: Código do cliente inválido.";
                return;
            }

            var defaultSlaModel = new DefaultRequestSLAModel();
            var getDefaultSLARequest = new ConsultarPrazoPadraoRequest();

            getDefaultSLARequest.TipoDemanda = requestTypeId_;
            getDefaultSLARequest.SubTipoDemanda = _codigoProduto;
            getDefaultSLARequest.CodigoCliente = clientIdNumber;
            defaultSlaModel.Request = getDefaultSLARequest;

            var executionState = defaultSlaModel.Execute();

            if (executionState == ExecutionStatus.Success || executionState == ExecutionStatus.Warning)
            {
                var response = (ConsultarPrazoPadraoResponse)defaultSlaModel.Response;
                SolutionEstimatedDate = "Data prevista para solução: " + response.DataSLA.ToShortDateString();
            }
        }

        private void LoadProductRatesMethod()
        {
            ConsultarDetalheProdutoHabilitadoClienteTaxaDTO taxa = _productDetails.Taxas[0];

            Rates = new ObservableCollection<Rate>();
            _productsRatesModel = new RequestRatesPurviewModel();
            _productsRatesModel.Request = new GetDiscountRateRestrictionRequest();
            _productsRatesModel.Request.ProductCode = _codigoProduto;
            //_productsRatesModel.Request.AgentGroupCode
            //_productsRatesModel.Request.BranchActivityCode
            decimal defaultRate;
            if (taxa.PercentualTaxaPadrao != null && decimal.TryParse(taxa.PercentualTaxaPadrao.ToString(), out defaultRate))
            {
                _productsRatesModel.Request.DefaultRate = defaultRate;
            }

            var executionState = _productsRatesModel.Execute();

            if (executionState != ExecutionStatus.Success && executionState != ExecutionStatus.Warning)
            {
                ErrorMessage = _productsRatesModel.ErrorMessage;
                return;
            }

            Rates.Add(new Rate()
            {
                ContractedValue = taxa.PercentualTaxaFaixa,
                DefaultValue = taxa.PercentualTaxaPadrao,
                MatrixValue = taxa.TaxaMatriz,
                //MaxPortion = 
                MaxValue = _productsRatesModel.Response.MaxDiscountRateRestrictionPercentage,
                //MinPortion = 
                MinValue = _productsRatesModel.Response.MinDiscountRateRestrictionPercentage,
                NewCustomValue = taxa.PercentualTaxaFaixa != null ? taxa.PercentualTaxaFaixa.ToString() : string.Empty,
                //Portion = 
                UseMatrixValue = false
            });
        }

        private void CheckRatesErrosMethod(object param_)
        {
            HasRatesErros = Rates.Any((rate) =>
            {
                return !string.IsNullOrEmpty(rate.Error);
            });
        }

        private void SendChangeRateRequest(object param)
        {
            ChangeProductRatesModel changeProductRateModel = new ChangeProductRatesModel();
            changeProductRateModel.Request = new AlterarParcelaFaixaProdutoRequest();

            long clientIdNumber = new long();
            if (!long.TryParse(GetCrmContextValue(Constants.CONTEXTOCRM_CLIENTID), out clientIdNumber))
            {
                ErrorMessage = "Código do cliente inválido";
                return;
            }

            changeProductRateModel.Request.CodigoCliente = clientIdNumber;
            changeProductRateModel.Request.CodigoProduto = _codigoProduto;
            //changeProductRateModel.Request.Protocolo

            changeProductRateModel.Execute();
            
        }

        #region Aditional Classes

        public class Rate : INotifyPropertyChanged, IDataErrorInfo
        {
            public double? DefaultValue { get; set; }
            public double? ContractedValue { get; set; }
            public double? MatrixValue { get; set; }
            public decimal MinValue { get; set; }
            public decimal MaxValue { get; set; }
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
                            decimal customValue = 0;
                            if (string.IsNullOrEmpty(NewCustomValue))
                            {
                                errorMessage = UseMatrixValue ? "Valor não inserido" : string.Empty;
                            }
                            else if (decimal.TryParse(NewCustomValue, out customValue))
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
