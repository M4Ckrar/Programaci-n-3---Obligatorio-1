﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCPortLog.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoProducto", Namespace="http://schemas.datacontract.org/2004/07/WCFServices")]
    [System.SerializableAttribute()]
    public partial class DtoProducto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServicioProducto")]
    public interface IServicioProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/ProductoXId", ReplyAction="http://tempuri.org/IServicioProducto/ProductoXIdResponse")]
        MVCPortLog.ServiceReference1.DtoProducto ProductoXId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/ProductoXId", ReplyAction="http://tempuri.org/IServicioProducto/ProductoXIdResponse")]
        System.Threading.Tasks.Task<MVCPortLog.ServiceReference1.DtoProducto> ProductoXIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/ListarTodosLosProductos", ReplyAction="http://tempuri.org/IServicioProducto/ListarTodosLosProductosResponse")]
        MVCPortLog.ServiceReference1.DtoProducto[] ListarTodosLosProductos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProducto/ListarTodosLosProductos", ReplyAction="http://tempuri.org/IServicioProducto/ListarTodosLosProductosResponse")]
        System.Threading.Tasks.Task<MVCPortLog.ServiceReference1.DtoProducto[]> ListarTodosLosProductosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioProductoChannel : MVCPortLog.ServiceReference1.IServicioProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioProductoClient : System.ServiceModel.ClientBase<MVCPortLog.ServiceReference1.IServicioProducto>, MVCPortLog.ServiceReference1.IServicioProducto {
        
        public ServicioProductoClient() {
        }
        
        public ServicioProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MVCPortLog.ServiceReference1.DtoProducto ProductoXId(int id) {
            return base.Channel.ProductoXId(id);
        }
        
        public System.Threading.Tasks.Task<MVCPortLog.ServiceReference1.DtoProducto> ProductoXIdAsync(int id) {
            return base.Channel.ProductoXIdAsync(id);
        }
        
        public MVCPortLog.ServiceReference1.DtoProducto[] ListarTodosLosProductos() {
            return base.Channel.ListarTodosLosProductos();
        }
        
        public System.Threading.Tasks.Task<MVCPortLog.ServiceReference1.DtoProducto[]> ListarTodosLosProductosAsync() {
            return base.Channel.ListarTodosLosProductosAsync();
        }
    }
}