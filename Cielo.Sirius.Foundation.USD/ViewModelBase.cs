using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.Foundation.USD.Messenger;
using Cielo.Sirius.Foundation.USD.Navegation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cielo.Sirius.Foundation.USD
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        internal INavegator Navegator { get; set; }
        internal ICrmCommunicator CrmCommunicator { get; set; }
        public IMessenger Messenger { get; internal set; }

        private ViewStates _viewState;
        public ViewStates ViewState
        {
            get { return _viewState; }
            set
            {
                if (_viewState == value)
                    return;
                _viewState = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage == value)
                    return;
                _errorMessage = value;
                OnPropertyChanged();
            }
        }


        private string _errorId;
        public string ErrorId
        {
            get { return _errorId; }
            set
            {
                if (_errorId == value)
                    return;
                _errorId = value;
                OnPropertyChanged();
            }
        }

        private AsyncRelayCommand _loadCommand;
        public AsyncRelayCommand LoadCommand
        {
            get { return _loadCommand; }
            internal set
            {
                if (_loadCommand == value)
                    return;
                _loadCommand = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase()
        {
            Trace.CorrelationManager.StartLogicalOperation();
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
        }

        public virtual void PreInitialize(Dictionary<string, object> navegationParams_)
        { }

        public virtual void PosInitialize(Dictionary<string, object> navegationParams_)
        { }

        protected void Navegate(string viewKey_, string navegationRegionName_, string title_, Dictionary<string, object> navegationParams_, object context_ = null)
        {
            if (Navegator != null)
            {
                Navegator.Navegate(viewKey_, navegationRegionName_, title_, navegationParams_, context_);
            }
        }

        protected void UpdateCrmContextValue(string crmContextKey_, string value_)
        {
            if (CrmCommunicator != null)
            {
                CrmCommunicator.UpdateCrmContextValue(crmContextKey_, value_);
            }
        }

        protected string GetCrmContextValue(string crmContextKey_)
        {
            if (CrmCommunicator != null)
            {
                return CrmCommunicator.GetCrmContextValue(crmContextKey_);
            }

            return null;
        }

        protected void FireCrmRequestAction(string target_, string action_, object data_)
        {
            if (CrmCommunicator != null)
            {
                CrmCommunicator.FireCrmRequestAction(target_, action_, data_);
            }
        }

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
