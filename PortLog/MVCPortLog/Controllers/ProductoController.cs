using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPortLog.ServiceReference1;

namespace MVCPortLog.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        

        public ActionResult ListadoProducto()
        {
            //session usuariologeado igual a null
            //return a login
            if (Session["usuarioLogueado"] == null)
            {
                //return RedirectToAction("Login", "")
            }
            ServicioProductoClient popi = new ServicioProductoClient();
            popi.Open();
            IEnumerable<DtoProducto> productosDto = popi.ListarTodosLosProductos();
            Session["usuarioLogueado"] = productosDto;
            popi.Close();
            return View(productosDto);
        }
    }
}