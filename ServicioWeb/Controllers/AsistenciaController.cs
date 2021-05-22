using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.Controllers
{
  [RoutePrefix("api/asistencia")]
  public class AsistenciaController : ApiController
  {
    [Route("Insert")]
    [HttpPost]
    public bool Insert(Modelos.Dto.DtoAsistencia dtoAsistencia)
    {
      try
      {
        if (dtoAsistencia.asistencia.id == 0)
        {
          dtoAsistencia.asistencia.fecha = DateTime.Now.ToString("yyyyMMdd");
          dtoAsistencia.asistenciaDetalle.hora = DateTime.Now.ToString("HH:mm:ss");
          int id = new AccesoDatos.Asistencia().Insert(dtoAsistencia.asistencia);
          if (id > 0)
          {
            dtoAsistencia.asistenciaDetalle.idAsistencia = id;
            new AccesoDatos.AsistenciaDetalle().Insert(dtoAsistencia.asistenciaDetalle);
          }
        }
        else
        {
          dtoAsistencia.asistenciaDetalle.hora = DateTime.Now.ToString("HH:mm:ss");
          new AccesoDatos.AsistenciaDetalle().Insert(dtoAsistencia.asistenciaDetalle);
        }
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }

    }
    [Route("ObtenerAsistencia")]
    [HttpGet]
    public List<Modelos.Dto.DtoRegistro> ObtenerAsistencia(string identificacion)
    {
      //definicion de la fecha del servidor
      string fecha = DateTime.Now.ToString("yyyyMMdd");
      return new AccesoDatos.DtoPersonalizado().Select(identificacion, fecha);
    }
  }
}
