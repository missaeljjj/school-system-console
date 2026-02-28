using Npgsql;
namespace Repositorio;

internal class Repositorios : IEstudianteRepositorio
{
    private readonly DbConnection _ConexionDb;
    private readonly IOperacionesSql _repositoriooperaciones_sql;
    public Repositorios(DbConnection ConexionDb,IOperacionesSql repositoriooperaciones_sql)
    {
        _ConexionDb = ConexionDb;
       _repositoriooperaciones_sql = repositoriooperaciones_sql;
    }

    private string[] ParametroEstudiantes =
       {
         "Id",
         "Estudiante",
         "Grado",
         "Seccion"
        };

    public async Task<bool> Agregar(string nombre, DateTime fechaNacimiento, int codigoGrado)
    {
        try
        {
            using var conexion = await _ConexionDb.ConexionBaseDatos();

            using var comando = new NpgsqlCommand(ComandoSql.SqlAgregarEstudiante,  conexion);

            comando.Parameters.AddWithValue("@nombre_completo", nombre);
            comando.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
            comando.Parameters.AddWithValue("@codigo_gradoperteneciente", codigoGrado);

            int filas = await comando.ExecuteNonQueryAsync();
            return filas > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar estudiante en la base de datos", ex);
        }
    }

    public async Task MostrarTodos()
    {

        using var conexion = await _ConexionDb.ConexionBaseDatos();
        {
            using var comando = new NpgsqlCommand(ComandoSql.SqlObtenerEstudiantes, conexion);
            using var reader = await comando.ExecuteReaderAsync();
            await _repositoriooperaciones_sql.MostrarTabla(reader, ParametroEstudiantes);
        }
    }

    public async Task MostrarPorGrado(int CodigoGrado)
    {

        using var Conexion = await _ConexionDb.ConexionBaseDatos();
        using var comando = new NpgsqlCommand(ComandoSql.ObtenerEstudiantesPorGradoYSeccion, Conexion);
        comando.Parameters.AddWithValue("@codigo", CodigoGrado);
        using var reader = await comando.ExecuteReaderAsync();
        await _repositoriooperaciones_sql.MostrarTabla(reader, ParametroEstudiantes);

    }
    public async Task BuscarPorNombre(string Nombre)
    {
        using var Conexion = await _ConexionDb.ConexionBaseDatos();
        using var Comando = new NpgsqlCommand(ComandoSql.SqlBuscarEstudiantePorNombre, Conexion);
        Comando.Parameters.AddWithValue("@nombre_completo","%"+ Nombre + "%");
        using var reader = await Comando.ExecuteReaderAsync();
        await _repositoriooperaciones_sql.MostrarTabla(reader,ParametroEstudiantes);
    }
    public async Task BuscarPorID(int Id)
    {
        using var Conexion = await _ConexionDb.ConexionBaseDatos();
        using var Comando = new NpgsqlCommand(ComandoSql.SqlBuscarEstudiantePorId, Conexion);
        Comando.Parameters.AddWithValue("@id_estudiante", Id);
        using var reader = await Comando.ExecuteReaderAsync();
        await _repositoriooperaciones_sql.MostrarTabla(reader, ParametroEstudiantes);
    }
    


}
