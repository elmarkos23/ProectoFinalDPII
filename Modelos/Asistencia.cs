using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
  public class Asistencia
  {
    public int id { get; set; }
    public int idUsuario { get; set; }
    public string fecha { get; set; }
    public bool estado { get; set; }
  }
}
