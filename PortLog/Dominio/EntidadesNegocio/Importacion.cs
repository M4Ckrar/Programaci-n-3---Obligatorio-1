using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Importacion
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalidaPrevista { get; set; }
        public int CantidadImportada { get; set; }
        public int PrecioUnitarioProducto { get; set; }
        public int IdProductoImportado { get; set; }
        public string CedulaUsuarioDioAlta { get; set; }

        public bool ValidarImportacion()
        {
            DateTime hoy = DateTime.Today;
            if (FechaIngreso <= hoy && FechaSalidaPrevista > hoy && CantidadImportada > 0 && PrecioUnitarioProducto > 0)
                return true;
            else
                return false;
        }
    }
}
