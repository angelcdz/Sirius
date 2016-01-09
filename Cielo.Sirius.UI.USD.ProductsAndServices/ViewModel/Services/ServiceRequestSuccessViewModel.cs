using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cielo.Sirius.UI.USD.ProductsAndServices.ViewModel.Services
{
    class ServiceRequestSuccessViewModel : ViewModelBase
    {
        /// <summary>
        /// Campo Titulo da mensagem de retorno
        /// </summary>
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message == value)
                    return;
                _Message = value;
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

        public override void PreInitialize(Dictionary<string, object> navegationParams_)
        {
            if (navegationParams_ != null)
            {
                if (navegationParams_.ContainsKey("Message") && navegationParams_["Message"] != null)
                {
                    Message = navegationParams_["Message"].ToString();
                }
                if (navegationParams_.ContainsKey("MessageDetail") && navegationParams_["MessageDetail"] != null)
                {
                    MessageDetail = navegationParams_["MessageDetail"].ToString();
                }
            }
            base.PreInitialize(navegationParams_);
        }
    }
}
