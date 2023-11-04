﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCConsumeWCF.EmployeeTrackerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/WCFEmployee")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> salaryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> salary {
            get {
                return this.salaryField;
            }
            set {
                if ((this.salaryField.Equals(value) != true)) {
                    this.salaryField = value;
                    this.RaisePropertyChanged("salary");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeTrackerService.IEmployeeTracker")]
    public interface IEmployeeTracker {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/GetAll", ReplyAction="http://tempuri.org/IEmployeeTracker/GetAllResponse")]
        MVCConsumeWCF.EmployeeTrackerService.Employee[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/GetAll", ReplyAction="http://tempuri.org/IEmployeeTracker/GetAllResponse")]
        System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/GetById", ReplyAction="http://tempuri.org/IEmployeeTracker/GetByIdResponse")]
        MVCConsumeWCF.EmployeeTrackerService.Employee GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/GetById", ReplyAction="http://tempuri.org/IEmployeeTracker/GetByIdResponse")]
        System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Insert", ReplyAction="http://tempuri.org/IEmployeeTracker/InsertResponse")]
        MVCConsumeWCF.EmployeeTrackerService.Employee Insert(string name, decimal salary);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Insert", ReplyAction="http://tempuri.org/IEmployeeTracker/InsertResponse")]
        System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> InsertAsync(string name, decimal salary);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Update", ReplyAction="http://tempuri.org/IEmployeeTracker/UpdateResponse")]
        MVCConsumeWCF.EmployeeTrackerService.Employee Update(int id, string name, decimal salary);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Update", ReplyAction="http://tempuri.org/IEmployeeTracker/UpdateResponse")]
        System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> UpdateAsync(int id, string name, decimal salary);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Delete", ReplyAction="http://tempuri.org/IEmployeeTracker/DeleteResponse")]
        MVCConsumeWCF.EmployeeTrackerService.Employee Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeTracker/Delete", ReplyAction="http://tempuri.org/IEmployeeTracker/DeleteResponse")]
        System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> DeleteAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeTrackerChannel : MVCConsumeWCF.EmployeeTrackerService.IEmployeeTracker, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeTrackerClient : System.ServiceModel.ClientBase<MVCConsumeWCF.EmployeeTrackerService.IEmployeeTracker>, MVCConsumeWCF.EmployeeTrackerService.IEmployeeTracker {
        
        public EmployeeTrackerClient() {
        }
        
        public EmployeeTrackerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeTrackerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeTrackerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeTrackerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MVCConsumeWCF.EmployeeTrackerService.Employee[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public MVCConsumeWCF.EmployeeTrackerService.Employee GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public MVCConsumeWCF.EmployeeTrackerService.Employee Insert(string name, decimal salary) {
            return base.Channel.Insert(name, salary);
        }
        
        public System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> InsertAsync(string name, decimal salary) {
            return base.Channel.InsertAsync(name, salary);
        }
        
        public MVCConsumeWCF.EmployeeTrackerService.Employee Update(int id, string name, decimal salary) {
            return base.Channel.Update(id, name, salary);
        }
        
        public System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> UpdateAsync(int id, string name, decimal salary) {
            return base.Channel.UpdateAsync(id, name, salary);
        }
        
        public MVCConsumeWCF.EmployeeTrackerService.Employee Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task<MVCConsumeWCF.EmployeeTrackerService.Employee> DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
    }
}
