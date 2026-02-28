namespace BaseDeDatos;

internal class ComandoSql
{
    /*
    ===========================================
            COMANDOS DE SQL
            EXCLUSIVAMENTE ESTUDIANTES
    ===========================================
    */

    //POR COMPROBAR
    internal const string SqlAgregarMaestro =
        @"INSERT INTO maestros 
          (nombre_completo, codigo_gradoasignado) 
          VALUES (@nombre_completo, @codigo_gradoasignado);";

    //COMPROBADO
    internal const string SqlAgregarEstudiante =
        @"INSERT INTO students 
          (nombre_completo, fecha_nacimiento, codigo_gradoperteneciente) 
          VALUES (@nombre_completo, @fecha_nacimiento, @codigo_gradoperteneciente);";

    //COMPROBADO
    internal const string SqlObtenerCodigoGrado =
        @"SELECT codigo_grado 
          FROM grados 
          WHERE grado = @grado AND seccion = @seccion;";

    //COMPROBADO
    internal const string SqlObtenerEstudiantes =
        @"SELECT s.id_estudiante_new AS Id,
                 s.nombre_completo AS estudiante,
                 g.seccion,
                 g.grado
          FROM students s
          INNER JOIN grados g
              ON s.codigo_gradoperteneciente = g.codigo_grado
          ORDER BY s.nombre_completo ASC;";

    //COMPROBADO
    internal const string ObtenerEstudiantesPorGradoYSeccion = 
            @"SELECT 
            s.id_estudiante_new AS id,
            s.nombre_completo AS estudiante,
            g.grado,
            g.seccion,
            m.nombre AS maestro
            FROM students s
            INNER JOIN grados g 
            ON s.codigo_gradoperteneciente = g.codigo_grado
            INNER JOIN maestros m
            ON m.codigo_gradoasignado = g.codigo_grado
            WHERE g.codigo_grado = @codigo
            ;";

    //COMPROBADO
    internal const string SqlBuscarEstudiantePorId =
        @"SELECT s.id_estudiante_new AS id,
                 s.nombre_completo AS estudiante,
                 g.seccion,
                 g.grado
          FROM students s
          INNER JOIN grados g
              ON s.codigo_gradoperteneciente = g.codigo_grado
          WHERE s.id_estudiante_new = @id_estudiante;";

    //COMPROBADO
    internal const string SqlBuscarEstudiantePorNombre =
        @"SELECT s.id_estudiante_new AS Id,
                 s.nombre_completo AS Estudiante,
                 g.Seccion,
                 g.Grado
          FROM students s
          INNER JOIN grados g
              ON s.codigo_gradoperteneciente = g.codigo_grado
          WHERE s.nombre_completo ILIKE @nombre_completo;";

    /*
    ===========================================
            COMANDOS DE SQL
            EXCLUSIVAMENTE MAESTROS
    ===========================================
    */

    //POR COMPROBAR
    internal const string SqlObtenerMaestros =
        @"SELECT m.id_maestro_new AS id,
                 m.nombre_completo AS maestro,
                 g.seccion,
                 g.grado
          FROM maestros m
          INNER JOIN grados g
              ON m.codigo_gradoasignado = g.codigo_grado
          ORDER BY m.nombre_completo ASC;";

    //POR COMPROBAR
    internal const string SqlBuscarMaestroPorId =
        @"SELECT m.id_maestro_new AS id,
                 m.nombre_completo AS maestro,
                 g.seccion,
                 g.grado
          FROM maestros m
          INNER JOIN grados g
              ON m.codigo_gradoasignado = g.codigo_grado
          WHERE m.id_maestro_new = @id_maestro;";

    //POR COMPROBAR
    internal const string SqlBuscarMaestroPorNombre =
        @"SELECT m.id_maestro_new AS id,
                 m.nombre_completo AS maestro,
                 g.seccion,
                 g.grado
          FROM maestros m
          INNER JOIN grados g
              ON m.codigo_gradoasignado = g.codigo_grado
          WHERE m.nombre_completo ILIKE @nombre_completo;";

}
