using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
    public int id { get; set; }
    public string tipoIdentificacion  { get; set; }
    public string identificacion { get; set; }
    public string nombres { get; set; }
    public string apellidos { get; set; }
    public int idDepartamento { get; set; }
    public string genero { get; set; }
    public bool estado { get; set; }
  }
}
