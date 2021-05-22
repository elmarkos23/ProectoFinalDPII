using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class DtoPersonalizado
  {
    public List<Modelos.Dto.DtoRegistro> Select(string identificacion, string fecha)
    {
      List<Modelos.Dto.DtoRegistro> dato = new List<Modelos.Dto.DtoRegistro>();
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        string sql = @" SELECT A.id AS idAsistencia,AD.id as idAsistenciaDetalle,A.idUsuario,A.fecha,Ad.tipo,AD.hora
                        FROM Asistencia AS A
                        INNER JOIN AsistenciaDetalle AS AD ON AD.idAsistencia = A.id
                        INNER JOIN Usuario AS U ON U.id = A.idUsuario
                        WHERE CAST(fecha AS DATE)='" + fecha + "' AND U.identificacion = '" + identificacion + "'";
        dato = (List<Modelos.Dto.DtoRegistro>)db.Query<Modelos.Dto.DtoRegistro>(sql);
      }
      return dato;
    }
    public List<Modelos.Dto.DtoReporte> SelectReporte()
    {
      List<Modelos.Dto.DtoReporte> dato = new List<Modelos.Dto.DtoReporte>();
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        string sql = @" SELECT U.identificacion,
U.nombres+' '+U.apellidos AS nombres,
A.fecha,CASE AD.tipo WHEN 'I' THEN 'ENTRADA' ELSE 'SALIDA' END AS tipo,
cast(AD.hora as varchar(8)) as hora,
AD.ubicacionReferencial,d.nombre as departamento,AD.foto,ad.ubicacion as latlng
                        FROM Asistencia AS A
                        INNER JOIN AsistenciaDetalle AS AD ON A.id=AD.idAsistencia
                        INNER JOIN Usuario AS U ON U.id=A.idUsuario
                        INNER JOIN Departamento AS D on d.id=u.idDepartamento
                        ORDER BY A.fecha,ad.tipo";
        dato = (List<Modelos.Dto.DtoReporte>)db.Query<Modelos.Dto.DtoReporte>(sql);
      }
      return dato;
    }
  }
}
