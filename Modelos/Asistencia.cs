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
    public DateTime registroEntrada { get; set; }
    public DateTime registroSalida { get; set; }
    public string UbicacionEntrada { get; set; }
    public string SalidaEntrada { get; set; }
    public byte[] FotoEntrada { get; set; }
    public byte[] FotoSalida { get; set; }
  }
}
