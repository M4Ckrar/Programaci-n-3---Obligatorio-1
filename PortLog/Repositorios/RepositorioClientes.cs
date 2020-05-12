using Dominio.EntidadesNegocio;
using Dominio.InterfazRepositorios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    class RepositorioClientes
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
    }
}
