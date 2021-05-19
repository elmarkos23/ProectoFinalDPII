SELECT U.id,U.nombres+' '+U.apellidos AS nombres
FROM Asistencia AS A
INNER JOIN AsistenciaDetalle AS AD ON A.id=AD.idAsistencia
INNER JOIN Usuario AS U ON U.id=A.idUsuario