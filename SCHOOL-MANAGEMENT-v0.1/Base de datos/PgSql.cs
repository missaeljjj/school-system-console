using Npgsql;


namespace BaseDeDatos
{
    //*************************************************************************
    //Clase estatica para manejar la conexion a la base de datos PostgreSQL
    //Muy importante mantener la seguridad de la cadena de conexion
    //aqui se establece la conexion a la base de datos
    //con el host, puerto, usuario, contrasena y base de datos
    //la base de datos solo es accesible directamente a traves de PgAdmin
    //*************************************************************************
   
        internal static class DbConnection
        {
        private const string ConnectionString =
        "Host=ep-icy-scene-a8wdfisq.eastus2.azure.neon.tech;" + 
        "Port=5432;" +                                         
        "Database=neondb;" +                                   
        "Username=neondb_owner;" +
        "Password=YOUR_PASSWORD";
           


            //*************************************************************************
            //Metodo para obtener una conexion abierta a la base de datos
            //Retorna un objeto NpgsqlConnection
            //*************************************************************************

            public static NpgsqlConnection ConexionBaseDatos()
            {
                var conexion = new NpgsqlConnection(ConnectionString);
                conexion.Open();
                return conexion;

            }
        }
    }
