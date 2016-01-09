using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Sirius.Foundation.USD;
using Cielo.Sirius.Foundation.USD.Commands;
using Cielo.Sirius.Foundation.USD.Messenger;
using Cielo.Sirius.UI.USD.ProductsAndServices.Model;
using System.Windows.Input;
using Cielo.Sirius.Contracts;


namespace Cielo.Sirius.UI.USD.ProductsAndServices.TestControls
{
    class ContextControlViewModel : ViewModelBase
    {
        private String _contextId;
        public String ContextId
        {
            get { return _contextId; }
            set
            {
                if (_contextId == value)
                    return;
                _contextId = value;
                OnPropertyChanged();
            }
        }

        private String _contextValue;
        public String ContextValue
        {
            get { return _contextValue; }
            set
            {
                if (_contextValue == value)
                    return;
                _contextValue = value;
                OnPropertyChanged();
            }
        }


        private String _contextIdProtocolo;
        public String ContextIdProtocolo
        {
            get { return _contextIdProtocolo; }
            set
            {
                if (_contextIdProtocolo == value)
                    return;
                _contextIdProtocolo = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueProtocolo;
        public String ContextValueProtocolo
        {
            get { return _contextValueProtocolo; }
            set
            {
                if (_contextValueProtocolo == value)
                    return;
                _contextValueProtocolo = value;
                OnPropertyChanged();
            }
        }


        private String _contextIdNomeContato;
        public String ContextIdNomeContato
        {
            get { return _contextIdNomeContato; }
            set
            {
                if (_contextIdNomeContato == value)
                    return;
                _contextIdNomeContato = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueNomeContato;
        public String ContextValueNomeContato
        {
            get { return _contextValueNomeContato; }
            set
            {
                if (_contextValueNomeContato == value)
                    return;
                _contextValueNomeContato = value;
                OnPropertyChanged();
            }
        }


        private String _contextIdTelefone;
        public String ContextIdTelefone
        {
            get { return _contextIdTelefone; }
            set
            {
                if (_contextIdTelefone == value)
                    return;
                _contextIdTelefone = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueTelefone;
        public String ContextValueTelefone
        {
            get { return _contextValueTelefone; }
            set
            {
                if (_contextValueTelefone == value)
                    return;
                _contextValueTelefone = value;
                OnPropertyChanged();
            }
        }


        private String _contextIdCelular;
        public String ContextIdCelular
        {
            get { return _contextIdCelular; }
            set
            {
                if (_contextIdCelular == value)
                    return;
                _contextIdCelular = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueCelular;
        public String ContextValueCelular
        {
            get { return _contextValueCelular; }
            set
            {
                if (_contextValueCelular == value)
                    return;
                _contextValueCelular = value;
                OnPropertyChanged();
            }
        }

        private String _contextIdIlhaDeAtendimento;
        public String ContextIdIlhaDeAtendimento
        {
            get { return _contextIdIlhaDeAtendimento; }
            set
            {
                if (_contextIdIlhaDeAtendimento == value)
                    return;
                _contextIdIlhaDeAtendimento = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueIlhaDeAtendimento;
        public String ContextValueIlhaDeAtendimento
        {
            get { return _contextValueIlhaDeAtendimento; }
            set
            {
                if (_contextValueIlhaDeAtendimento == value)
                    return;
                _contextValueIlhaDeAtendimento = value;
                OnPropertyChanged();
            }
        }

        private String _contextIdTituloDeOcorrencia;
        public String ContextIdTituloDeOcorrencia
        {
            get { return _contextIdTituloDeOcorrencia; }
            set
            {
                if (_contextIdTituloDeOcorrencia == value)
                    return;
                _contextIdTituloDeOcorrencia = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueTituloDeOcorrencia;
        public String ContextValueTituloDeOcorrencia
        {
            get { return _contextValueTituloDeOcorrencia; }
            set
            {
                if (_contextValueTituloDeOcorrencia == value)
                    return;
                _contextValueTituloDeOcorrencia = value;
                OnPropertyChanged();
            }
        }

        private String _contextIdAccount;
        public String ContextIdAccount
        {
            get { return _contextIdAccount; }
            set
            {
                if (_contextIdAccount == value)
                    return;
                _contextIdAccount = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueAccount;
        public String ContextValueAccount
        {
            get { return _contextValueAccount; }
            set
            {
                if (_contextValueAccount == value)
                    return;
                _contextValueAccount = value;
                OnPropertyChanged();
            }
        }

        private String _contextIdParentCaseId;
        public String ContextIdParentCaseId
        {
            get { return _contextIdParentCaseId; }
            set
            {
                if (_contextIdParentCaseId == value)
                    return;
                _contextIdParentCaseId = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueParentCaseId;
        public String ContextValueParentCaseId
        {
            get { return _contextValueParentCaseId; }
            set
            {
                if (_contextValueParentCaseId == value)
                    return;
                _contextValueParentCaseId = value;
                OnPropertyChanged();
            }
        }

        private String _contextIdContactId;
        public String ContextIdContactId
        {
            get { return _contextIdContactId; }
            set
            {
                if (_contextIdContactId == value)
                    return;
                _contextIdContactId = value;
                OnPropertyChanged();
            }
        }

        private String _contextValueContactId;
        public String ContextValueContactId
        {
            get { return _contextValueContactId; }
            set
            {
                if (_contextValueContactId == value)
                    return;
                _contextValueContactId = value;
                OnPropertyChanged();
            }
        }


        #region Commands

        private ICommand _Iniciar;

        public ICommand Iniciar
        {
            get
            {
                if (_Iniciar == null)
                {
                    _Iniciar = new RelayCommand(
                        param =>
                        {
                            UpdateCrmContextValue(ContextId, ContextValue);
                            UpdateCrmContextValue(ContextIdProtocolo, ContextValueProtocolo);
                            UpdateCrmContextValue(ContextIdNomeContato, ContextValueNomeContato);
                            UpdateCrmContextValue(ContextIdCelular, ContextValueCelular);
                            UpdateCrmContextValue(ContextIdIlhaDeAtendimento, ContextValueIlhaDeAtendimento);
                            UpdateCrmContextValue(ContextIdTelefone, ContextValueTelefone);
                            UpdateCrmContextValue(ContextIdTituloDeOcorrencia, ContextValueTituloDeOcorrencia);
                            UpdateCrmContextValue(ContextIdAccount, ContextValueAccount);
                            UpdateCrmContextValue(ContextIdParentCaseId, ContextValueParentCaseId);
                            UpdateCrmContextValue(ContextIdContactId, ContextValueContactId);

                            Navegate("EquipmentDetails", "ProductsAndServicesMainRegion", "", null);
                        },
                        param => true
                    );
                }
                return _Iniciar;
            }
        }

        #endregion

        public ContextControlViewModel()
        {
            ContextId = Constants.CONTEXTOCRM_CLIENTID;
            ContextValue = "10011001";

            ContextIdProtocolo = Constants.CONTEXTOCRM_PROTOCOLO;
            ContextValueProtocolo = "0000222";

            ContextIdNomeContato = Constants.CONTEXTOCRM_NOMECONTATO;
            ContextValueNomeContato = "Cielo";

            ContextIdTelefone = Constants.CONTEXTOCRM_TELEFONE;
            ContextValueTelefone = "985435678";

            ContextIdTituloDeOcorrencia = Constants.CONTEXTOCRM_TITULOCORRENCIA;
            ContextValueTituloDeOcorrencia = "Titulo de ocorrencia";

            ContextIdCelular = Constants.CONTEXTOCRM_CELULAR;
            ContextValueCelular = "985424789";

            ContextIdIlhaDeAtendimento = Constants.CONTEXTOCRM_ILHADEATENDIMENTO;
            ContextValueIlhaDeAtendimento = "ab4d2b05-1a32-e511-80ce-000d3ac01090";

            ContextIdAccount = Constants.CONTEXTOCRM_ACCOUNT;
            ContextValueAccount = "99367d71-08ad-4aec-8e73-55ae151614f9";

            ContextIdParentCaseId = Constants.CONTEXTOCRM_PARENTCASEID;
            ContextValueParentCaseId = "32321b5c-8138-e511-80fa-000d3ac01597";

            ContextIdContactId = Constants.CONTEXTOCRM_CONTACTID;
            ContextValueContactId = "00478d80-19ad-5aec-9e84-66ae262725f1";
        }
    }
}
