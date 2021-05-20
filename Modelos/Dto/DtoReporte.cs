using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
  public class DtoReporte
  {
    public string identificacion { get; set; }
    public string usuario { get; set; }
    public string fecha { get; set; }
    public string hora { get; set; }
    public string tipo { get; set; }
    public string ubicacionReferencial { get; set; }
    public string departamento { get; set; }
  }
}
