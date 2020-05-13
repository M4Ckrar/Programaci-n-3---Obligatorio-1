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
    public class RepositorioProducto : IRepositorio<Producto>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;


        //public IEnumerable<Producto> TraerTodosLosProductos()
        //{
        //    try
        //    {
        //        Producto product = null;
        //        List<Producto> listaProductos = new List<Producto>();
        //        SqlConnection cn = new SqlConnection(cadenaConexion);
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = "SELECT * FROM Producto";
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                product = new Producto
        //                {
        //                    Nombre = (string)dr["Nombre"],
        //                    RUTCliente = (long)dr["RutCliente"],
        //                };
        //                listaProductos.Add(product);
        //            }
        //        }
        //        cn.Close();
        //        return listaProductos;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        public bool Add(Producto unObjeto)
        {
            if (unObjeto == null || !unObjeto.ValidarProducto()) return false;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Producto VALUES (@Nombre,@PesoUnidad,@RutCliente)";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@Nombre", unObjeto.Nombre));
                cmd.Parameters.AddWithValue("@PesoUnidad", unObjeto.PesoUnidad);
                cmd.Parameters.AddWithValue("@RutCliente", unObjeto.RUTCliente);
                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                cn.Close();
                return (filas == 1);

            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Producto> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Producto";
                cmd.Connection = cn;

                cn.Open();

                SqlDataReader readerProducto = cmd.ExecuteReader();

                if (readerProducto.HasRows)
                {
                    List<Producto> losProductos = new List<Producto>();
                    while (readerProducto.Read())
                    {
                        losProductos.Add(new Producto
                        {
                            Nombre = readerProducto["Nombre"].ToString(),
                            PesoUnidad = (float)readerProducto["PesoUnidad"],
                            RUTCliente = (long)readerProducto["RutCliente"]
                        });
                    }
                    cn.Close();
                    return losProductos;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Producto FindById(object Id)
        {
            int idBuscado = (int)Id;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Producto WHERE ID=@ID";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@ID", idBuscado));

                cn.Open();

                SqlDataReader readerProducto = cmd.ExecuteReader();

                Producto unProducto = null;
                if (readerProducto.HasRows)
                {
                    if (readerProducto.Read())
                    {
                        unProducto = new Producto
                        {
                            Nombre = readerProducto["Nombre"].ToString(),
                            PesoUnidad = (float)readerProducto["PesoUnidad"],
                            RUTCliente = (long)readerProducto["RutCliente"]
                        };
                    }

                    cn.Close();

                }
                return unProducto;
            }

            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Remove(object Id)
        {
            int idBuscado = (int)Id;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE Producto WHERE ID=@ID";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@ID", idBuscado));

                cn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                cn.Close();
                return filasAfectadas == 1;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Update(Producto unObjeto)
        {
            if (unObjeto == null || !unObjeto.ValidarProducto()) return false;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Producto SET Nombre=@Nombre, PesoUnidad=@PesoUnidad, RutCliente=@RutCliente WHERE Id=@ID";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Nombre", unObjeto.Nombre);
                cmd.Parameters.AddWithValue("@PesoUnidad", unObjeto.PesoUnidad);
                cmd.Parameters.AddWithValue("@RutCliente", unObjeto.RUTCliente);
                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                cn.Close();
                return (filas == 1);

            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
