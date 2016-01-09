using System.Windows;
using System.Windows.Controls;
using Cielo.Sirius.Foundation.USD.Commands;

namespace Cielo.Sirius.Foundation.USD
{
    public class ViewBaseControl : UserControl
    {
        public ViewStates ViewState
        {
            get { return (ViewStates)GetValue(ViewStateProperty); }
            set { SetValue(ViewStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewStateProperty =
            DependencyProperty.Register("ViewState", typeof(ViewStates), typeof(ViewBaseControl), new PropertyMetadata(ViewStates.Default));

        
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ViewBaseControl), new PropertyMetadata(null));


        public AsyncRelayCommand LoadCommand
        {
            get { return (AsyncRelayCommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register("LoadCommand", typeof(AsyncRelayCommand), typeof(ViewBaseControl), new PropertyMetadata(null));


        public object CustomErrorContent
        {
            get { return (object)GetValue(CustomErrorContentProperty); }
            set { SetValue(CustomErrorContentProperty, value); }
        }

        public static readonly DependencyProperty CustomErrorContentProperty =
            DependencyProperty.Register("CustomErrorContent", typeof(object), typeof(ViewBaseControl), new PropertyMetadata(null));

        public DataTemplate CustomErrorContentTemplate
        {
            get { return (DataTemplate)GetValue(CustomErrorContentTemplateProperty); }
            set { SetValue(CustomErrorContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty CustomErrorContentTemplateProperty =
            DependencyProperty.Register("CustomErrorContentTemplate", typeof(DataTemplate), typeof(ViewBaseControl), new PropertyMetadata(null));



        public string ErrorId
        {
            get { return (string)GetValue(ErrorIdProperty); }
            set { SetValue(ErrorIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorIdProperty =
            DependencyProperty.Register("ErrorId", typeof(string), typeof(ViewBaseControl), new PropertyMetadata(null));

        
    }
}
