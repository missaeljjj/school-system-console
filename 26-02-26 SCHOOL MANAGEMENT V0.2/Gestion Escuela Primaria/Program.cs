public class Principal
{
    internal static async Task Main(string[] args)
    {
        //Ayudas
        var dbconexion = new DbConnection();
        var menu = new Menu();
        var utiles = new Utiles(menu);
        var validacion = new Validacion(utiles);

        //reposiotrio de operacion
        IOperacionesSql repositorio_operaciones = new RepositorioOperaciones(dbconexion);
        IEstudianteRepositorio repositoriosestudiante = new Repositorios(dbconexion, repositorio_operaciones);
        //Entidades
        Estudiante estudiante = new Estudiante();
        Maestros maestros = new Maestros();
        Usuario usuario = new Usuario();



        // servicios base
        var agregar = new Agregar(repositorio_operaciones, repositoriosestudiante, utiles, validacion, menu, estudiante);
        var mostrar = new Mostrar(repositoriosestudiante, repositorio_operaciones, utiles,estudiante);
        var busqueda = new Buscar(repositoriosestudiante, menu, utiles, validacion, mostrar,estudiante);
        var consultas = new Consultas(busqueda, mostrar, menu);

        // menus
        var menugestiomaestroscs = new MenuGestionMaestroscs(utiles, menu, agregar);
        var menugestionestudiantes = new GestionMenuEstudiantes(utiles, menu, agregar, mostrar, busqueda);

        // elecciones (depende de menus)
        var elecciones = new Elecciones(menu, utiles, menugestiomaestroscs, menugestionestudiantes, consultas);

        // menu principal
        int opcion = 0;
        string[] OpcionesPrincipales = { "1. Gestionar", "2. Consultar", "3. Salir" };

        while (opcion != 3)
        {
            opcion = menu.MenuSeleccion(OpcionesPrincipales, "Seleccione una opción", "SISTEMA ESCOLAR");

            switch (opcion)
            {
                case 1:
                    await elecciones.ElegirAdmin();
                    break;

                case 2:
                    await elecciones.ElegirConsulta();
                    break;

                case 3:
                    await utiles.Cargando("Saliendo del sistema...");
                    break;

                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida.[/]");
                    utiles.Reintentar();
                    break;
            }
        }

        Console.Clear();
        AnsiConsole.MarkupLine("[green]Gracias por usar el sistema escolar[/]");
    }
}