using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation.USD.Commands
{
    public class AsyncRelayCommand : RelayCommand, INotifyPropertyChanged
    {
        private Action<object> _afterExecute;

        private bool _isExecuting = false;
        public bool IsExecuting
        {
            get
            {
                return this._isExecuting;
            }
            private set
            {
                _isExecuting = value;
                OnPropertyChanged();
            }
        }

        public AsyncRelayCommand(Action<object> execute_, Predicate<object> canExecute_, Action<object> afterExecute_)
            : base(execute_, canExecute_)
        {
            this._afterExecute = afterExecute_;
        }

        public AsyncRelayCommand(Action<object> execute_, Predicate<object> canExecute_)
            : base(execute_, canExecute_)
        {
        }

        public AsyncRelayCommand(Action<object> execute_)
            : base(execute_)
        {
        }

        public override Boolean CanExecute(Object parameter)
        {
            return ((base.CanExecute(parameter)) && (!this.IsExecuting));
        }

        public override void Execute(object parameters)
        {
            this.IsExecuting = true;
            Task task = Task.Factory.StartNew(() =>
            {
                this._execute(parameters);
            });
            task.ContinueWith(t =>
            {
                this.IsExecuting = false;
                if (this._afterExecute != null)
                {
                    _afterExecute.Invoke(parameters);
                }
            });
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
