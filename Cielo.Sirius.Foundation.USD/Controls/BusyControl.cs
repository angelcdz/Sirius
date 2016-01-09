using Cielo.Sirius.Foundation.USD.Commands;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Cielo.Sirius.Foundation.USD.Controls
{
    public class BusyControl : ContentControl
    {
        #region Dependency Properties

        #region View State

        public ViewStates ViewState
        {
            get { return (ViewStates)GetValue(ViewStateProperty); }
            set { SetValue(ViewStateProperty, value); }
        }

        public static readonly DependencyProperty ViewStateProperty =
            DependencyProperty.Register("ViewState", typeof(ViewStates), typeof(BusyControl),
            new PropertyMetadata(ViewStates.Default, new PropertyChangedCallback(OnViewStateChanged)));

        #endregion

        #region Busy

        public static readonly DependencyProperty BusyContentProperty =
            DependencyProperty.Register("BusyContent", typeof(object), typeof(BusyControl), new PropertyMetadata(null));

        public object BusyContent
        {
            get { return (object)GetValue(BusyContentProperty); }
            set { SetValue(BusyContentProperty, value); }
        }

        public static readonly DependencyProperty BusyContentTemplateProperty =
            DependencyProperty.Register("BusyContentTemplate", typeof(DataTemplate), typeof(BusyControl), new PropertyMetadata(null));

        public DataTemplate BusyContentTemplate
        {
            get { return (DataTemplate)GetValue(BusyContentTemplateProperty); }
            set { SetValue(BusyContentTemplateProperty, value); }
        }


        #endregion

        #region Action Error

        public static readonly DependencyProperty ActionErrorContentProperty =
           DependencyProperty.Register("ActionErrorContent", typeof(object), typeof(BusyControl), new PropertyMetadata(null));

        public object ActionErrorContent
        {
            get { return (object)GetValue(ActionErrorContentProperty); }
            set { SetValue(ActionErrorContentProperty, value); }
        }

        public static readonly DependencyProperty ActionErrorContentTemplateProperty =
            DependencyProperty.Register("ActionErrorContentTemplate", typeof(DataTemplate), typeof(BusyControl), new PropertyMetadata(null));

        public DataTemplate ActionErrorContentTemplate
        {
            get { return (DataTemplate)GetValue(ActionErrorContentTemplateProperty); }
            set { SetValue(ActionErrorContentTemplateProperty, value); }
        }


        #endregion

        #region Loading Error

        public object LoadingErrorContent
        {
            get { return (object)GetValue(LoadingErrorContentProperty); }
            set { SetValue(LoadingErrorContentProperty, value); }
        }

        public static readonly DependencyProperty LoadingErrorContentProperty =
            DependencyProperty.Register("LoadingErrorContent", typeof(object), typeof(BusyControl), new PropertyMetadata(null));

        public DataTemplate LoadingErrorContentTemplate
        {
            get { return (DataTemplate)GetValue(LoadingErrorContentTemplateProperty); }
            set { SetValue(LoadingErrorContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty LoadingErrorContentTemplateProperty =
            DependencyProperty.Register("LoadingErrorContentTemplate", typeof(DataTemplate), typeof(BusyControl), new PropertyMetadata(null));


        #endregion

        #region Custom Error

        public object CustomErrorContent
        {
            get { return (object)GetValue(CustomErrorContentProperty); }
            set { SetValue(CustomErrorContentProperty, value); }
        }

        public static readonly DependencyProperty CustomErrorContentProperty =
            DependencyProperty.Register("CustomErrorContent", typeof(object), typeof(BusyControl), new PropertyMetadata(null));

        public DataTemplate CustomErrorContentTemplate
        {
            get { return (DataTemplate)GetValue(CustomErrorContentTemplateProperty); }
            set { SetValue(CustomErrorContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty CustomErrorContentTemplateProperty =
            DependencyProperty.Register("CustomErrorContentTemplate", typeof(DataTemplate), typeof(BusyControl), new PropertyMetadata(null));


        #endregion


        public string ErrorTime
        {
            get { return (string)GetValue(ErrorTimeProperty); }
            set { SetValue(ErrorTimeProperty, value); }
        }

        public static readonly DependencyProperty ErrorTimeProperty =
            DependencyProperty.Register("ErrorTime", typeof(string), typeof(BusyControl), new PropertyMetadata(""));

        
        public string ErrorId
        {
            get { return (string)GetValue(ErrorIdProperty); }
            set { SetValue(ErrorIdProperty, value); }
        }

        public static readonly DependencyProperty ErrorIdProperty =
            DependencyProperty.Register("ErrorId", typeof(string), typeof(BusyControl), new PropertyMetadata(string.Empty));

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(BusyControl), new PropertyMetadata(string.Empty));

        public Control FocusAfterBusy
        {
            get { return (Control)GetValue(FocusAfterBusyProperty); }
            set { SetValue(FocusAfterBusyProperty, value); }
        }

        public static readonly DependencyProperty FocusAfterBusyProperty =
          DependencyProperty.Register("FocusAfterBusy", typeof(Control), typeof(BusyControl), new PropertyMetadata(null));

        public ICommand ReloadCommand
        {
            get { return (ICommand)GetValue(ReloadCommandProperty); }
            set { SetValue(ReloadCommandProperty, value); }
        }

        public static readonly DependencyProperty ReloadCommandProperty =
            DependencyProperty.Register("ReloadCommand", typeof(ICommand), typeof(BusyControl), new PropertyMetadata(null));

        #endregion

        #region Commands

        private ICommand _closeErroCommand;
        public ICommand CloseErroCommand
        {
            get
            {
                if (_closeErroCommand == null)
                {

                    _closeErroCommand = new RelayCommand(
                        param => this.ViewState = ViewStates.Default,
                        param => true);
                }

                return _closeErroCommand;
            }
        }

        #endregion

        #region Private Methods

        private static void OnViewStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((BusyControl)d).OnViewStateChanged(e);
        }

        protected virtual void OnViewStateChanged(DependencyPropertyChangedEventArgs e)
        {
            if (this.ViewState == ViewStates.Default  && this.FocusAfterBusy != null)
            {
                this.FocusAfterBusy.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                {
                    this.FocusAfterBusy.Focus();
                }
                ));
            }

            if (this.ViewState != ViewStates.Default && this.ViewState != ViewStates.Busy)
            {
                ErrorTime = DateTime.Now.ToString("dd/MM/yyy HH:mm:ss");
            }
        }

        #endregion
    }
}
