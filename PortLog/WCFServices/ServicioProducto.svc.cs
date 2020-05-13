using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Repositorios;

namespace WCFServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioProducto : IServicioProducto
    {
        public IEnumerable<DtoProducto> ListarTodosLosProductos()
        {
            try
            {
                RepositorioProducto repoProductos = new RepositorioProducto();
                List<DtoProducto> listaDtoProductos = new List<DtoProducto>();
                DtoProducto dtoProdAux = null;
                foreach (Producto p in repoProductos.FindAll())
                {
                    dtoProdAux = new DtoProducto
                    {
                        Nombre = p.Nombre,
                        Rut = p.RUTCliente,
                    };
                    listaDtoProductos.Add(dtoProdAux);
                }
                return listaDtoProductos;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public DtoProducto ProductoXId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 
*/
