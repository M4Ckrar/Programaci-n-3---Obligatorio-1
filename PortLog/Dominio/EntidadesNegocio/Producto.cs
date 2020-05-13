using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double PesoUnidad { get; set; }
        public long RUTCliente { get; set; }

        public bool ValidarProducto()
        {
            string auxNombre = Nombre.Trim();
            if (auxNombre.Length > 0 && auxNombre.Length <= 50 && PesoUnidad > 0)
                return true;
            else
                return false;
        }
    }
}
