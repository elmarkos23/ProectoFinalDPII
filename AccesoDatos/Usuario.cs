using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
  public class Usuario
  {
    
    public List<Modelos.Dto.DtoUsuarios> ObtenerUsuarios()
    {
      List<Modelos.Dto.DtoUsuarios> lista = new List<Modelos.Dto.DtoUsuarios>();
      using (var db = new SqlConnection(Conexion.GetConexion()))
      {
        try
        {
          string sql = @"select u.id,
                        u.identificacion,
                        nombres + ' ' + apellidos as nombres,
                        case genero when 'M' then 'MUJER' else 'HOMBRE' end as genero,
                        d.nombre as departamento,
                        case estado when 1 then 'ACTIVO' else 'NO ACTIVO'end as estado
                        from Usuario as u
                        inner join Departamento as d on d.id = u.idDepartamento";
          lista = (List<Modelos.Dto.DtoUsuarios>)db.Query<Modelos.Dto.DtoUsuarios>(sql);
        }
        catch (Exception ex)
        {

          throw;
        }

      }
      return lista;
    }
  }
}
