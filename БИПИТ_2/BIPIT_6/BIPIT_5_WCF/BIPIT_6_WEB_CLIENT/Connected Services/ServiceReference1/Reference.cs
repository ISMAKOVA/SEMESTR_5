﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIPIT_6_WEB_CLIENT.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Data.DataSet GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/NewRec", ReplyAction="http://tempuri.org/IService/NewRecResponse")]
        void NewRec(string exh_fk, string halls_fk, string date_start, string date_end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/NewRec", ReplyAction="http://tempuri.org/IService/NewRecResponse")]
        System.Threading.Tasks.Task NewRecAsync(string exh_fk, string halls_fk, string date_start, string date_end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataExhibits", ReplyAction="http://tempuri.org/IService/GetDataExhibitsResponse")]
        System.Data.DataSet GetDataExhibits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataExhibits", ReplyAction="http://tempuri.org/IService/GetDataExhibitsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetDataExhibitsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataHalls", ReplyAction="http://tempuri.org/IService/GetDataHallsResponse")]
        System.Data.DataSet GetDataHalls();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataHalls", ReplyAction="http://tempuri.org/IService/GetDataHallsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetDataHallsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/HostInfo", ReplyAction="http://tempuri.org/IService/HostInfoResponse")]
        void HostInfo(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/HostInfo", ReplyAction="http://tempuri.org/IService/HostInfoResponse")]
        System.Threading.Tasks.Task HostInfoAsync(int x);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : BIPIT_6_WEB_CLIENT.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<BIPIT_6_WEB_CLIENT.ServiceReference1.IService>, BIPIT_6_WEB_CLIENT.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
        
        public void NewRec(string exh_fk, string halls_fk, string date_start, string date_end) {
            base.Channel.NewRec(exh_fk, halls_fk, date_start, date_end);
        }
        
        public System.Threading.Tasks.Task NewRecAsync(string exh_fk, string halls_fk, string date_start, string date_end) {
            return base.Channel.NewRecAsync(exh_fk, halls_fk, date_start, date_end);
        }
        
        public System.Data.DataSet GetDataExhibits() {
            return base.Channel.GetDataExhibits();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetDataExhibitsAsync() {
            return base.Channel.GetDataExhibitsAsync();
        }
        
        public System.Data.DataSet GetDataHalls() {
            return base.Channel.GetDataHalls();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetDataHallsAsync() {
            return base.Channel.GetDataHallsAsync();
        }
        
        public void HostInfo(int x) {
            base.Channel.HostInfo(x);
        }
        
        public System.Threading.Tasks.Task HostInfoAsync(int x) {
            return base.Channel.HostInfoAsync(x);
        }
    }
}
