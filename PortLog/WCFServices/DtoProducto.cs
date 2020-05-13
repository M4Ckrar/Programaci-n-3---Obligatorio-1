using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServices
{
    [DataContract]
    public class DtoProducto
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Id { get; set; }

        public long Rut{ get; set; }

        public int PesoUnidad { get; set; }
    }
}