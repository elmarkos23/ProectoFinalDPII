using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioWeb.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Title = "Home Page";

      return View();
    }
    [HttpGet]
    public Modelos.Usuario ObtenerUsuario(string identificacion)
    {
      return new AccesoDatos.Usuario().ObtenerUsuario(identificacion);
    }
  }
}
