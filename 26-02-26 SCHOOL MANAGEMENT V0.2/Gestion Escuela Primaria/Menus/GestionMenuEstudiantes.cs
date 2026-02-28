//Namespace para que los menus esten presente en este espacio
namespace Menus;

internal class GestionMenuEstudiantes
{
    private readonly Utiles  _utiles;
    private readonly Menu _menu;
    private readonly Agregar _agregar;
    private readonly Mostrar _mostrar;
    private readonly Buscar _busqueda;   

    internal GestionMenuEstudiantes(Utiles utiles, Menu menu, Agregar agregar, Mostrar mostrar, Buscar busqueda)
    {
        _utiles = utiles;
        _menu = menu;
        _agregar = agregar;
        _mostrar = mostrar;
        _busqueda = busqueda;
    }
    internal async Task Gestion()
    {
        //***************************************************************
        //           Menu para la gestion de estudiantes
        //***************************************************************
        
        int opcionMenu = 0;
        string[] opcionesGestionEstudiantes =
        {
            "1. Agregar Estudiante",
            "2. Modificar Estudiante",
            "3. Eliminar Estudiante",
            "4. Ver Estudiantes",
            "5. Buscar Estudiante",
            "6. Regresar al Menú administrador"
        };

       
        Console.Clear();
        await _utiles.Cargando("Iniciando sistema de gestion de estudiantes..."); 
        while (true)
        {
            opcionMenu = _menu.MenuSeleccion(opcionesGestionEstudiantes, "Seleccione una operacion para la gestion", "GESTION MAESTROS");

            switch (opcionMenu)
            {
                case 1:
                    // Lógica para agregar estudiante
                    await _agregar.AgregarEstudiante();
                    break;
                case 2:
                    // Lógica para modificar estudiante
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad de modificar estudiante en desarrollo...[/]");
                    break;
                case 3:
                    // Lógica para eliminar estudiante
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad de eliminar estudiante en desarrollo...[/]");
                    break;
                case 4:
                    //Mostrar estudiantes por grado
                    await _mostrar.ObtenerEstudiantesPorGrado();
                    break;
                case 5:
                    //Buscar estudiante por nombre o ID
                    await _busqueda.SeleccionBusqueda();
                    break;
                case 6:
                    return;
                default:
                    // Manejo de opción no válida
                    break;
            } 
        }
    }
}