using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.Controllers
{
    public class UsuarioController : ApiController
    {
    [HttpGet]
    public Modelos.Usuario ObtenerUsuario(string identificacion)
    {
      return new AccesoDatos.Usuario().ObtenerUsuario(identificacion);
    }
  }
}
