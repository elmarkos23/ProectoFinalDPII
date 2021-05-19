using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
  public class DtoUsuarios
  {
    public int id { get; set; }
    public int identificacion { get; set; }
    public string nombres { get; set; }
    public string genero { get; set; }
    public string departamento { get; set; }
    public string estado { get; set; }

  }
}
