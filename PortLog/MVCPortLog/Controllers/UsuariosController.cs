using Dominio.EntidadesNegocio;
using Dominio.InterfazRepositorios;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPortLog.Controllers
{
    public class UsuariosController : Controller
    {
        private RepositorioUsuarios repo = new RepositorioUsuarios();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro(string cedula, string password, string repeatPassword, int rol)
        {
            if(password == repeatPassword)
            {
                bool auxRol;
                if (rol == 0)
                    auxRol = false;
                else
                    auxRol = true;
                Usuario usuarioPorRegistrar = new Usuario { Cedula = cedula, Password = password, Rol = auxRol };
                if (usuarioPorRegistrar.ValidarUsuario())
                {
                    if (repo.FindById(usuarioPorRegistrar.Cedula) == null)
                    {
                        repo.Add(usuarioPorRegistrar);
                        ViewBag.ErrMsg = "El usuario fue registrado sin problemas";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.ErrMsg = "El usuario que intenta registrar ya existe";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.ErrMsg = "La contraseña no es lo suficientemente segura (mínimo de 6 caracteres, tiene que tener al menos una mayúscula, una minúscula y un número) o la cedula ingresada no cumple con el formato (4556707-2)";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.ErrMsg = "Las contraseñas no coinciden";
                return View("Index");
            }
        }
    }
}