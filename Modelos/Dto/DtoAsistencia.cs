using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
  public class DtoAsistencia
  {
    public Asistencia asistencia { get; set; }
    public AsistenciaDetalle asistenciaDetalle { get; set; }
    public DtoAsistencia()
    {
      asistencia = new Asistencia();
      asistenciaDetalle = new AsistenciaDetalle();
    }
  }
}
