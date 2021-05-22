using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.Controllers
{
  [RoutePrefix("api/usuario")]
  public class UsuarioController : ApiController
    {
    [Route("ObtenerUsuario")]
    [HttpGet]
    public Modelos.Usuario ObtenerUsuario(string identificacion)
    {
      return new AccesoDatos.Usuario().ObtenerUsuario(identificacion);
    }
  }
}
