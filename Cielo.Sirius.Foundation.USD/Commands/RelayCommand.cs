using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Cielo.Sirius.Foundation.USD.Commands
{
       public class RelayCommand : ICommand
    {
        protected readonly Action<object> _execute;
        protected readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute_)
            : this(execute_, null)
        {
        }

        public RelayCommand(Action<object> execute_, Predicate<object> canExecute_)
        {
            if (execute_ == null)
            {
                throw new ArgumentNullException("execute");
            }

            this._execute = execute_;
            this._canExecute = canExecute_;
        }

        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual void Execute(object parameters)
        {
            _execute(parameters);
        }
    }
}
