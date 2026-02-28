
namespace Menus;

internal class MenuGestionMaestroscs
{
    private Utiles _utiles;
    private readonly Menu _menu;
    private readonly Agregar _agregar;

    internal MenuGestionMaestroscs(Utiles utiles, Menu menu, Agregar agregar)
    {
        _utiles = utiles;
        _menu = menu;
        _agregar = agregar;
    }

    internal async Task Gestion()
    {
        
        Console.Clear();
        string[] opciones = {"1. Agregar Maestro","2. Eliminar Maestro","3. Modificar Maestro","4. Mostrar Maestros","5. Regresar al menu administrador"};

        await _utiles.Cargando("Cargando Gestión de Maestros...");

        while (true)
        {
            int opcion = _menu.MenuSeleccion(opciones, "Seleccione una opción para gestionar los maestros:", "GESTION MAESTROS");

            switch (opcion)
            {
                case 1:

                    await _agregar.AgregarMaestro();
                    // Lógica para agregar maestro
                    break;
                case 2:
                    AnsiConsole.MarkupLine("[red]Funcionalidad de eliminar maestro aún no implementada.[/]");
                    break;
                case 3:
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad de modificar maestro aún no implementada.[/]");
                    break;
                case 4:
                    AnsiConsole.MarkupLine("[blue]Funcionalidad de listar maestros aún no implementada.[/]");
                    break;
                case 5:
                    return;
            }  
        }
    }
}
