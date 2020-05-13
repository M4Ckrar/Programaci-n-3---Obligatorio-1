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
    class RepositorioUsuarios : IRepositorio<Usuario>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

        public bool Add(Usuario unObjeto)
        {
            if (unObjeto == null || !unObjeto.ValidarUsuario())
                return false;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Usuario VALUES (@Cedula,@Passwrd,@Rol)";
                cmd.Connection = cn;                                
                cmd.Parameters.AddWithValue("@Cedula", unObjeto.Cedula);
                cmd.Parameters.AddWithValue("@Passwrd", unObjeto.Password);
                cmd.Parameters.AddWithValue("@Rol", unObjeto.Rol);                              
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

        public IEnumerable<Usuario> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario";
                cmd.Connection = cn;
                
                cn.Open();                
                SqlDataReader readerUsuarios = cmd.ExecuteReader();
                if (readerUsuarios.HasRows)
                {
                    List<Usuario> allUsers = new List<Usuario>();
                    while (readerUsuarios.Read())
                    {
                        allUsers.Add(new Usuario
                        {
                            Cedula = readerUsuarios["Cedula"].ToString(),
                            Password = readerUsuarios["Passwrd"].ToString(),                            
                            Rol = (Boolean)readerUsuarios["Rol"],                            
                        });
                    }                    
                    cn.Close();
                    return allUsers;
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

        public Usuario FindById(object Id)
        {
            string idBuscado = Id.ToString(); 
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE ID=@ID";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@ID", idBuscado));                
                cn.Open();                
                SqlDataReader readerUsuario = cmd.ExecuteReader();
                Usuario unUsuario = null;
                if (readerUsuario.HasRows)
                {
                    if (readerUsuario.Read())
                    {
                        unUsuario = new Usuario
                        {
                            Cedula = readerUsuario["Cedula"].ToString(),
                            Password = readerUsuario["Passwrd"].ToString(),
                            Rol = (Boolean)readerUsuario["Rol"],
                        };
                    }                    
                    cn.Close();

                }
                return unUsuario;
            }            
            catch (Exception ex)
            {                
                return null;
            }

        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
