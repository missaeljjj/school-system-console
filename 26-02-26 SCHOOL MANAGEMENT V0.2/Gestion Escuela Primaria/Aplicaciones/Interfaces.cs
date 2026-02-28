using Npgsql;

namespace Interfaz;
//CONTRATOS
public interface IEstudianteRepositorio
{
    //De Agregar
    Task<bool> Agregar(string Nombre, DateTime FechaNacimiento, int codigoGrado);
    //De Mostrar
    Task MostrarTodos();
    Task MostrarPorGrado(int CodigoGrado);
    //De Busquedas
    Task BuscarPorNombre(string Nombre);
    Task BuscarPorID(int Id);

}
//CONTRATO
public interface IOperacionesSql
{
    Task<int> ObtenerCodigoGrado(string Grado, char seccion);

    Task MostrarTabla(NpgsqlDataReader reader, string[] parametros);

}

