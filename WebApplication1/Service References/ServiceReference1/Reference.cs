﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CouchbaseWebService.Web.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET", ConfigurationName="ServiceReference1.airportSoap")]
    public interface airportSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByISOCountryCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getAirportInformationByISOCountryCode(string CountryAbbrviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByISOCountryCode", ReplyAction="*")]
        System.Threading.Tasks.Task<string> getAirportInformationByISOCountryCodeAsync(string CountryAbbrviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByCityOrAirportName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getAirportInformationByCityOrAirportName(string cityOrAirportName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByCityOrAirportName", ReplyAction="*")]
        System.Threading.Tasks.Task<string> getAirportInformationByCityOrAirportNameAsync(string cityOrAirportName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetAirportInformationByCountry", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAirportInformationByCountry(string country);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetAirportInformationByCountry", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetAirportInformationByCountryAsync(string country);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByAirportCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getAirportInformationByAirportCode(string airportCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/getAirportInformationByAirportCode", ReplyAction="*")]
        System.Threading.Tasks.Task<string> getAirportInformationByAirportCodeAsync(string airportCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface airportSoapChannel : CouchbaseWebService.Web.ServiceReference1.airportSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class airportSoapClient : System.ServiceModel.ClientBase<CouchbaseWebService.Web.ServiceReference1.airportSoap>, CouchbaseWebService.Web.ServiceReference1.airportSoap {
        
        public airportSoapClient() {
        }
        
        public airportSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public airportSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public airportSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public airportSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getAirportInformationByISOCountryCode(string CountryAbbrviation) {
            return base.Channel.getAirportInformationByISOCountryCode(CountryAbbrviation);
        }
        
        public System.Threading.Tasks.Task<string> getAirportInformationByISOCountryCodeAsync(string CountryAbbrviation) {
            return base.Channel.getAirportInformationByISOCountryCodeAsync(CountryAbbrviation);
        }
        
        public string getAirportInformationByCityOrAirportName(string cityOrAirportName) {
            return base.Channel.getAirportInformationByCityOrAirportName(cityOrAirportName);
        }
        
        public System.Threading.Tasks.Task<string> getAirportInformationByCityOrAirportNameAsync(string cityOrAirportName) {
            return base.Channel.getAirportInformationByCityOrAirportNameAsync(cityOrAirportName);
        }
        
        public string GetAirportInformationByCountry(string country) {
            return base.Channel.GetAirportInformationByCountry(country);
        }
        
        public System.Threading.Tasks.Task<string> GetAirportInformationByCountryAsync(string country) {
            return base.Channel.GetAirportInformationByCountryAsync(country);
        }
        
        public string getAirportInformationByAirportCode(string airportCode) {
            return base.Channel.getAirportInformationByAirportCode(airportCode);
        }
        
        public System.Threading.Tasks.Task<string> getAirportInformationByAirportCodeAsync(string airportCode) {
            return base.Channel.getAirportInformationByAirportCodeAsync(airportCode);
        }
    }
}
