﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryItPage.WebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findNearestStore", ReplyAction="http://tempuri.org/IService1/findNearestStoreResponse")]
        string findNearestStore(string zipCode, string storeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findNearestStore", ReplyAction="http://tempuri.org/IService1/findNearestStoreResponse")]
        System.Threading.Tasks.Task<string> findNearestStoreAsync(string zipCode, string storeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/showAllStates", ReplyAction="http://tempuri.org/IService1/showAllStatesResponse")]
        string showAllStates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/showAllStates", ReplyAction="http://tempuri.org/IService1/showAllStatesResponse")]
        System.Threading.Tasks.Task<string> showAllStatesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryItPage.WebService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryItPage.WebService.IService1>, TryItPage.WebService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string findNearestStore(string zipCode, string storeName) {
            return base.Channel.findNearestStore(zipCode, storeName);
        }
        
        public System.Threading.Tasks.Task<string> findNearestStoreAsync(string zipCode, string storeName) {
            return base.Channel.findNearestStoreAsync(zipCode, storeName);
        }
        
        public string showAllStates() {
            return base.Channel.showAllStates();
        }
        
        public System.Threading.Tasks.Task<string> showAllStatesAsync() {
            return base.Channel.showAllStatesAsync();
        }
    }
}