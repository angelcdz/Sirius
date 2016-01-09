﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34209.
// 
#pragma warning disable 1591

namespace Cielo.Sirius.DAO.Products.WR.Faturamento {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicoSOAP", Namespace="http://service.cielo.com.br/cadastro/faturamento/faturamento/v1")]
    public partial class Servico : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private CieloSoapHeaderType cieloSoapHeaderField;
        
        private System.Threading.SendOrPostCallback solicitarNegociacaoTaxaProdutoComercialOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Servico() {
            this.Url = global::Cielo.Sirius.DAO.Products.Properties.Settings.Default.ServiceURL_Faturamento;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public CieloSoapHeaderType cieloSoapHeader {
            get {
                return this.cieloSoapHeaderField;
            }
            set {
                this.cieloSoapHeaderField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event solicitarNegociacaoTaxaProdutoComercialCompletedEventHandler solicitarNegociacaoTaxaProdutoComercialCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("cieloSoapHeader")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://service.cielo.com.br/cadastro/faturamento/faturamento/v1/solicitarNegociac" +
            "aoTaxaProdutoComercial", RequestElementName="solicitarNegociacaoTaxaProdutoComercialRequest", RequestNamespace="http://service.cielo.com.br/cadastro/faturamento/faturamento/v1", ResponseNamespace="http://service.cielo.com.br/cadastro/faturamento/faturamento/v1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("codigoRetorno", DataType="integer")]
        public string solicitarNegociacaoTaxaProdutoComercial([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string protocolo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<long> codigoCliente, [System.Xml.Serialization.XmlElementAttribute(DataType="integer", IsNullable=true)] string codigoProduto, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nomeContato, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<decimal> percentualTaxaPropostaConcorrente, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string celularContato, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string telefoneContato, out string descricaoRetornoMensagem, out string statusRetorno, out string sistemaLegado, out SolicitacaoCentralAtendimento solicitacaoCentralAtendimento) {
            object[] results = this.Invoke("solicitarNegociacaoTaxaProdutoComercial", new object[] {
                        protocolo,
                        codigoCliente,
                        codigoProduto,
                        nomeContato,
                        percentualTaxaPropostaConcorrente,
                        celularContato,
                        telefoneContato});
            descricaoRetornoMensagem = ((string)(results[1]));
            statusRetorno = ((string)(results[2]));
            sistemaLegado = ((string)(results[3]));
            solicitacaoCentralAtendimento = ((SolicitacaoCentralAtendimento)(results[4]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void solicitarNegociacaoTaxaProdutoComercialAsync(string protocolo, System.Nullable<long> codigoCliente, string codigoProduto, string nomeContato, System.Nullable<decimal> percentualTaxaPropostaConcorrente, string celularContato, string telefoneContato) {
            this.solicitarNegociacaoTaxaProdutoComercialAsync(protocolo, codigoCliente, codigoProduto, nomeContato, percentualTaxaPropostaConcorrente, celularContato, telefoneContato, null);
        }
        
        /// <remarks/>
        public void solicitarNegociacaoTaxaProdutoComercialAsync(string protocolo, System.Nullable<long> codigoCliente, string codigoProduto, string nomeContato, System.Nullable<decimal> percentualTaxaPropostaConcorrente, string celularContato, string telefoneContato, object userState) {
            if ((this.solicitarNegociacaoTaxaProdutoComercialOperationCompleted == null)) {
                this.solicitarNegociacaoTaxaProdutoComercialOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitarNegociacaoTaxaProdutoComercialOperationCompleted);
            }
            this.InvokeAsync("solicitarNegociacaoTaxaProdutoComercial", new object[] {
                        protocolo,
                        codigoCliente,
                        codigoProduto,
                        nomeContato,
                        percentualTaxaPropostaConcorrente,
                        celularContato,
                        telefoneContato}, this.solicitarNegociacaoTaxaProdutoComercialOperationCompleted, userState);
        }
        
        private void OnsolicitarNegociacaoTaxaProdutoComercialOperationCompleted(object arg) {
            if ((this.solicitarNegociacaoTaxaProdutoComercialCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitarNegociacaoTaxaProdutoComercialCompleted(this, new solicitarNegociacaoTaxaProdutoComercialCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://canonico.cielo.com.br/governancasoa/comum/v1")]
    [System.Xml.Serialization.XmlRootAttribute("cieloSoapHeader", Namespace="http://canonico.cielo.com.br/governancasoa/comum/v1", IsNullable=false)]
    public partial class CieloSoapHeaderType : System.Web.Services.Protocols.SoapHeader {
        
        private object itemField;
        
        private string recursoField;
        
        private string realmField;
        
        private IdentificacaoRequestType identificacaoRequestField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("token", typeof(string), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("usuario", typeof(UsuarioType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string recurso {
            get {
                return this.recursoField;
            }
            set {
                this.recursoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string realm {
            get {
                return this.realmField;
            }
            set {
                this.realmField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public IdentificacaoRequestType identificacaoRequest {
            get {
                return this.identificacaoRequestField;
            }
            set {
                this.identificacaoRequestField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://canonico.cielo.com.br/governancasoa/comum/v1")]
    public partial class UsuarioType {
        
        private string idField;
        
        private string senhaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string senha {
            get {
                return this.senhaField;
            }
            set {
                this.senhaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://canonico.cielo.com.br/canalrelacionamento/atendimentoassistido/v1")]
    public partial class SolicitacaoCentralAtendimento {
        
        private System.Nullable<long> codigoClienteField;
        
        private bool codigoClienteFieldSpecified;
        
        private string codigoSolicitacaoField;
        
        private System.Nullable<System.DateTime> dataPrevistaConclusaoSolicitacaoField;
        
        private bool dataPrevistaConclusaoSolicitacaoFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> codigoCliente {
            get {
                return this.codigoClienteField;
            }
            set {
                this.codigoClienteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codigoClienteSpecified {
            get {
                return this.codigoClienteFieldSpecified;
            }
            set {
                this.codigoClienteFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", IsNullable=true)]
        public string codigoSolicitacao {
            get {
                return this.codigoSolicitacaoField;
            }
            set {
                this.codigoSolicitacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true)]
        public System.Nullable<System.DateTime> dataPrevistaConclusaoSolicitacao {
            get {
                return this.dataPrevistaConclusaoSolicitacaoField;
            }
            set {
                this.dataPrevistaConclusaoSolicitacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dataPrevistaConclusaoSolicitacaoSpecified {
            get {
                return this.dataPrevistaConclusaoSolicitacaoFieldSpecified;
            }
            set {
                this.dataPrevistaConclusaoSolicitacaoFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://canonico.cielo.com.br/governancasoa/comum/v1")]
    public partial class IdentificacaoRequestType {
        
        private string nomeSistemaField;
        
        private string nomeTipoChamadaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nomeSistema {
            get {
                return this.nomeSistemaField;
            }
            set {
                this.nomeSistemaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nomeTipoChamada {
            get {
                return this.nomeTipoChamadaField;
            }
            set {
                this.nomeTipoChamadaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void solicitarNegociacaoTaxaProdutoComercialCompletedEventHandler(object sender, solicitarNegociacaoTaxaProdutoComercialCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class solicitarNegociacaoTaxaProdutoComercialCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal solicitarNegociacaoTaxaProdutoComercialCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string descricaoRetornoMensagem {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string statusRetorno {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public string sistemaLegado {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public SolicitacaoCentralAtendimento solicitacaoCentralAtendimento {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SolicitacaoCentralAtendimento)(this.results[4]));
            }
        }
    }
}

#pragma warning restore 1591