﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.60310.0
// 
namespace LuckyDraw.DataService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LuckyDrawParticipants", Namespace="http://schemas.datacontract.org/2004/07/LuckyDraw.Web.Contracts")]
    public partial class LuckyDrawParticipants : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.ObjectModel.ObservableCollection<string> NamesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<string> Names {
            get {
                return this.NamesField;
            }
            set {
                if ((object.ReferenceEquals(this.NamesField, value) != true)) {
                    this.NamesField = value;
                    this.RaisePropertyChanged("Names");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="DataService.LuckyDrawService")]
    public interface LuckyDrawService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:LuckyDrawService/GetNames", ReplyAction="urn:LuckyDrawService/GetNamesResponse")]
        System.IAsyncResult BeginGetNames(System.AsyncCallback callback, object asyncState);
        
        LuckyDraw.DataService.LuckyDrawParticipants EndGetNames(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LuckyDrawServiceChannel : LuckyDraw.DataService.LuckyDrawService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetNamesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetNamesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public LuckyDraw.DataService.LuckyDrawParticipants Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((LuckyDraw.DataService.LuckyDrawParticipants)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LuckyDrawServiceClient : System.ServiceModel.ClientBase<LuckyDraw.DataService.LuckyDrawService>, LuckyDraw.DataService.LuckyDrawService {
        
        private BeginOperationDelegate onBeginGetNamesDelegate;
        
        private EndOperationDelegate onEndGetNamesDelegate;
        
        private System.Threading.SendOrPostCallback onGetNamesCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public LuckyDrawServiceClient() {
        }
        
        public LuckyDrawServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LuckyDrawServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LuckyDrawServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LuckyDrawServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetNamesCompletedEventArgs> GetNamesCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult LuckyDraw.DataService.LuckyDrawService.BeginGetNames(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetNames(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LuckyDraw.DataService.LuckyDrawParticipants LuckyDraw.DataService.LuckyDrawService.EndGetNames(System.IAsyncResult result) {
            return base.Channel.EndGetNames(result);
        }
        
        private System.IAsyncResult OnBeginGetNames(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((LuckyDraw.DataService.LuckyDrawService)(this)).BeginGetNames(callback, asyncState);
        }
        
        private object[] OnEndGetNames(System.IAsyncResult result) {
            LuckyDraw.DataService.LuckyDrawParticipants retVal = ((LuckyDraw.DataService.LuckyDrawService)(this)).EndGetNames(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetNamesCompleted(object state) {
            if ((this.GetNamesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetNamesCompleted(this, new GetNamesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetNamesAsync() {
            this.GetNamesAsync(null);
        }
        
        public void GetNamesAsync(object userState) {
            if ((this.onBeginGetNamesDelegate == null)) {
                this.onBeginGetNamesDelegate = new BeginOperationDelegate(this.OnBeginGetNames);
            }
            if ((this.onEndGetNamesDelegate == null)) {
                this.onEndGetNamesDelegate = new EndOperationDelegate(this.OnEndGetNames);
            }
            if ((this.onGetNamesCompletedDelegate == null)) {
                this.onGetNamesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetNamesCompleted);
            }
            base.InvokeAsync(this.onBeginGetNamesDelegate, null, this.onEndGetNamesDelegate, this.onGetNamesCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override LuckyDraw.DataService.LuckyDrawService CreateChannel() {
            return new LuckyDrawServiceClientChannel(this);
        }
        
        private class LuckyDrawServiceClientChannel : ChannelBase<LuckyDraw.DataService.LuckyDrawService>, LuckyDraw.DataService.LuckyDrawService {
            
            public LuckyDrawServiceClientChannel(System.ServiceModel.ClientBase<LuckyDraw.DataService.LuckyDrawService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetNames(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetNames", _args, callback, asyncState);
                return _result;
            }
            
            public LuckyDraw.DataService.LuckyDrawParticipants EndGetNames(System.IAsyncResult result) {
                object[] _args = new object[0];
                LuckyDraw.DataService.LuckyDrawParticipants _result = ((LuckyDraw.DataService.LuckyDrawParticipants)(base.EndInvoke("GetNames", _args, result)));
                return _result;
            }
        }
    }
}
