using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
  public class AsistenciaDetalle
  {
    public int id { get; set; }
    public int idAsistencia { get; set; }
    public string tipo { get; set; }
    public string hora { get; set; }
    public string ubicacion { get; set; }
    public string ubicacionReferencial { get; set; }
    public byte[] foto { get; set; }
    public bool estado { get; set; }
  }
}
