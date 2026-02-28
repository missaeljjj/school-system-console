namespace Menus;
internal class MenuBusqueda
{
    private readonly Menu _menu;
    private readonly Buscar _buscar;

    internal MenuBusqueda(Menu menu, Buscar buscar)
    {
        _menu = menu;
        _buscar = buscar;
    }
    internal async Task SeleccionBusqueda()
    {
        

        string[] opciones = { "1. Buscar Estudiante", "2. Buscar Maestro", "3. Regresar" };

        int seleccion = _menu.MenuSeleccion(opciones, "Seleccione una opción de búsqueda:", "Búsqueda: ");

        switch (seleccion)
        {
            case 1:
                await _buscar.SeleccionBusqueda();
                break;
            case 2:
                await _buscar.SeleccionBusquedaMaestro();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}