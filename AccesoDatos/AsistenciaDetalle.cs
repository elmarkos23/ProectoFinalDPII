using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class AsistenciaDetalle
  {
    public int Insert(Modelos.AsistenciaDetalle dato)
    {
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        string sql = " INSERT INTO [dbo].[AsistenciaDetalle] ([idAsistencia],[tipo],[hora],[ubicacion],[ubicacionReferencial],[foto],[estado]) VALUES (@idAsistencia,@tipo,@hora,@ubicacion,@ubicacionReferencial,@foto,@estado);" +
              " SELECT @@IDENTITY";
        var result = db.ExecuteScalar(sql, new
        {
          idAsistencia = dato.idAsistencia,
          tipo = dato.tipo,
          hora = dato.hora,
          ubicacion = dato.ubicacion,
          ubicacionReferencial = dato.ubicacionReferencial,
          foto = dato.foto,
          estado = dato.estado
        });
        return dato.id = Convert.ToInt32(result);
      }
    }
  }
}
