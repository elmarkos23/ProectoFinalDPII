using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class Conexion
  {
    public Conexion()
    {
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-EC")
      {
        DateTimeFormat = { ShortDatePattern = "dd/MM/yyyy" },
        NumberFormat =
                {
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = ",",
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                }
      };

    }
    public static String GetConexion()
    {
      return ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    }
  }
}
