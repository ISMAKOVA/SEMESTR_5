﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientForm.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.WebSoap")]
    public interface WebSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Calculate", ReplyAction="*")]
        double Calculate(int N, int M);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Calculate", ReplyAction="*")]
        System.Threading.Tasks.Task<double> CalculateAsync(int N, int M);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebSoapChannel : ClientForm.ServiceReference2.WebSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebSoapClient : System.ServiceModel.ClientBase<ClientForm.ServiceReference2.WebSoap>, ClientForm.ServiceReference2.WebSoap {
        
        public WebSoapClient() {
        }
        
        public WebSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Calculate(int N, int M) {
            return base.Channel.Calculate(N, M);
        }
        
        public System.Threading.Tasks.Task<double> CalculateAsync(int N, int M) {
            return base.Channel.CalculateAsync(N, M);
        }
    }
}
