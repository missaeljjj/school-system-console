
namespace Extras
{
    internal class Utiles
    {
        private readonly Menu _menu;

        internal Utiles(Menu menu) 
        {
            _menu = menu;
        }

        public void Continuar()
        {
            AnsiConsole.MarkupLine("Presione cualquier [blue]tecla[/] para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public void Reintentar()
        {

            AnsiConsole.MarkupLine("Presione cualquier [blue] tecla[/] para reintentar ");
            Console.ReadKey();
            Console.Clear();

        }

        public async Task Cargando(string mensaje, Func<Task> tarea)
        {
            await AnsiConsole.Status()
                .StartAsync(mensaje, async ctx =>
                {
                    await tarea(); // Espera a que la DB responda
                });
        }

        // VERSIÓN B: Para pausas visuales (Mensajes de error/salida)
        // Solo recibe el mensaje y espera un tiempo fijo (por defecto 2 seg)
        public async Task Cargando(string mensaje, int milisegundos = 2000)
        {
            await AnsiConsole.Status()
                .StartAsync(mensaje, async ctx =>
                {
                    await Task.Delay(milisegundos); // Simula carga para que el usuario lea
                });
        }


        internal bool Decision(string mensaje)
        {
            string[] opciones = { "1. Si ", "2 .No" };
            int opcion = _menu.MenuSeleccion(opciones, mensaje,"");

            if(opcion == 1)
                return true;

            return false;
        }


        internal bool ContadorIntentos(string usuarioCorrecto, string Contraseña)
        {

            Usuario usuario = new Usuario();

            if (!string.Equals(usuarioCorrecto, usuario.user) || !string.Equals(Contraseña, usuario.password))
            {
                AnsiConsole.MarkupLine("[red]Usuario o contraseña incorrecta[/]");
                Reintentar();
                return true;

            }
            return false;
        }
        internal async Task<bool>  LOGIN()
        {
            string UsuarioIngresado = "";
            string ContraseñaIngresada = "";
            int contador = 0;

            while (true)
            {

                Console.WriteLine("Ingrese el usuario administrador:"); Console.Write("Usuario: ");
                UsuarioIngresado = Console.ReadLine()!.Trim();
                Console.WriteLine("Ingrese la contraseña administrador:"); Console.Write("contraseña: ");
                ContraseñaIngresada = Console.ReadLine()!.Trim();

                if (!ContadorIntentos(UsuarioIngresado, ContraseñaIngresada))
                    return true;

                contador++;

                if (contador == 3)
                {
                    AnsiConsole.MarkupLine("[red]Ha superado el numero de intentos permitidos. Saliendo del sistema...[/]");
                    await Cargando("Saliendo del sistema...");
                    return false;
                }
            }
        }

        internal string Grado()
        {
            Console.Clear();

            string[] grados = new string[] { "Primer grado", "Segundo grado", "Tercer grado", "Cuarto grado", "Quinto grado", "Sexto grado" };
            int opcion = _menu.MenuSeleccion(grados, "Seleccione el grado del estudiante:", "Sistema escolar");

            Console.Clear();
            switch (opcion)
            {
                case 1: return grados[0];   case 2: return grados[1];
                case 3: return grados[2];   case 4: return grados[3];
                case 5: return grados[4];   case 6: return grados[5];
                            default:
                                return "Grado no seleccionado";
            }

        }
        internal char Seccion()
        {
            Console.Clear();

            string[] opciones = { "Seccion A", "Seccion B" };

            int opcion = _menu.MenuSeleccion(opciones, "Seleccione la sección del grado:", "SISTEMA ESCOLA");
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                default:
                    return ' ';
            }

        }

    }
}