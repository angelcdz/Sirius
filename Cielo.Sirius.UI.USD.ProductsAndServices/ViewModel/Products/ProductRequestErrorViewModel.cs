using Cielo.Sirius.Foundation.USD;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Products
{
    class ProductRequestErrorViewModel : ViewModelBase
    {
        /// <summary>
        /// Campo Titulo da mensagem de retorno
        /// </summary>
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message == value)
                    return;
                _message = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Campo detalhe da mensagem de retorno
        /// </summary>
        private string _messageDetail;
        public string MessageDetail
        {
            get { return _messageDetail; }
            set
            {
                if (_messageDetail == value)
                    return;
                _messageDetail = value;
                OnPropertyChanged();
            }
        }

        public override void PreInitialize(System.Collections.Generic.Dictionary<string, object> navegationParams_)
        {
            Message = navegationParams_["Message"] as string;
            MessageDetail = navegationParams_["MessageDetail"] as string;
            base.PreInitialize(navegationParams_);
        }
    }
}
