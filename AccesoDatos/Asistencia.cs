using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class Asistencia
  {
    public bool ObtenerUsuario(string fecha,string tipo)
    {
      bool estado = false;
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        try
        {
          string sql = @"SELECT [id],[idDepartamento],[tipoIdentificacion],[identificacion],[nombres],[apellidos],[genero],[estado]
                      FROM [dbo].[Usuario]
                      WHERE identificacion='" + fecha + "'";
          estado = db.QuerySingle<bool>(sql);
        }
        catch (Exception ex)
        {

          throw;
        }

      }
      return estado;
    }
    public int Insert(Modelos.Asistencia dato)
    {
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        string sql = " INSERT INTO [dbo].[Asistencia] ([idUsuario],[fecha],[estado]) VALUES (@idUsuario,@fecha,@estado);" +
              " SELECT @@IDENTITY";
        var result = db.ExecuteScalar(sql, new
        {
          idUsuario = dato.idUsuario,
          fecha=dato.fecha,
          estado = dato.estado
        });
        return dato.id = Convert.ToInt32(result);
      }
    }
  }
}
