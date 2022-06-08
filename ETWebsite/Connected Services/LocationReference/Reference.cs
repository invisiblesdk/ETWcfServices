﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETWebsite.LocationReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LocationReference.ILocation")]
    public interface ILocation {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/GetLocation", ReplyAction="http://tempuri.org/ILocation/GetLocationResponse")]
        ETApplicationServices.DTOs.LocationDto[] GetLocation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/GetLocation", ReplyAction="http://tempuri.org/ILocation/GetLocationResponse")]
        System.Threading.Tasks.Task<ETApplicationServices.DTOs.LocationDto[]> GetLocationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/PostLocation", ReplyAction="http://tempuri.org/ILocation/PostLocationResponse")]
        string PostLocation(ETApplicationServices.DTOs.LocationDto locationDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/PostLocation", ReplyAction="http://tempuri.org/ILocation/PostLocationResponse")]
        System.Threading.Tasks.Task<string> PostLocationAsync(ETApplicationServices.DTOs.LocationDto locationDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/PutLocation", ReplyAction="http://tempuri.org/ILocation/PutLocationResponse")]
        string PutLocation(ETApplicationServices.DTOs.LocationDto locationDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/PutLocation", ReplyAction="http://tempuri.org/ILocation/PutLocationResponse")]
        System.Threading.Tasks.Task<string> PutLocationAsync(ETApplicationServices.DTOs.LocationDto locationDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/DeleteLocation", ReplyAction="http://tempuri.org/ILocation/DeleteLocationResponse")]
        string DeleteLocation(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/DeleteLocation", ReplyAction="http://tempuri.org/ILocation/DeleteLocationResponse")]
        System.Threading.Tasks.Task<string> DeleteLocationAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/GetLocationById", ReplyAction="http://tempuri.org/ILocation/GetLocationByIdResponse")]
        ETApplicationServices.DTOs.LocationDto GetLocationById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/GetLocationById", ReplyAction="http://tempuri.org/ILocation/GetLocationByIdResponse")]
        System.Threading.Tasks.Task<ETApplicationServices.DTOs.LocationDto> GetLocationByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/Message", ReplyAction="http://tempuri.org/ILocation/MessageResponse")]
        string Message();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocation/Message", ReplyAction="http://tempuri.org/ILocation/MessageResponse")]
        System.Threading.Tasks.Task<string> MessageAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocationChannel : ETWebsite.LocationReference.ILocation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocationClient : System.ServiceModel.ClientBase<ETWebsite.LocationReference.ILocation>, ETWebsite.LocationReference.ILocation {
        
        public LocationClient() {
        }
        
        public LocationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LocationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ETApplicationServices.DTOs.LocationDto[] GetLocation() {
            return base.Channel.GetLocation();
        }
        
        public System.Threading.Tasks.Task<ETApplicationServices.DTOs.LocationDto[]> GetLocationAsync() {
            return base.Channel.GetLocationAsync();
        }
        
        public string PostLocation(ETApplicationServices.DTOs.LocationDto locationDto) {
            return base.Channel.PostLocation(locationDto);
        }
        
        public System.Threading.Tasks.Task<string> PostLocationAsync(ETApplicationServices.DTOs.LocationDto locationDto) {
            return base.Channel.PostLocationAsync(locationDto);
        }
        
        public string PutLocation(ETApplicationServices.DTOs.LocationDto locationDto) {
            return base.Channel.PutLocation(locationDto);
        }
        
        public System.Threading.Tasks.Task<string> PutLocationAsync(ETApplicationServices.DTOs.LocationDto locationDto) {
            return base.Channel.PutLocationAsync(locationDto);
        }
        
        public string DeleteLocation(int id) {
            return base.Channel.DeleteLocation(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteLocationAsync(int id) {
            return base.Channel.DeleteLocationAsync(id);
        }
        
        public ETApplicationServices.DTOs.LocationDto GetLocationById(int id) {
            return base.Channel.GetLocationById(id);
        }
        
        public System.Threading.Tasks.Task<ETApplicationServices.DTOs.LocationDto> GetLocationByIdAsync(int id) {
            return base.Channel.GetLocationByIdAsync(id);
        }
        
        public string Message() {
            return base.Channel.Message();
        }
        
        public System.Threading.Tasks.Task<string> MessageAsync() {
            return base.Channel.MessageAsync();
        }
    }
}