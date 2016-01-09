using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cielo.Sirius.UI.USD.ProductsAndServices
{
    public class ChangeProductSegmentedParcelledCreditRateItem : INotifyPropertyChanged, IDataErrorInfo
    {
        public int BeginInstallmentRange { get; set; }
        public int EndInstallmentRange { get; set; }

        public string InstallmentRangeText
        {
            get
            {
                return String.Format("{0}x a {1}x", this.BeginInstallmentRange, this.EndInstallmentRange);
            }
        }

        public double? DefaultValue { get; set; }
        public double? ContractedValue { get; set; }
        public double? ParentCompanyRateValue { get; set; }
        public double? MEIRateValue { get; set; }

        public bool MEIIndicator { get; set; }
        public bool UseParentCompanyRateValue { get; set; }

        public decimal MinDiscountRestrictionValue { get; set; }
        public decimal MaxDiscountRestrictionValue { get; set; }

        private string _rateItemValue;
        public string RateItemValue
        {
            get { return _rateItemValue; }
            set
            {
                if (_rateItemValue == value)
                    return;
                _rateItemValue = value;
                OnPropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
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
                    case "RateItemValue":
                        decimal customValue = 0;
                        if (string.IsNullOrEmpty(RateItemValue))
                        {
                            errorMessage = UseParentCompanyRateValue ? "Valor não inserido" : string.Empty;
                        }
                        else if (decimal.TryParse(RateItemValue, out customValue))
                        {
                            if (customValue > MaxDiscountRestrictionValue)
                            {
                                errorMessage = "Valor superior ao máximo";
                            }
                            else if (customValue < MinDiscountRestrictionValue)
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
}