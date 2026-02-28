using Npgsql;

namespace BaseDeDatos;

//*************************************************************************
//Clase estatica para manejar la conexion a la base de datos PostgreSQL
//Muy importante mantener la seguridad de la cadena de conexion
//aqui se establece la conexion a la base de datos
//con el host, puerto, usuario, contrasena y base de datos
//la base de datos solo es accesible directamente a traves de PgAdmin
//*************************************************************************

internal class DbConnection
{
    private const string ConnectionString =
    "Host=Your_host;" +
    "Port=5432;" +
    "Database=YourDataBase;" +
    "Username=YourUsername;" +
    "Password=YOURPASSWORD;";


    //*************************************************************************
    //Metodo para obtener una conexion abierta a la base de datos
    //Retorna un objeto NpgsqlConnection
    //*************************************************************************
        internal async Task<NpgsqlConnection> ConexionBaseDatos()
        {
            var conexion = new NpgsqlConnection(ConnectionString);
            await conexion.OpenAsync();
            return conexion;

        }
    }


