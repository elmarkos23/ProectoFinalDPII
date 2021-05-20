using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class Departamento
  {
    public List<Modelos.Departamento> Select()
    {
      List<Modelos.Departamento> dato = new List<Modelos.Departamento>();
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        string sql = @" SELECT [id],[nombre] FROM [dbo].[Departamento]";
        dato = (List<Modelos.Departamento>)db.Query<Modelos.Departamento>(sql);
      }
      return dato;
    }
  }
}
