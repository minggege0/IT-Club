﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT_Club_UI.UserInfoServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserInfoServiceReference.IUserInfoService")]
    public interface IUserInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/Query", ReplyAction="http://tempuri.org/IUserInfoService/QueryResponse")]
        string Query(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/Query", ReplyAction="http://tempuri.org/IUserInfoService/QueryResponse")]
        System.Threading.Tasks.Task<string> QueryAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/DeleteEntity", ReplyAction="http://tempuri.org/IUserInfoService/DeleteEntityResponse")]
        bool DeleteEntity(IT_Club_Model.UserInfo User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/DeleteEntity", ReplyAction="http://tempuri.org/IUserInfoService/DeleteEntityResponse")]
        System.Threading.Tasks.Task<bool> DeleteEntityAsync(IT_Club_Model.UserInfo User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/UpdateEntity", ReplyAction="http://tempuri.org/IUserInfoService/UpdateEntityResponse")]
        bool UpdateEntity(IT_Club_Model.UserInfo User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/UpdateEntity", ReplyAction="http://tempuri.org/IUserInfoService/UpdateEntityResponse")]
        System.Threading.Tasks.Task<bool> UpdateEntityAsync(IT_Club_Model.UserInfo User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/AddEntity", ReplyAction="http://tempuri.org/IUserInfoService/AddEntityResponse")]
        bool AddEntity(IT_Club_Model.UserInfo User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserInfoService/AddEntity", ReplyAction="http://tempuri.org/IUserInfoService/AddEntityResponse")]
        System.Threading.Tasks.Task<bool> AddEntityAsync(IT_Club_Model.UserInfo User);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserInfoServiceChannel : IT_Club_UI.UserInfoServiceReference.IUserInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserInfoServiceClient : System.ServiceModel.ClientBase<IT_Club_UI.UserInfoServiceReference.IUserInfoService>, IT_Club_UI.UserInfoServiceReference.IUserInfoService {
        
        public UserInfoServiceClient() {
        }
        
        public UserInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Query(string name) {
            return base.Channel.Query(name);
        }
        
        public System.Threading.Tasks.Task<string> QueryAsync(string name) {
            return base.Channel.QueryAsync(name);
        }
        
        public bool DeleteEntity(IT_Club_Model.UserInfo User) {
            return base.Channel.DeleteEntity(User);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteEntityAsync(IT_Club_Model.UserInfo User) {
            return base.Channel.DeleteEntityAsync(User);
        }
        
        public bool UpdateEntity(IT_Club_Model.UserInfo User) {
            return base.Channel.UpdateEntity(User);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateEntityAsync(IT_Club_Model.UserInfo User) {
            return base.Channel.UpdateEntityAsync(User);
        }
        
        public bool AddEntity(IT_Club_Model.UserInfo User) {
            return base.Channel.AddEntity(User);
        }
        
        public System.Threading.Tasks.Task<bool> AddEntityAsync(IT_Club_Model.UserInfo User) {
            return base.Channel.AddEntityAsync(User);
        }
    }
}