using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
  public class DtoRegistro : Asistencia
  {
    public AsistenciaDetalle detalle { get; set; }
  }
}
