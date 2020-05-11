using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Cliente
    {
        public long RUT { get; set; }
        public DateTime FechaIngreso { get; set; }

        public bool ValidarCliente()
        {
            DateTime hoy = DateTime.Today;
            if (RUT >= 200000000000 && RUT <= 299999999999 && FechaIngreso <= hoy)
                return true;
            else
                return false;
        }    
    }
}
