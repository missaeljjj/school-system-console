using BaseDeDatos;
using Datos;
using Npgsql;
using Spectre.Console;

namespace Extras
{
    internal class Utiles
    {
        //*************************************************************************
        //Metodo para pausar la ejecucion del programa hasta que el usuario
        //presione una tecla y limpiar la consola
        //Metodo no estatico se debe poder instanciar la clase Utiles
        //Mas que todo es para mejorar la experiencia del usuario
        //Para continuar despues de mostrar un mensaje
        //*************************************************************************

        public void Continuar()
        {
            AnsiConsole.MarkupLine("Presione cualquier [blue]tecla[/] para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        //*************************************************************************
        //Metodo para pausar la ejecucion del programa hasta que el usuario
        //presione una tecla y limpiar la consola
        //Metodo no estatico se debe poder instanciar la clase Utiles
        //Mas que todo es para mejorar la experiencia del usuario
        //para reintentar una accion
        //*************************************************************************
        public void Reintentar()
        {

            AnsiConsole.MarkupLine("Presione cualquier [blue] tecla[/] para reintentar ");
            Console.ReadKey();
            Console.Clear();

        }


        //*************************************************************************
        //Metodo asincrono para mostrar una barra de carga con un mensaje personalizado
        //Metodo no estatico se debe poder instanciar la clase Utiles
        //*************************************************************************

        internal async Task Cargando(string mensaje)
        {
            await AnsiConsole.Status()
                .Spinner(Spinner.Known.Aesthetic)
                .StartAsync(mensaje, async ctx =>
                {
                    // Simular una tarea que toma tiempo
                    await Task.Delay(2000);
                });
        }

        internal bool ContadorIntentos(string usuarioCorrecto, string Contraseña)
        {
            Usuarios U = new Usuarios();

            if (!string.Equals(usuarioCorrecto, U.NombreGestion) || !string.Equals(Contraseña, U.ContraseñaGestion))
            {
                AnsiConsole.MarkupLine("[red]Usuario o contraseña incorrecta[/]");
                Reintentar();
                return true;

            }
            return false;
        }

        internal int ObtenerCodigoGrado(string grado, char seccion)
        {

            using (var conexion = DbConnection.ConexionBaseDatos())
            {
                const string sql = "SELECT codigo_grado FROM grados WHERE grado = @grado AND seccion = @seccion";

                using var comando = new NpgsqlCommand(sql, conexion);
                {
                    comando.Parameters.AddWithValue("@grado", grado);
                    comando.Parameters.AddWithValue("@seccion", seccion);

                    var resultado = comando.ExecuteScalar();
                    if (resultado != null && int.TryParse(resultado.ToString(), out int codigoGrado))
                    {
                        return codigoGrado;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]No se encontró el código de grado para el grado y sección proporcionados.[/]");
                        return -1; // O cualquier valor que indique que no se encontró el código
                    }
                }

            }
        }

        internal bool LOGIN()
        {
            string UsuarioIngresado = "";
            string ContraseñaIngresada = "";
            int cont = 0;

            while (true)
            {

                Console.WriteLine("Ingrese el usuario administrador:"); Console.Write("Usuario: ");
                UsuarioIngresado = Console.ReadLine()!.Trim();
                Console.WriteLine("Ingrese la contraseña administrador:"); Console.Write("contraseña: ");
                ContraseñaIngresada = Console.ReadLine()!.Trim();

                if (!ContadorIntentos(UsuarioIngresado, ContraseñaIngresada))
                    return true;

                cont++;

                if (cont == 3)
                {
                    AnsiConsole.MarkupLine("[red]Ha superado el numero de intentos permitidos. Saliendo del sistema...[/]");
                    Cargando("Saliendo del sistema...").Wait();
                    return false;
                }


            }
        }

    }

}


