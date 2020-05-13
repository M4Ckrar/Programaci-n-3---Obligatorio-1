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
    public class LoginController : Controller
    {
        private RepositorioUsuarios repo = new RepositorioUsuarios();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Almacen()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["usuarioLogueado"] = null;
            return View("Index");
        }

        public ActionResult PerformLogin(string cedula, string password)
        {
            Usuario usuarioEnLogin = repo.FindById(cedula);
            if(usuarioEnLogin != null && usuarioEnLogin.Password == password)
            {
                Session["usuarioLogueado"] = usuarioEnLogin;
                if (usuarioEnLogin.Rol)
                {
                    return RedirectToAction("Admin", "Login");
                }
                else
                {
                    return RedirectToAction("Almacen", "Login");
                }
            }
            else
            {
                ViewBag.ErrMsg = "Este usuario no existe o la contraseña es incorrecta";
                return View("Index");
            }
        }
    }
}