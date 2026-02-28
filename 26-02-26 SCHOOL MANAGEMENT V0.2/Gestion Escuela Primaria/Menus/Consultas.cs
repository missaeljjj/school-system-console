namespace Menus;
internal class Consultas
{
    private readonly Buscar _buscar;
    private readonly Mostrar _mostrar;
    private readonly Menu _menu;

    internal Consultas(Buscar buscar, Mostrar mostrar, Menu menu)
    {
        _buscar = buscar;
        _mostrar = mostrar;
        _menu = menu;
    }

    internal void ConsultaDocente()
    {
        string[] opciones = { "1. Mostrar ", "2. Busqueda", "3. Regresar" };

        while (true)
        {
            int seleccion = _menu.MenuSeleccion(opciones, "Seleccione una opción de consulta:", "Consultas: ");
            switch (seleccion)
            {
                case 1:
                    Console.WriteLine("EN PROCESO...");
                    break;
                case 2:
                    Console.WriteLine("En proceso...");
                break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            } 
        }
    }

    internal async Task ConsultaEstudiante()
    {
        string[] opciones = { "1. Mostrar ", "2. Busqueda", "3. Regresar" };

        int seleccion = _menu.MenuSeleccion(opciones, "Seleccione una opción de consulta:", "Consultas: ");
        switch (seleccion)
        {
            case 1:
                await _mostrar.ObtenerEstudiantesPorGrado();
                break;
            case 2:
                await _buscar.SeleccionBusqueda();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}
