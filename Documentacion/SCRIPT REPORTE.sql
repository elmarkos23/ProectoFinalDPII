SELECT U.id,U.nombres+' '+U.apellidos AS nombres,A.fecha,CASE AD.tipo WHEN 'I' THEN 'ENTRADA' ELSE 'SALIDA' END AS tipo,AD.hora,AD.ubicacionReferencial,d.nombre as departamento
FROM Asistencia AS A
INNER JOIN AsistenciaDetalle AS AD ON A.id=AD.idAsistencia
INNER JOIN Usuario AS U ON U.id=A.idUsuario
INNER JOIN Departamento AS D on d.id=u.idDepartamento
ORDER BY A.fecha,ad.tipo


