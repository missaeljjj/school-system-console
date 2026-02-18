using Extras;
using Gestion_Escuela_Primaria.Menus;
using Npgsql;
using BaseDeDatos;
using Spectre.Console;
using Menus;
namespace Datos;

    internal class Agregar
    {

        internal async Task AgregarEstdiante()
        {
            //instacias...
            Utiles utiles = new Utiles();
            Elecciones selecciones = new Elecciones();
            Validacion validacion = new Validacion();
            Menu Menu = new Menu();
            string[] opc = new string[] { "Si", "No" };

            //se seleccionan los grados y secciones del estudiante que se agregara 
            string grado = selecciones.Grado();
            char seccion = selecciones.Seccion();

            //se pone un await para que el programa no se quede en pausa en negro mientras se conecta a la base de datos
            await utiles.Cargando("Cargando Datos...");

            //se obtienen el codigo de grado segund seccion y grado mediante un metodo 
            int codigogrado = utiles.ObtenerCodigoGrado(grado, seccion);
            string nombre = validacion.Validaciones<string>("Ingrese el nombre completo del estudiante: ", "Nombre Completo: ");
            DateTime fechanacimietno = validacion.PedirFechaNacimiento();

            AnsiConsole.MarkupLine("Desea ingresar los siguientes datos: ");
            AnsiConsole.MarkupLineInterpolated($"ESTUDIANTE: [blue] {nombre} [/]\n");
            AnsiConsole.MarkupInterpolated($"GRADO: [blue] {grado} [/]SECCION: [blue] {seccion} [/]\n");

            int opcs = Menu.MenuSeleccion(opc, "¿Desea ingresar los datos?", "");
            if (opcs == 2)
            {
                AnsiConsole.MarkupLine("Operacion cancelada.");
                utiles.Continuar();
                return;
            }

            Console.Clear();
            //Aqui entramos al sql para realizar los comandos pertin[entes en este caso agregar al estudiante
            using (var conexion = DbConnection.ConexionBaseDatos())
            {
                const string sql = "INSERT INTO students (nombre_completo,fecha_nacimiento,codigo_gradoperteneciente) VALUES (@nombre_completo,@fecha_nacimiento,@codigo_gradoperteneciente)";

                using (var comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre_completo", nombre);
                    comando.Parameters.AddWithValue("@fecha_nacimiento", fechanacimietno);
                    comando.Parameters.AddWithValue("@codigo_gradoperteneciente", codigogrado);
                    comando.ExecuteNonQuery();

                }
                ;
            }
            AnsiConsole.MarkupLine("Estudiante agregado [green]exitosamente[/].");
            utiles.Continuar();

        }

        internal async Task AgregarMaestro()
        {
            //instacias...
            Utiles utiles = new Utiles();
            Elecciones selecciones = new Elecciones();
            Validacion validacion = new Validacion();
            Menu Menu = new Menu();
            string[] opc = new string[] { "Si", "No" };

            //se seleccionan los grados y secciones del estudiante que se agregara 
            string grado = selecciones.Grado();
            char seccion = selecciones.Seccion();

            //se pone un await para que el programa no se quede en pausa en negro mientras se conecta a la base de datos
            await utiles.Cargando("Cargando Datos...");

            //se obtienen el codigo de grado segund seccion y grado mediante un metodo 
            int codigogrado = utiles.ObtenerCodigoGrado(grado, seccion);
            string nombre = validacion.Validaciones<string>("Ingrese el nombre completo del docente: ", "Nombre Completo: ");
        

            AnsiConsole.MarkupLine("Desea ingresar los siguientes datos: ");
            AnsiConsole.MarkupLineInterpolated($"MAESTRO: [blue] {nombre} [/]\n");
            AnsiConsole.MarkupInterpolated($"GRADO: [blue] {grado} [/]SECCION: [blue] {seccion} [/]\n");

            int opcs = Menu.MenuSeleccion(opc, "¿Desea ingresar los datos?", "");
            if (opcs == 2)
            {
                AnsiConsole.MarkupLine("Operacion cancelada.");
                utiles.Continuar();
                return;
            }

            Console.Clear();
            //Aqui entramos al sql para realizar los comandos pertin[entes en este caso agregar al estudiante
            using (var conexion = DbConnection.ConexionBaseDatos())
            {
                const string sql = "INSERT INTO maestros (nombre,codigo_gradoasignado) VALUES (@nombre_completo,@codigo_gradoasignado)";

                using (var comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre_completo", nombre);
                    comando.Parameters.AddWithValue("@codigo_gradoasignado", codigogrado);
                    comando.ExecuteNonQuery();

                }
                ;
            }
            AnsiConsole.MarkupLine("Maestro agregado [green]exitosamente[/].");
            utiles.Continuar();
        

        }

    }


