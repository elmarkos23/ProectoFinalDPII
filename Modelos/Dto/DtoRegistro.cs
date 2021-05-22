using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
  public class DtoRegistro 
  {
    public int idAsistencia { get; set; }
    public int idAsistenciaDetalle { get; set; }
    public int idUsuario { get; set; }
    public DateTime fecha { get; set; }
    public string tipo { get; set; }
    public TimeSpan hora { get; set; }
    
  }
}
