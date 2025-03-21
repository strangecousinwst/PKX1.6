﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace KRONOS.pt.mcdonalds.portugal {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="mcdonalds_svcSoap", Namespace="http://tempuri.org/")]
    public partial class mcdonalds_svc : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCitiesOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchRestaurantOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllRestaurantsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRestaurantOperationCompleted;
        
        private System.Threading.SendOrPostCallback EnviaContactoOperationCompleted;
        
        private System.Threading.SendOrPostCallback MailFranchisingOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecordContactoChatOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public mcdonalds_svc() {
            this.Url = global::KRONOS.Properties.Settings.Default.KRONOS_pt_mcdonalds_portugal_mcdonalds_svc;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
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
        public event GetCitiesCompletedEventHandler GetCitiesCompleted;
        
        /// <remarks/>
        public event SearchRestaurantCompletedEventHandler SearchRestaurantCompleted;
        
        /// <remarks/>
        public event GetAllRestaurantsCompletedEventHandler GetAllRestaurantsCompleted;
        
        /// <remarks/>
        public event GetRestaurantCompletedEventHandler GetRestaurantCompleted;
        
        /// <remarks/>
        public event EnviaContactoCompletedEventHandler EnviaContactoCompleted;
        
        /// <remarks/>
        public event MailFranchisingCompletedEventHandler MailFranchisingCompleted;
        
        /// <remarks/>
        public event RecordContactoChatCompletedEventHandler RecordContactoChatCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCities", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetCities() {
            object[] results = this.Invoke("GetCities", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetCitiesAsync() {
            this.GetCitiesAsync(null);
        }
        
        /// <remarks/>
        public void GetCitiesAsync(object userState) {
            if ((this.GetCitiesOperationCompleted == null)) {
                this.GetCitiesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCitiesOperationCompleted);
            }
            this.InvokeAsync("GetCities", new object[0], this.GetCitiesOperationCompleted, userState);
        }
        
        private void OnGetCitiesOperationCompleted(object arg) {
            if ((this.GetCitiesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCitiesCompleted(this, new GetCitiesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SearchRestaurant", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet SearchRestaurant(string distrito, bool playland, bool fraldario, bool festas, bool mcdrive) {
            object[] results = this.Invoke("SearchRestaurant", new object[] {
                        distrito,
                        playland,
                        fraldario,
                        festas,
                        mcdrive});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void SearchRestaurantAsync(string distrito, bool playland, bool fraldario, bool festas, bool mcdrive) {
            this.SearchRestaurantAsync(distrito, playland, fraldario, festas, mcdrive, null);
        }
        
        /// <remarks/>
        public void SearchRestaurantAsync(string distrito, bool playland, bool fraldario, bool festas, bool mcdrive, object userState) {
            if ((this.SearchRestaurantOperationCompleted == null)) {
                this.SearchRestaurantOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchRestaurantOperationCompleted);
            }
            this.InvokeAsync("SearchRestaurant", new object[] {
                        distrito,
                        playland,
                        fraldario,
                        festas,
                        mcdrive}, this.SearchRestaurantOperationCompleted, userState);
        }
        
        private void OnSearchRestaurantOperationCompleted(object arg) {
            if ((this.SearchRestaurantCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchRestaurantCompleted(this, new SearchRestaurantCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllRestaurants", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetAllRestaurants() {
            object[] results = this.Invoke("GetAllRestaurants", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllRestaurantsAsync() {
            this.GetAllRestaurantsAsync(null);
        }
        
        /// <remarks/>
        public void GetAllRestaurantsAsync(object userState) {
            if ((this.GetAllRestaurantsOperationCompleted == null)) {
                this.GetAllRestaurantsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllRestaurantsOperationCompleted);
            }
            this.InvokeAsync("GetAllRestaurants", new object[0], this.GetAllRestaurantsOperationCompleted, userState);
        }
        
        private void OnGetAllRestaurantsOperationCompleted(object arg) {
            if ((this.GetAllRestaurantsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllRestaurantsCompleted(this, new GetAllRestaurantsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRestaurant", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetRestaurant(int id) {
            object[] results = this.Invoke("GetRestaurant", new object[] {
                        id});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetRestaurantAsync(int id) {
            this.GetRestaurantAsync(id, null);
        }
        
        /// <remarks/>
        public void GetRestaurantAsync(int id, object userState) {
            if ((this.GetRestaurantOperationCompleted == null)) {
                this.GetRestaurantOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRestaurantOperationCompleted);
            }
            this.InvokeAsync("GetRestaurant", new object[] {
                        id}, this.GetRestaurantOperationCompleted, userState);
        }
        
        private void OnGetRestaurantOperationCompleted(object arg) {
            if ((this.GetRestaurantCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRestaurantCompleted(this, new GetRestaurantCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EnviaContacto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Result EnviaContacto(string nome, string telefone, string email, string restaurante, string assunto, string mensagem) {
            object[] results = this.Invoke("EnviaContacto", new object[] {
                        nome,
                        telefone,
                        email,
                        restaurante,
                        assunto,
                        mensagem});
            return ((Result)(results[0]));
        }
        
        /// <remarks/>
        public void EnviaContactoAsync(string nome, string telefone, string email, string restaurante, string assunto, string mensagem) {
            this.EnviaContactoAsync(nome, telefone, email, restaurante, assunto, mensagem, null);
        }
        
        /// <remarks/>
        public void EnviaContactoAsync(string nome, string telefone, string email, string restaurante, string assunto, string mensagem, object userState) {
            if ((this.EnviaContactoOperationCompleted == null)) {
                this.EnviaContactoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnviaContactoOperationCompleted);
            }
            this.InvokeAsync("EnviaContacto", new object[] {
                        nome,
                        telefone,
                        email,
                        restaurante,
                        assunto,
                        mensagem}, this.EnviaContactoOperationCompleted, userState);
        }
        
        private void OnEnviaContactoOperationCompleted(object arg) {
            if ((this.EnviaContactoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EnviaContactoCompleted(this, new EnviaContactoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/MailFranchising", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Result MailFranchising(string nome, string morada, int cp1, int cp2, string localidade, string sexo, string ocupacao, string telemovel, string email, string dataNascimento) {
            object[] results = this.Invoke("MailFranchising", new object[] {
                        nome,
                        morada,
                        cp1,
                        cp2,
                        localidade,
                        sexo,
                        ocupacao,
                        telemovel,
                        email,
                        dataNascimento});
            return ((Result)(results[0]));
        }
        
        /// <remarks/>
        public void MailFranchisingAsync(string nome, string morada, int cp1, int cp2, string localidade, string sexo, string ocupacao, string telemovel, string email, string dataNascimento) {
            this.MailFranchisingAsync(nome, morada, cp1, cp2, localidade, sexo, ocupacao, telemovel, email, dataNascimento, null);
        }
        
        /// <remarks/>
        public void MailFranchisingAsync(string nome, string morada, int cp1, int cp2, string localidade, string sexo, string ocupacao, string telemovel, string email, string dataNascimento, object userState) {
            if ((this.MailFranchisingOperationCompleted == null)) {
                this.MailFranchisingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMailFranchisingOperationCompleted);
            }
            this.InvokeAsync("MailFranchising", new object[] {
                        nome,
                        morada,
                        cp1,
                        cp2,
                        localidade,
                        sexo,
                        ocupacao,
                        telemovel,
                        email,
                        dataNascimento}, this.MailFranchisingOperationCompleted, userState);
        }
        
        private void OnMailFranchisingOperationCompleted(object arg) {
            if ((this.MailFranchisingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MailFranchisingCompleted(this, new MailFranchisingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RecordContactoChat", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ResultRecord RecordContactoChat(string nome, string pergunta, string email, bool receberEmail) {
            object[] results = this.Invoke("RecordContactoChat", new object[] {
                        nome,
                        pergunta,
                        email,
                        receberEmail});
            return ((ResultRecord)(results[0]));
        }
        
        /// <remarks/>
        public void RecordContactoChatAsync(string nome, string pergunta, string email, bool receberEmail) {
            this.RecordContactoChatAsync(nome, pergunta, email, receberEmail, null);
        }
        
        /// <remarks/>
        public void RecordContactoChatAsync(string nome, string pergunta, string email, bool receberEmail, object userState) {
            if ((this.RecordContactoChatOperationCompleted == null)) {
                this.RecordContactoChatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecordContactoChatOperationCompleted);
            }
            this.InvokeAsync("RecordContactoChat", new object[] {
                        nome,
                        pergunta,
                        email,
                        receberEmail}, this.RecordContactoChatOperationCompleted, userState);
        }
        
        private void OnRecordContactoChatOperationCompleted(object arg) {
            if ((this.RecordContactoChatCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecordContactoChatCompleted(this, new RecordContactoChatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Result {
        
        private string dadosField;
        
        private string messageField;
        
        /// <remarks/>
        public string dados {
            get {
                return this.dadosField;
            }
            set {
                this.dadosField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ResultRecord {
        
        private string descriptionField;
        
        private int nIDField;
        
        private bool resultField;
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public int nID {
            get {
                return this.nIDField;
            }
            set {
                this.nIDField = value;
            }
        }
        
        /// <remarks/>
        public bool result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void GetCitiesCompletedEventHandler(object sender, GetCitiesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCitiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCitiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SearchRestaurantCompletedEventHandler(object sender, SearchRestaurantCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchRestaurantCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchRestaurantCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void GetAllRestaurantsCompletedEventHandler(object sender, GetAllRestaurantsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllRestaurantsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllRestaurantsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void GetRestaurantCompletedEventHandler(object sender, GetRestaurantCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRestaurantCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRestaurantCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void EnviaContactoCompletedEventHandler(object sender, EnviaContactoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EnviaContactoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EnviaContactoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Result Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Result)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void MailFranchisingCompletedEventHandler(object sender, MailFranchisingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MailFranchisingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MailFranchisingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Result Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Result)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RecordContactoChatCompletedEventHandler(object sender, RecordContactoChatCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecordContactoChatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecordContactoChatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ResultRecord Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ResultRecord)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591